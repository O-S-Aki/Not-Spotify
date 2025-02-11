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

        /// <summary>
        /// Returns a paged list of type <typeparamref name="T"/> to a list of the same type.
        /// </summary>
        /// <typeparam name="T">A generic type.</typeparam>
        /// <param name="pagedList">The paged list to convert.</param>
        /// <returns>The returned list.</returns>
        private static List<T> PagingToList<T>(Paging<T> pagedList)
        {
            List<T> list = new List<T>();

            if (pagedList.Items != null && pagedList.Items.Any())
            {
                foreach (T item in pagedList.Items)
                {
                    list.Add(item);
                }
            }

            return list;
        }
    }
}
