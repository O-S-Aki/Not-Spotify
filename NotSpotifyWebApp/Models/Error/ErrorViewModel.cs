/*==============================================================================
 *
 * Description - The model for viewing an exception.
 *
 * Copyright © Dami Sam Akiode, 2025
 *
 * Personal Project - Not Spotify (ErrorViewModel.cs)
 *
 *============================================================================*/

namespace NotSpotifyWebApp.Models
{
    /// <summary>
    /// Holds the definition for the <see cref="ErrorViewModel"/> class.
    /// </summary>
    public class ErrorViewModel
    {
        /// <summary>
        /// Gets or sets the Request Id.
        /// </summary>
        public string? RequestId { get; set; }

        /// <summary>
        /// Gets a value indicating whether the Request Id should be shown.
        /// </summary>
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
