using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiciTrainingPlanDAL
{
    public interface IDataManipulator<T>
    {
        void Create(ITable table);
        void Update(ITable table);
        void Delete(long ID);
        List<T> GetData();
    }
}
