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

        public void insertIntoDAL(ObservableCollection<int> Visualisation,ObservableCollection<int> Motivation, ObservableCollection<int> Focus, ObservableCollection<int> Habit, ObservableCollection<int> Confidence, long IDBicikliste)
        {
            int visualisation = Total(Visualisation);
            int motivation = Total(Motivation);
            int focus = Total(Focus);
            int habit = Total(Habit);
            int confidence = Total(Confidence);

            Mentalne_Sposobnosti mentalneSposobnosti = new Mentalne_Sposobnosti();
            mentalneSposobnosti.Datum_testiranja = DateTime.Today;
            mentalneSposobnosti.ID_Bicikliste = IDBicikliste;
            mentalneSposobnosti.Motivacija = motivation;
            mentalneSposobnosti.Samopouzdanje = confidence;
            mentalneSposobnosti.Navika = habit;
            mentalneSposobnosti.Fokus = focus;
            mentalneSposobnosti.Vizualizacija = visualisation;
           
            TestMentalnihSposobnostiManipulator mentalneSposobnostiManipulator = new TestMentalnihSposobnostiManipulator();
            mentalneSposobnostiManipulator.Insert(mentalneSposobnosti);
        }

        private int Total(ObservableCollection<int> collection)
        {
            int sum = 0;
            foreach(var item in collection)
            {
                sum += item;
            }
            return sum; 
        }
    }
}
