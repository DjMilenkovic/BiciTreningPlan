using BiciTrainingPlanDAL;
using BiciTrainingPlanDAL.TestManipulator;
using ProjectDBDataModel.Entity;
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
        public Biciklista getDataFromDAL(long ID)
        {
            BiciklistaRepository biciklista = new BiciklistaRepository();
            return biciklista.GetOneData(ID);            
        }

        public List<Biciklista> getDataFromDAL()
        {
            BiciklistaRepository biciklista = new BiciklistaRepository();
            return biciklista.GetData();
        }

        public void insertIntoDAL(Biciklista biciklista)
        {
            BiciklistaRepository biciRepo = new BiciklistaRepository();
            biciRepo.Insert(biciklista);
        }
    }
}
