using ProjectDBDataModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BiciTrainingPlanDAL.TestManipulator
{
    public class TestSprintaManipulator : IRepository<Sprint_Test>
    {
        long IDBicikliste;

        public TestSprintaManipulator(long IDBicikliste)
        {
            this.IDBicikliste = IDBicikliste;
        }

        public TestSprintaManipulator() { }
        
        public void Delete(long ID)
        {
            throw new NotImplementedException();
        }

        public Sprint_Test GetOneData(long ID)
        {
            using (var db = new ProjectDBEntities())
            {
                var query = (from b in db.Sprint_Test
                            where b.ID_Bicikliste == ID
                            orderby b.Datum_testiranja descending
                            select b).FirstOrDefault();
                
                return query;
            }
        }

        public List<Sprint_Test> GetData()
        {
            using (var db = new ProjectDBEntities())
            {
                var query = from b in db.Sprint_Test
                            where b.ID_Bicikliste == IDBicikliste
                            select b;

                return query.ToList();
            }
        }

        public void Insert(Sprint_Test entity)
        {
            var testSprinta = entity as Sprint_Test;
            if (testSprinta != null)
            {
                using (var db = new ProjectDBEntities())
                {
                    var customers = db.Set<Sprint_Test>();
                    customers.Add(testSprinta);
                    db.SaveChanges();
                }
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public void Update(Sprint_Test entity)
        {
            throw new NotImplementedException();
        }
    }
}
