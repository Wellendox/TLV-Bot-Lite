namespace TLVBot.Services;

public abstract class TlvInteractionModuleBase : InteractionModuleBase<SocketInteractionContext<SocketInteraction>>
{
    /// <summary>
    /// Responds the component embed asynchronous.
    /// </summary>
    /// <param name="title">The title.</param>
    /// <param name="desc">The desc.</param>
    /// <param name="builder">The builder.</param>
    /// <param name="thumbnailUrl">The thumbnail URL.</param>
    /// <param name="isEphemeral">if set to <c>true</c> [is ephemeral].</param>
    /// <param name="imageUrl">The image URL.</param>
    public async Task RespondComponentEmbedAsync(string title, string desc, ComponentBuilder builder,
        string? thumbnailUrl = Embeds.DefaultThumbnailUrl, bool isEphemeral = false, string? imageUrl = null)
    {
        var embed = Embeds.BuildSimpleEmbed(title, desc, thumbnailUrl, imageUrl);
        await RespondAsync(null, embed: embed, components: builder.Build(), ephemeral: isEphemeral);
    }

    /// <summary>
    /// Responds the simple embed asynchronous.
    /// </summary>
    /// <param name="title">The title.</param>
    /// <param name="desc">The desc.</param>
    /// <param name="thumbnailUrl">The thumbnail URL.</param>
    /// <param name="isEphemeral">if set to <c>true</c> [is ephemeral].</param>
    /// <param name="imageUrl">The image URL.</param>
    public async Task RespondSimpleEmbedAsync(string title, string desc,
        string thumbnailUrl = Embeds.DefaultThumbnailUrl, bool isEphemeral = false, string? imageUrl = null)
    {
        var embed = Embeds.BuildSimpleEmbed(title, desc, thumbnailUrl, imageUrl);
        await RespondAsync(embed: embed, ephemeral: isEphemeral);
    }

    /// <summary>
    /// Responds the simple embed asynchronous.
    /// </summary>
    /// <param name="embedBuilder">The embed builder.</param>
    /// <param name="isEphemeral">if set to <c>true</c> [is ephemeral].</param>
    public async Task RespondSimpleEmbedAsync(EmbedBuilder embedBuilder, bool isEphemeral = false)
    {
        await RespondAsync(embed: embedBuilder.Build(), ephemeral: isEphemeral);
    }

    /// <summary>
    /// Responds the error embed asynchronous.
    /// </summary>
    /// <param name="desc">The desc.</param>
    /// <param name="isEphemeral">if set to <c>true</c> [is ephemeral].</param>
    public async Task RespondErrorEmbedAsync(string desc, bool isEphemeral = false)
    {
        var embed = Embeds.Error(desc);
        await RespondAsync(null, embed: embed, ephemeral: isEphemeral);
    }

    /// <summary>
    /// Sends the message asynchronous.
    /// </summary>
    /// <param name="message">The message.</param>
    /// <param name="embed">The embed.</param>
    /// <returns></returns>
    public async Task<RestUserMessage> SendMessageAsync(string? message = null, Embed? embed = null)
    {
        return await Context.Channel.SendMessageAsync(message, false, embed);
    }

    /// <summary>
    /// Sends the field embed.
    /// </summary>
    /// <param name="title">The title.</param>
    /// <param name="fields">The fields.</param>
    /// <param name="description">The description.</param>
    /// <param name="thumbnailUrl">The thumbnail URL.</param>
    /// <param name="builder">The builder.</param>
    public async Task SendFieldEmbed(string title, List<Tuple<string, string, string>> fields,
        string? description = null, string thumbnailUrl = Embeds.DefaultThumbnailUrl,
        ComponentBuilder? builder = null)
    {
        var embed = Embeds.BuildFieldEmbed(title, fields, description, thumbnailUrl);
        await RespondAsync(embed: embed, components: builder?.Build());
    }

    /// <summary>
    /// Sends the field embed.
    /// </summary>
    /// <param name="title">The title.</param>
    /// <param name="fields">The fields.</param>
    /// <param name="description">The description.</param>
    /// <param name="thumbnailUrl">The thumbnail URL.</param>
    /// <param name="builder">The builder.</param>
    public async Task SendFieldEmbed(string title, List<EmbedFieldBuilder>? fields, string? description = null,
        string thumbnailUrl = Embeds.DefaultThumbnailUrl, ComponentBuilder? builder = null)
    {
        var embed = Embeds.BuildFieldEmbed(title, fields, description, thumbnailUrl);
        await RespondAsync(embed: embed, components: builder?.Build());
    }

    /// <summary>
    /// Sends the error.
    /// </summary>
    /// <param name="desc">The desc.</param>
    /// <returns></returns>
    public async Task<RestUserMessage> SendError(string desc)
    {
        var embed = Embeds.Error(desc);
        return await SendMessageAsync(null, embed);
    }

    /// <summary>
    /// Sends the dm asynchronous.
    /// </summary>
    /// <param name="msg">The MSG.</param>
    /// <param name="user">The user.</param>
    /// <returns></returns>
    public async Task<IUserMessage> SendDmAsync(string msg, SocketUser user)
    {
        var embed = Embeds.BuildSimpleEmbed("A message from God", msg);
        return await user.SendMessageAsync(null, embed: embed);
    }
}