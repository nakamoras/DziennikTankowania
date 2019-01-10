using System;
using System.Windows.Input;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using DziennikTanowania.Validator;
using DziennikTanowania.Models;
using DziennikTanowania.Services;
using DziennikTanowania.Views;
using System.Threading.Tasks;


namespace DziennikTanowania.ViewModels
{
    public class DetailsFuelingLogViewModel : BaseFuelingLogViewModel
    {
        public ICommand DeleteFuelingLogCommand { get; private set; }
        public ICommand UpdateFuelingLogCommand { get; private set; }
        
        

        public DetailsFuelingLogViewModel(INavigation navigation, int selectedFuelingLogID)
        {
            
            _navigation = navigation;
            _fuelingLogValidator = new FuelingLogValidator();
            _fuelingLog = new FuelingLog();
            _fuelingLog.Id = selectedFuelingLogID;
            _fuelingLogRepository = new FuelingLogRepository();
            

            DeleteFuelingLogCommand = new Command(async () => await DeleteLog());
            UpdateFuelingLogCommand = new Command(async () => await UpdateLog());
            

            

            FetchFuelingLogDetails();
        }

        

        void FetchFuelingLogDetails()
        {
            _fuelingLog = _fuelingLogRepository.GetFuelingLogData(_fuelingLog.Id);
        }


        

        async Task UpdateLog()
        {
            var validationResults = _fuelingLogValidator.Validate(_fuelingLog);
            if(validationResults.IsValid)
            {
                _fuelingLogRepository.UpdateFuelingLog(_fuelingLog);
                await _navigation.PopAsync();
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Tankowanie", validationResults.Errors[0].ErrorMessage, "Ok");
            }
        }

        async Task DeleteLog()
        {
            bool isUserAccept = await Application.Current.MainPage.DisplayAlert("Tankowanie", "Usunąć wpis?", "Tak", "Nie");
            if (isUserAccept)
            {
                _fuelingLogRepository.DeleteFuelingLog(_fuelingLog.Id);
                await _navigation.PopAsync();
            }
        }


    }
}
