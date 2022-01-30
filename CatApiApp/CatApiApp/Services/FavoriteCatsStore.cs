using CatApiApp.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CatApiApp.Services
{
    public class FavoriteCatsStore : IDataStore<FavoriteCats>, IDeleteStore
    {
        /// <summary>
        /// This method delete a cat from the list of favorite.
        /// </summary>
        /// <param name="Favorite_id">The id of the favorite cat.</param>
        /// <returns></returns>
        public async Task<Response> Delete(string Favorite_id)
        {
            try
            {
                System.Threading.CancellationTokenSource cancellationToken = new System.Threading.CancellationTokenSource(new TimeSpan(0, 5, 0));

                string url = $"v1/favourites/{Favorite_id}";
                using (HttpResponseMessage respose = await ApiHelper.ApiClient.DeleteAsync(url, cancellationToken.Token))
                {
                    if (respose.IsSuccessStatusCode)
                    {
                        Response cats = await respose.Content.ReadAsAsync<Response>();
                        return cats;
                    }
                    else
                    {
                        if (respose.StatusCode == System.Net.HttpStatusCode.NotFound)
                        {
                            await Application.Current.MainPage.DisplayAlert("Atención!", "Servidor no encontrado", "Ok");
                        }
                        else
                            await Application.Current.MainPage.DisplayAlert("Atención!", respose.ReasonPhrase, "Ok");

                        return new Response();
                    }
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Atención!", ex.Message, "Ok");
                return new Response();

            }
        }

        /// <summary>
        /// This methods return a list of cats.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<FavoriteCats>> GetItemsAsync()
        {
            try
            {
                System.Threading.CancellationTokenSource cancellationToken = new System.Threading.CancellationTokenSource(new TimeSpan(0, 5, 0));

                string url = $"v1/favourites";
                using (HttpResponseMessage respose = await ApiHelper.ApiClient.GetAsync(url, cancellationToken.Token))
                {
                    if (respose.IsSuccessStatusCode)
                    {
                        List<FavoriteCats> cats = await respose.Content.ReadAsAsync<List<FavoriteCats>>();
                        return cats;
                    }
                    else
                    {
                        if (respose.StatusCode == System.Net.HttpStatusCode.NotFound)
                        {
                            await Application.Current.MainPage.DisplayAlert("Atención!", "Servidor no encontrado", "Ok");
                        }
                        else
                            await Application.Current.MainPage.DisplayAlert("Atención!", respose.ReasonPhrase, "Ok");

                        return new List<FavoriteCats>();
                    }
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Atención!", ex.Message, "Ok");
                return new List<FavoriteCats>();

            }
        }



    }
}
