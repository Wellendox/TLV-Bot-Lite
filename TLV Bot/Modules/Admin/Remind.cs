namespace TLVBot.Modules.Admin;

public class Remind : TlvInteractionModuleBase, IRemind
{
    [SlashCommand("remind", "Remind every user of a specific role of something through a DM message.")]
    [RequireContext(ContextType.Guild)]
    [RequireAuthority]
    [DefaultMemberPermissions(GuildPermission.BanMembers)]
    public async Task RemindAsync(SocketRole role, string message)
    {
        try
        {
            foreach (SocketGuildUser member in role.Members)
            {
                Embed embedUser = Embeds.BuildSimpleEmbed($"Reminder from {Context.Guild.Name}", message, Context.Guild.IconUrl);
                await member.CreateDMChannelAsync().Result.SendMessageAsync(embed: embedUser);
            }
            await RespondAsync($"Sent a DM to {role.Members.Count()} Users.", ephemeral: true);
        }
        catch (Exception ex)
        {
            Log.Error(ex, ex.Message);
        }
    }
}