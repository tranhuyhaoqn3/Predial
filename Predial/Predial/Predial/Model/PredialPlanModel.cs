using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Predial.Model
{
  public  class PredialPlanModel
    {
        [PrimaryKey, AutoIncrement]
        public int PredialPlanID { get; set; }
        public string PredialPlanName { get; set; }
        public string CallCenterNumber { get; set; }
        public int EWT { get; set; }
        public string KeyPressed { get; set; }
    }
}
