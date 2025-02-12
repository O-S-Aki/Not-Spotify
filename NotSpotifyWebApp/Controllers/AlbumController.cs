/*==============================================================================
 *
 * Description - Controls the views and actions regarding the album controller.
 *
 * Copyright © Dami Sam Akiode, 2025
 *
 * Personal Project - Not Spotify (AlbumController.cs)
 *
 *============================================================================*/

using Microsoft.AspNetCore.Mvc;
using NotSpotifyWebApp.Models;
using NotSpotifyWebApp.Services;
using SpotifyAPI.Web;

namespace NotSpotifyWebApp.Controllers
{
    /// <summary>
    /// Holds the definition for the <see cref="AlbumController"/> class.
    /// </summary>
    public class AlbumController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AlbumController"/> class.
        /// </summary>
        /// <param name="spotifyAuthService">The authentication service.</param>
        public AlbumController(SpotifyAuthService spotifyAuthService)
            : base(spotifyAuthService)
        {
        }

        /// <summary>
        /// The view for an artist's profile.
        /// </summary>
        /// <param name="id">The Id of the artist to view.</param>
        /// <returns>The Profile View.</returns>
        [Route("album/details")]
        public async Task<IActionResult> DetailsAsync(string id)
        {
            string accessToken = SpotifyAuthService.GetAccessToken();
            if (string.IsNullOrEmpty(accessToken))
            {
                return Redirect("/auth/login");
            }

            SpotifyClient spotify = new SpotifyClient(accessToken);

            FullAlbum album = await spotify.Albums.Get(id);
            FullArtist artist = await spotify.Artists.Get(album.Artists[0].Id);

            return View(new AlbumViewModel(album, artist));
        }
    }
}
