using ProjectDBDataModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiciTrainingPlanDAL
{
    public class TreningDaniManipulator : IRepository<Trening_Dani>
    {
        private long IDBicikliste;
        public TreningDaniManipulator(long IDBicikliste)
        {
            this.IDBicikliste = IDBicikliste;
        }
        public TreningDaniManipulator()
        {

        }

        public void Insert(Trening_Dani entity)
        {
            var treningDan = entity as Trening_Dani;
            if (treningDan != null)
            {
                using (var db = new ProjectDB())
                {
                    var customers = db.Set<Trening_Dani>();
                    customers.Add(treningDan);
                    db.SaveChanges();
                }
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public List<dynamic> GetDataWithJoin(long IDBicikliste, long IDSezone)
        {            
            using (var db = new ProjectDB())
            {
                var query = from treningDani in db.Trening_Dani.Where(o => o.ID_Bicikliste == IDBicikliste && o.ID_Sezone == IDSezone)
                            join trening in db.Treninzis on treningDani.ID_Treninga equals trening.ID
                            join tipTreninga in db.Tipovi_Treninga on trening.ID_Tipovi_treninga equals tipTreninga.ID into newTrainingDan
                            from treninzi in newTrainingDan.DefaultIfEmpty()
                            orderby treningDani.Datum_treninga ascending
                            select new
                            {
                                treningDani.Datum_treninga,
                                treningDani.Vreme_treninga,
                                treninzi.Naziv
                            };
                           
                return query.ToList<dynamic>();
            }
        }

        public void Update(Trening_Dani entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(long ID)
        {
            throw new NotImplementedException();
        }

        public List<Trening_Dani> GetData()
        {
            throw new NotImplementedException();
        }
    }
}
