using BiciTreningPlan.Model;
using BiciTreningPlanBLL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiciTreningPlan.ViewModel.Main
{
    class RiderProfileViewModel
    {
        public RiderProfile riderProfile;
        public ObservableCollection<Rider> Riders { get; set; }
        public RiderProfileViewModel()
        {
            riderProfile = new RiderProfile();
            riderProfile.getDataFromDAL();
            //Riders = new ObservableCollection<Rider>();
        }
    }
}
