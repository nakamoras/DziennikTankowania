using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using DziennikTanowania.Models;
using DziennikTanowania.ViewModels;

namespace DziennikTanowania.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddLog : ContentPage
    {
        public AddLog()
        {
            InitializeComponent();
            BindingContext = new AddLogViewModel(Navigation);
        }
    }
}