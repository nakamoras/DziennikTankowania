using System;
using System.Collections.Generic;
using System.Text;
using DziennikTanowania.Models;
using DziennikTanowania.Helpers;

namespace DziennikTanowania.Services
{
    public class FuelingLogRepository : IFuelingLogRepository
    {
        DatabaseHelper _databaseHelper;

        public FuelingLogRepository()
        {
            _databaseHelper = new DatabaseHelper();
        }

        public void DeleteAllFuelingLogs()
        {
            _databaseHelper.DeleteAllFuelingLogs();
        }

        public void DeleteFuelingLog(int fuelingLogId)
        {
            _databaseHelper.DeleteFuelingLog(fuelingLogId);
        }

        public List<FuelingLog> GetAllData()
        {
            return _databaseHelper.GetAllData();
        }

        public List<FuelingLog> GetAllDataSortedByMiles()
        {
            return _databaseHelper.GetAllDataSortedByMiles();
        }

        public FuelingLog GetFuelingLogData(int fuelingLogId)
        {
            return _databaseHelper.GetFuelingLogData(fuelingLogId);
        }

        public void InsertFuelingLog(FuelingLog fuelingLog)
        {
            _databaseHelper.InsertFuelingLog(fuelingLog);
        }

        public void UpdateFuelingLog(FuelingLog fuelingLog)
        {
            _databaseHelper.UpdateFuelingLog(fuelingLog);
        }


        public void FetchDistanceFromLastRefueling(List<FuelingLog> fuelingLogs)
        {
            
                FuelingLog fuelingLog = new FuelingLog();
                for (int i = 1; i < fuelingLogs.Count; i++)
                {
                    var actualDistance = fuelingLogs[i - 1].ActualMileage;
                    var previousDistance = fuelingLogs[i].ActualMileage;
                    var distanceFromLastRefueling = actualDistance - previousDistance;
                    fuelingLog = GetFuelingLogData(fuelingLogs[i - 1].Id);
                    fuelingLog.DistanceFromLastRefueling = distanceFromLastRefueling;
                    UpdateFuelingLog(fuelingLog);
                }
            
     
        }

        public void FetchMilesPerLiter(List<FuelingLog> fuelingLogs)
        {   
            
                FuelingLog fuelingLog = new FuelingLog();
                for (int i = 0; i < fuelingLogs.Count - 1; i++)
                {
                    var distanceFromLastRefueling = fuelingLogs[i].DistanceFromLastRefueling;
                    var liters = fuelingLogs[i].AmountOfRefueledFuel;
                    double milesPerLiter = (liters / distanceFromLastRefueling) * 100;
                    fuelingLog = GetFuelingLogData(fuelingLogs[i].Id);
                    fuelingLog.MilesPerLiter = milesPerLiter;
                    UpdateFuelingLog(fuelingLog);

                }
            
 
        }

        public decimal TotalExpensesOnFuel(List<FuelingLog> fuelingLogs)
        {
            
            if (fuelingLogs.Count == 0) return 0;
            else
            {
                decimal totalExpenses = 0;
                for(int i=0; i< fuelingLogs.Count - 1; i++)
                {
                    totalExpenses += fuelingLogs[i].TotalPrice;
                }
                return totalExpenses;
            }
        }

        public double TotalLiters(List<FuelingLog> fuelingLogs)
        {
            
            if (fuelingLogs.Count == 0) return 0;
            else
            {
                double totalLiters = 0;
                for(int i=0; i< fuelingLogs.Count - 1; i++)
                {
                    totalLiters += fuelingLogs[i].AmountOfRefueledFuel;
                }
                return totalLiters;
            }

        }

        public int TotalDistance(List<FuelingLog> fuelingLogs)
        {
            
            if (fuelingLogs.Count == 0) return 0;
            else
            {
                int totalDistance = 0;
                for(int i=0; i< fuelingLogs.Count -1; i++)
                {
                    totalDistance += fuelingLogs[i].DistanceFromLastRefueling;
                }
                return totalDistance;
            }

        }

        public int NumberOfRefuelings(List<FuelingLog> fuelingLogs)
        {
            
            if (fuelingLogs.Count == 0) return 0;
            else
            {
                int numberOfRefuelings = 0;
                for(int i=0; i<fuelingLogs.Count -1; i++)
                {
                    numberOfRefuelings++;
                }
                return numberOfRefuelings;
            }
            
            
        }

        public double MaxLiters(List<FuelingLog> fuelingLogs)
        {
            try
            {
                if (fuelingLogs.Count == 0) return 0;
                else
                {
                    double maxLiters = 0;
                    maxLiters = fuelingLogs[1].AmountOfRefueledFuel;
                    for (int i = 0; i < fuelingLogs.Count - 1; i++)
                    {

                        maxLiters = Math.Max(maxLiters, fuelingLogs[i].AmountOfRefueledFuel);
                    }
                    return maxLiters;
                }
            }
            catch(ArgumentOutOfRangeException e)
            {
                return 0;
            }
            
            
            
            
        }

