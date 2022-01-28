using CatApiApp.Models;
using CatApiApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using System.Linq;

namespace CatApiApp.ViewModels
{
    public class FavoriteCatsBreedsViewModel : NotificationObject
    {
        #region Propiedades
        public ObservableCollection<FavoriteCats> ListFavoriteCats { get; set; }
        private FavoriteCatsStore _favoriteCatsStore { get; set; }
        public ICommand RemoveFavorite { get; set; }
        #endregion


        #region Ctors
        public FavoriteCatsBreedsViewModel()
        {
            _favoriteCatsStore = new FavoriteCatsStore();
            RemoveFavorite = new Command<FavoriteCats>(Remove);
            FillList();
        }


        #endregion

        #region Metodos
        private async void Remove(FavoriteCats obj)
        {
            if (IsBusy)
                return;
            IsBusy = true;
            try
            {
                ListFavoriteCats.Remove(ListFavoriteCats.FirstOrDefault(x => x.id == obj.id));
                var response = await _favoriteCatsStore.DeleteFavoriteCat(obj.image.id);
            }
            catch (Exception ex)
            {
                Acr.UserDialogs.UserDialogs.Instance.Alert(ex.Message, "Error!", "Ok");
            }
            finally
            {
                IsBusy = true;
            }
        }

        private async void FillList()
        {
            try
            {
                ListFavoriteCats = new ObservableCollection<FavoriteCats>(await _favoriteCatsStore.GetItemsAsync());
            }
            catch (Exception ex)
            {
                Acr.UserDialogs.UserDialogs.Instance.Alert(ex.Message, "Error!", "Ok");
            }
        }
        #endregion

    }
}
