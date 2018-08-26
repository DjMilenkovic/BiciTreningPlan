using System.Collections.Generic;

namespace BiciTrainingPlanDAL
{
    public interface IRepository<T>
    {
        void Insert(T entity);
        void Update(T entity);
        void Delete(long ID);
        List<T> GetData();
    }
}
