/*==============================================================================
 *
 * Description - The model for viewing a single track.
 *
 * Copyright © Dami Sam Akiode, 2025
 *
 * Personal Project - Not Spotify (TrackViewModel.cs)
 *
 *============================================================================*/

using System.Diagnostics.CodeAnalysis;
using SpotifyAPI.Web;

namespace NotSpotifyWebApp.Models
{
    /// <summary>
    /// Holds the definition for the <see cref="TrackViewModel"/> class.
    /// </summary>
    public class TrackViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TrackViewModel"/> class.
        /// </summary>
        /// <param name="track">The track to view.</param>
        [SetsRequiredMembers]
        public TrackViewModel(FullTrack track)
        {
            Id = track.Id;
            Href = track.Href;
            Uri = track.Uri;
            Name = track.Name;
            Album = track.Album;
            Artists = track.Artists;
            DurationMs = track.DurationMs;
            Explicit = track.Explicit;
            TrackNumber = track.TrackNumber;
            Type = track.Type;

            DurationFormatted = TimeSpan.FromMilliseconds(DurationMs).ToString(@"mm\:ss");
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
        /// Gets or sets the Album that the track belongs to.
        /// </summary>
        public required SimpleAlbum Album { get; set; }

        /// <summary>
        /// Gets or sets the artists on the song.
        /// </summary>
        public required List<SimpleArtist> Artists { get; set; }

        /// <summary>
        /// Gets or sets the duratino in milliseconds.
        /// </summary>
        public required int DurationMs { get; set; }

        /// <summary>
        /// Gets or sets the formatted duration in mm:ss.
        /// </summary>
        public required string DurationFormatted { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the track is explicit.
        /// </summary>
        public required bool Explicit { get; set; }

        /// <summary>
        /// Gets or sets the track number.
        /// </summary>
        public required int TrackNumber { get; set; }

        /// <summary>
        /// Gets or sets the Type.
        /// (Track, Episode, or Chapter).
        /// </summary>
        public required ItemType Type { get; set; }

        /// <summary>
        /// Converts a list of <see cref="FullTrack"/> to a list of <see cref="TrackViewModel"/>.
        /// </summary>
        /// <param name="tracks">A list of track objects.</param>
        /// <returns>A list of Track View Models.</returns>
        public static List<TrackViewModel> ToViewModels(List<FullTrack> tracks)
        {
            List<TrackViewModel> viewModels = new List<TrackViewModel>();

            foreach (FullTrack track in tracks)
            {
                viewModels.Add(new TrackViewModel(track));
            }

            return viewModels;
        }
    }
}
