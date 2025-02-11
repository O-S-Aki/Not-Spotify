/*==============================================================================
 *
 * Description - The model for viewing a single album.
 *
 * Copyright © Dami Sam Akiode, 2025
 *
 * Personal Project - Not Spotify (AlbumViewModel.cs)
 *
 *============================================================================*/

using System.Diagnostics.CodeAnalysis;
using SpotifyAPI.Web;

namespace NotSpotifyWebApp.Models
{
    /// <summary>
    /// Holds the definition for the <see cref="AlbumViewModel"/> class.
    /// </summary>
    public class AlbumViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AlbumViewModel"/> class.
        /// </summary>
        /// <param name="album">The album to view.</param>
        [SetsRequiredMembers]
        public AlbumViewModel(SimpleAlbum album)
        {
            Id = album.Id;
            Href = album.Href;
            Uri = album.Uri;
            Name = album.Name;
            AlbumType = album.AlbumType;
            Image = album.Images[0].Url;
            Artists = album.Artists;
            TotalTracks = album.TotalTracks;

            DateTime albumReleaseDate = DateTime.Parse(album.ReleaseDate);
            ReleaseDate = albumReleaseDate.ToString("yyyy");
        }

        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        public required string Id { get; set; }

        /// <summary>
        /// Gets or sets the Href link.
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
        /// Gets or sets the Album Type.
        /// </summary>
        public required string AlbumType { get; set; }

        /// <summary>
        /// Gets or sets the Artists.
        /// </summary>
        public required List<SimpleArtist> Artists { get; set; }

        /// <summary>
        /// GEts or sets the Image.
        /// </summary>
        public required string Image { get; set; }

        /// <summary>
        /// Gets or sets the Release Date.
        /// </summary>
        public required string ReleaseDate { get; set; }

        /// <summary>
        /// Gets or sets the Total Tracks.
        /// </summary>
        public required int TotalTracks { get; set; }

        /// <summary>
        /// Converts a list of <see cref="SimpleAlbum"/> to a list of <see cref="AlbumViewModel"/>.
        /// </summary>
        /// <param name="albums">The albums to convert.</param>
        /// <returns>A list of album view models.</returns>
        public static List<AlbumViewModel> ToViewModels(List<SimpleAlbum> albums)
        {
            List<AlbumViewModel> viewModels = new List<AlbumViewModel>();

            foreach (var album in albums)
            {
                viewModels.Add(new AlbumViewModel(album));
            }

            return viewModels;
        }
    }
}
