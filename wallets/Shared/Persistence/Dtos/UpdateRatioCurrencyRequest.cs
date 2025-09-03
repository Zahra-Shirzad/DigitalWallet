namespace wallets.Shared.Persistence.Dtos;

public record UpdateRatioCurrencyRequest(
    string Code,
    decimal Raitio
    );
