namespace TLVBot.Modules.Admin;

[Group("move", "Move users to voice channels!")]
public class Move : TlvInteractionModuleBase, IMove
{
    [RequireAuthority]
    [SlashCommand("all", "Move all users of one voice channel to another")]
    [DefaultMemberPermissions(GuildPermission.BanMembers)]
    public async Task MoveAsync(SocketVoiceChannel from, SocketVoiceChannel to)
    {
        try
        {
            foreach (var user in from.Users)
                if (user.VoiceState == null)
                    continue;
                else
                    await user.ModifyAsync(ch => ch.ChannelId = to.Id);

            await RespondSimpleEmbedAsync("Move", $"Finished moving all users from {from.Name} to {to.Name}!", isEphemeral: true);
        }
        catch (Exception ex)
        {
            Log.Error(ex, ex.Message);
        }
    }

    [RequireAuthority]
    [SlashCommand("selection", "Move all tagged users into a specific voice channel.")]
    public async Task MoveAsync(string users, SocketVoiceChannel channel)
    {
        try
        {
            //Regex magic to filter out the special characters
            var regex = Regex.Replace(users, @"(@|<|>|!)", "");
            var usersFiltered = regex.Split(" ");

            //Adding the users to the list
            List<SocketGuildUser> usersList = new();
            foreach (var user in usersFiltered)
            {
                var userId = Convert.ToUInt64(user);
                var userToAdd = Context.Guild.Users.FirstOrDefault(u => u.Id == userId);

                if (userToAdd != null)
                    usersList.Add(userToAdd);
            }
            //Run through the finished list and do the stuff and things.
            foreach (var user in usersList)
            {
                if (user.VoiceState == null)
                    continue;

                await user.ModifyAsync(ch => ch.ChannelId = channel.Id);
            }
            await RespondSimpleEmbedAsync("Move", "Finished moving the users that were connected to a voice channel!", isEphemeral: true);
        }
        catch (Exception ex)
        {
            Log.Error(ex, ex.Message);
        }
    }
}