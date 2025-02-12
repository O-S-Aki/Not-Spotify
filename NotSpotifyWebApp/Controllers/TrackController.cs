/*==============================================================================
 *
 * Description - Controls the views and actions regarding the track controller.
 *
 * Copyright © Dami Sam Akiode, 2025
 *
 * Personal Project - Not Spotify (TrackController.cs)
 *
 *============================================================================*/

using Microsoft.AspNetCore.Mvc;
using NotSpotifyWebApp.Models;
using NotSpotifyWebApp.Services;
using SpotifyAPI.Web;

namespace NotSpotifyWebApp.Controllers
{
    /// <summary>
    /// Holds the definition for the <see cref="TrackController"/> class.
    /// </summary>
    public class TrackController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TrackController"/> class.
        /// </summary>
        /// <param name="spotifyAuthService">The authentication service.</param>
        public TrackController(SpotifyAuthService spotifyAuthService)
        : base(spotifyAuthService)
        {
        }
    }
}
