using ProjectDBDataModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiciTrainingPlanDAL.RaceManipulator
{
    public class ListaTrkaUSezoniManipulator : IRepository<Trke_U_Sezoni>
    {
        private long IDBicikliste;
        private long IDSezone;

        public ListaTrkaUSezoniManipulator()
        {

        }
        public ListaTrkaUSezoniManipulator(long IDBicikliste, long IDSezone)
        {
            this.IDBicikliste = IDBicikliste;
            this.IDSezone = IDSezone;
        }
        public void Delete(long ID)
        {
            throw new NotImplementedException();
        }
       
        public void Delete(long IDSezone, long IDBicikliste, long IDTrke)
        {
            using (var db = new ProjectDB())
            {
                var result = db.Trke_U_Sezoni.SingleOrDefault(b => (b.ID_Bicikliste == IDBicikliste) && (b.ID_Sezone == IDSezone) && (b.ID_Trke == IDTrke));
                if (result != null)
                {
                    db.Trke_U_Sezoni.Remove(result);
                    db.SaveChanges();
                }
            }
        }

        public List<Trke_U_Sezoni> GetData()
        {
            using (var db = new ProjectDB())
            {
                var query = from listaTrkaUSezoni in db.Trke_U_Sezoni.Where(o => o.ID_Bicikliste == IDBicikliste && o.ID_Sezone == IDSezone)
                            select listaTrkaUSezoni;

                return query.ToList();
            }
        }

        public List<dynamic> GetDataWithLeftJoin(long IDBicikliste, long IDSezone)
        {
            using (var db = new ProjectDB())
            {
                var query = from listaTrkaUSezoni in db.Trke_U_Sezoni.Where(o => o.ID_Bicikliste == IDBicikliste && o.ID_Sezone==IDSezone)
                            join listaTrka in db.Lista_Trka on listaTrkaUSezoni.ID_Trke equals listaTrka.ID
                            join putanja in db.Putanjas on listaTrka.ID_Putanje equals putanja.ID into newListaTrka
                            from trke in newListaTrka.DefaultIfEmpty()
                            select new
                            {
                                trke.ID,
                                listaTrka.Naziv_trke,
                                trke.Cela_putanja,                                
                                listaTrkaUSezoni.Datum_trke
                            };

                return query.ToList<dynamic>();
            }
        }

        public void Insert(Trke_U_Sezoni entity)
        {
            var listaTrkaUSezoniManipulator = entity as Trke_U_Sezoni;
            if (listaTrkaUSezoniManipulator != null)
            {
                using (var db = new ProjectDB())
                {
                    var customers = db.Set<Trke_U_Sezoni>();
                    customers.Add(listaTrkaUSezoniManipulator);
                    db.SaveChanges();
                }
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public void Update(Trke_U_Sezoni entity)
        {
            throw new NotImplementedException();
        }
    }
}
