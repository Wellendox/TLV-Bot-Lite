namespace TLVBot.Modules.Admin.Interfaces;

public interface IKick
{
    Task KickAsync(SocketGuildUser user, string? reasoning);
}