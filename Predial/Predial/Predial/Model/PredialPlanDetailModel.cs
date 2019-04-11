using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Predial.Model
{
    public class PredialPlanDetailModel
    {
        [PrimaryKey, AutoIncrement]
        public long DetailID { get; set; }
        public long ClientPredialPlanID { get; set; }
        public int Step { get; set; }
        public string Key { get; set; }
        public bool IsDynamicKey { get; set; }
        public int WaitingSeconds { get; set; }
    }
}
