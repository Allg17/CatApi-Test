using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CatApiApp.Services.Utils
{
    public interface IGet<T>
    {
        Task<IEnumerable<T>> GetItemsAsync();
    }
}
