// Inherit from PreconditionAttribute
namespace TLVBot.Services.Attributes;

public class RequireAuthorityAttribute : PreconditionAttribute
{
    /// <inheritdoc/>
    public override async Task<PreconditionResult> CheckRequirementsAsync(IInteractionContext context, ICommandInfo commandInfo, IServiceProvider services)
    {
        // Check if this user is a Guild User, which is the only context where roles exist
        if (context.User is SocketGuildUser gUser)
        {
            // If this command was executed by a user with the appropriate role, return a success
            if (gUser.Roles.Any(r => gUser.GuildPermissions.Administrator))
                return PreconditionResult.FromSuccess();
            // Since it wasn't, fail
            await context.Interaction.RespondAsync(embed: Embeds.Error("You must be a Moderator or Admin to run this command."));
            return PreconditionResult.FromError("You must be a Moderator or Admin to run this command.");
        }
        await context.Interaction.RespondAsync(embed: Embeds.Error("You must be a Moderator or Admin to run this command."));
        return PreconditionResult.FromError("You must be in a server to run this command.");
    }
}