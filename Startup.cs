using Blazored.Toast;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using QuotationMgmtSystem.ApplicationDbContext;
using QuotationMgmtSystem.Authentication;
using QuotationMgmtSystem.Data;
using QuotationMgmtSystem.IServices;
using QuotationMgmtSystem.Services;
using QuotationMgmtSystem.StateObjects;

namespace QuotationMgmtSystem
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthenticationCore();
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
            services.AddSingleton<UserAccountService>();
            services.AddScoped<ProtectedSessionStorage>();

            services.AddSingleton<WeatherForecastService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IQuotationService, QuotationService>();

            #region Connection String
            services.AddDbContext<AppDbContext>(cs => cs.UseSqlServer(Configuration.GetConnectionString("QuotationMgmtDefault")));
            #endregion

            services.AddBlazoredToast();
            // If we'll apply Singleton then the KeepNote is shared among all users of applications
            services.AddScoped<KeepNote>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}