using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using DziennikTanowania.Models;
using DziennikTanowania.Views;
using DziennikTanowania.ViewModels;
using System.Collections.ObjectModel;

namespace DziennikTanowania.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LogList : ContentPage
    {
        public LogList()
        {
            InitializeComponent();
           
        }

        protected override void OnAppearing()
        {
            this.BindingContext = new FuelingLogListViewModel(Navigation);
        }

        async void DodajButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddLog());
        }

        
        


    }
}