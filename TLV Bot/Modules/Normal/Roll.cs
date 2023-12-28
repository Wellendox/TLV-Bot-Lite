namespace TLVBot.Modules.Normal;

[Group("roll", "A list of roll commands")]
public class Roll : TlvInteractionModuleBase, IRoll
{
    [SlashCommand("selection", "Get a selection between D6, D20 and D100.")]
    [DefaultMemberPermissions(GuildPermission.SendMessages)]
    public async Task RollAsync()
    {
        var builder = new ComponentBuilder()
            .WithButton("D6", $"d6:{Context.User.Id}", ButtonStyle.Primary)
            .WithButton("D20", $"d20:{Context.User.Id}", ButtonStyle.Secondary)
            .WithButton("D100", $"d100:{Context.User.Id}", ButtonStyle.Danger);

        await RespondAsync("Roll one of the dice!", components: builder.Build());
    }

    [DoUserCheck]
    [ComponentInteraction("d20:*", true)]
    public async Task RollD20Async(string unused)
    {
        Random rnd = new Random();
        await RespondAsync($"You have rolled **{rnd.Next(1, 20)}** (D20)");
    }

    [DoUserCheck]
    [ComponentInteraction("d6:*", true)]
    public async Task RollD6Async(string unused)
    {
        Random rnd = new Random();
        await RespondAsync($"You have rolled **{rnd.Next(1, 6)}** (D6)");
    }

    [DoUserCheck]
    [ComponentInteraction("d100:*", true)]
    public async Task RollD100Async(string unused)
    {
        Random rnd = new Random();
        await RespondAsync($"You have rolled **{rnd.Next(1, 100)}** (D100)");
    }

    [SlashCommand("max", "Roll a die between 1 and a number given")]
    public async Task RollMaxAsync(int max) //1 to Max
    {
        Random rnd = new Random();
        await RespondAsync($"You have rolled **{rnd.Next(1, max)}** (D{max})");
    }

    [SlashCommand("min-max-amount", "Roll a die between min X and max Y, for Z amount of times.")]
    public async Task RollMinMaxAmountAsync(int min, int max, int amount)
    {
        string msg = "";
        Random rnd = new Random();
        int resultTotal = 0;

        for (int i = 0; i < amount; ++i)
        {
            int rndNumber = rnd.Next(min, max);
            msg += $"You have rolled **{rndNumber}** (D{min}-{max})\n";
            resultTotal += rndNumber;
        }
        msg += $"\nYour total sum rolled is: **{resultTotal}**";
        await RespondAsync(msg);
    }

    [SlashCommand("min-max-amount-attribute", "Roll a die between min X and max Y, for Z amount of times, based on an attribute.")]
    public async Task RollMinMaxAmountAttributeAsync(int min, int max, int amount, string attribute)
    {
        string msg = "";
        Random rnd = new Random();
        int resultTotal = 0;

        for (int i = 0; i < amount; ++i)
        {
            int rndNumber = rnd.Next(min, max);
            msg += $"You have rolled **{rndNumber}** (D{min}-{max})\n";
            resultTotal += rndNumber;
        }
        msg += $"\nYour total sum rolled for the attribute {attribute} is: **{resultTotal}**";
        await RespondAsync(msg);
    }
}