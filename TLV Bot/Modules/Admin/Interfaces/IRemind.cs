namespace TLVBot.Modules.Admin.Interfaces;

public interface IRemind
{
    Task RemindAsync(SocketRole role, string message);
}