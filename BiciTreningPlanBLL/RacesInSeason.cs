using BiciTrainingPlanDAL.RaceManipulator;
using ProjectDBDataModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiciTreningPlanBLL
{
    public class RacesInSeason
    {
        public List<dynamic> getDataFromDALWithJoin(long IDBicikliste, long IDSeason)
        {
            ListaTrkaUSezoniManipulator trkeUSezoni = new ListaTrkaUSezoniManipulator();
            return trkeUSezoni.GetDataWithLeftJoin(IDBicikliste, IDSeason);
        }

        public List<Trke_U_Sezoni> getDataFromDAL(long IDBicikliste, long IDSeason)
        {
            ListaTrkaUSezoniManipulator trkeUSezoni = new ListaTrkaUSezoniManipulator(IDBicikliste, IDSeason);
            return trkeUSezoni.GetData();
        }

        public DateTime getMaxRaceID(long IDBicikliste, long IDSeason)
        {
            return getDataFromDAL(IDBicikliste, IDSeason).Select(o => o.Datum_trke).Max();
        }

        public void insertIntoDAL(long iDBicikliste, long iDSezone, long trkaID, DateTime RaceDate)
        {
            Trke_U_Sezoni trka = new Trke_U_Sezoni();
            trka.ID_Bicikliste = iDBicikliste;
            trka.ID_Sezone = iDSezone;
            trka.ID_Trke = trkaID;
            trka.Datum_trke = RaceDate;

            ListaTrkaUSezoniManipulator trkeUSezoni = new ListaTrkaUSezoniManipulator();
            trkeUSezoni.Insert(trka);
        }

        public void deleteIntoDAL(long IDSezone, long IDBicikliste, long IDTrke)
        {
            ListaTrkaUSezoniManipulator trkeUSezoni = new ListaTrkaUSezoniManipulator();
            trkeUSezoni.Delete(IDSezone, IDBicikliste, IDTrke);
        }
    }
}
