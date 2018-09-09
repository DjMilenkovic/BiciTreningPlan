using ProjectDBDataModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiciTrainingPlanDAL.RaceManipulator
{
    public class TreningListManipulator : IRepository<Treninzi>
    {
        public void Delete(long ID)
        {
            throw new NotImplementedException();
        }

        public List<Treninzi> GetData()
        {
            using (var db = new ProjectDB())
            {
                var query = from dtp in db.Treninzis
                            select dtp;

                return query.ToList();
            }
        }

        public long GetID(long IskustveniNivo, long TipTreninga, long TreningPeriod)
        {
            using (var db = new ProjectDB())
            {
                var query = from dtp in db.Treninzis
                            where dtp.ID_Iskustveni_nivo == IskustveniNivo
                            where dtp.ID_Tipovi_treninga == TipTreninga
                            where dtp.ID_Trening_perioda == TreningPeriod
                            select dtp;

                long result = query.FirstOrDefault().ID;
                return result;
            }
        }

        public Treninzi GetTrening(long IskustveniNivo, long TipTreninga, long TreningPeriod)
        {
            using (var db = new ProjectDB())
            {
                var query = from dtp in db.Treninzis
                            where (dtp.ID_Iskustveni_nivo == IskustveniNivo) & (dtp.ID_Tipovi_treninga == TipTreninga) & (dtp.ID_Trening_perioda == TreningPeriod)
                            select dtp;
               
                return query.FirstOrDefault();
            }
        }

        public void Insert(Treninzi entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Treninzi entity)
        {
            throw new NotImplementedException();
        }
    }
}
