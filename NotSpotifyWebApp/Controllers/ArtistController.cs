/*==============================================================================
 *
 * Description - Controlls the views and actions regarding the artist controller.
 *
 * Copyright © Dami Sam Akiode, 2025
 *
 * Personal Project - Not Spotify (ArtistController.cs)
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
    public class ArtistController : Controller
    {
        private readonly SpotifyAuthService _SpotifyAuthService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ArtistController"/> class.
        /// </summary>
        /// <param name="spotifyAuthService">The authentication service.</param>
        public ArtistController(SpotifyAuthService spotifyAuthService)
        {
            _SpotifyAuthService = spotifyAuthService;
        }

        /// <summary>
        /// The default view for the artist section Spotify application.
        /// </summary>
        /// <returns>A redirect to the artist's profile.</returns>
        [Route("artist")]
        public IActionResult Index()
        {
            return RedirectToAction("profile");
        }

        /// <summary>
        /// The view for an artist's profile.
        /// </summary>
        /// <param name="id">The Id of the artist to view.</param>
        /// <returns>The Profile View.</returns>
        [Route("artist/profile")]
        public async Task<IActionResult> ProfileAsync(string id)
        {
            string accessToken = _SpotifyAuthService.GetAccessToken();
            if (string.IsNullOrEmpty(accessToken))
            {
                return Redirect("/auth/login");
            }

            SpotifyClient spotify = new SpotifyClient(accessToken);

            FullArtist artist = await spotify.Artists.Get(id);

            ArtistsTopTracksRequest tracksRequest = new ArtistsTopTracksRequest("GB");
            ArtistsTopTracksResponse topTracks = await spotify.Artists.GetTopTracks(id, tracksRequest);

            return View(new ArtistViewModel(artist, topTracks));
        }
    }
}
