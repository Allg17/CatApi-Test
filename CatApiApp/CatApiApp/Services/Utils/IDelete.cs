using CatApiApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CatApiApp.Services.Utils
{
    public interface IDelete<T>
    {
        Task<Response> DeleteItemAsync(string id);
    }
}
