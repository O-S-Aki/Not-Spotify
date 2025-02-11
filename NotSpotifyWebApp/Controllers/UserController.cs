/*==============================================================================
 *
 * Description - Controlls the views and actions regarding the user controller.
 *
 * Copyright © Dami Sam Akiode, 2025
 *
 * Personal Project - Not Spotify (UserController.cs)
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
    public class UserController : Controller
    {
        private readonly SpotifyAuthService _SpotifyAuthService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="spotifyAuthService">The authentication service.</param>
        public UserController(SpotifyAuthService spotifyAuthService)
        {
            _SpotifyAuthService = spotifyAuthService;
        }

        /// <summary>
        /// The default view for the user section Spotify application.
        /// </summary>
        /// <returns>A redirect to the user's profile.</returns>
        [Route("user")]
        public IActionResult Index()
        {
            return RedirectToAction("profile");
        }

        /// <summary>
        /// The view for a user's profile.
        /// </summary>
        /// <returns>The Profile View.</returns>
        [Route("user/profile")]
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

            Paging<FullPlaylist> allPlaylists = await spotify.Playlists.CurrentUsers(new PlaylistCurrentUsersRequest());
            List<FullPlaylist> publicPlaylists = new List<FullPlaylist>();

            if (allPlaylists.Items != null && allPlaylists.Items.Any())
            {
                foreach (FullPlaylist playlist in allPlaylists.Items)
                {
                    if (playlist.Owner!.Id == currentUser.Id && playlist.Public == true)
                    {
                        publicPlaylists.Add(playlist);
                    }
                }
            }

            return View(new UserProfileViewModel(currentUser, topArtists, topTracks, publicPlaylists));
        }
    }
}
