using wallets.Shared.Persistence;
using wallets.Shared.Persistence.Dtos;
using wallets.Shared.Persistence.Entities;

namespace wallets.Controllers.Currency
{
    [ApiController]
    [Route("[controller]")]
    public class CurrenciesController : ControllerBase
    {
        private readonly WalletDbContext _walletDbContext;

        public CurrenciesController(WalletDbContext walletDbContext)
        {
            _walletDbContext = walletDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCurrencyRequest request)
        {
            //validation
            var currency = new Shared.Persistence.Entities.Currency(request.Code, request.Name, request.Raitio);
            _walletDbContext.currencies.Add(currency);

            return ((await _walletDbContext.SaveChangesAsync()) > 0) switch
            {
                true => Ok(currency),
                false => BadRequest(currency)
            };

        }

        [HttpPatch]
        public async Task<IActionResult> UpdateRatio(UpdateRatioCurrencyRequest request)
        {
            var currency = await _walletDbContext.currencies.FirstOrDefaultAsync(x => x.Code == request.Code);
            if (currency is null)
                return BadRequest(currency);

            currency.UpdateRatio(request.Raitio);

            return ((await _walletDbContext.SaveChangesAsync()) > 0) switch
            {
                true => Ok(currency),
                false => BadRequest(currency)
            };
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var currencies = await _walletDbContext.currencies
                .Select(c => new CurrencyResponse(c.Code, c.Name, c.Raitio))
                .ToListAsync();

            return (currencies.Any()) switch
            {
                true => Ok(currencies),
                false => NotFound()
            };
        }

        [HttpGet("/{code}")]
        public async Task<IActionResult> GetbyCode([FromRoute] string code)
        {
            var currency = await _walletDbContext.currencies
                .FirstOrDefaultAsync(x => x.Code == code);

            return (currency is null) switch
            {
                true => Ok(currency),
                false => NotFound()
            };
        }

    }
}
