using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using DziennikTanowania.Validator;
using DziennikTanowania.Models;
using DziennikTanowania.Services;
using System.Threading.Tasks;
using DziennikTanowania.Views;

namespace DziennikTanowania.ViewModels
{
    public class AddLogViewModel : BaseFuelingLogViewModel
    {
        public ICommand AddLogCommand { get; private set; }

        public AddLogViewModel(INavigation navigation)
        {
            _navigation = navigation;
            _fuelingLogValidator = new FuelingLogValidator();
            _fuelingLog = new FuelingLog();
            _fuelingLogRepository = new FuelingLogRepository();

            AddLogCommand = new Command(async () => await AddFuelingLog());

        }

        async Task AddFuelingLog()
        {
            var validationResults = _fuelingLogValidator.Validate(_fuelingLog);

            if (validationResults.IsValid)
            {
                _fuelingLogRepository.InsertFuelingLog(_fuelingLog);
                await _navigation.PopAsync();
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Tankowanie", validationResults.Errors[0].ErrorMessage, "Ok");
            }

        }
    }
}
