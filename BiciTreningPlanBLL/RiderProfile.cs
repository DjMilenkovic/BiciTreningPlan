using BiciTrainingPlanDAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiciTreningPlanBLL
{
    public class RiderProfile
    {
        public void getDataFromDAL()
        {
            BiciklistaManipulator biciklistaManipulator = new BiciklistaManipulator();
            //List<Biciklista> myList = biciklistaManipulator.GetOneData(1);
            //ObservableCollection<Biciklista> myCollection = new ObservableCollection<Biciklista>(myList as List<Biciklista>);
            var m = biciklistaManipulator.GetOneData(1); 
        }
    }
}
