using ProjectDBDataModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiciTrainingPlanDAL
{
    public class VremeManipulator : IRepository<Vreme>
    {
        public void Delete(long ID)
        {
            throw new NotImplementedException();
        }

        public List<Vreme> GetData()
        {
            using (var db = new ProjectDB())
            {
                var query = from b in db.Vremes                            
                            select b;

                return query.DefaultIfEmpty().ToList();
            }
        }

        public void Insert(Vreme entity)
        {
            var vreme = entity as Vreme;
            if (vreme != null)
            {
                using (var db = new ProjectDB())
                {
                    var customers = db.Set<Vreme>();
                    customers.Add(vreme);
                    db.SaveChanges();
                }
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public void Update(Vreme entity)
        {
            throw new NotImplementedException();
        }
    }
}
