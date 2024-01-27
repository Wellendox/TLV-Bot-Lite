namespace TLVBot.Modules.Memes;

public class EightBallModule : TlvInteractionModuleBase, I8Ball
{
    [SlashCommand("8ball", "Ask the magic 8ball a question.")]
    [DefaultMemberPermissions(GuildPermission.SendMessages)]
    public async Task EightBallAsync(string question)
    {
        if (!question.Contains("?"))
        {
            await RespondErrorEmbedAsync("You did not ask a question, Homie.");
            return;
        }

        string[] responses = { "Yes.", "No.", "Maybe. Ask me again later." };
        Random rnd = new Random();
        int choice = rnd.Next(responses.Length);

        await RespondAsync($"**<@{Context.User.Id}> asked:** \"{question}\"\n{responses[choice]}");
    }
}