/*==============================================================================
 *
 * Description - The main program file of the Web Application.
 *
 * Copyright © Dami Sam Akiode, 2025
 *
 * Personal Project - Not Spotify (Program.cs)
 *
 *============================================================================*/

using NotSpotifyClassLibrary;
using NotSpotifyWebApp.Services;

namespace NotSpotifyWebApp
{
    /// <summary>
    /// Holds the definition for the <see cref="Program"/> class.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The main method.
        /// </summary>
        /// <param name="args">Input arguments.</param>
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configure Spotify Services
            builder.Services.Configure<SpotifyConfig>(builder.Configuration.GetSection("Spotify"));
            builder.Services.AddSingleton<SpotifyAuthService>();

            // Configure Session - setting an Idle Timeont
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Auth}/{action=Login}");

            app.Run();
        }
    }
}
