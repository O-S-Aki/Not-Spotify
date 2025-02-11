/*==============================================================================
 *
 * Description - The model for viewing the currently logged in user's top artists.
 *
 * Copyright © Dami Sam Akiode, 2025
 *
 * Personal Project - Not Spotify (TopArtistsViewModel.cs)
 *
 *============================================================================*/

using System.Diagnostics.CodeAnalysis;
using SpotifyAPI.Web;

namespace NotSpotifyWebApp.Models
{
    /// <summary>
    /// Holds the definition for the <see cref="TopArtistsViewModel"/> class.
    /// </summary>
    public class TopArtistsViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TopArtistsViewModel"/> class.
        /// </summary>
        /// <param name="topArtists">The user's top artists.</param>
        [SetsRequiredMembers]
        public TopArtistsViewModel(UsersTopArtistsResponse topArtists)
        {
            Href = topArtists.Href;
            Total = topArtists.Total;
            Items = ArtistViewModel.ToViewModels(topArtists.Items);
        }

        /// <summary>
        /// Gets or sets the Href.
        /// </summary>
        public required string Href { get; set; }

        /// <summary>
        /// Gets or sets the total number of top artists for the month.
        /// </summary>
        public required int Total { get; set; }

        /// <summary>
        /// Gets or sets a list of each artist.
        /// </summary>
        public required List<ArtistViewModel> Items { get; set; }
    }
}
