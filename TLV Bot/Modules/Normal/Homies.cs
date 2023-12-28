namespace TLVBot.Modules.Normal;

public class Homies : TlvInteractionModuleBase, IHomies
{
    [SlashCommand("homies", "Everybody can use some love from time to time. Spread the love to the homies!")]
    [DefaultMemberPermissions(GuildPermission.SendMessages)]
    public async Task HomiesAsync()
    {
        await RespondAsync("https://cdn.discordapp.com/attachments/495627748908466186/653679225986875435/c0be78fa.mp4");
    }
}