/*==============================================================================
 *
 * Description - Defines the configuration for user authentication with Spotify.
 *
 * Copyright © Dami Sam Akiode, 2025
 *
 * Personal Project - Not Spotify (SpotifyConfig.cs)
 *
 *============================================================================*/

namespace NotSpotifyClassLibrary
{
    /// <summary>
    /// Holds the definnition for the <see cref="SpotifyConfig"/> class.
    /// </summary>
    public class SpotifyConfig
    {
        /// <summary>
        /// Gets or sets the Client Id.
        /// </summary>
        public required string ClientId { get; set; }

        /// <summary>
        /// Gets or sets the Client Secret.
        /// </summary>
        public required string ClientSecret { get; set; }

        /// <summary>
        /// Gets or sets the Redirect URI.
        /// </summary>
        public required string RedirectUri { get; set; }
    }
}
