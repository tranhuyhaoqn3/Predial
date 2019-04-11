using Predial.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Predial.DatabaseHelper
{
    public class DataAccessBase
    {
        protected SQLiteConnection sqliteConnection;
        public DataAccessBase()
        {
            sqliteConnection = DependencyService.Get<IDatabaseConnection>().DbConnection();
            sqliteConnection.CreateTable<UserModel>();

            sqliteConnection.CreateTable<PredialPlanModel>();
            sqliteConnection.DropTable<PredialPlanDetailModel>();

            sqliteConnection.CreateTable<PredialPlanDetailModel>();
        }

    }
}
