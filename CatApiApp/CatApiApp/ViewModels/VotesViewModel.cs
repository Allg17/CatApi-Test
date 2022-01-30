using CatApiApp.Models;
using CatApiApp.Services;
using Newtonsoft.Json;
using Refit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CatApiApp.ViewModels
{
    public class VotesViewModel : NotificationObject
    {
        #region Propertys
        public ObservableCollection<Vote> ListVotes { get; set; }
        private IVoteApi Voteapiresponse { get; set; }
        private IimageApi Imageapiresponse { get; set; }
        public ICommand GetVotesCommand { get; set; }
        public ICommand DeleteVoteCommand { get; set; }
        private string _Sub_id { get; set; }
        #endregion

        #region Ctors
        public VotesViewModel()
        {

            _Sub_id = "AlbertLopez";
            string BaseUrl = "https://api.thecatapi.com";
            Voteapiresponse = RestService.For<IVoteApi>(BaseUrl);
            Imageapiresponse = RestService.For<IimageApi>(BaseUrl);
            Command();
        }
        #endregion


        #region Methods
        private void Command()
        {
            DeleteVoteCommand = new Command<Vote>(async (a) =>
            {
                if (IsBusy)
                    return;
                IsBusy = true;
                try
                {
                    if (await Acr.UserDialogs.UserDialogs.Instance.ConfirmAsync("Are you sure to delete this?", "Atention!", "Yes", "No"))
                    {
                        using (Acr.UserDialogs.UserDialogs.Instance.Loading("Deleting..."))
                        {
                            var response = await Voteapiresponse.DeleteVote(a.id);
                            if (response.Contains("SUCCESS"))
                            {
                                GetVotesCommand.Execute(null);
                            }
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
                }
            });

            GetVotesCommand = new Command(async () =>
            {
                try
                {
                    using (Acr.UserDialogs.UserDialogs.Instance.Loading("Searching..."))
                    {
                        List<Vote> vs = new List<Vote>();
                        var res = JsonConvert.DeserializeObject<List<Vote>>(await Voteapiresponse.GetOwerVotes(_Sub_id));
                        foreach (Vote item in res)
                        {
                            item.Url = (await Imageapiresponse.GetImage(item.image_id)).url;
                            vs.Add(item);
                        }
                        ListVotes = new ObservableCollection<Vote>(vs);
                    }
                }
                catch (Exception ex)
                {
                    Acr.UserDialogs.UserDialogs.Instance.Alert(ex.Message, "Error!", "Ok");
                }
            });
        }
        #endregion
    }
}
