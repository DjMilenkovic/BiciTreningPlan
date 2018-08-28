using ProjectDBDataModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BiciTrainingPlanDAL.TestManipulator
{
    class TestOcenjivanjaManipulator : IRepository<Test_Ocenjivanja>
    {
        long IDBicikliste;

        public TestOcenjivanjaManipulator(long IDBicikliste)
        {
            this.IDBicikliste = IDBicikliste;
        }

        public TestOcenjivanjaManipulator() { }
        

        public void Delete(long ID)
        {
            throw new NotImplementedException();
        }

        public List<Test_Ocenjivanja> GetData()
        {
            using (var db = new ProjectDBEntities())
            {
                var query = from b in db.Test_Ocenjivanja
                            where b.ID_Bicikliste == IDBicikliste
                            select b;

                return query.ToList();
            }
        }

        public void Insert(Test_Ocenjivanja entity)
        {
            var testOcenjivanja = entity as Test_Ocenjivanja;
            if (testOcenjivanja != null)
            {
                using (var db = new ProjectDBEntities())
                {
                    var customers = db.Set<Test_Ocenjivanja>();
                    customers.Add(testOcenjivanja);
                    db.SaveChanges();
                }
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public void Update(Test_Ocenjivanja entity)
        {
            throw new NotImplementedException();
        }
    }
}
