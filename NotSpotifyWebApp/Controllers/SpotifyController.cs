/*==============================================================================
 *
 * Description - Controlls the views and actions regarding the spotify endpoint.
 *
 * Copyright © Dami Sam Akiode, 2025
 *
 * Personal Project - Not Spotify (SpotifyController.cs)
 *
 *============================================================================*/

using Microsoft.AspNetCore.Mvc;
using NotSpotifyWebApp.Models;
using NotSpotifyWebApp.Services;
using SpotifyAPI.Web;

namespace NotSpotifyWebApp.Controllers
{
    /// <summary>
    /// Holds the definition for the <see cref="SpotifyController"/> class.
    /// </summary>
    public class SpotifyController : Controller
    {
        private readonly SpotifyAuthService _SpotifyAuthService;

        /// <summary>
        /// Initializes a new instance of the <see cref="SpotifyController"/> class.
        /// </summary>
        /// <param name="spotifyAuthService">The authentication service.</param>
        public SpotifyController(SpotifyAuthService spotifyAuthService)
        {
            _SpotifyAuthService = spotifyAuthService;
        }

        /// <summary>
        /// The default view for the Spotify application.
        /// </summary>
        /// <returns>A redirect to the user's profile.</returns>
        [Route("spotify")]
        public IActionResult Index()
        {
            return RedirectToAction("Profile");
        }

        /// <summary>
        /// The view for a user's profile.
        /// </summary>
        /// <returns>The Profile View.</returns>
        [Route("spotify/profile")]
        public async Task<IActionResult> ProfileAsync()
        {
            string accessToken = _SpotifyAuthService.GetAccessToken();
            if (string.IsNullOrEmpty(accessToken))
            {
                return Redirect("/auth/login");
            }

            SpotifyClient spotify = new SpotifyClient(accessToken);

            PrivateUser currentUser = await spotify.UserProfile.Current();

            TimeRange oneMonth = TimeRange.ShortTerm;
            UsersTopItemsRequest monthFilter = new UsersTopItemsRequest(oneMonth);

            UsersTopArtistsResponse topArtists = await spotify.UserProfile.GetTopArtists(monthFilter);
            UsersTopTracksResponse topTracks = await spotify.UserProfile.GetTopTracks(monthFilter);

            return View(new ProfileViewModel(currentUser, topArtists, topTracks));
        }

        /// <summary>
        /// The view for a user's most recently liked tracks.
        /// </summary>
        /// <returns>The Tracks View.</returns>
        [Route("spotify/tracks")]
        public async Task<IActionResult> TracksAsync()
        {
            string accessToken = _SpotifyAuthService.GetAccessToken();
            if (string.IsNullOrEmpty(accessToken))
            {
                return Redirect("/auth/login");
            }

            SpotifyClient spotify = new SpotifyClient(accessToken);

            Paging<SavedTrack> tracks = await spotify.Library.GetTracks();

            return View(tracks);
        }

        /// <summary>
        /// The view for a user's playlists.
        /// </summary>
        /// <returns>The playlists view.</returns>
        [Route("spotify/playlists")]
        public async Task<IActionResult> PlaylistsAsync()
        {
            string accessToken = _SpotifyAuthService.GetAccessToken();
            if (string.IsNullOrEmpty(accessToken))
            {
                return Redirect("/auth/login");
            }

            SpotifyClient spotify = new SpotifyClient(accessToken);

            Paging<FullPlaylist> playlists = await spotify.Playlists.CurrentUsers();

            return View(playlists);
        }
    }
}
