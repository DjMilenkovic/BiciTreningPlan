using BiciTreningPlan.ViewModel.TrainingPlan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BiciTreningPlan.Services;
using BiciTreningPlan.Command;

namespace BiciTreningPlan.ViewModel.Main
{
    class TrainingPlanViewModel
    {
        WindowService service = new WindowService();
        ICommand openNewTrainingPlan;

        public TrainingPlanViewModel(){
            OpenNewTrainingPlan = new RelayCommand(ShowWindow);
        }

        public ICommand OpenNewTrainingPlan
        {
            get
            {
                return openNewTrainingPlan;
            }
            set
            {
                openNewTrainingPlan = value; 
            }
        }

        public void ShowWindow(Object obj)
        {
            service.showWindow(new NewTrainingPlanViewModel(), "Novi Trening Plan");
        }
    }
}
