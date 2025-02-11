/*==============================================================================
 *
 * Description - The model for viewing the currently logged in user's public playlists.
 *
 * Copyright © Dami Sam Akiode, 2025
 *
 * Personal Project - Not Spotify (PublicPlaylistsViewModel.cs)
 *
 *============================================================================*/

using System.Diagnostics.CodeAnalysis;
using SpotifyAPI.Web;

namespace NotSpotifyWebApp.Models
{
    /// <summary>
    /// Holds the definition for the <see cref="PublicPlaylistsViewModel"/> class.
    /// </summary>
    public class PublicPlaylistsViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PublicPlaylistsViewModel"/> class.
        /// </summary>
        /// <param name="playlists">The user's public playlists.</param>
        [SetsRequiredMembers]
        public PublicPlaylistsViewModel(List<FullPlaylist> playlists)
        {
            Total = playlists.Count;
            Items = PlaylistViewModel.ToViewModels(playlists);
        }

        /// <summary>
        /// Gets or sets the total number of top artists for the month.
        /// </summary>
        public required int Total { get; set; }

        /// <summary>
        /// Gets or sets a list of each artist.
        /// </summary>
        public required List<PlaylistViewModel> Items { get; set; }
    }
}
