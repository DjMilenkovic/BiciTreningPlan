using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiciTrainingPlanDAL.TestManipulator
{
    class TestMentalnihSposobnostiManipulator : IDataManipulator<Mentalne_Sposobnosti>
    {
        long IDBicikliste;

        public TestMentalnihSposobnostiManipulator(long IDBicikliste)
        {
            this.IDBicikliste = IDBicikliste;
        }

        public TestMentalnihSposobnostiManipulator() { }

        public void Create(ITable tableTestMentalnihSposobnostiManipulator)
        {
            var testMentalnihSposobnosti = tableTestMentalnihSposobnostiManipulator as Mentalne_Sposobnosti;
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

        public void Delete(long ID)
        {
            throw new NotImplementedException();
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

        public void Update(ITable table)
        {
            throw new NotImplementedException();
        }
    }
}
