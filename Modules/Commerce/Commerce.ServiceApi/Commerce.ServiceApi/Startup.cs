using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Commerce.Business;
using Commerce.BusinessImplementation;
using Commerce.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Commerce.ServiceApi
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<INhHelper, NhHelper>(x => new NhHelper(new Dictionary<string, string> {
                { "connection.provider","NHibernate.Connection.DriverConnectionProvider" },
                { "connection.connection_string","Data Source=DESKTOP-HVEJO59;Database=COMMERCE;Integrated Security=true;"},
                { "show_sql","true" },
                { "dialect","NHibernate.Dialect.MsSql2008Dialect" },
                { "connection.driver_class","NHibernate.Driver.Sql2008ClientDriver" },

                //{ "dialect","NHibernate.Dialect.MsSqlCeDialect" },
                //{ "connection.driver_class","NHibernate.Driver.SqlServerCeDriver" }
            }, true, new List<string>
            {
                "Commerce.NhMapping"
            }));


            services.AddScoped<IOrderFacade, OrderFacade>();
            services.AddCors(options =>
            {


                options.AddPolicy("test_",
                    builder =>
                    {

                        builder.AllowAnyOrigin();
                        builder.AllowAnyHeader();
                        builder.AllowAnyMethod();
                        builder.AllowCredentials();
                    });
            });
            services.AddScoped<IRepository, NhRepository>();
            services.AddScoped<IProductFacade, ProductFacade>();
            services.AddScoped<IWordPressConnector, WordPressConnector>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            //var keys = new[] { "connection.provider", "connection.connection_string", "show_sql", "dialect", "connection.driver_class" };
            //var settings = keys.ToDictionary(k => k, v => Configuration.GetValue<string>($"zogal:oto:nh:{v}"));
            //var assemblyIndex = 0;
            //string assembly = null;
            //var assemblies = new List<string>();
            //while ((assembly = Configuration.GetValue<string>($"zogal:oto:nh:assembly:{assemblyIndex}")) != null)
            //{
            //    assemblies.Add(assembly);
            //    assemblyIndex++;
            //}

            //services.AddScoped<INhHelper, NhHelper>(x => new NhHelper(settings, true, assemblies));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("test_");
            app.UseMvc();
        }
    }
}
