using CatApiApp.Models;
using CatApiApp.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CatApiApp.ViewModels
{
    public class MenuViewModel : NotificationObject
    {
        #region Propiedades
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        public ObservableCollection<HomeMenuItem> MenuItems { get; set; }
        public ICommand ItemSelectedCommand { get; set; }
        #endregion

        #region Ctors
        public MenuViewModel()
        {
            FillList();
            Comandos();
        }
        #endregion

        #region Metodos
        private void FillList()
        {
            MenuItems = new ObservableCollection<HomeMenuItem>();
            MenuItems.Add(new HomeMenuItem { Id = MenuItemType.Home, Title = "Home", Icon = ImageSource.FromResource("CatApiApp.Images.Home.png") });
            MenuItems.Add(new HomeMenuItem { Id = MenuItemType.ListCats, Title = "Public Cats", Icon = ImageSource.FromResource("CatApiApp.Images.CatsBreeds.png") });
            MenuItems.Add(new HomeMenuItem { Id = MenuItemType.FavoriteCats, Title = "Favorite Cats", Icon = ImageSource.FromResource("CatApiApp.Images.FavCat.png") });
            MenuItems.Add(new HomeMenuItem { Id = MenuItemType.VoteCats, Title = "Vote Cats", Icon = ImageSource.FromResource("CatApiApp.Images.Voteicon.png") });
            MenuItems.Add(new HomeMenuItem { Id = MenuItemType.PublicImages, Title = "Public Images", Icon = ImageSource.FromResource("CatApiApp.Images.CatsBreeds.png") });
        }
        private void Comandos()
        {
            ItemSelectedCommand = new Command<HomeMenuItem>(async (ItemSelected) =>
            {
                if (IsBusy)
                    return;
                IsBusy = true;
                try
                {
                    if (ItemSelected != null)
                    {
                        await RootPage.NavigateFromMenu((int)ItemSelected.Id);
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
            });
        }
        #endregion
    }
}
