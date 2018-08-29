using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BiciTrainingPlanDAL.TestManipulator;
using ProjectDBDataModel.Entity;

namespace BiciTreningPlanBLL
{
    public class NaturalAbilities
    {
        public Prirodne_Sposobnosti getDataFromDAL(long ID)
        {
            TestPrirodnihSposobnostiVozacaManipulator prirodneSposobnostiManipulator = new TestPrirodnihSposobnostiVozacaManipulator();
            var result = prirodneSposobnostiManipulator.GetOneData(ID);
            if (result == null)
            {
                result = new Prirodne_Sposobnosti();
                result.ID_Bicikliste = ID;
                result.Brzina = 0;
                result.Snaga = 0;
                result.Izdrzljivost = 0;
            }
            return result;
        }

        public int getNaturalAbilite(string ProficienciesProfile, long ID)
        {
            if (ProficienciesProfile == "Brdaš")
            {
                return getDataFromDAL(ID).Snaga;
            }
            else if (ProficienciesProfile == "Sprinter")
            {
                return getDataFromDAL(ID).Brzina;
            }
            else
            {            
                return getDataFromDAL(ID).Izdrzljivost;
            } 
        }
    }
}
