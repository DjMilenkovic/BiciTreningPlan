using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiciTrainingPlanDAL.TestManipulator
{
    class TestPrirodnihSposobnostiVozacaManipulator : IDataManipulator<Prirodne_Sposobnosti>
    {
        long IDBicikliste;

        public TestPrirodnihSposobnostiVozacaManipulator(long IDBicikliste)
        {
            this.IDBicikliste = IDBicikliste;
        }

        public TestPrirodnihSposobnostiVozacaManipulator() { }

        public void Create(ITable tableTestPrirodnihSposobnostiVozacaManipulator)
        {
            var testPrirodnihSposobnostiVozaca = tableTestPrirodnihSposobnostiVozacaManipulator as Prirodne_Sposobnosti;
            if (testPrirodnihSposobnostiVozaca != null)
            {
                using (var db = new ProjectDBEntities())
                {
                    var customers = db.Set<Prirodne_Sposobnosti>();
                    customers.Add(testPrirodnihSposobnostiVozaca);
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

        public List<Prirodne_Sposobnosti> GetData()
        {
            using (var db = new ProjectDBEntities())
            {
                var query = from b in db.Prirodne_Sposobnosti
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
