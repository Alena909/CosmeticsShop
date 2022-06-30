using System.Net;
using CosmeticsShop.Models;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CosmeticsShop
{
    public class Program

    { public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.WebHost.ConfigureKestrel(serverOptions =>
            {
                serverOptions.Configure(builder.Configuration);
            });

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            var connString = Environment.GetEnvironmentVariable("ProductContext__ConnectionString");
            builder.Services.AddDbContext<ProductContext>(options =>
            {
                options.UseMySql(connString, ServerVersion.AutoDetect(connString));
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
           /* if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }*/

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto,
                KnownProxies = { IPAddress.Parse("209.50.57.191") }
            });

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            if (app.Environment.IsDevelopment())
            {
                app.Run();
            }
            else
            {
                // force production to use port 5000
                app.Run("http://127.0.0.1:5000");
            }
        }
    }
}