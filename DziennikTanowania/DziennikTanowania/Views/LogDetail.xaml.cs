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

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int seletedIndex = picker.SelectedIndex;

            if (seletedIndex == 2)
            {
                DisplayAlert("Pomoc", "REZERWA\r\n\nOpcję należy wybrać jeśli osiągniemy rezerwe paliwa, w tym momencie program obliczy czastkowe spalanie.\r\n\nDOTANKOWANIE\r\n\nNależy wybrać gdy dotankowaliśmy przed osiagnieciem rezerwy wynik zostanie dodany do nastepnego tankowania w którym osiągniemy rezerwe.", "OK");
                picker.SelectedItem = picker.ItemsSource[0];
            }
            
        }


    }
}