using BiciTrainingPlanDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiciTreningPlanBLL
{
    public class Class1
    {
        public void getDataFromDAL()
        {
            Biciklista biciklista = new Biciklista();
            IDataManipulator<Biciklista> biciklistaManipulator = new BiciklistaManipulator(biciklista);
               
        }
    }
}
