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
    /// Holds the definition for the <see cref="TrackListViewModel"/> class.
    /// </summary>
    public class TrackListViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TrackListViewModel"/> class.
        /// </summary>
        /// <param name="topTracks">The user's top tracks.</param>
        [SetsRequiredMembers]
        public TrackListViewModel(UsersTopTracksResponse topTracks)
        {
            Total = topTracks.Total;
            Items = TrackViewModel.ToViewModels(topTracks.Items);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TrackListViewModel"/> class.
        /// </summary>
        /// <param name="topTracks">The artist's top tracks.</param>
        [SetsRequiredMembers]
        public TrackListViewModel(ArtistsTopTracksResponse topTracks)
        {
            Total = topTracks.Tracks.Count;
            Items = TrackViewModel.ToViewModels(topTracks.Tracks);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TrackListViewModel"/> class.
        /// </summary>
        /// <param name="tracks">The list of tracks tracks.</param>
        [SetsRequiredMembers]
        public TrackListViewModel(List<SimpleTrack> tracks)
        {
            Total = tracks.Count;
            Items = TrackViewModel.ToViewModels(tracks);
        }

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
