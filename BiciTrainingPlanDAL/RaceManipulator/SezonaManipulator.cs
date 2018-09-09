using ProjectDBDataModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiciTrainingPlanDAL.RaceManipulator
{
    public class SezonaManipulator : IRepository<Sezona>
    {
        private long IDBiciklista;

        public SezonaManipulator(long IDBiciklista)
        {
            this.IDBiciklista = IDBiciklista;
        }

        public SezonaManipulator() { }
       
        public void Delete(DateTime time, long ID)
        {
            using (var db = new ProjectDB())
            {
                var result = db.Sezonas.SingleOrDefault(b => b.Datum_pocetka == time && b.ID_Bicikliste==ID);
                if (result != null)
                {
                    db.Sezonas.Remove(result);
                    db.SaveChanges();
                }
            }
        }

        public List<Sezona> GetData()
        {
            using (var db = new ProjectDB())
            {
                var query = from sezone in db.Sezonas.Where(o => o.ID_Bicikliste == IDBiciklista)
                            select sezone;

                return query.ToList();
            }
        }        

        public Sezona GetOneSeason(long IDBicikliste)
        {
            using (var db = new ProjectDB())
            {
                var query = from sezone in db.Sezonas.Where(o => o.ID_Bicikliste == IDBiciklista)
                            orderby sezone.Datum_pocetka descending
                            select sezone;
                var result = query.FirstOrDefault();
                return result;
            }
        }

        public void Insert(Sezona entity)
        {
            var sezona = entity as Sezona;
            if (sezona != null)
            {
                using (var db = new ProjectDB())
                {
                    var customers = db.Set<Sezona>();
                    customers.Add(sezona);
                    db.SaveChanges();
                }
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public void Update(Sezona entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(long ID)
        {
            throw new NotImplementedException();
        }     
    }
}
