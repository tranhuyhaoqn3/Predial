using Predial.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Predial.DatabaseHelper
{
   public class PredialPlanDetailDataAccess:DataAccessBase
    {

        public PredialPlanDetailDataAccess()
        {
            if (sqliteConnection.Table<PredialPlanDetailModel>().Count() == 0)
            {
                var predialPlanDefault = new PredialPlanDetailModel
                {
                    ClientPredialPlanID = 1,
                    Key = 5.ToString(),
                    Step = 1,
                    WaitingSeconds = 2
                };
                sqliteConnection.Insert(predialPlanDefault);
                predialPlanDefault = new PredialPlanDetailModel
                {
                    ClientPredialPlanID = 1,
                    Key = 2.ToString(),
                    Step = 2,
                    WaitingSeconds = 3
                };
                sqliteConnection.Insert(predialPlanDefault);
                predialPlanDefault = new PredialPlanDetailModel
                {
                    ClientPredialPlanID = 1,
                    Key = 6.ToString(),
                    Step = 3,
                    WaitingSeconds = 2
                };
                sqliteConnection.Insert(predialPlanDefault);
            }
        }
        public List<PredialPlanDetailModel> GetPredialPlansDetail(PredialPlanModel predialPlan)
        {
            return sqliteConnection.Table<PredialPlanDetailModel>().Where(item=> item.ClientPredialPlanID == predialPlan.PredialPlanID).ToList();
        }

        public bool InsertPredialPlanDetail(PredialPlanDetailModel predialPlanDetail)
        {
            if (sqliteConnection.Insert(predialPlanDetail) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool UpdatePredialPlanDetail(PredialPlanDetailModel predialPlanDetail)
        {
            if (sqliteConnection.Update(predialPlanDetail) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool DeletePredialPlan(PredialPlanDetailModel predialPlanDetail)
        {
            if (sqliteConnection.Delete(predialPlanDetail) > 0)
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