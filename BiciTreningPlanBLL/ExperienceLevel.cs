using BiciTrainingPlanDAL;
using ProjectDBDataModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiciTreningPlanBLL
{
    public class ExperienceLevel
    {
        public List<Iskustveni_Nivo> GetDataFromDAL()
        {
            IskustveniNivoManipulator iskustveniNivo = new IskustveniNivoManipulator();
            return iskustveniNivo.GetData();
        }
    }
}
