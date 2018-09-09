using BiciTrainingPlanDAL.RaceManipulator;
using ProjectDBDataModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiciTreningPlanBLL
{
    public class RacesList
    {
        public List<dynamic> getDataFromDALWithJoin(long ID)
        {
            ListaTrkaManipulator listaTrkaManipulator = new ListaTrkaManipulator();
            var result = listaTrkaManipulator.GetDataWithJoin(ID);
           
            return result;
        }

        public void deleteIntoDAL(long ID)
        {
            ListaTrkaManipulator listaTrkaManipulator = new ListaTrkaManipulator();
            listaTrkaManipulator.Delete(ID);         
        }

        public void insertIntoDAL(Lista_Trka entity)
        {
            ListaTrkaManipulator listaTrkaManipulator = new ListaTrkaManipulator();
            listaTrkaManipulator.Insert(entity);
        }

        public List<Lista_Trka> getDataFromDAL(long IDBicikliste)
        {
            ListaTrkaManipulator listaTrkaManipulator = new ListaTrkaManipulator(IDBicikliste);
            return listaTrkaManipulator.GetData();
        }
    }
}
