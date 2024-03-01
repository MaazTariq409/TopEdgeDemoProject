using Microsoft.EntityFrameworkCore;
using TopEdgeDemoProject.Data;
using TopEdgeDemoProject.Repository;
using TopEdgeDemoProject.Repository.Interfaces;
using TopEdgeDemoProject.Services;

namespace TopEdgeDemoProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddScoped<IScrapRepository, ScrapRepository>();
            builder.Services.AddScoped<IScrapperService, ScrapperService>();

            builder.Services.AddDbContext<ScrapingDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("TopEdgeConnectionString"));
            });

            // Add services to the container.
            builder.Services.AddControllersWithViews();

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
        }
    }
}