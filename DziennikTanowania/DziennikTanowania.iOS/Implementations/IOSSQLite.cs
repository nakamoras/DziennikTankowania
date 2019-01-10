using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DziennikTanowania.Helpers;
using DziennikTanowania.iOS.Implementations;
using Foundation;
using SQLite;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(IOSSQLite))]
namespace DziennikTanowania.iOS.Implementations
{
    public class IOSSQLite :ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libraryPath = Path.Combine(documentsPath, "..", "Library");
            var path = Path.Combine(libraryPath, DatabaseHelper.DbFileName);
            var conn = new SQLiteConnection(path);
            return conn;
        }

        

    }
}