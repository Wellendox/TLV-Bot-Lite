using Discord.Commands;
using TLVBot.Modules.Admin.Interfaces;

namespace TLVBot.Modules.Memes;

public class Monke : TlvInteractionModuleBase, IMonke
{
    [SlashCommand("monke", "Mmmmm, monke.")]
    [Remarks("**Type:** Meme\n**Parameters:** None")]
    [DefaultMemberPermissions(GuildPermission.SendMessages)]
    public async Task MonkeAsync()
    {
        var memeInput = new List<string>{
            "https://www.youtube.com/watch?v=SA2o6Nac9Yg",
            "https://media.giphy.com/media/ODfWCpu4DHU2c/giphy.gif",
            "https://media.giphy.com/media/iXOoi6i2l9PZvCN0zU/giphy-downsized-large.gif",
            "https://media1.tenor.com/images/e7749358757dfe77e3f57c5ac547230c/tenor.gif?itemid=11409190",
            "https://i.gifer.com/UVGk.gif",
            "https://tenor.com/view/kouga-monkey-rotate-spin-gif-16774879",
            "https://tenor.com/view/monkey-spin-gif-15290512",
            "https://gyazo.com/7d8b49ec8fc7f9e32da863621358375e",
            "https://gyazo.com/490b6b75f0d53b6e5108dfacf45a91cd",
            "https://gyazo.com/22a4e2c63d5c04ffb14b440f52449dd6",
            "https://gyazo.com/d67eb7107b06c4ab268b08c35cae9280",
            "https://cdn.discordapp.com/attachments/687035302006489214/711361062053871626/video0.mov",
            "https://tenor.com/view/gorilla-walking-run-gif-14877257",
            "https://tenor.com/view/spin-dance-twirling-monkey-gif-9406313",
            "https://cdn.discordapp.com/attachments/432613790937382962/711760299333779456/munky_2.mp4",
            "https://cdn.discordapp.com/attachments/687035302006489214/712901110536601600/video0.mp4",
            "https://cdn.discordapp.com/attachments/318013465652494336/714178076451274822/video0.mp4",
            "https://tenor.com/view/monkey-licking-lick-kiss-tongue-gif-9316431",
            "https://cdn.discordapp.com/attachments/432613790937382962/716652463582609448/88326145_202653644306359_1548950564841193472_n.mp4",
            "https://cdn.discordapp.com/attachments/432613790937382962/717155868713549864/ape.webm",
            "https://media.discordapp.net/attachments/557402426857226275/779665679937962014/D09FD180D0B8D0BAD0BED0BBD18B-D0B4D0BBD18F-D0B4D0B0D183D0BDD0BED0B2-D180D0B0D0B7D0BDD0BED0B5-D0BAD0BE.png",
            "https://cdn.discordapp.com/attachments/527838637249921045/775407095625154650/aVwrA7v_460svvp9.webm",
            "https://www.youtube.com/watch?v=drszcKWAcFg",
            "https://www.youtube.com/watch?v=3-_OIDRL91c",
            "https://www.youtube.com/watch?v=z9wZhEytm8E",
            "https://www.youtube.com/watch?v=Q15CCnO9nis",
            "https://cdn.discordapp.com/attachments/459633095612825600/779239214201307146/video0_42.mp4",
            "https://cdn.discordapp.com/attachments/590993952040026132/785481601240137728/video0.mp4",
            "https://cdn.discordapp.com/attachments/680928395399266314/783969362470109184/video0.mp4",
            "https://cdn.discordapp.com/attachments/642656238072627221/785862710679961640/1607189392101.webm",
            "https://cdn.discordapp.com/attachments/381520882608373761/786003130650198016/y2mate.com_-_How_to_gangster_3_qkQg9GGitow_v144P.mp4",
            "https://youtu.be/ZydHB78zNvA?t=130",
            "https://youtu.be/gjSqjnuPGJA",
            "https://cdn.discordapp.com/attachments/381520882608373761/777209669190025261/monkeydream.mov",
            "https://youtube.com/shorts/lqcF_djB5bw",
            "https://cdn.discordapp.com/attachments/432619912922529837/788867075082813460/banana.mp4",
            "https://cdn.discordapp.com/attachments/762193632257769492/789186411609456710/video0.mp4",
            "https://cdn.discordapp.com/attachments/384437930468573224/789112217806962688/video0.mp4",
            "https://tenor.com/view/bassie-gorilla-trappen-kick-agressief-gif-15509885",
            "https://cdn.discordapp.com/attachments/432613790937382962/794749805770833941/video0_120.mp4",
            "https://www.youtube.com/watch?v=-wzAnhYvpKc",
            "https://youtu.be/yR0R-GHQYaI",
            "https://youtu.be/-a57_IOKpjM",
            "https://youtu.be/6G7HYqjBxgg",
            "https://youtu.be/Z00nVaTXl_M",
            "https://youtu.be/5oJgXrPuKGs",
            "https://youtu.be/7tEZWoR7QJY",
            "https://media.discordapp.net/attachments/432613790937382962/801790980788846592/7bd8c72.jpg?width=409&height=676",
            "https://media.discordapp.net/attachments/682366611881328818/776748487907344404/image0-36-1.gif",
            "https://cdn.discordapp.com/attachments/748220103375454258/757594485688369222/NOOOOOOOO.mp4",
            "https://cdn.discordapp.com/attachments/608383820437258252/804181174443311134/1Oh_nyo_monkii_hurt.mp4",
            "https://cdn.discordapp.com/emojis/595114606964506641.gif?v=1",
            "https://tenor.com/view/monkey-gif-8955300",
            "https://www.youtube.com/watch?v=phqmXMr7Trw",
            "https://www.youtube.com/watch?v=Ukppt9ISrc4",
            "https://tenor.com/view/david-monke-david-gaming-gaming-monke-gaming-gif-19468007",
            "https://media.discordapp.net/attachments/432613790937382962/884419453989830666/monke.mp4",
            "https://cdn.discordapp.com/attachments/432613790937382962/889950201610137700/orangutan_asmr.mp4",
            "https://cdn.discordapp.com/attachments/868146710772326482/916031315139239946/chimp_dark_souls.mp4",
            "https://cdn.discordapp.com/attachments/905635921460867122/920067366933647441/video0_23.mov",
            "https://cdn.discordapp.com/attachments/381520882608373761/975353083280371762/119742642_210510383748803_3021128896388264305_n_1.mp4"
        };
        Random random = new Random();
        string randomMemeUrl = memeInput[random.Next(memeInput.Count)];
        await RespondAsync(randomMemeUrl);
    }
}