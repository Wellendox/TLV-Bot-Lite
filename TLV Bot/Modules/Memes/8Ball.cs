namespace TLVBot.Modules.Memes;

public class _8Ball : TlvInteractionModuleBase, I8Ball
{
    [SlashCommand("8ball", "Ask the magic 8ball a question.")]
    [DefaultMemberPermissions(GuildPermission.SendMessages)]
    public async Task EightBallAsync(string eightball)
    {
        //Combine every word (parameter) given to the function into one string
        string question = string.Join(" ", eightball);

        if (!question.Contains("?"))
        {
            await RespondErrorEmbedAsync("You did not ask a question Homie.");
            return;
        }

        Random rnd = new Random();
        int choice = rnd.Next(0, 2);

        switch (choice)
        {
            case 0:
                await RespondAsync($"**<@{Context.User.Id}> asked:** \"{eightball}\"\nYes.");
                break;

            case 1:
                await RespondAsync($"**<@{Context.User.Id}> asked:** \"{eightball}\"\nNo.");
                break;

            case 2:
                await RespondAsync($"**<@{Context.User.Id}> asked:** \"{eightball}\"\nMaybe. Ask me again later.");
                break;
        }
    }
}