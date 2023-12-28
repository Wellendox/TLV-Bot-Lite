namespace TLVBot.Modules.Normal;

[Group("avatar", "For all Avatar commands")]
public class Avatar : TlvInteractionModuleBase, IAvatar
{
    [SlashCommand("account", "Sends the account Avatar of either yourself, or a user you tagged.")]
    [RequireContext(ContextType.Guild)]
    [DefaultMemberPermissions(GuildPermission.SendMessages)]
    public async Task AccountAvatarAsync(SocketGuildUser? socketGuildUser = null)
    {
        socketGuildUser ??= Context.User as SocketGuildUser;
        if (socketGuildUser == null) return;

        string url = socketGuildUser.GetAvatarUrl(size: 512);
        await RespondAsync(url ?? socketGuildUser.GetDefaultAvatarUrl());
    }

    [SlashCommand("server", "Sends the server Avatar of either yourself, or a user you tagged.")]
    [RequireContext(ContextType.Guild)]
    [DefaultMemberPermissions(GuildPermission.SendMessages)]
    public async Task ServerAvatarAsync(SocketGuildUser? socketGuildUser = null)
    {
        socketGuildUser ??= Context.User as SocketGuildUser;
        if (socketGuildUser == null) return;

        string url = socketGuildUser.GetGuildAvatarUrl(size: 512);
        await RespondAsync(url ?? "You don't have a server avatar. Use \"/avatar account\" instead.", ephemeral: url == null);
    }
}