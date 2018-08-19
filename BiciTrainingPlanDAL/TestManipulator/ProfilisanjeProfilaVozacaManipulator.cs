using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiciTrainingPlanDAL.TestManipulator
{
    class ProfilisanjeProfilaVozacaManipulator : IDataManipulator<Profilisanje_Profila_Vozaca>
    {
        long IDBicikliste;

        public ProfilisanjeProfilaVozacaManipulator(long IDBicikliste)
        {
            this.IDBicikliste = IDBicikliste;
        }

        public ProfilisanjeProfilaVozacaManipulator() { }

        public void Create(ITable tableProfilisanjeProfilaVozacaManipulator)
        {
            var testProfilisanjeProfilaVozaca = tableProfilisanjeProfilaVozacaManipulator as Profilisanje_Profila_Vozaca;
            if (testProfilisanjeProfilaVozaca != null)
            {
                using (var db = new ProjectDBEntities())
                {
                    var customers = db.Set<Profilisanje_Profila_Vozaca>();
                    customers.Add(testProfilisanjeProfilaVozaca);
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

        public List<Profilisanje_Profila_Vozaca> GetData()
        {
            throw new NotImplementedException();
        }

        public void Update(ITable table)
        {
            throw new NotImplementedException();
        }
    }
}
