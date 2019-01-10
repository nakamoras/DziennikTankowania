using DziennikTanowania.ViewModels;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DziennikTanowania.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StatystykiPage : ContentPage
    {
        public StatystykiPage()
        {
            InitializeComponent();
            

        }

        protected override void OnAppearing()
        {
            this.BindingContext = new StatisticsViewModel(Navigation);
        }
    }
}