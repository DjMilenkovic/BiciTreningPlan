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
    public class NaturalAbilitiesProfileViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<int> speed;
        public ObservableCollection<int> Speed
        {
            get { return speed; }
            set
            {
                speed = value;
                RaisePropertyChanged("Speed");
            }
        }
        private ObservableCollection<int> strength;
        public ObservableCollection<int> Strength
        {
            get { return strength; }
            set
            {
                strength = value;
                RaisePropertyChanged("Strength");
            }
        }
        private ObservableCollection<int> endurance;
        private long IDBicikliste;

        public ObservableCollection<int> Endurance
        {
            get { return endurance; }
            set
            {
                endurance = value;
                RaisePropertyChanged("Endurance");
            }
        }
        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand Save { get; set; }

        public Dictionary<int,string> ComboBoxDisplay { get; set; }
        public NaturalAbilitiesProfileViewModel()
        {
            IDBicikliste = Properties.Settings.Default.BiciklistaID;
            ComboBoxDisplay = new Dictionary<int, string>();
            ComboBoxDisplay.Add(0, "Ne slažem se");
            ComboBoxDisplay.Add(1, "Slažem se");

            Speed = new ObservableCollection<int> { 0, 0, 0, 0, 0 };
            Strength = new ObservableCollection<int> { 0, 0, 0, 0, 0 };
            Endurance = new ObservableCollection<int> { 0, 0, 0, 0, 0 };

            Save = new RelayCommand(InsertNaturalAbilities);
        }

        private void InsertNaturalAbilities(object obj)
        {
            NaturalAbilities natural = new NaturalAbilities();
            natural.insertIntoDAL(Speed, Strength, Endurance, IDBicikliste);
        }
    }
}
