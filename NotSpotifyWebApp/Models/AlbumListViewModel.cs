/*==============================================================================
 *
 * Description - The model for viewing the an artist's albums.
 *
 * Copyright © Dami Sam Akiode, 2025
 *
 * Personal Project - Not Spotify (AlbumListViewModel.cs)
 *
 *============================================================================*/

using System.Diagnostics.CodeAnalysis;
using SpotifyAPI.Web;

namespace NotSpotifyWebApp.Models
{
    /// <summary>
    /// Holds the definition for the <see cref="AlbumListViewModel"/> class.
    /// </summary>
    public class AlbumListViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AlbumListViewModel"/> class.
        /// </summary>
        /// <param name="albums">The list of albums to view.</param>
        [SetsRequiredMembers]
        public AlbumListViewModel(List<SimpleAlbum> albums)
        {
            Total = albums.Count;
            Items = AlbumViewModel.ToViewModels(albums);
        }

        /// <summary>
        /// Gets or sets the Total.
        /// </summary>
        public required int Total { get; set; }

        /// <summary>
        /// Gets or sets the Items.
        /// </summary>
        public required List<AlbumViewModel> Items { get; set; }
    }
}
