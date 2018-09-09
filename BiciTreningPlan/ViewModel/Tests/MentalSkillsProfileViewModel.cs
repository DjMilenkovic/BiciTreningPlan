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
    class MentalSkillsProfileViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<int> visualisation;
        public ObservableCollection<int> Visualisation
        {
            get { return visualisation; }
            set
            {
                visualisation = value;
                RaisePropertyChanged("Visualisation");
            }
        }

        private ObservableCollection<int> motivation;
        public ObservableCollection<int> Motivation
        {
            get { return motivation; }
            set
            {
                motivation = value;
                RaisePropertyChanged("Motivation");
            }
        }

        private ObservableCollection<int> focus;
        public ObservableCollection<int> Focus
        {
            get { return focus; }
            set
            {
                focus = value;
                RaisePropertyChanged("Focus");
            }
        }

        private ObservableCollection<int> habit;
        public ObservableCollection<int> Habit
        {
            get { return habit; }
            set
            {
                habit = value;
                RaisePropertyChanged("Habit");
            }
        }

        private ObservableCollection<int> confidence;
        public ObservableCollection<int> Confidence
        {
            get { return confidence; }
            set
            {
                confidence = value;
                RaisePropertyChanged("Confidence");
            }
        }

        private Dictionary<int, string> comboBoxDisplay;
        private long IDBicikliste;

        public Dictionary<int, string> ComboBoxDisplay
        {
            get { return comboBoxDisplay; }
            set
            {
                comboBoxDisplay = value;
                RaisePropertyChanged("ComboBoxDisplay");
            }
        }

        public ICommand Save { get; set; } 
        

        public MentalSkillsProfileViewModel()
        {
            IDBicikliste = Properties.Settings.Default.BiciklistaID;

            ComboBoxDisplay = new Dictionary<int, string>();
            ComboBoxDisplay.Add(1, "Nikad");
            ComboBoxDisplay.Add(2, "Retko");
            ComboBoxDisplay.Add(3, "Ponekad");
            ComboBoxDisplay.Add(4, "Često");
            ComboBoxDisplay.Add(5, "Obično");
            ComboBoxDisplay.Add(6, "Uvek");

            Visualisation = new ObservableCollection<int> { 1, 1, 1, 1, 1, 1 };
            Motivation = new ObservableCollection<int> { 1, 1, 1, 1, 1, 1 };
            Focus = new ObservableCollection<int> { 1, 1, 1, 1, 1, 1 };
            Habit = new ObservableCollection<int> { 1, 1, 1, 1, 1, 1 };
            Confidence = new ObservableCollection<int> { 1, 1, 1, 1, 1, 1 };

            Save = new RelayCommand(InsertMentalSkills);
        }

        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void InsertMentalSkills(object obj)
        {
            MentalSkill mental = new MentalSkill();
            mental.insertIntoDAL(Visualisation, Motivation, Focus, Habit, Confidence, IDBicikliste);
        }
    }
}
