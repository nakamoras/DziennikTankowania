using DziennikTanowania.Models;
using DziennikTanowania.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace DziennikTanowania.ViewModels
{
    public class StatisticsViewModel : BaseFuelingLogViewModel
    {
        
        private int _numberOfRefuelings = -1;
        private double _maxLiters = -1;
        private double _minLiters = -1;
        private decimal _cheapestLiter = -1;
        private decimal _mostExpensiveLiter = -1;
        private decimal _totalExpensesOnFuel = -1;
        private double _totalLiters = -1;
        private int _totalDistance = -1;
        private double _distanceForOneLiter = -1;
        private decimal _averageCostOfOneKilometer = -1;
        private double _latestMilesPerLiter = -1;
        private double _totalMilesPerLiter = -1;
        private double _bestPartialMilesPerLiter = -1;
        private double _worstPartialMilesPerLiter = -1;
        

        public StatisticsViewModel(INavigation navigation)
        {
            _navigation = navigation;
            _fuelingLog = new FuelingLog();
            _fuelingLogRepository = new FuelingLogRepository();
            

            FetchLogs();
        }

        


        void FetchLogs()
        {
            FuelingLogList = _fuelingLogRepository.GetAllDataSortedByMiles();
        }



        public int NumberOfRefuelings
        {
            get => _numberOfRefuelings;
            set
            {
                _numberOfRefuelings = _fuelingLogRepository.NumberOfRefuelings(FuelingLogList);
                OnPropertyChanged("NumberOfRefuelings");
            }
           
        }

        public double MaxLiters
        {
            get => _maxLiters;
            set
            {
                _maxLiters = _fuelingLogRepository.MaxLiters(FuelingLogList);
                OnPropertyChanged("MaxLiters");
            }
                
           
        }
       
        public double MinLiters
        {
            get => _minLiters;
            set
            {
                _minLiters = _fuelingLogRepository.MinLiters(FuelingLogList);
                OnPropertyChanged("MinLiters");
            }
            
        }

        public decimal CheapestLiter
        {
            get => _cheapestLiter;
            set
            {
                _cheapestLiter = _fuelingLogRepository.CheapestLiter(FuelingLogList);
                OnPropertyChanged("CheapestLiter");
            }
            
        }

        public decimal MostExpensiveLiter
        {
            get => _mostExpensiveLiter;
            set
            {
                _mostExpensiveLiter = _fuelingLogRepository.MostExpensiveLiter(FuelingLogList);
                OnPropertyChanged("MostExpensiveLiter");
            }
           
        }
        public decimal TotalExpensesOnFuel
        {
            get => _totalExpensesOnFuel;
            set
            {
                _totalExpensesOnFuel = _fuelingLogRepository.TotalExpensesOnFuel(FuelingLogList);
                OnPropertyChanged("TotalExpensesOnFuel");
            }
        }
        public double TotalLiters
        {
            get => _totalLiters;
            set
            {
                _totalLiters = _fuelingLogRepository.TotalLiters(FuelingLogList);
                OnPropertyChanged("TotalLiters");
            }
        }
        public int TotalDistance
        {
            get => _totalDistance;
            set
            {
                _totalDistance = _fuelingLogRepository.TotalDistance(FuelingLogList);
                OnPropertyChanged("TotalDistance");
            }
        }

        public double DistanceForOneLiter
        {
            get => _distanceForOneLiter;
            set
            {
                _distanceForOneLiter = _fuelingLogRepository.DistanceForOneLiter(FuelingLogList);
                OnPropertyChanged("DistanceForOneLiter");
            }
        }

       public decimal AverageCostOfOneKilometer
       {
           get => _averageCostOfOneKilometer;
           set
           {
               _averageCostOfOneKilometer = _fuelingLogRepository.AverageCostOfOneKilometer(FuelingLogList);
               OnPropertyChanged("AverageCostOfOneKilometer");
           }
    
       }
    
       public double LatestMilesPerLiter
       {
           get => _latestMilesPerLiter;
           set
           {
               _latestMilesPerLiter = _fuelingLogRepository.LatestMilesPerLiter(FuelingLogList);
               OnPropertyChanged("LatestMilesPerLiter");
           }
       }
    
       public double TotalMilesPerLiter
       {
           get => _totalMilesPerLiter;
           set
           {
               _totalMilesPerLiter = _fuelingLogRepository.TotalMilesPerLiter(FuelingLogList);
               OnPropertyChanged("TotalMilesPerLiter");
           }
       }
    
       public double BestPartialMilesPerLiter
       {
           get => _bestPartialMilesPerLiter;
           set
           {
               _bestPartialMilesPerLiter = _fuelingLogRepository.BestPartialMilesPerLiter(FuelingLogList);
               OnPropertyChanged("BestPartialMilesPerLiter");
           }
       }
    
       public double WorstPartialMilesPerLiter
       {
           get => _worstPartialMilesPerLiter;
           set
           {
               _worstPartialMilesPerLiter = _fuelingLogRepository.WorstPartialMilesPerLiter(FuelingLogList);
               OnPropertyChanged("WorstPartialMilesPerLiter");
           }
       }
           
       

    }
}
