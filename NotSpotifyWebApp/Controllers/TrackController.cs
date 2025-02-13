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

        /// <summary>
        /// The view for a track.
        /// </summary>
        /// <param name="id">The Id of the artist to view.</param>
        /// <returns>The Profile View.</returns>
        [Route("track/details")]
        public async Task<IActionResult> DetailsAsync(string id)
        {
            string accessToken = SpotifyAuthService.GetAccessToken();
            if (string.IsNullOrEmpty(accessToken))
            {
                return Redirect("/auth/login");
            }

            SpotifyClient spotify = new SpotifyClient(accessToken);

            FullTrack track = await spotify.Tracks.Get(id);
            FullArtist artist = await spotify.Artists.Get(track.Artists[0].Id);

            ArtistsTopTracksRequest tracksRequest = new ArtistsTopTracksRequest("GB");
            ArtistsTopTracksResponse topTracks = await spotify.Artists.GetTopTracks(artist.Id, tracksRequest);

            Paging<SimpleAlbum> discographyPaged = await spotify.Artists.GetAlbums(artist.Id);
            List<SimpleAlbum> discography = PagingToList(discographyPaged);

            return View(new TrackViewModel(track, new ArtistViewModel(artist, topTracks, discography)));
        }
    }
}
