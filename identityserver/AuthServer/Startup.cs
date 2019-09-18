using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using AuthServer.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AuthServer
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentityServer()
                .AddDeveloperSigningCredential()
                .AddSigningCredential(new X509Certificate2(@"D:\IdentityServer\localhostcorecert.pfx", "PlR05FX8mEakeHqg"))
                .AddInMemoryIdentityResources(InMemoryConfiguration.GetIdentityResources())
                .AddTestUsers(InMemoryConfiguration.Users().ToList())
                .AddInMemoryClients(InMemoryConfiguration.Clients())
              .AddInMemoryApiResources(InMemoryConfiguration.ApiResources());
            services.AddAuthorization();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseIdentityServer();
            app.UseAuthorization();
            app.UseRouting();
            app.UseStaticFiles();
            app.UseEndpoints(
                endpoints => endpoints.MapDefaultControllerRoute()
            );
        }
    }
}
