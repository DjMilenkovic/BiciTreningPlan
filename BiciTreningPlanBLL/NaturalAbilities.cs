using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BiciTrainingPlanDAL.TestManipulator;
using ProjectDBDataModel.Entity;
using System.Collections.ObjectModel;

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

        public void insertIntoDAL(ObservableCollection<int> Speed, ObservableCollection<int> Strength, ObservableCollection<int> Endurance, long IDBicikliste)
        {
            int speed = Total(Speed);
            int strength = Total(Strength);
            int endurance = Total(Endurance);

            Prirodne_Sposobnosti mentalneSposobnosti = new Prirodne_Sposobnosti();
            mentalneSposobnosti.Datum_testiranja = DateTime.Today;
            mentalneSposobnosti.ID_Bicikliste = IDBicikliste;
            mentalneSposobnosti.Brzina = speed;
            mentalneSposobnosti.Snaga = strength;
            mentalneSposobnosti.Izdrzljivost = endurance;

            TestPrirodnihSposobnostiVozacaManipulator prirodneSposobnostiManipulator = new TestPrirodnihSposobnostiVozacaManipulator();
            prirodneSposobnostiManipulator.Insert(mentalneSposobnosti);
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
