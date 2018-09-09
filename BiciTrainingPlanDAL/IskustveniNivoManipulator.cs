using ProjectDBDataModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BiciTrainingPlanDAL
{
   public class IskustveniNivoManipulator : IRepository<Iskustveni_Nivo>
    {          
        
        public void Delete(long ID)
        {
            throw new NotImplementedException();
        }

        public List<Iskustveni_Nivo> GetData()
        {
            using (var db = new ProjectDB())
            {
                var query = from b in db.Iskustveni_Nivo
                            orderby b.ID
                            select b;

                return query.ToList();
            }
        }

        public void Insert(Iskustveni_Nivo entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Iskustveni_Nivo entity)
        {
            throw new NotImplementedException();
        }        
    }
}
