using BiciTrainingPlanDAL.TestManipulator;
using ProjectDBDataModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiciTreningPlanBLL
{
    public class SprintTest
    {
        public Sprint_Test getDataFromDAL(long ID)
        {
            TestSprintaManipulator biciklistaManipulator = new TestSprintaManipulator();
            var result = biciklistaManipulator.GetOneData(ID);
            if(result == null)
            {
                result = new Sprint_Test();
                result.ID_Bicikliste = ID;
                result.Maksimalna_Snaga = 0;
                result.Prosecna_Snaga = 0;
            }
            return result;
        }
    }
}
