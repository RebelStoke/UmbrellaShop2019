﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using PetshopApp2019.Infrastructure.SQLData.Repositories;
using UmbrellaShop.Core.ApplicationService;
using UmbrellaShop.Core.ApplicationService.ServiceImplementation;
using UmbrellaShop.Core.ApplicationService.ServiceImplemetation;
using UmbrellaShop.Core.DomainService;
using UmbrellaShop.Infrastructure.SQLData;
using UmbrellaShop.Infrastructure.SQLData.Repositories;

namespace UmbrellaShop.UI.RestAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            Environment = env;
        }

        public IConfiguration Configuration { get; }
        public IHostingEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            if (Environment.IsDevelopment())
            {
                services.AddDbContext<UmbrellaShopContext>
                    (opt => opt.UseSqlite("Data Source=UmbrellaShopSQLLite.db")
                );
            }
            else
            {
                services.AddDbContext<UmbrellaShopContext>(
                    opt =>
                    {
                        opt.UseSqlServer(Configuration.GetConnectionString("defaultConnection"));
                    });
               
            }
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    buildier => buildier
                    .AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()
                    );
            }

            );
            services.AddScoped<IUmbrellaRepository, UmbrellaRepository>();
            services.AddScoped<IUmbrellaService, UmbrellaService>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });

            // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors("AllowSpecificOrigin");
            if (env.IsDevelopment())
            {
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var context = scope.ServiceProvider.GetRequiredService<UmbrellaShopContext>();
                    context.Database.EnsureDeleted();
                    context.Database.EnsureCreated();
                    DbInitializer.Seed(context);

                }
                app.UseDeveloperExceptionPage();
            }
            else
            {
                using (var scope = app.ApplicationServices.CreateScope())
                {

                    var context = scope.ServiceProvider.GetRequiredService<UmbrellaShopContext>();
                    context.Database.EnsureCreated();
                    DbInitializer.Seed(context);

                }
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}