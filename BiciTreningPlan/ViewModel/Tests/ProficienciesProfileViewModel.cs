using BiciTreningPlan.Command;
using BiciTreningPlanBLL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BiciTreningPlan.ViewModel.Tests
{
    class ProficienciesProfileViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<int> sprint;
        public ObservableCollection<int> Sprint
        {
            get { return sprint; }
            set
            {
                sprint = value;
                RaisePropertyChanged("Sprint");
            }
        }
        private ObservableCollection<int> climb;
        public ObservableCollection<int> Climb
        {
            get { return climb; }
            set
            {
                climb = value;
                RaisePropertyChanged("Climb");
            }
        }
        private ObservableCollection<int> tt;
        public ObservableCollection<int> TT
        {
            get { return tt; }
            set
            {
                tt = value;
                RaisePropertyChanged("TT");
            }
        }

        private long IDBicikliste;

        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand Save { get; set; }

        public Dictionary<int, string> ComboBoxDisplay { get; set; }

        public ProficienciesProfileViewModel()
        {
            IDBicikliste = Properties.Settings.Default.BiciklistaID;
            ComboBoxDisplay = new Dictionary<int, string>();
            ComboBoxDisplay.Add(0, "Ne slažem se");
            ComboBoxDisplay.Add(1, "Slažem se");

            Sprint = new ObservableCollection<int> { 0, 0, 0, 0, 0 };
            Climb = new ObservableCollection<int> { 0, 0, 0, 0, 0 };
            TT = new ObservableCollection<int> { 0, 0, 0, 0, 0 };

            Save = new RelayCommand(InsertProficienciesProfile);
        }

        private void InsertProficienciesProfile(object obj)
        {
            ProficienciesProfile natural = new ProficienciesProfile();
            natural.insertIntoDAL(Sprint, Climb, TT, IDBicikliste);
        }
    }
}
