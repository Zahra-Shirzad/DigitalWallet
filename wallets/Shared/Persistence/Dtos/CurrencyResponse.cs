namespace wallets.Shared.Persistence.Dtos;

public record CurrencyResponse(
    string Code,
    string Name,
    decimal Raitio);
