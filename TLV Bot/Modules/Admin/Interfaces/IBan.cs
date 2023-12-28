namespace TLVBot.Modules.Admin.Interfaces;

public interface IBan
{
    Task BanAsync(SocketGuildUser user, string? reasoning);
}