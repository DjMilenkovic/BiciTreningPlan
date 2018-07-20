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
    class RacesViewModel
    {
        WindowService service = new WindowService();
        ICommand openAddNewRoutes;

        public RacesViewModel()
        {
            OpenAddNewRoutes = new RelayCommand(ShowWindow);
        }

        public ICommand OpenAddNewRoutes
        {
            get
            {
                return openAddNewRoutes;
            }
            set
            {
                openAddNewRoutes = value;
            }
        }

        public void ShowWindow(Object obj)
        {
            service.showWindow(new RoutesViewModel(), "Putanje");
        }
    }
}
