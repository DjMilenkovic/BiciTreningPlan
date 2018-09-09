using ProjectDBDataModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectDBDataModel;
using BiciTrainingPlanDAL.TestManipulator;
using System.Collections.ObjectModel;

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

        public void insertIntoDAL(ObservableCollection<int> Sprint, ObservableCollection<int> Climb, ObservableCollection<int> TT, long IDBicikliste)
        {
            Profilisanje_Profila_Vozaca profilVozaca = new Profilisanje_Profila_Vozaca();
            profilVozaca.ID_Bicikliste = IDBicikliste;
            profilVozaca.Datum_testiranja = DateTime.Today;
            profilVozaca.Brdo = Total(Climb);
            profilVozaca.Sprint = Total(Sprint);
            profilVozaca.Hronometar = Total(TT);

            ProfilisanjeProfilaVozacaManipulator profilVozacaManipulator = new ProfilisanjeProfilaVozacaManipulator();
            profilVozacaManipulator.Insert(profilVozaca);
        }


        private int Total(ObservableCollection<int> collection)
        {
            int sum = 0;
            foreach (var item in collection)
            {
                sum += item;
            }
            return sum;
        }
    }
}
