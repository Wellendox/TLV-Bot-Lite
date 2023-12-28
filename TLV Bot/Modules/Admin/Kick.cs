namespace TLVBot.Modules.Admin;

public class Kick : TlvInteractionModuleBase, IKick
{
    [SlashCommand("kick", "Kick a user.")]
    [RequireContext(ContextType.Guild)]
    [DefaultMemberPermissions(GuildPermission.BanMembers)]
    [RequireAuthority]
    public async Task KickAsync(SocketGuildUser user, string? reasoning = null)
    {
        //Kick the User
        try
        {
            await RespondSimpleEmbedAsync("Kick", $"I've kicked the user **{user.Username}** with the reason:\n**{(reasoning == null ? "None given." : reasoning)}**", isEphemeral: true);
            if (!user.IsBot) await user.SendMessageAsync(null, false, Embeds.BuildSimpleEmbed("Kicked", $"You've been kicked from the server **{Context.Guild.Name}** by **{Context.User.Username}**.\n\n**Reason:**\n{reasoning}"));
            await user.KickAsync(reasoning, null);
        }
        catch (Exception ex)
        {
            Log.Error(ex, ex.Message);
        }
    }
}