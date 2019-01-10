using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace DziennikTanowania.Helpers
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
