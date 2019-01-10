using System;
using System.Collections.Generic;
using System.Text;
using DziennikTanowania.Models;

namespace DziennikTanowania.Services
{
    public interface IFuelingLogRepository
    {
        List<FuelingLog> GetAllData();
        List<FuelingLog> GetAllDataSortedByMiles();
        FuelingLog GetFuelingLogData(int fuelingLogId);

        void DeleteAllFuelingLogs();
        void DeleteFuelingLog(int fuelingLogId);
        void InsertFuelingLog(FuelingLog fuelingLog);
        void UpdateFuelingLog(FuelingLog fuelingLog);
        void FetchDistanceFromLastRefueling(List<FuelingLog> fuelingLogs);
        void FetchMilesPerLiter(List<FuelingLog> fuelingLogs);
        decimal TotalExpensesOnFuel(List<FuelingLog> fuelingLogs);
        double TotalLiters(List<FuelingLog> fuelingLogs);
        int TotalDistance(List<FuelingLog> fuelingLogs);
        int NumberOfRefuelings(List<FuelingLog> fuelingLogs);
        double MaxLiters(List<FuelingLog> fuelingLogs);
        double MinLiters(List<FuelingLog> fuelingLogs);
        decimal CheapestLiter(List<FuelingLog> fuelingLogs);
        decimal MostExpensiveLiter(List<FuelingLog> fuelingLogs);
        double DistanceForOneLiter(List<FuelingLog> fuelingLogs);
        decimal AverageCostOfOneKilometer(List<FuelingLog> fuelingLogs);
        double LatestMilesPerLiter(List<FuelingLog> fuelingLogs);
        double TotalMilesPerLiter(List<FuelingLog> fuelingLogs);
        double BestPartialMilesPerLiter(List<FuelingLog> fuelingLogs);
        double WorstPartialMilesPerLiter(List<FuelingLog> fuelingLogs);

    }
}
