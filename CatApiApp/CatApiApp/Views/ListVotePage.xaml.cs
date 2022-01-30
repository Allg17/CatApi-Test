using CatApiApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CatApiApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListVotePage : ContentPage
    {
        public ListVotePage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            ((VotesViewModel)BindingContext).GetVotesCommand.Execute(null);
        }
    }
}