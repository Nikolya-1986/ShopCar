using ShopCar.Interfaces;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Microsoft.EntityFrameworkCore;
using ShopCar.Repository;
using ShopCar.Models;

namespace ShopCar
{
    public class Startup
    {
        private IConfigurationRoot _configString;
        public Startup(IHostingEnvironment hostingEnvironment)
        {
            _configString = new ConfigurationBuilder().SetBasePath(hostingEnvironment.ContentRootPath).AddJsonFile("appsettings.json").Build();
        }
        public void ConfigurationServices(IServiceCollection services)
        {
            services.AddDbContext<AppDBContent>(options => options.UseSqlServer(_configString.GetConnectionString("DefaultConnection")));
            services.AddTransient<IAllCars, CarRepository>(); // связь между классом и интерфейсом который реализует данный класс
            services.AddTransient<ICarsCategory, CategoryRepository>();
            services.AddControllersWithViews();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp => ShopCart.GetCart(sp));
            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            app.UseMvcWithDefaultRoute();

            using (var scope = app.ApplicationServices.CreateScope()) // создание окружения и внутри переменную
            {
                AppDBContent content = scope.ServiceProvider.GetRequiredService<AppDBContent>(); // подключение к базе данных
                DBObjects.Initial(content);
            }
        }
    }
}