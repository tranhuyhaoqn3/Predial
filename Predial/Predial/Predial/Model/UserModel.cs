using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Predial
{
    public class UserModel
    {
        [PrimaryKey]
        public string PhoneNumber { get; set; }
        public bool License { get; set; }
    }
}
