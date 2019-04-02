using Predial.DatabaseHelper;
using Predial.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace Predial
{
    public class UserDataAccess:DataAccessBase
    {
        public UserModel GetUser()
        {
            return sqliteConnection.Table<UserModel>().First();
        }


        public bool UpdateUser(UserModel user)
        {
            if (sqliteConnection.Update(user) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }   
    }
}