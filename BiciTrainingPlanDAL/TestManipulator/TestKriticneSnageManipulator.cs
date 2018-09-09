using ProjectDBDataModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BiciTrainingPlanDAL
{
    public class TestKriticneSnageManipulator : IRepository<Test_Kriticne_Snage>
    {
        long IDBicikliste;

        public TestKriticneSnageManipulator(long IDBicikliste)
        {
            this.IDBicikliste = IDBicikliste;
        }

        public TestKriticneSnageManipulator(){}

        public void Delete(long ID)
        {
            throw new NotImplementedException();
        }

        public List<Test_Kriticne_Snage> GetData()
        {
            using (var db = new ProjectDB())
            {
                var query = from b in db.Test_Kriticne_Snage
                            where b.ID_Bicikliste == IDBicikliste
                            select b;

                return query.ToList();
            }
        }               

        public void Insert(Test_Kriticne_Snage entity)
        {
            var testKriticneSnageManipulator = entity as Test_Kriticne_Snage;
            if (testKriticneSnageManipulator != null)
            {
                using (var db = new ProjectDB())
                {
                    var customers = db.Set<Test_Kriticne_Snage>();
                    customers.Add(testKriticneSnageManipulator);
                    db.SaveChanges();
                }
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public void Update(Test_Kriticne_Snage entity)
        {
            throw new NotImplementedException();
        }
    }
}
