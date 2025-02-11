/*==============================================================================
 *
 * Description - Controlls the views and actions regarding user authentication.
 *
 * Copyright © Dami Sam Akiode, 2025
 *
 * Personal Project - Not Spotify (AuthController.cs)
 *
 *============================================================================*/

using Microsoft.AspNetCore.Mvc;
using NotSpotifyWebApp.Services;

namespace NotSpotifyWebApp.Controllers
{
    /// <summary>
    /// Holds the definition for the <see cref="AuthController"/> class.
    /// </summary>
    public class AuthController : Controller
    {
        private readonly SpotifyAuthService _AuthService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthController"/> class.
        /// </summary>
        /// <param name="authService">The service to use to authenticate the user.</param>
        public AuthController(SpotifyAuthService authService)
        {
            _AuthService = authService;
        }

        /// <summary>
        /// Logs in the user, by redirecting them to the spotify portal.
        /// </summary>
        /// <returns>A redirect to spotify's login portal.</returns>
        public IActionResult Login()
        {
            string authUrl = _AuthService.GetAuthorizationUrl();
            return Redirect(authUrl);
        }

        /// <summary>
        /// The redirection url, gets the logged in user's access token.
        /// </summary>
        /// <param name="code">The callback view with the user's access token.</param>
        /// <returns>A Callback screen.</returns>
        [Route("auth/callback")]
        public async Task<IActionResult> CallbackAsync(string code)
        {
            if (string.IsNullOrEmpty(code))
            {
                return BadRequest("Authorization code is missing!");
            }

            var spotify = await _AuthService.GetSpotifyClientAsync(code);
            var user = await spotify.UserProfile.Current();

            HttpContext.Session.SetString("AccessToken", _AuthService.GetAccessToken());

            // return Content($"Welcome, {user.DisplayName}!");
            return RedirectToAction("index", "user");
        }
    }
}
