namespace TLVBot.Modules.Normal.Interfaces;

public interface IAvatar
{
    Task AccountAvatarAsync(SocketGuildUser? socketGuildUser = null);

    Task ServerAvatarAsync(SocketGuildUser? socketGuildUser = null);
}