using CatApiApp.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CatApiApp.Services
{
    [Headers("Content-Type: application/json","x-api-key: 42030dee-dc15-4010-a931-b9aaf28fbd09")]
    public interface ICatsBreedsApi
    {
        /// <summary>
        /// Return a list of cats breeds
        /// </summary>
        /// <param name="limit"> the number of row that you want to bring</param>
        /// <returns> a list of CatBreeds </returns>
        [Get("/v1/breeds?limit={limit}")]
        Task<List<CatBreeds>> GetListofCatBreeds(int limit);
    }
}
