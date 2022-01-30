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
        private string Sub_id { get; set; }
        public ObservableCollection<CatBreeds> ListOfCats { get; set; }
        private ICatsApi apiresponse { get; set; }
        private IVoteApi Voteapiresponse { get; set; }
        public ICommand TabCommand { get; set; }
        public ICommand FavoriteCommand { get; set; }
        public ICommand ThumbsUpCommand { get; set; }
        public ICommand ThumbsDownCommand { get; set; }
        #endregion

        #region Ctors
        public ListofCatsViewMode()
        {
            Sub_id = "AlbertLopez";
            string BaseUrl = "https://api.thecatapi.com";
            apiresponse = RestService.For<ICatsApi>(BaseUrl);
            Voteapiresponse = RestService.For<IVoteApi>(BaseUrl);
            LoadCats();
            TabCommand = new Command<string>(ClickCommand);
            FavoriteCommand = new Command<CatBreeds>(ClickFavoriteCommand);
            ThumbsUpCommand = new Command<CatBreeds>(ThumbsUpVote);
            ThumbsDownCommand = new Command<CatBreeds>(ThumbsDownVote);
        }

        #endregion

        #region Metodos
        private void ThumbsDownVote(CatBreeds obj)
        {
            vote(obj, 0);
        }
        private void ThumbsUpVote(CatBreeds obj)
        {
            vote(obj, 1);
        }

        private async void vote(CatBreeds obj, int value)
        {
            if (IsBusy)
                return;
            IsBusy = true;
            try
            {
                Response response = JsonConvert.DeserializeObject<Response>(await Voteapiresponse.CreateAvote(new CreateVote { image_id = obj.image.id, value = value, sub_id = Sub_id }));
                if (response.message == "SUCCESS")
                {
                    obj.IsThumbsEnable = false;
                    Acr.UserDialogs.UserDialogs.Instance.Alert("Vote Sent!", "Atention!", "Ok");
                }
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
                        obj.FavoriteImage = ImageSource.FromFile("AddFavorite.png");
                        obj.Favorite = false;
                    }
                }
                else
                {
                    Response response = JsonConvert.DeserializeObject<Response>(await apiresponse.PostFavorite(JsonConvert.SerializeObject(new Favourite { image_id = obj.image.id, sub_id = Sub_id })));
                    if (response.message == "SUCCESS")
                    {
                        obj.IDFavorite = response.id;
                        obj.FavoriteImage = ImageSource.FromFile("RemoveFavorite.png");
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
