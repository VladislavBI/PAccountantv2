using System;
using System.Linq;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PAccountant2.Host.Domain.Models;
using PAccountant2.Host.Setup.DI;
using PAccountant2.Host.Setup.EntityFramework;
using PAccountant2.Host.Setup.Jwt;
using PAccountant2.Host.Setup.Mapping;
using PAccountantv2.Host.Api.Infrastructure.Helper;

namespace PAccountantv2.Host.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            // TODO: remove after find solution for jwt create bug
            services.AddScoped<ITokenService, JwtTokenService>();
            DiProfile.InitilizeDI(services);
            services.AddAutoMapper(typeof(MapperProfile));
            InitilizeJwt(services);
            InitializeDb(services);
 
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();
           
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=AuthView}/{action=Index}");
            });
        }

        private void InitializeDb(IServiceCollection services)
        {

            var dbSettingsSection = Configuration.GetSection("DBSettings");
            services.Configure<DbSettings>(dbSettingsSection);
            var dbSettings = dbSettingsSection.Get<DbSettings>();
            EFProfile.InitilizeEf(services, dbSettings);
        }

        private void InitilizeJwt(IServiceCollection services)
        {


            var jwtSettingsSection = Configuration.GetSection("JwtSettings");
            services.Configure<JwtSettings>(jwtSettingsSection);
            var jwtSettings = jwtSettingsSection.Get<JwtSettings>();
            JwtProfile.InitilizeJwt(services, jwtSettings);
        }


    }
}
