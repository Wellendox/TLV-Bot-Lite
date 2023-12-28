using IResult = Discord.Interactions.IResult;

namespace TLVBot.Services;

public class InteractionHandler : DiscordClientService
{
    private readonly DiscordSocketClient _client;

    private readonly InteractionService _commands;

    private readonly IServiceProvider _services;

    public InteractionHandler(DiscordSocketClient client, IServiceProvider services, InteractionService commands,
        ILogger<InteractionHandler> logger) : base(client, logger)
    {
        _commands = commands;
        _client = client;
        _services = services;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        // Add the public modules that inherit InteractionModuleBase<T> to the InteractionService
        await _commands.AddModulesAsync(Assembly.GetEntryAssembly(), _services);

        // Process the InteractionCreated payloads to execute Interactions commands
        _client.InteractionCreated += OnInteractionCreated;
        _client.Ready += OnClientReady;

        // Process the command execution results
        _commands.SlashCommandExecuted += OnSlashCommandExecuted;
        _commands.ContextCommandExecuted += OnContextCommandExecuted;
        _commands.ComponentCommandExecuted += OnComponentCommandExecuted;
        _commands.ModalCommandExecuted += OnModalCommandExecuted;
    }

    #region Methods

    /// <summary>
    /// Registers commands
    /// </summary>
    /// <param name="guild"></param>
    /// <returns></returns>
    private async Task RegisterCommandsAsync(SocketGuild guild)
    {
        try
        {
            ModuleInfo[] modules = _commands.Modules.ToArray();

            //Register command group
            await _commands.AddModulesToGuildAsync(guild, true, modules);

            //Logging
            Log.Information(new LogMessage(LogSeverity.Debug, "RegisterCommandsAsync",
                $"Adding *{modules.Length}* modules to guild *{guild.Name}*").Message);
        }
        catch (Exception ex)
        {
            Log.Information(new LogMessage(LogSeverity.Error, "RegisterCommandsAsync",
                "RegisterCommandsAsync ran into a problem.", ex).Message);
        }
    }

    #endregion Methods

    #region Event Handlers / Delegates

    private async Task OnClientReady()
    {
        try
        {
            foreach (var guild in _client.Guilds)
                await RegisterCommandsAsync(guild);

            Log.Information(new LogMessage(LogSeverity.Debug, "OnClientReady", "Bot is ready!").Message);
        }
        catch (Exception ex)
        {
            Log.Error(new LogMessage(LogSeverity.Error, "OnClientReady", "OnClientReady ran into a problem.", ex).Message);
        }
    }

    private Task OnComponentCommandExecuted(ComponentCommandInfo cmdInfo, IInteractionContext context, IResult result)
    {
        return Task.CompletedTask;
    }

    private Task OnContextCommandExecuted(ContextCommandInfo cmdInfo, IInteractionContext context, IResult result)
    {
        return Task.CompletedTask;
    }

    private Task OnSlashCommandExecuted(SlashCommandInfo cmdInfo, IInteractionContext context, IResult result)
    {
        return Task.CompletedTask;
    }

    private Task OnModalCommandExecuted(ModalCommandInfo cmdInfo, IInteractionContext context, IResult result)
    {
        return Task.CompletedTask;
    }

    private async Task OnInteractionCreated(SocketInteraction interaction)
    {
        try
        {
            // Create an execution context that matches the generic type parameter of your
            // InteractionModuleBase<T> modules.
            var context = new SocketInteractionContext(_client, interaction);

            // Execute the incoming command.
            var result = await _commands.ExecuteCommandAsync(context, _services);
            if (result.IsSuccess) return;

            switch (result.Error)
            {
                case InteractionCommandError.UnmetPrecondition:
                    await context.Interaction.RespondAsync(embed: Embeds.Error(
                            $"[OnInteractionCreated]\nA Precondition wasn't met. Perhaps you do not have the permissions to use this command, or it cannot be used in this channel.\n**Error:** {result.Error}\n\n**Reason:**\n{result.ErrorReason}"),
                        ephemeral: true);
                    break;

                case InteractionCommandError.UnknownCommand:
                    await context.Interaction.RespondAsync(embed: Embeds.Error(
                            $"[OnInteractionCreated]\nI literally don't know that command homie.\n**Error:** {result.Error}\n\n**Reason:**\n{result.ErrorReason}"),
                        ephemeral: true);
                    break;

                case InteractionCommandError.BadArgs:
                    await context.Interaction.RespondAsync(
                        embed: Embeds.Error(
                            $"[OnInteractionCreated]\nYou gave me the wrong arguments. Try again with the correct ones mane.\n**Error:** {result.Error}\n\n**Reason:**\n{result.ErrorReason}"),
                        ephemeral: true);
                    break;

                case InteractionCommandError.Exception:
                    await context.Interaction.RespondAsync(
                        embed: Embeds.Error(
                            $"[OnInteractionCreated]\nI couldn't process that command homie. Here's the exception:\n**Error:** {result.Error}\n\n**Reason:**\n{result.ErrorReason}"),
                        ephemeral: true);
                    break;

                case InteractionCommandError.Unsuccessful:
                    await context.Interaction.RespondAsync(
                        embed: Embeds.Error(
                            $"[OnInteractionCreated]\nI couldn't process that command homie.\n**Error:** {result.Error}\n\n**Reason:**\n{result.ErrorReason}"),
                        ephemeral: true);
                    break;

                default:
                    await context.Interaction.RespondAsync(
                        embed: Embeds.Error(
                            $"[OnInteractionCreated]\nI dont know what went wrong.\n**Error:** {result.Error}\n\n**Reason:**\n{result.ErrorReason}"),
                        ephemeral: true);
                    break;
            }
        }
        catch (Exception ex)
        {
            Log.Error(new LogMessage(LogSeverity.Error, "OnInteractionCreated",
                "OnInteractionCreated ran into a problem.", ex).Message);

            // If a Slash Command execution fails it is most likely that the original interaction
            // acknowledgement will persist. It is a good idea to delete the original response, or
            // at least let the user know that something went wrong during the command execution.
            if (interaction.Type == InteractionType.ApplicationCommand)
                await interaction.GetOriginalResponseAsync().ContinueWith(async msg => await msg.Result.DeleteAsync());
        }
    }

    #endregion Event Handlers / Delegates
}