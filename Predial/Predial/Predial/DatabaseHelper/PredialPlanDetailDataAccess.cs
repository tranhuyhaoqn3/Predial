using Predial.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Predial.DatabaseHelper
{
   public class PredialPlanDetailDataAccess:DataAccessBase
    {
        public List<PredialPlanDetailModel> GetAllPredialPlansDetail()
        {
            return sqliteConnection.Table<PredialPlanDetailModel>().ToList();
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