using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using DziennikTanowania.Droid.Implementations;
using DziennikTanowania.Helpers;
using SQLite;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(AndroidSQLite))]
namespace DziennikTanowania.Droid.Implementations
{
    public class AndroidSQLite : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

            var path = Path.Combine(documentsPath, DatabaseHelper.DbFileName);
            var conn = new SQLiteConnection(path);
            return conn;
        }
    }
}