using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiciTrainingPlanDAL
{
    public class GetData
    {

        public IOrderedQueryable<Biciklista> GetDataFromDB()
        {
            using (var db = new ProjectDBEntities())
            {
                var query = from b in db.Biciklistas
                            orderby b.Ime
                            select b;
                return query;   
            }
        }

    }
}
