using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PAccountant2.DAL.Context;
using PAccountant2.Host.Domain.Models;

namespace PAccountant2.Host.Setup.EntityFramework
{
    public static class EFProfile
    {
        public static void InitilizeEf(IServiceCollection services, DbSettings settings)
        {
            if (services == null || settings == null)
            {
                throw new NullReferenceException();
            }

            if (!settings.ConnectionStrings.ContainsKey(settings.CurrentConnectionName))
            {
                throw new KeyNotFoundException(settings.CurrentConnectionName);
            }

            services.AddDbContext<PaccountantContext>(opts =>
            opts.UseSqlServer(settings.ConnectionStrings[settings.CurrentConnectionName],
                 x => x.MigrationsAssembly(settings.MigrationAssembly))
            );
        }
    }
}
