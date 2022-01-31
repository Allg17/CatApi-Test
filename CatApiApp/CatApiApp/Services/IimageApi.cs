using CatApiApp.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CatApiApp.Services
{
    [Headers("Content-Type: application/json", "x-api-key: 42030dee-dc15-4010-a931-b9aaf28fbd09")]
    public interface IimageApi
    {
        /// <summary>
        /// This endpoint bring the image of a specify Image_id
        /// </summary>
        /// <param name="Image_id">id of the image</param>
        /// <returns></returns>
        [Get("/v1/images/{Image_id}")]
        Task<Image> GetImage(string Image_id);

        /// <summary>
        /// This endpoint bring the All the public Images
        /// </summary>
        /// <param name="category_ids">id of the Category of the image</param>
        /// <returns></returns>
        [Get("/v1/images/search")]
        Task<List<Image>> GetAllPublicImage(string category_ids);
    }
}
