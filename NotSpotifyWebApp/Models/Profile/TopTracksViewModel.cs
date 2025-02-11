/*==============================================================================
 *
 * Description - The model for viewing the currently logged in user's top tracks.
 *
 * Copyright © Dami Sam Akiode, 2025
 *
 * Personal Project - Not Spotify (TopTracksViewModel.cs)
 *
 *============================================================================*/

using System.Diagnostics.CodeAnalysis;
using SpotifyAPI.Web;

namespace NotSpotifyWebApp.Models
{
    /// <summary>
    /// Holds the definition for the <see cref="TopTracksViewModel"/> class.
    /// </summary>
    public class TopTracksViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TopTracksViewModel"/> class.
        /// </summary>
        /// <param name="topTracks">The user's top tracks.</param>
        [SetsRequiredMembers]
        public TopTracksViewModel(UsersTopTracksResponse topTracks)
        {
            Href = topTracks.Href;
            Total = topTracks.Total;
            Items = TrackViewModel.ToViewModels(topTracks.Items);
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
        public required List<TrackViewModel> Items { get; set; }
    }
}
