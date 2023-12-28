namespace TLVBot.Modules.Normal;

public class Stats : TlvInteractionModuleBase, IStats
{
    [SlashCommand("stats", "Displays a bunch of nerdy Server-Statistics")]
    [RequireContext(ContextType.Guild)]
    [DefaultMemberPermissions(GuildPermission.SendMessages)]
    public async Task StatsAsync()
    {
        IReadOnlyCollection<SocketTextChannel> channelSocket = Context.Guild.TextChannels;
        SocketTextChannel[] channelArray = channelSocket.ToArray();
        Task<IInviteMetadata> channelInvite = channelArray[0].CreateInviteAsync(null, null, false, true);

        Random rnd = new Random();
        EmbedBuilder embedBuilder = new EmbedBuilder()
            .WithThumbnailUrl(Context.Guild.IconUrl)
            .WithDescription($"Server Statistics")
            .AddField("Name", $"{Context.Guild.Name}", true)
            .AddField("ID", Context.Guild.Id, true)
            .AddField("Created at", Context.Guild.CreatedAt, true)
            .AddField("Region", Context.Guild.VoiceRegionId, true)
            .AddField("Invite link", channelInvite.Result, true)
            .AddField("Total Members", Context.Guild.MemberCount, true)
            .WithAuthor(Context.Guild.Name, Context.Guild.IconUrl, channelInvite.Result.ToString())
            .WithCurrentTimestamp()
            .WithColor(new Color(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255)));

        await RespondSimpleEmbedAsync(embedBuilder);
    }
}