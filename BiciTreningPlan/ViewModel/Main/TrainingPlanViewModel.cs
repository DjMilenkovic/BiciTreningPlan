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
using BiciTreningPlanBLL;
using System.ComponentModel;

namespace BiciTreningPlan.ViewModel.Main
{
    class TrainingPlanViewModel:INotifyPropertyChanged
    {
        WindowService service = new WindowService();
        private long IDBicikliste;
        private long IDSezone;

        public object TreningDan { get; set; }
        private ObservableCollection<dynamic> trainingPlanList;
        public ObservableCollection<dynamic> TrainingPlanList
        {
            get { return trainingPlanList; }
            set
            {
                trainingPlanList = value;
                RaisePropertyChanged("TrainingPlanList");
            }
        }
        public ICommand TrainingInformation { get; set; }
        public ICommand OpenNewTrainingPlan { get; set; }
        public ICommand Loaded { get; set; }

        private bool isBusy;
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                RaisePropertyChanged("IsBusy");
            }
        }

        private IMsgBoxService msg;

        public event PropertyChangedEventHandler PropertyChanged;

        public TrainingPlanViewModel(){
            IDBicikliste = Properties.Settings.Default.BiciklistaID;
            IDSezone = Properties.Settings.Default.SezonaID;
            OpenNewTrainingPlan = new RelayCommand(ShowWindow);
            TrainingInformation = new RelayCommand(ShowInformation);
            Loaded = new RelayCommand(Load);
            msg = new MsgBoxService();
        }

        private void Load(object obj)
        {
            LoadTrainingPlan();
        }

        private void ShowInformation(object obj)
        {
            var date = (DateTime)TreningDan.GetType().GetProperty("Datum_treninga").GetValue(TreningDan, null);
            if (date != null)
                service.showWindow(new DescriptionViewModel(date), "Informacije o treningu");
        }

        public void ShowWindow(object obj)
        {
            Season sezona = new Season();

            string firstMonday = sezona.GetNextMonday().ToShortDateString();
            string seasonFirstMonday = sezona.MaxDate(IDBicikliste).ToShortDateString();

            if (firstMonday == seasonFirstMonday)
            {
                if (msg.AskForConfirmation("Da li želite da kreirate novu sezonu i izbrišete postojeću sa istim datumom?"))
                {
                    DeleteSeason(DateTime.Parse(firstMonday));
                    service.showWindow(new NewTrainingPlanViewModel(), "Novi Trening Plan");
                    LoadTrainingPlan();
                }
            }
            else
            {
                service.showWindow(new NewTrainingPlanViewModel(), "Novi Trening Plan");
                LoadTrainingPlan();
            }
        }

        private async void LoadTrainingPlan()
        {
            IsBusy = true;
            await GetTraining();
            IsBusy = false;
        }

        private async Task GetTraining()
        {
            if (IDSezone != 0 && IDBicikliste != 0)
            {
                TrainingDays treningDani = new TrainingDays(IDBicikliste, IDSezone);
                await Task.Run(() =>
                {
                    TrainingPlanList = new ObservableCollection<dynamic>
                    (treningDani.getPutanjeWithJoin());
                });
            }
        }

        private void DeleteSeason(DateTime firstMonday)
        {
            Season sezona = new Season();
            sezona.DeleteToDAL(firstMonday, IDBicikliste);
        }

        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}