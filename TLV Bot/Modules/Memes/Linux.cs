using Discord.Commands;

namespace TLVBot.Modules.Memes;

public class Linux : TlvInteractionModuleBase, ILinux
{
    [SlashCommand("linux", "Memes about Linux users.")]
    [Remarks("**Type:** Meme\n**Parameters:** None")]
    [DefaultMemberPermissions(GuildPermission.SendMessages)]
    public async Task LinuxAsync()
    {
        var memeInput = new List<string>
        {
            "https://cdn.discordapp.com/attachments/914262251266007041/916315075944513576/image0-59.png",
            "https://tenor.com/view/linux-breakin-windows10-windows-computer-gif-21384541",
            "https://tenor.com/view/how-linux-users-install-a-web-browser-linux-linux-users-gif-20223386",
            "https://media.discordapp.net/attachments/914262251266007041/916315195217940501/eb3.png?width=333&height=676",
            "https://media.discordapp.net/attachments/914262251266007041/916315403108646942/pfbjx6w3fxy51.png?width=604&height=676",
            "https://media.discordapp.net/attachments/914262251266007041/916315861957103646/r_1893446_EZDzi.png",
            "https://tenor.com/view/linux-linux-users-gaming-computer-computers-gif-23121479",
            "https://tenor.com/view/linux-gif-22007330",
            "https://tenor.com/view/discord-meme-funny-linux-users-linux-gif-22551985",
            "https://tenor.com/view/linux-linus-linus-tech-tips-gamer-game-gif-19431173",
            "https://tenor.com/view/linux-users-antivirus-hacker-esmbot-gif-19576259"
        };
        Random random = new Random();
        string randomMemeUrl = memeInput[random.Next(memeInput.Count)];

        await RespondAsync(randomMemeUrl);
    }
}