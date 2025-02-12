/*==============================================================================
 *
 * Description - Controls the views and actions regarding the playlist controller.
 *
 * Copyright © Dami Sam Akiode, 2025
 *
 * Personal Project - Not Spotify (PlaylistController.cs)
 *
 *============================================================================*/

using Microsoft.AspNetCore.Mvc;
using NotSpotifyWebApp.Models;
using NotSpotifyWebApp.Services;
using SpotifyAPI.Web;

namespace NotSpotifyWebApp.Controllers
{
    /// <summary>
    /// Holds the definition for the <see cref="UserController"/> class.
    /// </summary>
    public class PlaylistController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlaylistController"/> class.
        /// </summary>
        /// <param name="spotifyAuthService">The authentication service.</param>
        public PlaylistController(SpotifyAuthService spotifyAuthService)
            : base(spotifyAuthService)
        {
        }
    }
}
