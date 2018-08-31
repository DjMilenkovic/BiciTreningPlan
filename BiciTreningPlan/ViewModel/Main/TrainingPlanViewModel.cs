using BiciTreningPlan.ViewModel.TrainingPlan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BiciTreningPlan.Services;
using BiciTreningPlan.Command;
using ProjectDBDataModel.Entity;
using System.Collections.ObjectModel;

namespace BiciTreningPlan.ViewModel.Main
{
    class TrainingPlanViewModel
    {
        WindowService service = new WindowService();
        public Trening_Dani TreningDan { get; set; }
        ObservableCollection<Trening_Dani> TrainingPlanList { get; set; }
        public ICommand TrainingInformation { get; set; }
        public ICommand OpenNewTrainingPlan { get; set; }

        public TrainingPlanViewModel(){
            OpenNewTrainingPlan = new RelayCommand(ShowWindow);
            TrainingInformation = new RelayCommand(ShowInformation);
        //    TrainingPlanList = 
        }

        private void ShowInformation(object obj)
        {
            if(TreningDan!=null)
                service.showWindow(new DescriptionViewModel(TreningDan), "Informacije o treningu");
        }

        public void ShowWindow(object obj)
        {
            service.showWindow(new NewTrainingPlanViewModel(), "Novi Trening Plan");
        }
    }
}