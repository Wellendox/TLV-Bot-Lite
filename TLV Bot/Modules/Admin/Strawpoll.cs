namespace TLVBot.Modules.Admin;

public class Strawpoll : TlvInteractionModuleBase, IStrawpoll
{
    [SlashCommand("strawpoll", "Creates a strawpoll.")]
    [RequireContext(ContextType.Guild)]
    [RequireAuthority]
    [DefaultMemberPermissions(GuildPermission.BanMembers)]
    public async Task StrawpollAsync(string message)
    {
        try
        {
            if (message.Length > 100)
            {
                await RespondAsync(embed: Embeds.Error("The poll question cannot be more than 100 characters long. I know it's much to ask, but that's how it is mane."), ephemeral: true);
                return;
            }

            await RespondWithModalAsync<StrawpollModal>($"strawpoll_modal:{message}");
        }
        catch (Exception ex)
        {
            Log.Error(ex, ex.Message);
        }
    }

    [ModalInteraction("strawpoll_modal:*")]
    public async Task HandleStrawpoll(string title, StrawpollModal modal)
    {
        var options = new List<string>
        {
            modal.Option1 ?? string.Empty,
            modal.Option2 ?? string.Empty
        };
        if (!string.IsNullOrEmpty(modal.Option3))
            options.Add(modal.Option3);

        if (!string.IsNullOrEmpty(modal.Option4))
            options.Add(modal.Option4);

        if (!string.IsNullOrEmpty(modal.Option5))
            options.Add(modal.Option5);

        var emojiList = new List<Emoji>();
        string msg = "";
        for (var i = 0; i < options.Count; ++i)
        {
            var emojiString = $"{i + 1}\u20E3"; //<-- What the fuck
            var emoji = new Emoji(emojiString);
            emojiList.Add(emoji);
            msg += $"{emoji}: **{options[i]}**\n\n";
        }

        var embed = Embeds.BuildSimpleEmbed(title, msg);
        var strawpoll = await Context.Channel.SendMessageAsync(embed: embed);
        await RespondAsync("Strawpoll added! Only you can see this message.", ephemeral: true);
        await strawpoll.AddReactionsAsync(emojiList);
    }
}

/// <summary>
/// The modal that is used to create a Ticket
/// </summary>
/// <seealso cref="IModal"/>
public class StrawpollModal : IModal
{
    #region Implementation of IModal

    /// <inheritdoc/>
    public string Title => "Strawpoll";

    [InputLabel("Option 1")]
    [RequiredInput]
    [ModalTextInput("option1", TextInputStyle.Short, "Cool Option 1", maxLength: 100)]
    public string? Option1 { get; set; }

    [InputLabel("Option 2")]
    [RequiredInput]
    [ModalTextInput("option2", TextInputStyle.Short, "Cool Option 2", maxLength: 100)]
    public string? Option2 { get; set; }

    [InputLabel("Option 3")]
    [RequiredInput(false)]
    [ModalTextInput("option3", TextInputStyle.Short, "Cool Option 3", maxLength: 100)]
    public string? Option3 { get; set; }

    [InputLabel("Option 4")]
    [RequiredInput(false)]
    [ModalTextInput("option4", TextInputStyle.Short, "Cool Option 4", maxLength: 100)]
    public string? Option4 { get; set; }

    [InputLabel("Option 5")]
    [RequiredInput(false)]
    [ModalTextInput("option5", TextInputStyle.Short, "Cool Option 5", maxLength: 100)]
    public string? Option5 { get; set; }

    #endregion Implementation of IModal
}