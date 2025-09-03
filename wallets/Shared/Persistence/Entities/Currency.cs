
namespace wallets.Shared.Persistence.Entities;

public class Currency
{
    public string Code { get; set; }
    public string Name { get; set; }
    public decimal Raitio { get; set; }
    public DateTime ModifiedAtUTC { get; set; }

    public Currency(string code, string name, decimal raitio)
    {
        Code = code;
        Name = name;
        Raitio = raitio;
        ModifiedAtUTC = DateTime.UtcNow;
    }

    public void UpdateRatio(decimal raitio)
    {
        Raitio = raitio;
        ModifiedAtUTC = DateTime.UtcNow;
    }
}

public class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
{
    public void Configure(EntityTypeBuilder<Currency> builder)
    {
        builder.HasKey(x => x.Code);

        builder.Property(x => x.Code)
            .HasMaxLength(10)
            .IsUnicode(false)//should be ascii
            .IsRequired();

        builder.Property(x => x.Name)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.Raitio)
            .IsRequired();
    }
}
