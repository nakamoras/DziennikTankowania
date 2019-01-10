using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;
using Xamarin.Forms;
using DziennikTanowania.Models;
namespace DziennikTanowania.Helpers
{
    public class DatabaseHelper
    {
        static SQLiteConnection sqLiteConnection;
        public const string DbFileName = "FuelingLogs.db";

        public DatabaseHelper()
        {
            sqLiteConnection = DependencyService.Get<ISQLite>().GetConnection();
            sqLiteConnection.CreateTable<FuelingLog>();
        }

        public List<FuelingLog> GetAllData()
        {
            return sqLiteConnection.Table<FuelingLog>().ToList();
        }

        public List<FuelingLog> GetAllDataSortedByMiles()
        {
            return sqLiteConnection.Table<FuelingLog>().OrderByDescending(V => V.ActualMileage).ToList();
        }

        public FuelingLog GetFuelingLogData(int id)
        {
            return sqLiteConnection.Table<FuelingLog>().FirstOrDefault(t => t.Id == id);
        }

        public void DeleteAllFuelingLogs()
        {
            sqLiteConnection.DeleteAll<FuelingLog>();
        }

        public void DeleteFuelingLog(int id)
        {
            sqLiteConnection.Delete<FuelingLog>(id);
        }

        public void InsertFuelingLog(FuelingLog fuelingLog)
        {
            sqLiteConnection.Insert(fuelingLog);
        }

        public void UpdateFuelingLog(FuelingLog fuelingLog)
        {
            sqLiteConnection.Update(fuelingLog);
        }
        
    }
}
