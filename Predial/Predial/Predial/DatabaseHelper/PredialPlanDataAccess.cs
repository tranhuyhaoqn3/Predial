using Predial.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Predial.DatabaseHelper
{
   public class PredialPlanDataAccess:DataAccessBase 
    {
        public PredialPlanDataAccess()
        {
            if(sqliteConnection.Table<PredialPlanModel>().Count() == 0)
            {
                var predialPlanDefault = new PredialPlanModel
                {
                    PredialPlanName = "Call AK Sontor Service"
                };
                sqliteConnection.Insert(predialPlanDefault);

                predialPlanDefault = new PredialPlanModel
                {
                    PredialPlanName = "Bolton Health Care"
                };
                sqliteConnection.Insert(predialPlanDefault);

                predialPlanDefault = new PredialPlanModel
                {
                    PredialPlanName = "Apple Texas Sale Service"
                };
                sqliteConnection.Insert(predialPlanDefault);
            }
          
        }

        public List<PredialPlanModel> GetAllPredialPlans()
        {
            return sqliteConnection.Table<PredialPlanModel>().ToList();
        }

        public bool InsertPredialPlan(PredialPlanModel predialPlan)
        {
            if (sqliteConnection.Insert(predialPlan) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool UpdatePredialPlan(PredialPlanModel predialPlan)
        {
            if (sqliteConnection.Update(predialPlan) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool DeletePredialPlan(PredialPlanModel predialPlan)
        {
            if (sqliteConnection.Delete(predialPlan) > 0)
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
