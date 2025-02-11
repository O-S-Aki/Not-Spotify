/*==============================================================================
 *
 * Description - The model for viewing a single playlist.
 *
 * Copyright © Dami Sam Akiode, 2025
 *
 * Personal Project - Not Spotify (PlaylistViewModel.cs)
 *
 *============================================================================*/

using System.Diagnostics.CodeAnalysis;
using SpotifyAPI.Web;

namespace NotSpotifyWebApp.Models
{
    /// <summary>
    /// Holds the definition for the <see cref="PlaylistViewModel"/> class.
    /// </summary>
    public class PlaylistViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlaylistViewModel"/> class.
        /// </summary>
        /// <param name="playlist">The playlist to view.</param>
        [SetsRequiredMembers]
        public PlaylistViewModel(FullPlaylist playlist)
        {
            Id = playlist.Id ?? string.Empty;
            Href = playlist.Href ?? string.Empty;
            Uri = playlist.Uri ?? string.Empty;
            Name = playlist.Name ?? string.Empty;
            Image = playlist.Images![0].Url;
            Owner = playlist.Owner!;
        }

        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        public required string Id { get; set; }

        /// <summary>
        /// Gets or sets the Href.
        /// </summary>
        public required string Href { get; set; }

        /// <summary>
        /// Gets or sets the Uri.
        /// </summary>
        public required string Uri { get; set; }

        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Gets or sets the Image.
        /// </summary>
        public required string Image { get; set; }

        /// <summary>
        /// Gets or sets the Owner.
        /// </summary>
        public required PublicUser Owner { get; set; }

        /// <summary>
        /// Converts a list of <see cref="FullPlaylist"/> to a list of <see cref="PlaylistViewModel"/>.
        /// </summary>
        /// <param name="playlists">List of playlists.</param>
        /// <returns>List of playlists view models.</returns>
        public static List<PlaylistViewModel> ToViewModels(List<FullPlaylist> playlists)
        {
            List<PlaylistViewModel> viewModels = new List<PlaylistViewModel>();

            foreach (FullPlaylist playlist in playlists)
            {
                viewModels.Add(new PlaylistViewModel(playlist));
            }

            return viewModels;
        }
    }
}
