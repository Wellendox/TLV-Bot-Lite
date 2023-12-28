namespace TLVBot.Modules.Normal;

public class Help : TlvInteractionModuleBase, ICmds
{
    public InteractionService Commands;

    public Help(InteractionService commands, IServiceProvider services)
    {
        this.Commands = commands;
    }

    [SlashCommand("help", "A list of commands registered to the guild.")]
    [DefaultMemberPermissions(GuildPermission.SendMessages)]
    public async Task CmdsAsync()
    {
        try
        {
            int chunkBy = 6;
            var modules = Context.Guild.GetApplicationCommandsAsync().Result.Chunk(chunkBy);
            int maxPages = modules.Count();
            int page = 0;

            var builder = new ComponentBuilder()
                .WithButton("Previous", $"previousCmd:{maxPages},{chunkBy}", ButtonStyle.Primary)
                .WithButton("Next", $"nextCmd:{maxPages},{chunkBy}", ButtonStyle.Success);

            string msg = "";

            foreach (var module in modules.ElementAt(page))
                msg += $"**/{module.Name}**\t - {module.Type}  command\n**{module.Description}**\n\n";

            await RespondComponentEmbedAsync($"cmds page {page + 1}", msg, builder);
        }
        catch (Exception ex)
        {
            Log.Error(ex, ex.Message);
        }
    }

    [ComponentInteraction("nextCmd:*,*", true)]
    public async Task NextAsync(string maxPages, string chunkValue)
    {
        try
        {
            if (Context.Interaction is SocketMessageComponent originalResponse)
            {
                var embedPicked = originalResponse.Message.Embeds.FirstOrDefault()?.Title;
                if (embedPicked != null)
                {
                    var pageString = Regex.Replace(embedPicked, "[^0-9.]", "");
                    int max = Convert.ToInt32(maxPages) - 1;
                    int chunk = Convert.ToInt32(chunkValue);
                    int page = Convert.ToInt32(pageString) - 1;

                    page++;
                    if (page > max)
                        page = 0;

                    await DoPagination(page, chunk);
                }
            }
        }
        catch (Exception ex)
        {
            Log.Error(ex, ex.Message);
        }
    }

    [ComponentInteraction("previousCmd:*,*", true)]
    public async Task PreviousAsync(string maxPages, string chunkValue)
    {
        try
        {
            var originalResponse = Context.Interaction as SocketMessageComponent;
            if (originalResponse != null)
            {
                var embedPicked = originalResponse.Message.Embeds.FirstOrDefault()?.Title;
                if (embedPicked != null)
                {
                    var pageString = Regex.Replace(embedPicked, "[^0-9.]", "");
                    int max = Convert.ToInt32(maxPages) - 1;
                    int chunk = Convert.ToInt32(chunkValue);
                    int page = Convert.ToInt32(pageString) - 1;

                    page--;
                    if (page < 0)
                        page = max;

                    await DoPagination(page, chunk);
                }
            }
        }
        catch (Exception ex)
        {
            Log.Error(ex, ex.Message);
        }
    }

    public async Task DoPagination(int page, int chunk)
    {
        try
        {
            var modules = Context.Guild.GetApplicationCommandsAsync().Result.Chunk(chunk);

            string msg = "";

            foreach (var module in modules.ElementAt(page))
                msg += $"/**{module.Name}**\t - {module.Type}  command\n**{module.Description}**\n\n";

            Embed embed = Embeds.BuildSimpleEmbed($"cmds page {page + 1}", msg);

            if (Context.Interaction is SocketMessageComponent originalResponse) await originalResponse.UpdateAsync(x => x.Embed = embed);
        }
        catch (Exception ex)
        {
            Log.Error(ex, ex.Message);
        }
    }
}