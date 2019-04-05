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
        public UserDataAccess()
        {
            if (sqliteConnection.Table<UserModel>().Count() == 0)
            {
                var userData = new UserModel()
                {
                    PhoneNumber="09370403220",
                    License=true
                };
                sqliteConnection.Insert(userData);
            }
        }
        public UserModel GetUser()
        {
            return sqliteConnection.Table<UserModel>().First();

        }

        public bool UpdateUser(UserModel user)
        {
            var dto = sqliteConnection.Table<UserModel>().First();
            dto.PhoneNumber = user.PhoneNumber;
            if (sqliteConnection.Update(dto) > 0)
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