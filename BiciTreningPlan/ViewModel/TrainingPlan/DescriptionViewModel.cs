using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectDBDataModel.Entity;
using BiciTreningPlanBLL;

namespace BiciTreningPlan.ViewModel.TrainingPlan
{
    class DescriptionViewModel
    {
        public string Date { get { return trainingDay.Datum_treninga.ToShortDateString(); } }
        public string TrainingType { get { return trainingType.Naziv; } }
        public string Description { get { return trainingType.Opis; } }
        public string Duration { get { return trainingDay.Vreme_treninga; } }
        public string TrainingPeriod { get { return trainingPeriod.Naziv; } }
        public string PeriodDescription { get { return trainingPeriod.Opis; } }
        public Trening_Periodi trainingPeriod { get; set; }
        public Tipovi_Treninga trainingType { get; set; }
        public Trening_Dani trainingDay { get; set; }
        public Treninzi trainings { get; set; }

        public DescriptionViewModel(DateTime trainindDayDate)
        {
            //this.trainingDay = trainindDayDate;
//            ID_Treninga = trainingDay.ID_Treninga;
        }

        public void setTrainingPeriod()
        {
          //  TrainingPeriods period = new TrainingPeriods(IDBicikliste,IDSezone);
         //   trainingPeriod = period.getDataFromDAL(trainingDay.ID_Treninga);
            //send PeriodID
        }

        public void setTrainingType()
        {
            //send TypeID
        }

        //Trening period
        //Trening tip

    }
}
