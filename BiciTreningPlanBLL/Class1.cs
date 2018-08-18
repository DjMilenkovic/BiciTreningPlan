using BiciTrainingPlanDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiciTreningPlanBLL
{
    public class Class1
    {
        public void getDataFromDAL()
        {
            GetData data = new GetData();
            data.GetDataFromDB();
        }
    }
}
