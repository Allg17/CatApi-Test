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
        [Get("/v1/breeds?limit=10")]
        Task<List<CatBreeds>> GetListofCatBreeds();

        [Post("/v1/favourites")]
        Task<string> PostFavorite([Body] string favourite);

        [Delete("/v1/favourites/{favourite_id}")]
        Task<Response> DeleteFavorite(string favourite_id);
    }
}
