using CatApiApp.Models;
using CatApiApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using System.Linq;
using System.IO;

namespace CatApiApp.ViewModels
{
    public class FavoriteCatsBreedsViewModel : NotificationObject
    {
        #region Propiedades
        public ObservableCollection<FavoriteCats> ListFavoriteCats { get; set; }
        private FavoriteCatsStore _favoriteCatsStore { get; set; }
        public ICommand RemoveFavorite { get; set; }
        public ICommand RefreshCommand { get; set; }
        public bool IsRefreshing { get; set; }
        #endregion


        #region Ctors
        public FavoriteCatsBreedsViewModel()
        {
            _favoriteCatsStore = new FavoriteCatsStore();
            RemoveFavorite = new Command<FavoriteCats>(Remove);
            RefreshCommand = new Command(Refresh);
            FillList();
        }

        #endregion

        #region Metodos
        private async void Refresh()
        {
            if (IsBusy)
                return;
            IsBusy = true;
            try
            {
                ListFavoriteCats.Clear();
                IsRefreshing = true;
                foreach (var item in await _favoriteCatsStore.GetItemsAsync())
                {
                    ListFavoriteCats.Add(item);
                }
            }
            catch (Exception ex)
            {
                Acr.UserDialogs.UserDialogs.Instance.Alert(ex.Message, "Error!", "Ok");
            }
            finally
            {
                IsRefreshing = false;
                IsBusy = false;
            }
        }
        private async void Remove(FavoriteCats obj)
        {
            if (IsBusy)
                return;
            IsBusy = true;
            try
            {
                if (await Acr.UserDialogs.UserDialogs.Instance.ConfirmAsync("Are you sure to remove this?", "Atention", "Yes", "No"))
                {
                    var response = await _favoriteCatsStore.DeleteItemAsync(obj.id);
                    if (response.message == "SUCCESS")
                    {
                        Acr.UserDialogs.UserDialogs.Instance.Alert("Successfully eliminated.", "Atention!", "Ok");
                    }
                }
            }
            catch (Exception ex)
            {
                Acr.UserDialogs.UserDialogs.Instance.Alert(ex.Message, "Error!", "Ok");
            }
            finally
            {
                IsBusy = false;
                Refresh();
            }
        }

        private async void FillList()
        {
            try
            {
                IsRefreshing = true;
                ListFavoriteCats = new ObservableCollection<FavoriteCats>(await _favoriteCatsStore.GetItemsAsync());
            }
            catch (Exception ex)
            {
                Acr.UserDialogs.UserDialogs.Instance.Alert(ex.Message, "Error!", "Ok");
            }
            finally
            {
                IsRefreshing = false;
            }
        }
        #endregion

    }
}
