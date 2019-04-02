using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Predial.Model
{
    public class PredialPlanDetailModel
    {
        [PrimaryKey, AutoIncrement]
        public int PredialPlanDetaiID { get; set; }
        public int PredialPlanID { get; set; }
        public int Step { get; set; }
        public string Key { get; set; }
        public int WaitingSeconds { get; set; }
    }
}
