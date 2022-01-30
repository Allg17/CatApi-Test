using CatApiApp.Models;
using CatApiApp.Services.Utils;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CatApiApp.Services
{
    public class CategoryStore : IGet<Category>
    {
        /// <summary>
        /// This methods return a list of Categorys.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Category>> GetItemsAsync()
        {
            try
            {
                System.Threading.CancellationTokenSource cancellationToken = new System.Threading.CancellationTokenSource(new TimeSpan(0, 5, 0));

                string url = $"v1/categories";
                using (HttpResponseMessage respose = await ApiHelper.ApiClient.GetAsync(url, cancellationToken.Token))
                {
                    if (respose.IsSuccessStatusCode)
                    {
                        List<Category> Category = await respose.Content.ReadAsAsync<List<Category>>();
                        return Category;
                    }
                    else
                    {
                        if (respose.StatusCode == System.Net.HttpStatusCode.NotFound)
                        {
                            await Application.Current.MainPage.DisplayAlert("Atención!", "Servidor no encontrado", "Ok");
                        }
                        else
                            await Application.Current.MainPage.DisplayAlert("Atención!", respose.ReasonPhrase, "Ok");

                        return new List<Category>();
                    }
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Atención!", ex.Message, "Ok");
                return new List<Category>();

            }
        }
    }
}
