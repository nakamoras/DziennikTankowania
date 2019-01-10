using DziennikTanowania.Helpers;
using DziennikTanowania.UWP.Implementations;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(UWPSQLite))]
namespace DziennikTanowania.UWP.Implementations
{
    
    public class UWPSQLite : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            string documentsPath = Windows.Storage.ApplicationData.Current.LocalFolder.Path;
            var path = Path.Combine(documentsPath, DatabaseHelper.DbFileName);
            var conn = new SQLiteConnection(path);
            return conn;
        }

        
    }
}