        public double MinLiters(List<FuelingLog> fuelingLogs)
        {
            try
            {
                if (fuelingLogs.Count == 0) return 0;
                else
                {
                    double minLiters = 0;
                    minLiters = fuelingLogs[1].AmountOfRefueledFuel;
                    for (int i = 0; i < fuelingLogs.Count - 1; i++)
                    {
                        minLiters = Math.Min(minLiters, fuelingLogs[i].AmountOfRefueledFuel);
                    }
                    return minLiters;
                }

            }
            catch(ArgumentOutOfRangeException e)
            {
                return 0;
            }




        }

        public decimal CheapestLiter(List<FuelingLog> fuelingLogs)
        {
            try
            {
                if (fuelingLogs.Count == 0) return 0;
                else
                {
                    decimal minPrice = 0;
                    minPrice = fuelingLogs[1].PricePerLiter;
                    for (int i = 0; i < fuelingLogs.Count - 1; i++)
                    {
                        minPrice = Math.Min(minPrice, fuelingLogs[i].PricePerLiter);
                    }
                    return minPrice;
                }
            }
            catch(ArgumentOutOfRangeException e)
            {
                return 0;
            }
            
            
            
        }

        public decimal MostExpensiveLiter(List<FuelingLog> fuelingLogs)
        {
            try
            {
                if (fuelingLogs.Count == 0) return 0;
                else
                {
                    decimal maxPrice = 0;
                    maxPrice = fuelingLogs[1].PricePerLiter;
                    for (int i = 0; i < fuelingLogs.Count - 1; i++)
                    {
                        maxPrice = Math.Max(maxPrice, fuelingLogs[i].PricePerLiter);
                    }
                    return maxPrice;
                }
            }
            catch(ArgumentOutOfRangeException e)
            {
                return 0;
            }
            
            
        }

        public double DistanceForOneLiter(List<FuelingLog> fuelingLogs)
        {
            if (fuelingLogs.Count == 0) return 0;
            else
            {
                double distance = 0;
                double liters = 0;
                double _distanceForOneLiter = 0;
                for (int i = 0; i < fuelingLogs.Count-1; i++)
                {
                    distance += fuelingLogs[i].DistanceFromLastRefueling;
                    liters += fuelingLogs[i].AmountOfRefueledFuel;
                }

                _distanceForOneLiter = distance / liters;
                if (double.IsNaN(_distanceForOneLiter)) return 0;
                else return _distanceForOneLiter;

            }
            
        }

        public decimal AverageCostOfOneKilometer(List<FuelingLog> fuelingLogs)
        {
            if (fuelingLogs.Count == 0) return 0;
            else
            {
                double distance = 0;
                decimal totalPrice = 0;
                decimal _averageCostOfOneKilometer = 0;
                for (int i = 0; i < fuelingLogs.Count-1; i++)
                {
                    distance += fuelingLogs[i].DistanceFromLastRefueling;
                    totalPrice += fuelingLogs[i].TotalPrice;
                }
                try
                {
                    _averageCostOfOneKilometer = (decimal)distance / totalPrice;
                }
                catch(DivideByZeroException e)
                {
                    return 0;
                }
                

                return _averageCostOfOneKilometer;
            }
            
        }

        public double LatestMilesPerLiter(List<FuelingLog> fuelingLogs)
        {
            if (fuelingLogs.Count == 0) return 0;
            else return fuelingLogs[0].MilesPerLiter;

        }

        public double TotalMilesPerLiter(List<FuelingLog> fuelingLogs)
        {
            if (fuelingLogs.Count == 0) return 0;
            else
            {
                double _totalMilesPerLiter = 0;
                double milesPerLiter = 0;
                for (int i = 0; i < fuelingLogs.Count - 1; i++)
                {
                    milesPerLiter += fuelingLogs[i].MilesPerLiter;
                }

                _totalMilesPerLiter = milesPerLiter / (fuelingLogs.Count - 1);
                if (double.IsNaN(_totalMilesPerLiter)) return 0;
                else return _totalMilesPerLiter;


            }

        }

        public double BestPartialMilesPerLiter(List<FuelingLog> fuelingLogs)
        {
            if (fuelingLogs.Count == 0) return 0;
            else
            {
                double _bestPartialMilePerLiter = fuelingLogs[0].MilesPerLiter;
                for (int i = 0; i < fuelingLogs.Count - 1; i++)
                {
                    _bestPartialMilePerLiter = Math.Max(_bestPartialMilePerLiter, fuelingLogs[i].MilesPerLiter);
                }
                return _bestPartialMilePerLiter;
            }
            

            
        }

        public double WorstPartialMilesPerLiter(List<FuelingLog> fuelingLogs)
        {
            if (fuelingLogs.Count == 0)return 0;
            else
            {
                double _worstPartialMilePerLiter = fuelingLogs[0].MilesPerLiter;
                for (int i = 0; i < fuelingLogs.Count - 1; i++)
                {
                    _worstPartialMilePerLiter = Math.Min(_worstPartialMilePerLiter, fuelingLogs[i].MilesPerLiter);
                }

                return _worstPartialMilePerLiter;
            }
            
        }
    }
}
