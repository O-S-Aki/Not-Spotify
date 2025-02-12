/*==============================================================================
 *
 * Description - Controls the views and actions regarding the artist controller.
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
    /// Holds the definition for the <see cref="ArtistController"/> class.
    /// </summary>
    public class ArtistController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ArtistController"/> class.
        /// </summary>
        /// <param name="spotifyAuthService">The authentication service.</param>
        public ArtistController(SpotifyAuthService spotifyAuthService)
            : base(spotifyAuthService)
        {
        }

        /// <summary>
        /// The view for an artist's profile.
        /// </summary>
        /// <param name="id">The Id of the artist to view.</param>
        /// <returns>The Profile View.</returns>
        [Route("artist/profile")]
        public async Task<IActionResult> ProfileAsync(string id)
        {
            string accessToken = SpotifyAuthService.GetAccessToken();
            if (string.IsNullOrEmpty(accessToken))
            {
                return Redirect("/auth/login");
            }

            SpotifyClient spotify = new SpotifyClient(accessToken);

            FullArtist artist = await spotify.Artists.Get(id);

            ArtistsTopTracksRequest tracksRequest = new ArtistsTopTracksRequest("GB");
            ArtistsTopTracksResponse topTracks = await spotify.Artists.GetTopTracks(id, tracksRequest);

            ArtistsAlbumsRequest albumsRequest = new ArtistsAlbumsRequest()
            {
                IncludeGroupsParam = ArtistsAlbumsRequest.IncludeGroups.Album,
            };

            ArtistsAlbumsRequest singlesRequest = new ArtistsAlbumsRequest()
            {
                IncludeGroupsParam = ArtistsAlbumsRequest.IncludeGroups.Single,
            };

            Paging<SimpleAlbum> discographyPaged = await spotify.Artists.GetAlbums(id);
            List<SimpleAlbum> discography = PagingToList(discographyPaged);

            Paging<SimpleAlbum> albumsPaged = await spotify.Artists.GetAlbums(id, albumsRequest);
            List<SimpleAlbum> albums = PagingToList(albumsPaged);

            Paging<SimpleAlbum> singlesPaged = await spotify.Artists.GetAlbums(id, singlesRequest);
            List<SimpleAlbum> singles = PagingToList(singlesPaged);

            return View(new ArtistViewModel(artist, topTracks, discography, albums, singles));
        }
    }
}
