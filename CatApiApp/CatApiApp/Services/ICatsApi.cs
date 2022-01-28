using CatApiApp.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CatApiApp.Services
{
    [Headers("Content-Type: application/json","x-api-key: 42030dee-dc15-4010-a931-b9aaf28fbd09")]
    public interface ICatsApi
    {
        /// <summary>
        /// Return a list of cats breeds
        /// </summary>
        /// <param name="limit"> the number of row that you want to bring</param>
        /// <returns> a list of CatBreeds </returns>
        [Get("/v1/breeds?limit={limit}")]
        Task<List<CatBreeds>> GetListofCatBreeds(int limit);

        /// <summary>
        /// Send the favorite cat
        /// </summary>
        /// <param name="favourite"> A Serialize string with the info of the favorite cat.</param>
        /// <returns> A string response witha message and the id of the favorite cat.</returns>
        [Post("/v1/favourites")]
        Task<string> PostFavorite([Body] string favourite);

        /// <summary>
        /// Delete the favorite cat previously added.
        /// </summary>
        /// <param name="favourite_id"> the id of the favorite cat added.</param>
        /// <returns> A response </returns>
        [Delete("/v1/favourites/{favourite_id}")]
        Task<Response> DeleteFavorite(string favourite_id);
    }
}
