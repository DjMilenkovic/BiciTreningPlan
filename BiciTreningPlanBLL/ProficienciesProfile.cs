using ProjectDBDataModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectDBDataModel;
using BiciTrainingPlanDAL.TestManipulator;

namespace BiciTreningPlanBLL
{
    public class ProficienciesProfile
    {
        public Profilisanje_Profila_Vozaca getDataFromDAL(long ID)
        {
            ProfilisanjeProfilaVozacaManipulator profilVozacaManipulator = new ProfilisanjeProfilaVozacaManipulator();
            var myList = profilVozacaManipulator.GetOneData(ID);
            if (myList == null)
            {
                myList = new Profilisanje_Profila_Vozaca();
                myList.ID_Bicikliste = ID;
                myList.Sprint = 0;
                myList.Brdo = 0;
                myList.Hronometar = 0;
            }

            return myList;
        }

        public string returnProficiencies(Profilisanje_Profila_Vozaca profilVozaca)
        {
            int brdo = profilVozaca.Brdo;
            int hronometar = profilVozaca.Hronometar;
            int sprint = profilVozaca.Sprint;

            string result = "Neodređeno";

            if (brdo > hronometar && brdo > sprint)
                result = "Brdaš";
            else if (hronometar > brdo && hronometar > sprint)            
                result = "Hronometraš";            
            else if (sprint > brdo && sprint > hronometar)
                result = "Sprinter";

            return result;   
        }
    }
}
