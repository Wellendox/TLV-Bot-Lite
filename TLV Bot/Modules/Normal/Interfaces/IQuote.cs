namespace TLVBot.Modules.Normal.Interfaces;

public interface IQuote
{
    Task QuoteAsync(SocketGuildUser user, SocketGuildUser? user2 = null, SocketGuildUser? user3 = null, SocketGuildUser? user4 = null, SocketGuildUser? user5 = null);
}