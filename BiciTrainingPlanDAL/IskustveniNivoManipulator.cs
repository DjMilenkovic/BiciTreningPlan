using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiciTrainingPlanDAL
{
    class IskustveniNivoManipulator : IDataManipulator<Iskustveni_Nivo>
    {
      
        public void Create(ITable table)
        {
            throw new NotImplementedException();
        }
        
        public void Delete(long ID)
        {
            throw new NotImplementedException();
        }

        public List<Iskustveni_Nivo> GetData()
        {
            using (var db = new ProjectDBEntities())
            {
                var query = from b in db.Iskustveni_Nivo
                            orderby b.ID
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
