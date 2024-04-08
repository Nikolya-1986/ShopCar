using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using ShopCar.Interfaces;
using ShopCar.Mocks;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using ShopCar.Repository;

namespace ShopCar
{
    public class Startup
    {
        private IConfigurationRoot _configString;
        public Startup(IHostingEnvironment hostingEnvironment)
        {
            _configString = new ConfigurationBuilder().SetBasePath(hostingEnvironment.ContentRootPath).AddJsonFile("dbsettings.json").Build();
        }
        public void ConfigurationServices(IServiceCollection services)
        {
            services.AddDbContext<AppDBContent>(options => options.UseSqlServer(_configString.GetConnectionString("DefaultConnection")));
            services.AddTransient<IAllCars, CarRepository>(); // связь между классом и интерфейсом который реализует данный класс
            services.AddTransient<ICarsCategory, CategoryRepository>();
            services.AddControllersWithViews();
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();

            using (var scope = app.ApplicationServices.CreateScope()) // создание окружения и внутри переменную
            {
                AppDBContent content = scope.ServiceProvider.GetRequiredService<AppDBContent>(); // подключение к базе данных
                DBObjects.Initial(content);
            }
        }
    }
}