using ProjectDBDataModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BiciTrainingPlanDAL.TestManipulator
{
    public class TestMentalnihSposobnostiManipulator : IRepository<Mentalne_Sposobnosti>
    {
        long IDBicikliste;

        public TestMentalnihSposobnostiManipulator(long IDBicikliste)
        {
            this.IDBicikliste = IDBicikliste;
        }

        public TestMentalnihSposobnostiManipulator() { }
    
        public void Delete(long ID)
        {
            throw new NotImplementedException();
        }

        public Mentalne_Sposobnosti GetOneData(long iD)
        {
            using (var db = new ProjectDBEntities())
            {
                var query = (from b in db.Mentalne_Sposobnosti
                            where b.ID_Bicikliste == IDBicikliste
                            orderby b.Datum_testiranja descending
                            select b).FirstOrDefault();
                
                return query;
            }        
        }

        public List<Mentalne_Sposobnosti> GetData()
        {
            using (var db = new ProjectDBEntities())
            {
                var query = from b in db.Mentalne_Sposobnosti
                            where b.ID_Bicikliste == IDBicikliste
                            select b;

                return query.ToList();
            }
        }

        public void Insert(Mentalne_Sposobnosti entity)
        {
            var testMentalnihSposobnosti = entity as Mentalne_Sposobnosti;
            if (testMentalnihSposobnosti != null)
            {
                using (var db = new ProjectDBEntities())
                {
                    var customers = db.Set<Mentalne_Sposobnosti>();
                    customers.Add(testMentalnihSposobnosti);
                    db.SaveChanges();
                }
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public void Update(Mentalne_Sposobnosti entity)
        {
            throw new NotImplementedException();
        }
    }
}
