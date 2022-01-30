using CatApiApp.Models;
using CatApiApp.ViewModels;
using CatApiApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CatApiApp
{
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public MainPage()
        {
            InitializeComponent();
            MasterBehavior = MasterBehavior.Popover;
            MenuPages.Add((int)MenuItemType.Home, (NavigationPage)Detail);
        }

        public async Task NavigateFromMenu(int id)
        {
            try
            {
                if (!MenuPages.ContainsKey(id))
                {
                    switch (id)
                    {
                        case (int)MenuItemType.Home:
                            MenuPages.Add(id, new NavigationPage(new HomePage()));
                            break;
                        case (int)MenuItemType.ListCats:
                            MenuPages.Add(id, new NavigationPage(new ListofCatsPage()));
                            break;
                        case (int)MenuItemType.FavoriteCats:
                            MenuPages.Add(id, new NavigationPage(new ListOfFavoriteCatsBreedsPage()));
                            break;
                        case (int)MenuItemType.VoteCats:
                            MenuPages.Add(id, new NavigationPage(new ListVotePage()));
                            break;

                    }
                }

                var newPage = MenuPages[id];

                if (newPage != null && Detail != newPage)
                {
                    Detail = newPage;
                    IsPresented = false;
                }
            }
            catch (Exception ex)
            {
                Acr.UserDialogs.UserDialogs.Instance.Alert(ex.Message, "Error!", "Ok");
            }
        }
    }
}
