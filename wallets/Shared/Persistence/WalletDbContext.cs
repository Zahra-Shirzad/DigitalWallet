
namespace wallets.Shared.Persistence;

public class WalletDbContext(DbContextOptions<WalletDbContext> dbContextOptions)
    : DbContext(dbContextOptions)
{
    public DbSet<Currency> currencies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(AssemblyMarker.ApplicationAssembly);
    }
}
