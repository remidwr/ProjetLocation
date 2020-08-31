using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Tools.Database;
using Tools.Security.RSA;
using Tools.Security.Token;
using DAL.Repositories;
using ProjetLocation.API.Helpers;

namespace ProjetLocation_API
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
            IConfigurationSection dbConnectionStringsSection = Configuration.GetSection("DBConnectionStrings");
            DBConnectionStrings connectionStrings = dbConnectionStringsSection.Get<DBConnectionStrings>();
            string connectionString = dbConnectionStringsSection.Get<DBConnectionStrings>().ConnectionStrings;

            IConfigurationSection appSettingsSection = Configuration.GetSection("AppSettings");
            AppSettings appSettings = appSettingsSection.Get<AppSettings>();
            string secret = appSettingsSection.Get<AppSettings>().Secret;

            services.AddControllers();
            services.AddSingleton<ITokenService, TokenService>(sp => new TokenService(secret));
            services.AddSingleton<KeyGenerator>();
            services.AddSingleton<DbProviderFactory>(sp => SqlClientFactory.Instance);
            services.AddSingleton(sp => new ConnectionInfo(connectionString));
            services.AddSingleton<Connection>();
            services.AddSingleton<AuthRepository>();
            services.AddSingleton<UserRepository>();
            services.AddSingleton<GoodRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
