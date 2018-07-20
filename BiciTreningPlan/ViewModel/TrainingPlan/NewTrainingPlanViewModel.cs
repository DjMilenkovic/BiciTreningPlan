using BiciTreningPlan.Command;
using BiciTreningPlan.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BiciTreningPlan.ViewModel.TrainingPlan
{
    class NewTrainingPlanViewModel
    {
        WindowService service = new WindowService();
        ICommand openAddNewRaces;

        public NewTrainingPlanViewModel() {
            OpenAddNewRaces = new RelayCommand(ShowWindow);
        }

        public ICommand OpenAddNewRaces
        {
            get
            {
                return openAddNewRaces;
            }
            set
            {
                openAddNewRaces = value;
            }
        }

        public void ShowWindow(Object obj)
        {
            service.showWindow(new RacesInSeasonViewModel(), "Trke u sezoni");
        }
    }
}
