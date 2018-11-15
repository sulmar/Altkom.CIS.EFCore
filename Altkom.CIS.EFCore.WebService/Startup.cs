using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Altkom.CIS.EFCore.DbServices;
using Altkom.CIS.EFCore.IServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Altkom.CIS.EFCore.WebService
{
    public class Startup
    {
        //public Startup(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}

        public Startup(IHostingEnvironment env)
        {
            // PM> Install-Package Microsoft.Extensions.Configuration.Json
            // PM> Install-Package Microsoft.Extensions.Configuration.Xml
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddXmlFile("appsettings.xml", optional: true)
                ;

            Configuration = builder.Build();



        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IProductsService, DbProductsService>();

            string connectionString = Configuration.GetConnectionString("ShopConnection");
            string password = Configuration["Password"];
            string login = Configuration["Users:Login"];

            // PM> Install-Package Microsoft.EntityFrameworkCore.SqlServer
            services.AddDbContext<ShopContext>(options => options.UseSqlServer(connectionString));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
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
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
