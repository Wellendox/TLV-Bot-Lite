namespace TLVBot.Modules.Admin;

public class Ban : TlvInteractionModuleBase, Interfaces.IBan
{
    [SlashCommand("ban", "Ban a user")]
    [RequireContext(ContextType.Guild)]
    [DefaultMemberPermissions(GuildPermission.BanMembers)]
    [RequireAuthority]
    public async Task BanAsync(SocketGuildUser user, string? reasoning = null)
    {
        if (user.IsBot) return;
        if (user == Context.User) return;

        try
        {
            await RespondSimpleEmbedAsync("Ban", $"I've banned the user **{user.Username}** with the reason:\n**{(reasoning == null ? "None given." : reasoning)}**", isEphemeral: true);
            await user.SendMessageAsync(null, false, Embeds.BuildSimpleEmbed("Banned", $"You've been banned from the server **{Context.Guild.Name}** by **{Context.User.Username}**.\n\n**Reason:**\n{reasoning}"));
            await Context.Guild.AddBanAsync(user, 7, reasoning, null);
        }
        catch (Exception ex)
        {
            Log.Error(ex, ex.Message);
        }
    }
}