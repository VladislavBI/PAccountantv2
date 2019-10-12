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
            services.AddAuthentication().AddCookie(options =>
            {
                options.LoginPath = "/login";
            });
            //services.AddSession(options =>
            //{
            //    // Set a short timeout for easy testing.
            //    options.IdleTimeout = TimeSpan.FromHours(1);
            //});
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
            //app.UseSession();

            ////TODO: find better not register redirect solution
            //app.Use(async (context, next) =>
            //{
            //    var authorizationHeader = context.Request.Headers["Authorization"];

            //    if (context.Request.Path.ToString().Contains("authentification"))
            //    {
            //        await next();
            //    }

            //    if (!authorizationHeader.Any())
            //    {
            //        var authorizationToken = context.Session.GetString("Authorization");

            //        if (!string.IsNullOrEmpty(authorizationToken))
            //        {
            //            context.Request.Headers.Add("Authorization", authorizationToken);
            //        }
            //        else
            //        {
            //            context.Request.Path = "/login";
            //        }

            //    }
            //    else
            //    {
            //        if (!context.Session.Keys.Any(key => string.Equals(key, authorizationHeader.FirstOrDefault(), StringComparison.CurrentCultureIgnoreCase)))
            //        {
            //            var tokenEncoded = Encoding.Default.GetBytes(authorizationHeader.FirstOrDefault());
            //            context.Session.Set("Authorization", tokenEncoded);
            //        }
            //    }


            //    await next();
            //});

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
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
