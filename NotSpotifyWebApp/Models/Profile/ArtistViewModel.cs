/*==============================================================================
 *
 * Description - The model for viewing a single artist.
 *
 * Copyright © Dami Sam Akiode, 2025
 *
 * Personal Project - Not Spotify (ArtistViewModel.cs)
 *
 *============================================================================*/

using System.Diagnostics.CodeAnalysis;
using SpotifyAPI.Web;

namespace NotSpotifyWebApp.Models
{
    /// <summary>
    /// Holds the definition for the <see cref="ArtistViewModel"/> class.
    /// </summary>
    public class ArtistViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ArtistViewModel"/> class.
        /// </summary>
        /// <param name="artist">The artist to view.</param>
        [SetsRequiredMembers]
        public ArtistViewModel(FullArtist artist)
        {
            Href = artist.Href;
            Id = artist.Id;
            Uri = artist.Uri;
            Name = artist.Name;
            Image = artist.Images[0].Url;
            Type = artist.Type;
            Followers = artist.Followers;

            Type = $"{Type[0].ToString().ToUpper()}{Type.Substring(1)}";
        }

        /// <summary>
        /// Gets or sets the Href.
        /// </summary>
        public required string Href { get; set; }

        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        public required string Id { get; set; }

        /// <summary>
        /// Gets or sets the Uri.
        /// </summary>
        public required string Uri { get; set; }

        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Gets or sets the Images.
        /// </summary>
        public required string Image { get; set; }

        /// <summary>
        /// Gets or sets the Type.
        /// </summary>
        public required string Type { get; set; }

        /// <summary>
        /// Gets or sets the Followers.
        /// </summary>
        public required Followers Followers { get; set; }

        /// <summary>
        /// Converts from a list of <see cref="FullArtist"/> to a list of <see cref="ArtistViewModel"/>.
        /// </summary>
        /// <param name="artists">List of artists.</param>
        /// <returns>List of artist view models.</returns>
        public static List<ArtistViewModel> ToViewModels(List<FullArtist> artists)
        {
            List<ArtistViewModel> viewModels = new List<ArtistViewModel>();

            foreach (FullArtist artist in artists)
            {
                viewModels.Add(new ArtistViewModel(artist));
            }

            return viewModels;
        }
    }
}
