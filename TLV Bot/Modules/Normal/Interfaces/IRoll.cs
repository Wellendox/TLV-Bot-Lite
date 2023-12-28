namespace TLVBot.Modules.Normal.Interfaces;

public interface IRoll
{
    Task RollAsync();

    Task RollD100Async(string unused);

    Task RollD20Async(string unused);

    Task RollD6Async(string unused);

    Task RollMaxAsync(int max);

    Task RollMinMaxAmountAsync(int min, int max, int amount);

    Task RollMinMaxAmountAttributeAsync(int min, int max, int amount, string attribute);
}