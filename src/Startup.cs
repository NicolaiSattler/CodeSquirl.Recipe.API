using AutoMapper;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using CodeSquirl.RecipeApp.Model;
using CodeSquirl.RecipeApp.DataProvider;
using CodeSquirl.RecipeApp.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Swashbuckle.AspNetCore.Swagger;

namespace CodeSquirl.RecipeApp.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private void ConfigureSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "CodeSquirl - Recipe App",
                    Description = "",
                    TermsOfService = "None",
                    Contact = new Contact
                    {
                        Name = "",
                        Email = "",
                        Url = ""
                    }
                });
            });
        }
        private IContainer ConfigureAutofac(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            var builder = new ContainerBuilder();
           
            builder.RegisterModule<ModelModule>();
            builder.RegisterModule<DataProviderModule>();
            builder.RegisterModule<ServiceModule>();     
            builder.RegisterModule(new APIModule(connectionString));
            builder.Populate(services);

            return builder.Build();
        }
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddControllersAsServices();

        #if DEBUG
            ConfigureSwagger(services);
        #endif 

            var container = ConfigureAutofac(services);
            return new AutofacServiceProvider(container);
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            
        #if DEBUG
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CodeSquirl - Recipe App (Alpha)");
            });
        #endif
        }
    }
}
