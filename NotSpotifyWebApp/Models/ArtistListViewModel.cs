/*==============================================================================
 *
 * Description - The model for viewing a list of artists.
 *
 * Copyright © Dami Sam Akiode, 2025
 *
 * Personal Project - Not Spotify (ArtistListViewModel.cs)
 *
 *============================================================================*/

using System.Diagnostics.CodeAnalysis;
using SpotifyAPI.Web;

namespace NotSpotifyWebApp.Models
{
    /// <summary>
    /// Holds the definition for the <see cref="ArtistListViewModel"/> class.
    /// </summary>
    public class ArtistListViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ArtistListViewModel"/> class.
        /// </summary>
        /// <param name="topArtists">The user's top artists.</param>
        [SetsRequiredMembers]
        public ArtistListViewModel(UsersTopArtistsResponse topArtists)
        {
            Total = topArtists.Total;
            Items = ArtistViewModel.ToViewModels(topArtists.Items);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArtistListViewModel"/> class.
        /// </summary>
        /// <param name="relatedArtists">The artis's related artists.</param>
        [SetsRequiredMembers]
        public ArtistListViewModel(ArtistsRelatedArtistsResponse relatedArtists)
        {
            Total = relatedArtists.Artists.Count;
            Items = ArtistViewModel.ToViewModels(relatedArtists.Artists);
        }

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
