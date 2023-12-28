namespace TLVBot.Modules.Normal.Interfaces;

public interface IInfo
{
    Task InfoAsync(SocketGuildUser? socketGuildUser = null);
}