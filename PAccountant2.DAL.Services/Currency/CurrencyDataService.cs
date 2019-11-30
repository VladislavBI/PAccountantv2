using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PAccountant2.BLL.Interfaces.Currency;
using PAccountant2.BLL.Interfaces.DTO.DataItems.Currency;
using PAccountant2.DAL.Context;

namespace PAccountant2.DAL.Services.Currency
{
    public class CurrencyDataService : ICurrencyDataService
    {
        private readonly PaccountantContext _context;

        private readonly IMapper _mapper;
        
        public CurrencyDataService(PaccountantContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ExchangeRateDataItem>> GetExchangeRates()
        {
            var dbRates = await _context.ExchangeRates.ToListAsync();

            var mappedRates = _mapper.Map<IEnumerable<ExchangeRateDataItem>>(dbRates);

            return mappedRates;
        }
    }
}
