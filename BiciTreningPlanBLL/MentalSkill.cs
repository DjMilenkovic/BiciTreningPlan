using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BiciTrainingPlanDAL.TestManipulator;
using ProjectDBDataModel.Entity;

namespace BiciTreningPlanBLL
{
    public class MentalSkill
    {
        public Mentalne_Sposobnosti getDataFromDAL(long ID)
        {
            TestMentalnihSposobnostiManipulator mentalneSposobnostiManipulator = new TestMentalnihSposobnostiManipulator();
            var result = mentalneSposobnostiManipulator.GetOneData(ID);
            if(result == null)
            {
                result = new Mentalne_Sposobnosti();
                result.ID_Bicikliste = ID;
                result.Fokus = 0;
                result.Motivacija = 0;
                result.Navika = 0;
                result.Samopouzdanje = 0;
                result.Vizualizacija = 0;
            }
            return result;
        }
    }
}
