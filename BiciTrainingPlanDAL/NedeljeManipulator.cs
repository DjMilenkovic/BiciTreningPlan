using ProjectDBDataModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiciTrainingPlanDAL
{
    public class NedeljeManipulator : IRepository<Nedelja>
    {
        private long IDSezone;
        private long IDBicikliste;

        public NedeljeManipulator() { }
        public NedeljeManipulator(long IDSezone, long IDBicikliste)
        {
            this.IDBicikliste = IDBicikliste;
            this.IDSezone = IDSezone;
        }
        public void Delete(long ID)
        {
            throw new NotImplementedException();
        }

        public List<Nedelja> GetData()
        {
            using (var db = new ProjectDB())
            {
                var query = from nedelja in db.Nedeljas where (nedelja.ID_Sezone == IDSezone && nedelja.ID_Bicikliste == IDBicikliste)
                            orderby nedelja.Broj_nedelje
                            select nedelja;

                return query.ToList();
            }
        }

        public void Insert(Nedelja entity)
        {
            var nedelja = entity as Nedelja;
            if (nedelja != null)
            {
                using (var db = new ProjectDB())
                {
                    var customers = db.Set<Nedelja>();
                    customers.Add(nedelja);
                    db.SaveChanges();
                }
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public Nedelja GetOneData(long brojNedelje, long seasonID, long biciklistaID)
        {
            using (var db = new ProjectDB())
            {
                var query = from ned in db.Nedeljas
                            where (ned.ID_Sezone == seasonID && ned.Broj_nedelje==brojNedelje && ned.ID_Bicikliste == biciklistaID)
                            select ned;

                var nedelja = query.FirstOrDefault();
                return nedelja;
            }
        }

        public void Update(Nedelja entity)
        {
            var nedelja = entity as Nedelja;
            if (nedelja != null)
            {
                using (var db = new ProjectDB())
                {
                    var result = db.Nedeljas.SingleOrDefault(b => b.Broj_nedelje == nedelja.Broj_nedelje && b.ID_Sezone == nedelja.ID_Sezone);
                    if (result != null)
                    {
                        result.ID_Trening_perioda = nedelja.ID_Trening_perioda;
                        result.Opis = nedelja.Opis;
                        db.SaveChanges();
                    }
                    else
                    {
                        throw new NullReferenceException();
                    }
                }
            }
        }
    }
}
