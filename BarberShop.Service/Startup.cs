using BarberShop.Service.Repository.Interfaces;
using BarberShop.Service.Services;
using BarberShop.Service.Services.Interfaces;
using BarberShop.Service.Repository.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BarberShop.Service.Repository.Database;
using BarberShop.Service.Repository.ModelsRepository;
using BarberShop.Service.Repository.Interfaces.ModelsRepository;
using BarberShop.Service.Utilities;
using BarberShop.Service.Models;

namespace BarberShop.Service
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        // Personal GitHub: https://github.com/luiz-diniz

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddMvc(options => options.EnableEndpointRouting = false);

            services.AddSingleton<ILogger, Logger>();
            services.AddSingleton<IHasher, Hasher>();
            services.AddSingleton<ICustomerService, CustomerService>();
            services.AddSingleton<ICustomerRepository, CustomerRepository>();
            services.AddSingleton<IEmployeeService, EmployeeService>();
            services.AddSingleton<IEmployeeRepository, EmployeeRepository>();
            services.AddSingleton<IPaymentService, PaymentService>();
            services.AddSingleton<IPaymentRepository, PaymentRepository>();
            services.AddSingleton<IServiceInfoService, ServiceInfoService>();
            services.AddSingleton<IServiceInfoRepository, ServiceInfoRepository>();
            services.AddSingleton<IShopAddressService, ShopAddressService>();
            services.AddSingleton<IShopAddressRepository, ShopAddressRepository>();
            services.AddSingleton<IOrderInfoService, OrderInfoService>();
            services.AddSingleton<IOrderInfoRepository, OrderInfoRepository>();
            services.AddSingleton<IOrderServicesService, OrderServicesService>();
            services.AddSingleton<IOrderServicesRepository, OrderServicesRepository>();
            services.AddSingleton<IOrderPaymentService, OrderPaymentService>();
            services.AddSingleton<IOrderPaymentRepository, OrderPaymentRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseMvc();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}