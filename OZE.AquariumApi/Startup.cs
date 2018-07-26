using System;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using OZE.AquariumApi.HttpFactories;
using OZE.AquariumApi.Services;

namespace OZE.AquariumApi {
    public class Startup
    {
        private readonly bool deviceDisconnected = true;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options => 
                options.AddPolicy("any", builder => 
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));
            services.AddTransient<IDeserializeService, DeserializeService>();

            if (deviceDisconnected) 
                services.AddTransient<IAquariumService, FakeAquariumService>();
            else
                services.AddTransient<IAquariumService, AquariumService>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddHttpClient<AquariumHttpFactory>(client => client.BaseAddress = new Uri("http://192.168.8.133"));
            services.AddLogging();
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

            app.UseCors("any");

            app.UseMvc();
        }
    }
}
