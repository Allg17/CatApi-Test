using CatApiApp.Models;
using CatApiApp.Services;
using Refit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CatApiApp.ViewModels
{
    public class PublicImagesViewModel : NotificationObject
    {
        #region Propertys
        public ObservableCollection<Models.Image> ListOfImages { get; set; }
        public ObservableCollection<Category> Categories { get; set; }
        public Category SelectedCategory { get; set; }
        private CategoryStore CategoryService { get; set; }
        private IimageApi Imageapiresponse { get; set; }
        public ICommand GetImagesCommand { get; set; }

        #endregion


        #region Ctors
        public PublicImagesViewModel()
        {
            string BaseUrl = "https://api.thecatapi.com";
            Imageapiresponse = RestService.For<IimageApi>(BaseUrl);
            CategoryService = new CategoryStore();
            Categories = new ObservableCollection<Category>();
            GetImagesCommand = new Command(Refresh);
            GetCategories();
        }
        #endregion

        #region Methods

        private async void GetCategories()
        {
            try
            {
                using (Acr.UserDialogs.UserDialogs.Instance.Loading("Loading..."))
                {
                    foreach (var item in await CategoryService.GetItemsAsync())
                    {
                        Categories.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                Acr.UserDialogs.UserDialogs.Instance.Alert(ex.Message, "Error!", "Ok");
            }
        }
        private async void Refresh(object obj)
        {
            if (IsBusy)
                return;
            IsBusy = true;
            try
            {
                if (SelectedCategory == null)
                {
                    Acr.UserDialogs.UserDialogs.Instance.Alert("You Must select a category first.", "Atention!", "Ok");
                    return;
                }

                using (Acr.UserDialogs.UserDialogs.Instance.Loading("Searching..."))
                    ListOfImages = new ObservableCollection<Models.Image>(await Imageapiresponse.GetAllPublicImage(SelectedCategory.id));
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
        #endregion
    }
}
