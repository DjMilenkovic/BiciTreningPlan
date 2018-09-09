using ProjectDBDataModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiciTrainingPlanDAL.RaceManipulator
{
    public class DnevniTreningPeriodiManipulator : IRepository<Dnevni_Trening_Periodi>
    {
        private long IDDana;
        private long IDTreningPerioda;
        public DnevniTreningPeriodiManipulator(long IDDana, long IDTreningPerioda)
        {
            this.IDDana = IDDana;
            this.IDTreningPerioda = IDTreningPerioda;
        }

        public void Delete(long ID)
        {
            throw new NotImplementedException();
        }

        public List<Dnevni_Trening_Periodi> GetData()
        {
            using (var db = new ProjectDB())
            {
                var query = from dtp in db.Dnevni_Trening_Periodi
                            where dtp.ID_Dana == IDDana && dtp.ID_Trening_period == IDTreningPerioda
                            select dtp;

                return query.ToList();
            }
        }

        public void Insert(Dnevni_Trening_Periodi entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Dnevni_Trening_Periodi entity)
        {
            throw new NotImplementedException();
        }
    }
}
