/*==============================================================================
 *
 * Description - Handles the communication betwen Javascript and MVC.
 *
 * Copyright © Dami Sam Akiode, 2025
 *
 * Personal Project - Not Spotify (ApiController.cs)
 *
 *============================================================================*/

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotSpotifyWebApp.Services;

namespace NotSpotifyWebApp.Controllers
{
    /// <summary>
    /// Holds the definition for the <see cref="ApiController"/> class.
    /// </summary>
    [Route("api")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private SpotifyAuthService _SpotifyAuthService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiController"/> class.
        /// </summary>
        /// <param name="spotifyAuthService">The spotify authentication service.</param>
        public ApiController(SpotifyAuthService spotifyAuthService)
        {
            _SpotifyAuthService = spotifyAuthService;
        }

        /// <summary>
        /// Gets the access token.
        /// </summary>
        /// <returns>A 200 (OK) with the access token.</returns>
        [HttpGet("token")]
        public IActionResult GetAccessToken()
        {
            string accessToken = _SpotifyAuthService.GetAccessToken();
            return Ok(new { token = accessToken });
        }
    }
}
