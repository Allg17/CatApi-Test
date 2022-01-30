using CatApiApp.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CatApiApp.Services
{
    public interface IimageApi
    {
        /// <summary>
        /// This endpoint bring the image of a specify Image_id
        /// </summary>
        /// <param name="Image_id">id of the image</param>
        /// <returns></returns>
        [Get("/v1/images/{Image_id}")]
        Task<Image> GetImage(string Image_id);
    }
}
