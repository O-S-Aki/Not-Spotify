/*==============================================================================
 *
 * Description - The authentication service used for the Web Application.
 *
 * Copyright © Dami Sam Akiode, 2025
 *
 * Personal Project - Not Spotify (SpotifyAuthService.cs)
 *
 *============================================================================*/

using Microsoft.Extensions.Options;
using NotSpotifyClassLibrary;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;

namespace NotSpotifyWebApp.Services
{
    /// <summary>
    /// Holds the definition for the <see cref="SpotifyAuthService"/> class.
    /// </summary>
    public class SpotifyAuthService
    {
        private readonly SpotifyConfig _Config;
        private string? _AccessToken;

        /// <summary>
        /// Initializes a new instance of the <see cref="SpotifyAuthService"/> class.
        /// </summary>
        /// <param name="config">The SpotifyConfig object to bind the credentials to.</param>
        public SpotifyAuthService(IOptions<SpotifyConfig> config)
        {
            _Config = config.Value;
        }

        /// <summary>
        /// Gets the URI for Authorisation.
        /// </summary>
        /// <returns>The Authorisation Uri.</returns>
        public string GetAuthorizationUrl()
        {
            var loginRequest = new LoginRequest(
                new Uri(_Config.RedirectUri),
                _Config.ClientId,
                LoginRequest.ResponseType.Code)
            {
                Scope =
                [
                    Scopes.UserReadPrivate,
                    Scopes.PlaylistReadPrivate,
                    Scopes.PlaylistReadCollaborative,
                    Scopes.UserReadEmail,
                    Scopes.UserLibraryRead,
                    Scopes.UserReadPlaybackState,
                    Scopes.UserModifyPlaybackState,
                    Scopes.UserReadCurrentlyPlaying,
                    Scopes.Streaming,
                    Scopes.AppRemoteControl,
                    Scopes.UserTopRead,
                ]
            };

            return loginRequest.ToUri().ToString();
        }

        /// <summary>
        /// Gets the client ro use for making calls to the Spotify client.
        /// </summary>
        /// <param name="code">The returned code from the callback.</param>
        /// <returns>The Spotify Client.</returns>
        public async Task<SpotifyClient> GetSpotifyClientAsync(string code)
        {
            var request = new AuthorizationCodeTokenRequest(
                _Config.ClientId,
                _Config.ClientSecret,
                code,
                new Uri(_Config.RedirectUri));

            var response = await new OAuthClient().RequestToken(request);
            _AccessToken = response.AccessToken;

            return new SpotifyClient(_AccessToken);
        }

        /// <summary>
        /// Gets an authorised user's access token after logging in.
        /// Needed for every call to a spotify endpoint.
        /// </summary>
        /// <returns>The access token.</returns>
        public string GetAccessToken()
        {
            return _AccessToken ?? string.Empty;
        }
    }
}
