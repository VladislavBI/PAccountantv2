using CurrenctyRateUtil.Services;
using Microsoft.Extensions.DependencyInjection;
using PAccountant2.BLL.Domain.Services;
using PAccountant2.BLL.Domain.Services.Accounting;
using PAccountant2.BLL.Domain.Services.Investment;
using PAccountant2.BLL.Interfaces.Account;
using PAccountant2.BLL.Interfaces.Authentification;
using PAccountant2.BLL.Interfaces.Investment;
using PAccountant2.BLL.Interfaces.Migration;
using PAccountant2.DAL.Services;
using PAccountant2.DAL.Services.Accounting;
using PAccountant2.DAL.Services.Currency;
using PAccountant2.DAL.Services.Investment;
using PAccountant2.Host.Domain.Services;


namespace PAccountant2.Host.Setup.DI
{
    public static class DiProfile
    {
        public static void InitilizeDI(IServiceCollection services)
        {
            services.AddScoped<IAuthentificationDataService, AuthentificationDataService>();
            services.AddScoped<IAuthentificationService, AuthentificationService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IAccountDataService, AccountDataService>();
            services.AddScoped<IAccountingDataService, AccountingDataService>();
            services.AddScoped<IAccountingService, AccountingService>();
            services.AddScoped<IInvestmentService, InvestmentService>();
            services.AddScoped<IInvestmentDataService, InvestmentDataService>();
            services.AddScoped<IContragentDataService, ContragentDataService>();
            services.AddScoped<ICurrencyDataService, CurrencyDataService>();

            services.AddScoped<IMigrationService, MigrationService>();
            services.AddScoped<IMigrationDataService, MigrationsDataService>();

            services.AddHostedService<CurrencyUpdateBackgroundService>();

            services.AddScoped<IRateService, RateService>();


        }
    }
}
