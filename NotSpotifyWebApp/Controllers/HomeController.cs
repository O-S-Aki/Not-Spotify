/*==============================================================================
 *
 * Description - Controlls the views and actions regarding the home endpoint.
 *
 * Copyright © Dami Sam Akiode, 2025
 *
 * Personal Project - Not Spotify (HomeController.cs)
 *
 *============================================================================*/

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NotSpotifyWebApp.Models;

namespace NotSpotifyWebApp.Controllers
{
    /// <summary>
    /// Holds the definition for the <see cref="HomeController"/> class.
    /// </summary>
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _Logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        public HomeController(ILogger<HomeController> logger)
        {
            _Logger = logger;
        }

        /// <summary>
        /// Gets the view for the Index page.
        /// </summary>
        /// <returns>Index view.</returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Gets the view for the Privacy page.
        /// </summary>
        /// <returns>Privacy view.</returns>
        public IActionResult Privacy()
        {
            return View();
        }

        /// <summary>
        /// Gets the view for the Error page.
        /// </summary>
        /// <returns>Error view.</returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
