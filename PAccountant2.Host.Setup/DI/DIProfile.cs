using Microsoft.Extensions.DependencyInjection;
using PAccountant2.BLL.Domain.Services;
using PAccountant2.BLL.Interfaces.Authentification;
using PAccountant2.DAL.Services;

namespace PAccountant2.Host.Setup.DI
{
    public static class DiProfile
    {
        public static void InitilizeDI(IServiceCollection services)
        {
            services.AddScoped<IAuthentificationDataService, AuthentificationDataService>();
            services.AddScoped<IAuthentificationService, AuthentificationService>();
        }
    }
}
