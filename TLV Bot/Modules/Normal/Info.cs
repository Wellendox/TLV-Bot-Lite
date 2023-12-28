namespace TLVBot.Modules.Normal;

public class Info : TlvInteractionModuleBase, IInfo
{
    [SlashCommand("info", "Displays some information about either yourself, or a user you tagged.")]
    [RequireContext(ContextType.Guild)]
    [DefaultMemberPermissions(GuildPermission.SendMessages)]
    public async Task InfoAsync(SocketGuildUser? socketGuildUser = null)
    {
        if (socketGuildUser == null)
            socketGuildUser = Context.User as SocketGuildUser;
        try
        {
            Random rnd = new Random();
            EmbedBuilder embedBuilder = new EmbedBuilder()
                .WithThumbnailUrl(socketGuildUser?.GetAvatarUrl() ?? socketGuildUser?.GetDefaultAvatarUrl() ?? @"https://m.media-amazon.com/images/I/618iVz7RxwL.jpg")
                .WithDescription(
                    $"Some information on the User you tagged, or yourself if you did not tag anyone.")
                .AddField("Tag", $"{socketGuildUser?.Username}#{socketGuildUser?.Discriminator}", true)
                .AddField("ID", socketGuildUser?.Id, true)
                .AddField("Joined Discord at", socketGuildUser?.CreatedAt, true)
                .AddField("Joined Server at", socketGuildUser?.JoinedAt, false)
                .WithAuthor(Context.Client.CurrentUser.Username)
                .WithCurrentTimestamp()
                .WithColor(new Color(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255)));

            Embed embed = embedBuilder.Build();
            await RespondSimpleEmbedAsync(embedBuilder);
        }
        catch (Exception ex)
        {
            Log.Error(ex, ex.Message);
        }
    }
}