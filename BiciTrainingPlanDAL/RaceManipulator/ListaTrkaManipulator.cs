using ProjectDBDataModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BiciTrainingPlanDAL.RaceManipulator
{
    public class ListaTrkaManipulator : IRepository<Lista_Trka>
    {
        long IDBicikliste;

        public ListaTrkaManipulator(long IDBicikliste)
        {
            this.IDBicikliste = IDBicikliste;
        }

        public ListaTrkaManipulator() { }

        public void Delete(long ID)
        {
            using (var db = new ProjectDBEntities())
            {
                var result = db.Lista_Trka.SingleOrDefault(b => b.ID == ID);
                if (result != null)
                {
                    db.Lista_Trka.Remove(result);
                    db.SaveChanges();
                }
            }
        }

        public List<dynamic> GetDataWithJoin()
        {
            using (var db = new ProjectDBEntities())
            {
                var query = from listaTrka in db.Lista_Trka.Where(o => o.ID_Bicikliste == IDBicikliste)
                            join putanja in db.Putanjas on listaTrka.ID_Putanje equals putanja.ID into newListaTrka
                            from trke in newListaTrka.DefaultIfEmpty()
                            select new
                            {
                                listaTrka.ID,
                                listaTrka.Naziv_trke,
                                trke.Cela_putanja
                            };
                           
                return query.ToList<dynamic>();
            }
        }

        public List<Lista_Trka> GetData()
        {
            using (var db = new ProjectDBEntities())
            {
                var query = from l in db.Lista_Trka
                            orderby l.ID
                            select l;

                return query.ToList();
            }
        }
        
        public void Insert(Lista_Trka entity)
        {
            var testListaTrkaManipulator = entity as Lista_Trka;
            if (testListaTrkaManipulator != null)
            {
                using (var db = new ProjectDBEntities())
                {
                    var customers = db.Set<Lista_Trka>();
                    customers.Add(testListaTrkaManipulator);
                    db.SaveChanges();
                }
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public void Update(Lista_Trka entity)
        {
            var trka = entity as Lista_Trka;
            if (trka != null)
            {
                using (var db = new ProjectDBEntities())
                {
                    var result = db.Lista_Trka.SingleOrDefault(b => b.ID == trka.ID);
                    if (result != null)
                    {
                        result.Naziv_trke = trka.Naziv_trke;
                        result.ID_Putanje = trka.ID_Putanje;
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
