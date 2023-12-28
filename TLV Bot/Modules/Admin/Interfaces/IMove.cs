namespace TLVBot.Modules.Admin.Interfaces;

public interface IMove
{
    Task MoveAsync(SocketVoiceChannel from, SocketVoiceChannel to);

    Task MoveAsync(string users, SocketVoiceChannel channel);
}