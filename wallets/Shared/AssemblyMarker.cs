
namespace wallets.Shared;

public static class AssemblyMarker
{
    public static readonly Lazy<Assembly> _currentAssembly = new Lazy<Assembly>(() =>
    typeof(AssemblyMarker).Assembly);

    public static Assembly ApplicationAssembly = _currentAssembly.Value;
}
