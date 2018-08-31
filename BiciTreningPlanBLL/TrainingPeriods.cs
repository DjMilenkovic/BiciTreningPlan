using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectDBDataModel.Entity;
using BiciTrainingPlanDAL.TestManipulator;
using BiciTrainingPlanDAL.RaceManipulator;

namespace BiciTreningPlanBLL
{
    public class TrainingPeriods
    {
        public Trening_Periodi getDataFromDAL(long ID)
        {
            TreningPeriodManipulator periodManipulator = new TreningPeriodManipulator();
            var result = periodManipulator.GetDataWithJoin(ID);            
            return result;
        }
    }
}
