using System;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OZE.AquariumApi.Database;
using OZE.AquariumApi.DataSeed;
using OZE.AquariumApi.HttpFactories;
using OZE.AquariumApi.Services;
using OZE.AquariumApi.Services.FakeServices;

namespace OZE.AquariumApi {
    public class Startup {
        private readonly bool deviceDisconnected = true;
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddCors(options =>
                options.AddPolicy("any", builder =>
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));
            services.AddTransient<IDeserializeService, DeserializeService>();
            services.AddTransient<MongoSeed>();

            if (deviceDisconnected) {
                services.AddTransient<IAquariumService, FakeAquariumService>();
                services.AddTransient<IScheduledTaskService, FakeScheduledTaskService>();
            }
            else {
                services.AddTransient<IAquariumService, AquariumService>();
                services.AddTransient<IScheduledTaskService, ScheduledTaskService>();
            }
            services.AddTransient<IDatabaseContext>(MongoFactory);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddHttpClient<AquariumHttpFactory>(client => client.BaseAddress = new Uri("http://192.168.8.133"));
            services.AddLogging();
        }

        private IDatabaseContext MongoFactory(IServiceProvider arg) => new MongoContext(Configuration["MongoDb:Url"], Configuration["MongoDb:AquariumDb"], Configuration["MongoDb:ScheduledTasks"]);

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }
            else {
                app.UseHsts();
            }

            var seed = serviceProvider.GetService<MongoSeed>();
            seed.SeedData();

            app.UseCors("any");

            app.UseMvc();
        }
    }
}
