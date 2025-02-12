/*==============================================================================
 *
 * Description - Holds the base controller that all others will inherit from.
 *
 * Copyright © Dami Sam Akiode, 2025
 *
 * Personal Project - Not Spotify (BaseController.cs)
 *
 *============================================================================*/

using Microsoft.AspNetCore.Mvc;
using NotSpotifyWebApp.Models;
using NotSpotifyWebApp.Services;
using SpotifyAPI.Web;

namespace NotSpotifyWebApp.Controllers
{
    /// <summary>
    /// Holds the definition for the <see cref="BaseController"/> class.
    /// Inherits from the detauls <see cref="Controller"/> class.
    /// Abstract, as all other controllers will inherit from this.
    /// </summary>
    public abstract class BaseController : Controller
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseController"/> class.
        /// </summary>
        /// <param name="spotifyAuthService">The authentication service.</param>
        public BaseController(SpotifyAuthService spotifyAuthService)
        {
            SpotifyAuthService = spotifyAuthService;
        }

        /// <summary>
        /// Gets or initializes authentication service for the spotify client.
        /// </summary>
        protected SpotifyAuthService SpotifyAuthService { get; init; }

        /// <summary>
        /// Returns a paged list of type <typeparamref name="T"/> to a list of the same type.
        /// </summary>
        /// <typeparam name="T">A generic type.</typeparam>
        /// <param name="pagedList">The paged list to convert.</param>
        /// <returns>The returned list.</returns>
        protected static List<T> PagingToList<T>(Paging<T> pagedList)
        {
            List<T> list = new List<T>();

            if (pagedList.Items != null && pagedList.Items.Any())
            {
                foreach (T item in pagedList.Items)
                {
                    list.Add(item);
                }
            }

            return list;
        }
    }
}
