using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiciTrainingPlanDAL
{
    public interface IDataManipulator<T>
    {
        void Create();
        void Update();
        void Delete();
        List<T> GetData();
    }
}
