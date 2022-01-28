using CatApiApp.Models;
using CatApiApp.Services;
using Refit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using System.Linq;
using Newtonsoft.Json;

namespace CatApiApp.ViewModels
{
    public class ListofCatsViewMode : NotificationObject
    {
        #region Propiedades
        public ObservableCollection<CatBreeds> ListOfCats { get; set; }
        public ICatsApi apiresponse { get; set; }
        public ICommand TabCommand { get; set; }
        public ICommand FavoriteCommand { get; set; }
        #endregion

        #region Ctors
        public ListofCatsViewMode()
        {
            apiresponse = RestService.For<ICatsApi>("https://api.thecatapi.com");
            LoadCats();
            TabCommand = new Command<string>(ClickCommand);
            FavoriteCommand = new Command<CatBreeds>(ClickFavoriteCommand);
        }


        #endregion

        #region Metodos

        private async void ClickFavoriteCommand(CatBreeds obj)
        {
            if (IsBusy)
                return;
            IsBusy = true;

            try
            {
                if (obj.Favorite)
                {
                    var res = await apiresponse.DeleteFavorite(obj.IDFavorite);
                    if (res.message == "SUCCESS")
                    {
                        obj.FavoriteImage = ImageSource.FromResource("CatApiApp.Images.AddFavorite.png");
                        obj.Favorite = false;
                    }
                }
                else
                {
                    var res = await apiresponse.PostFavorite(JsonConvert.SerializeObject(new Favourite { image_id = obj.image.id, sub_id = "your-user-123456" }));

                    Response response = JsonConvert.DeserializeObject<Response>(res);
                    if (response.message == "SUCCESS")
                    {
                        obj.IDFavorite = response.id;
                        obj.FavoriteImage = ImageSource.FromResource("CatApiApp.Images.RemoveFavorite.png");
                        obj.Favorite = true;
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("400"))
                {
                    Acr.UserDialogs.UserDialogs.Instance.Alert("Can't duplicate favorite cats.", "Atencion!", "Ok");
                }
                else
                    Acr.UserDialogs.UserDialogs.Instance.Alert(ex.Message, "Error!", "Ok");
            }
            finally
            {
                IsBusy = false;
            }
        }
        private async void ClickCommand(string url)
        {
            if (IsBusy)
                return;
            IsBusy = true;

            try
            {
                await Launcher.OpenAsync(url);
            }
            catch (Exception ex)
            {
                Acr.UserDialogs.UserDialogs.Instance.Alert(ex.Message, "Error!", "Ok");
            }
            finally
            {
                IsBusy = false;
            }
        }
        private async void LoadCats()
        {
            try
            {
                using (Acr.UserDialogs.UserDialogs.Instance.Loading("Searching..."))
                {
                    ListOfCats = new ObservableCollection<CatBreeds>(await apiresponse.GetListofCatBreeds(100));
                }
            }
            catch (Exception ex)
            {
                Acr.UserDialogs.UserDialogs.Instance.Alert(ex.Message, "Error!", "Ok");
            }
        }
        #endregion
    }
}
