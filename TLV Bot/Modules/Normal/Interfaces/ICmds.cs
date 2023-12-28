namespace TLVBot.Modules.Normal.Interfaces;

public interface ICmds
{
    Task CmdsAsync();

    Task NextAsync(string maxPages, string chunkValue);

    Task PreviousAsync(string maxPages, string chunkValue);

    Task DoPagination(int page, int chunk);
}