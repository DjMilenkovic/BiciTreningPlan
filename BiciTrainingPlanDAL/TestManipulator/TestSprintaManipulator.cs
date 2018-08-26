using BiciTrainingPlanDAL.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiciTrainingPlanDAL.TestManipulator
{
    class TestSprintaManipulator : IRepository<Sprint_Test>
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
