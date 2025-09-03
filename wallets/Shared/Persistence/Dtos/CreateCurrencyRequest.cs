namespace wallets.Shared.Persistence.Dtos;

public record CreateCurrencyRequest(
    string Code,
    string Name,
    decimal Raitio);

