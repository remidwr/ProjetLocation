using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProjetLocation.API;
using Tools.Database;
using Tools.Security.RSA;
using Tools.Security.Token;
using DAL.Repositories;

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
            IConfigurationSection configurationSection = Configuration.GetSection("ConnectionStrings");
            DBConnectionStrings connectionStrings = configurationSection.Get<DBConnectionStrings>();
            string connectionString = configurationSection.Get<DBConnectionStrings>().DB_ProjetLocation;

            services.AddControllers();
            services.AddSingleton<ITokenService, TokenService>(sp => new TokenService("@T=q=6Hd4cua$GdqSx-Ww%jKN$8-RbyaMTARJjvR4D_jwtYCqz!VL=c_6!@HE5+&5t?f7fPXQe@nX%LV^m8jrpLgKEdt*PyPZ*VV*fWGheyMkH^F@*8T^QYZe^mwEGjR7pdx=93XmS*nqAZpmPuHf%7tXkCk#k2F$+QPu?pkVPAWU2zbYASwZsrKP@?YwCz9eYkb!%rCU9q%Vwk67mt-u@Psh%qz@XRBY+hUyU8^FzWF8!Ay9aLajM@PGr4HF?8w5VKu8nV?7KmE+y?fk$hMwTp_5rh^@%rXJQv#RrCG=sV4VZkV&VDx-E6x4RU?T&NFxBGU7!@rHc!$PRxtbSZ#jTcRuw*jtY#Q4?XEdtCapJaS?Q8sWd$Hbea4HP3eQAzQnv$-utw%zq9*uzSv*2jx3kU6G777e9KWp%z*92rA@dK3+EN*TcDwyBWzXL*S8cjVubc^HgS_zW3GkyQYLJzt#?nyESbE+D_qN$WW92Gt+s+$R5$H4twbJ9f3fCZYzy6#"));
            services.AddSingleton<KeyGenerator>();
            services.AddSingleton<DbProviderFactory>(sp => SqlClientFactory.Instance);
            services.AddSingleton(sp => new ConnectionInfo(connectionString));
            services.AddSingleton<Connection>();
            services.AddSingleton<AuthRepository>();
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
