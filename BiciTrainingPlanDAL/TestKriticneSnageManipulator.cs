using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiciTrainingPlanDAL
{
    public class TestKriticneSnageManipulator : IDataManipulator<Test_Kriticne_Snage>
    {
        long IDBicikliste;

        public TestKriticneSnageManipulator(long IDBicikliste)
        {
            this.IDBicikliste = IDBicikliste;
        }

        public TestKriticneSnageManipulator(){}

        public void Create(ITable tableTestKriticneSnageManipulator)
        {
            var testKriticneSnageManipulator = tableTestKriticneSnageManipulator as Test_Kriticne_Snage;
            if (testKriticneSnageManipulator != null)
            {
                using (var db = new ProjectDBEntities())
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

        public void Delete(long ID)
        {
            throw new NotImplementedException();
        }

        public List<Test_Kriticne_Snage> GetData()
        {
            using (var db = new ProjectDBEntities())
            {
                var query = from b in db.Test_Kriticne_Snage
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
