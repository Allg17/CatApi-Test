using CatApiApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CatApiApp.Services
{
    public interface IDeleteStore
    {
        Task<Response> Delete(string Favorite_id);
    }
}
