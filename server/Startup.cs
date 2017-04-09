using System;
using System.IO;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.FileProviders;

namespace Parkwell.cms.server
{
    public class Startup 
    {
        public static IContainer Container;
        public IConfigurationRoot Configuration { get; set; }
        
        public Startup(IHostingEnvironment env)
        {
            var configurationBuilder = new ConfigurationBuilder();
            
            Configuration = configurationBuilder.Build();
        }
        
        public void Configure(IApplicationBuilder app)
        {
            
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
            services.AddMvcCore();

            // Create the container builder.
            var builder = new ContainerBuilder();

            //Register your services here eg. builder.Reguster ex
            
            builder.Populate(services);
            
            Container = builder.Build();

            // Create the IServiceProvider based on the container.
            return new AutofacServiceProvider(Container);
        }
    }
}