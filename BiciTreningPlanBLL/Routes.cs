using BiciTrainingPlanDAL.RaceManipulator;
using ProjectDBDataModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiciTreningPlanBLL
{
    public class Routes
    {
        public Routes()
        {

        }

        public void insertIntoDAL(Putanja putanja)
        {
            PutanjaManipulator putanjaManipulator = new PutanjaManipulator();
            putanjaManipulator.Insert(putanja);
        }

        public List<Tip_putanje> getTipPutanje()
        {
            TipPutanjeManipulator tipPutanjeManipulatore = new TipPutanjeManipulator();
            return tipPutanjeManipulatore.GetData();
        }

        public List<dynamic> getPutanjeWithJoin(long IDBicikliste)
        {
            PutanjaManipulator putanjaManipulator = new PutanjaManipulator();
            return putanjaManipulator.GetDataWithJoin(IDBicikliste);
        }

        public List<Putanja> getPutanje(long IDBicikliste)
        {
            PutanjaManipulator putanjaManipulator = new PutanjaManipulator(IDBicikliste);
            return putanjaManipulator.GetData();
        }

        public void deleteIntoDAL(long ID)
        {
            PutanjaManipulator putanjaManipulator = new PutanjaManipulator();
            putanjaManipulator.Delete(ID);
        }
    }
}
