using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Commerce.Core;
using Commerce.SystemManagement.BusinessImplementation;
using Commerce.SystemManagement.Business;
using Microsoft.AspNetCore.Mvc;


namespace Commerce.SystemManagement.ServiceApi
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
            var keys = new[] { "connection.provider", "connection.connection_string", "show_sql", "dialect", "connection.driver_class" };
            var settings = keys.ToDictionary(k => k, v => Configuration.GetValue<string>($"commerce:sys:nh:{v}"));
            var assemblyIndex = 0;
            string assembly = null;
            var assemblies = new List<string>();
            while ((assembly = Configuration.GetValue<string>($"commerce:sys:nh:assembly:{assemblyIndex}")) != null)
            {
                assemblies.Add(assembly);
                assemblyIndex++;
            }
            services.AddScoped<INhHelper, NhHelper>(x => new NhHelper(settings, true, assemblies));
            services.AddScoped<IRepository, NhRepository>();
            services.AddScoped<IUserFacade, UserFacade>();
            services.AddScoped<IRoleFacade, RoleFacade>();
            services.AddScoped<ITokenFacade, TokenFacade>();
      
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
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
