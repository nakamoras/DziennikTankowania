using DziennikTanowania.Models;
using DziennikTanowania.Services;
using DziennikTanowania.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using DziennikTanowania.Views;

namespace DziennikTanowania.ViewModels
{
    public class FuelingLogListViewModel : BaseFuelingLogViewModel
    {
        
        

        public FuelingLogListViewModel(INavigation navigation)
        {
            _navigation = navigation;
            _fuelingLog = new FuelingLog();
            _fuelingLogRepository = new FuelingLogRepository();
            FetchLogs();
            
        }

        void FetchLogs()
        {
            FuelingLogList = _fuelingLogRepository.GetAllDataSortedByMiles();
            _fuelingLogRepository.FetchDistanceFromLastRefueling(FuelingLogList);
            FuelingLogList = _fuelingLogRepository.GetAllDataSortedByMiles();
            _fuelingLogRepository.FetchMilesPerLiter(FuelingLogList);
            FuelingLogList = _fuelingLogRepository.GetAllDataSortedByMiles();
        }

        async void ShowLogDetails(int selectedLogID)
        {
            await _navigation.PushAsync(new LogDetail(selectedLogID));
        }

        





        FuelingLog _selectedLog;
        public FuelingLog SelectedFuelingLog
        {
            get => _selectedLog;
            set
            {
                if(value != null)
                {
                    _selectedLog = value;
                    OnPropertyChanged("SelectedFuelingLog");
                    ShowLogDetails(value.Id);
                }
            }
        }

        


    }
}
