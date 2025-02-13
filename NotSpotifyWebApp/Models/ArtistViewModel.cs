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

            Verified = artist.Followers.Total >= 50000;

            PopularityStars = artist.Popularity / 10;
            PopularityHasHalfStar = artist.Popularity % 10 >= 5;

            Type = $"{Type[0].ToString().ToUpper()}{Type[1..]}";
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArtistViewModel"/> class.
        /// </summary>
        /// <param name="artist">The artist to view.</param>
        /// <param name="topTracks">Their top tracks.</param>
        /// <param name="discographyFull">Their full discography.</param>
        /// <param name="discographyAlbums">Their discography of only albums.</param>
        /// <param name="discographySingles">Their disccography of only singles.</param>
        [SetsRequiredMembers]
        public ArtistViewModel(
            FullArtist artist,
            ArtistsTopTracksResponse topTracks,
            List<SimpleAlbum> discographyFull,
            List<SimpleAlbum> discographyAlbums,
            List<SimpleAlbum> discographySingles)
            : this(artist)
        {
            TopTracks = new TrackListViewModel(topTracks);

            DiscographyFull = new AlbumListViewModel(discographyFull);
            DiscographyAlbums = new AlbumListViewModel(discographyAlbums);
            DiscographySingles = new AlbumListViewModel(discographySingles);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArtistViewModel"/> class.
        /// </summary>
        /// <param name="artist">The artist to view.</param>
        /// <param name="topTracks">Their top tracks.</param>
        /// <param name="discography">Their full discography.</param>
        /// <param name="discographyAlbums">Their discography of only albums.</param>
        /// <param name="discographySingles">Their disccography of only singles.</param>
        [SetsRequiredMembers]
        public ArtistViewModel(
            FullArtist artist,
            ArtistsTopTracksResponse topTracks,
            List<SimpleAlbum> discography)
            : this(artist)
        {
            TopTracks = new TrackListViewModel(topTracks);
            DiscographyFull = new AlbumListViewModel(discography);
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
        /// Gets or sets a value indicating whether the artist is verified.
        /// </summary>
        public bool Verified { get; set; }

        /// <summary>
        /// Gets or sets the Popularity.
        /// </summary>
        public required int PopularityStars { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether a half star should be drawn for the popularity.
        /// </summary>
        public required bool PopularityHasHalfStar { get; set; }

        /// <summary>
        /// Gets or sets the top tracks.
        /// </summary>
        public TrackListViewModel? TopTracks { get; set; }

        /// <summary>
        /// Gets or sets the full discography.
        /// </summary>
        public AlbumListViewModel? DiscographyFull { get; set; }

        /// <summary>
        /// Gets or sets the albums in the discography.
        /// </summary>
        public AlbumListViewModel? DiscographyAlbums { get; set; }

        /// <summary>
        /// Gets or sets the singles in the discography.
        /// </summary>
        public AlbumListViewModel? DiscographySingles { get; set; }

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
