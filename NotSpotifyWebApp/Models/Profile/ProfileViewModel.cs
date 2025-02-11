﻿/*==============================================================================
 *
 * Description - The model for viewing the currently logged in user's profile.
 *
 * Copyright © Dami Sam Akiode, 2025
 *
 * Personal Project - Not Spotify (ProfileViewModel.cs)
 *
 *============================================================================*/

using System.Diagnostics.CodeAnalysis;
using SpotifyAPI.Web;

namespace NotSpotifyWebApp.Models
{
    /// <summary>
    /// Holds the definition for the <see cref="ProfileViewModel"/> class.
    /// </summary>
    public class ProfileViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProfileViewModel"/> class.
        /// </summary>
        /// <param name="user">The currently logged in user.</param>
        /// <param name="artists">The top artists for the month.</param>
        /// <param name="tracks">The top tracks for the month.</param>
        [SetsRequiredMembers]
        public ProfileViewModel(
            PrivateUser user,
            UsersTopArtistsResponse artists,
            UsersTopTracksResponse tracks)
        {
            DisplayName = user.DisplayName;
            Followers = user.Followers;
            Href = user.Href;
            Id = user.Id;
            Image = user.Images[0].Url;
            Uri = user.Uri;
            Type = user.Type;

            TopArtists = new TopArtistsViewModel(artists);
            TopTracks = new TopTracksViewModel(tracks);

            Type = $"{Type[0].ToString().ToUpper()}{Type.Substring(1)}";
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
        /// Gets or sets the Display Name.
        /// </summary>
        public required string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the followers.
        /// </summary>
        public required Followers Followers { get; set; }

        /// <summary>
        /// Gets or sets the display images.
        /// </summary>
        public required string Image { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        public required string Type { get; set; }

        /// <summary>
        /// Gets or sets the top artists.
        /// </summary>
        public required TopArtistsViewModel TopArtists { get; set; }

        /// <summary>
        /// Gets or sets the top tracks.
        /// </summary>
        public required TopTracksViewModel TopTracks { get; set; }
    }
}
