using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using ShopCar.Interfaces;
using ShopCar.Mocks;

// namespace ShopCar
// {
//     public class Program
//     {
//         public static void Main(string[] args)
//         {
//             CreateWebHostBuilder(args).Build().Run();
//         }

//         public static IWebHostBuilder CreateWebHostBuilder(string[] args) => WebHost.CreateDefaultBuilder(args).UseStartup<Startup>();
//     }
// }
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// builder.Services.AddScoped<IAllCars, MockCars>();
// builder.Services.AddScoped<ICarsCategory, MockCategory>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
