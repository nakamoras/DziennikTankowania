using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using DziennikTanowania.Models;
using DziennikTanowania.ViewModels;

namespace DziennikTanowania.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LogDetail : ContentPage
    {
        public LogDetail(int FuelLogID)
        {
            InitializeComponent();
            this.BindingContext = new DetailsFuelingLogViewModel(Navigation, FuelLogID);
        }

        
    }
}