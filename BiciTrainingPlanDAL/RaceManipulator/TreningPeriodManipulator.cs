using BiciTrainingPlanDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectDBDataModel.Entity;


namespace BiciTrainingPlanDAL.RaceManipulator
{
    public class TreningPeriodManipulator : IRepository<Trening_Periodi>
    {
        public void Delete(long ID)
        {
            throw new NotImplementedException();
        }

        public List<Trening_Periodi> GetData()
        {
            return null;
          /*  using (var db = new ProjectDB())
            {

                var query = //from trainingDan in db.Trening_Dani
                            from treninzi in db.Treninzis// on trainingDan.ID_Treninga equals treninzi.ID
                            join treningPeriod in db.Trening_Periodi on treninzi.ID_Trening_perioda equals treningPeriod.ID
                            where treninzi.ID == ID
                            select treningPeriod;

                return query;
            }*/
        }

        public Trening_Periodi GetDataWithJoin(long ID)
        {
            using (var db = new ProjectDB())
            {

                var query = //from trainingDan in db.Trening_Dani
                            from treninzi in db.Treninzis// on trainingDan.ID_Treninga equals treninzi.ID
                            join treningPeriod in db.Trening_Periodi on treninzi.ID_Trening_perioda equals treningPeriod.ID
                            where treninzi.ID == ID
                            select treningPeriod;

                return (Trening_Periodi)query;
            }
        }

        public void Insert(Trening_Periodi entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Trening_Periodi entity)
        {
            throw new NotImplementedException();
        }
    }
}
