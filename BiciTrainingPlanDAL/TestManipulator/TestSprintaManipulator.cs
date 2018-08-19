using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiciTrainingPlanDAL.TestManipulator
{
    class TestSprintaManipulator : IDataManipulator<Sprint_Test>
    {
        long IDBicikliste;

        public TestSprintaManipulator(long IDBicikliste)
        {
            this.IDBicikliste = IDBicikliste;
        }

        public TestSprintaManipulator() { }

        public void Create(ITable tableTestSprintaManipulator)
        {
            var testSprinta = tableTestSprintaManipulator as Sprint_Test;
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

        public void Update(ITable table)
        {
            throw new NotImplementedException();
        }
    }
}
