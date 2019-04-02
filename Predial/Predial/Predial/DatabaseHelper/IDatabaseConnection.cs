using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Predial
{
    public interface IDatabaseConnection
    {
        SQLiteConnection DbConnection();
    }
}
