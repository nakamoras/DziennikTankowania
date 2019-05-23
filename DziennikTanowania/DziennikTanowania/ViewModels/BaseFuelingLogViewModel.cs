using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using FluentValidation;
using Xamarin.Forms;
using DziennikTanowania.Models;
using DziennikTanowania.Services;

namespace DziennikTanowania.ViewModels
{
    public class BaseFuelingLogViewModel : INotifyPropertyChanged
    {
        
        public FuelingLog _fuelingLog;

        public INavigation _navigation;
        public IValidator _fuelingLogValidator;
        public IFuelingLogRepository _fuelingLogRepository;
        
        public int ActualMileage
        {
            get => _fuelingLog.ActualMileage;
            set
            {
                _fuelingLog.ActualMileage = value;
                OnPropertyChanged("ActualMileage");
            }

        }

        public double AmountOfRefueledFuel
        {
            get => _fuelingLog.AmountOfRefueledFuel;
            set
            {
                _fuelingLog.AmountOfRefueledFuel = value;
                OnPropertyChanged("AmountOfRefueledFuel");
            }
        }

        public decimal PricePerLiter
        {
            get => _fuelingLog.PricePerLiter;
            set
            {
                _fuelingLog.PricePerLiter = value;
                OnPropertyChanged("PricePerLiter");
            }
        }

        public DateTime DateTime
        {
            get => _fuelingLog.DateTime;
            set
            {
                _fuelingLog.DateTime = value;
                OnPropertyChanged("DateTime");
            }
        }

        public string[] RefuelingType
        {
            get => _fuelingLog.RefuelingType;
            set
            {
                _fuelingLog.RefuelingType = value;
                OnPropertyChanged("RefuelingType");
            }
        }

        public string SelectedRefuelingType
        {
            get => _fuelingLog.SelecteRefuelingType;
            set
            {
                _fuelingLog.SelecteRefuelingType = value;
                OnPropertyChanged("SelectedRefuelingType");
            }
        }

        public decimal TotalPrice
        {
            get => _fuelingLog.TotalPrice;
            set
            {
                _fuelingLog.TotalPrice = (decimal)_fuelingLog.AmountOfRefueledFuel * _fuelingLog.PricePerLiter;
                OnPropertyChanged("TotalPrice");
            }
        }

        public int DistanceFromLastRefueling
        {
            get => _fuelingLog.DistanceFromLastRefueling;
        }

        public double MilesPerLiter
        {
            get => _fuelingLog.MilesPerLiter;
        }

        List<FuelingLog> _fuelingLogList;
        public List<FuelingLog> FuelingLogList
        {
            get => _fuelingLogList;
            set
            {
                _fuelingLogList = value;
                OnPropertyChanged("FuelingLogList");
            }
        }

        
        


        



        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
