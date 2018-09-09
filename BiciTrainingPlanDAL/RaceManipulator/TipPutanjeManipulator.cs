using ProjectDBDataModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiciTrainingPlanDAL.RaceManipulator
{
    public class TipPutanjeManipulator : IRepository<Tip_putanje>
    {
        public void Delete(long ID)
        {
            throw new NotImplementedException();
        }

        public List<Tip_putanje> GetData()
        {
            using (var db = new ProjectDB())
            {
                var query = from tipovi in db.Tip_putanje
                            select tipovi;

                return query.ToList<Tip_putanje>();
            }
        }

        public void Insert(Tip_putanje entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Tip_putanje entity)
        {
            throw new NotImplementedException();
        }
    }
}
