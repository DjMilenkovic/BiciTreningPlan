using BiciTreningPlan.Command;
using BiciTreningPlan.Services;
using BiciTreningPlanBLL;
using ProjectDBDataModel.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BiciTreningPlan.ViewModel.TrainingPlan
{
    class NewTrainingPlanViewModel : INotifyPropertyChanged
    {
        WindowService service = new WindowService();

        private ObservableCollection<object> racesList;
        public ObservableCollection<dynamic> RacesList
        {
            get { return racesList; }
            set
            {
                racesList = value;
                RaisePropertyChanged("RacesList");
            }
        }

        private ObservableCollection<DateTime> selectedList;
        public ObservableCollection<DateTime> SelectedList
        {
            get { return selectedList; }
            set
            {
                selectedList = value;
                RaisePropertyChanged("SelectedList");
            }
        }

        public ICommand OpenAddNewRaces { get; set; }
        public ICommand Loaded { get; set; }
        public ICommand TrainingPlan { get; set; }

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

        private string time;
        public string Time
        {
            get { return time; }
            set
            {
                time = value;
                RaisePropertyChanged("Time");
            }
        }

        private long IDBicikliste;
        private long IDSeason;

        IMsgBoxService msgBox;

        public event PropertyChangedEventHandler PropertyChanged;

        public NewTrainingPlanViewModel() {
            IDBicikliste = Properties.Settings.Default.BiciklistaID;
            IDSeason = Properties.Settings.Default.SezonaID;
            OpenAddNewRaces = new RelayCommand(ShowWindow);
            Loaded = new RelayCommand(loaded);
            TrainingPlan = new RelayCommand(GenerateNewTrainingPlan);
            SelectedList = new ObservableCollection<DateTime> { DateTime.Today, DateTime.Today, DateTime.Today };
            msgBox = new MsgBoxService();
        }

        private void loaded(object obj)
        {
            IsBusy = true;

            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += (o, ea) =>
            {
                PredlogDuzineTreninga();
                NewSeason();
                LoadRacesList();
            };
            worker.RunWorkerCompleted += (o, ea) =>
            {
                IsBusy = false;               
            };

            worker.RunWorkerAsync();           
        }

        private void GenerateNewTrainingPlan(object obj)
        {
            IsBusy = true;

            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += (o, ea) =>
            {
                Weeks week = new Weeks(IDSeason, IDBicikliste);
                RacesInSeason trkeUSezoni = new RacesInSeason();
                DateTime LastRaceDate = trkeUSezoni.getMaxRaceID(IDBicikliste, IDSeason);
                week.insertIntoDAL(LastRaceDate);

                TrainingPeriods treningPeriodi = new TrainingPeriods(IDBicikliste,IDSeason);
                treningPeriodi.InsertTrainingPeriodsToWeeks(SelectedList.ToList());

                TrainingDays treningDani = new TrainingDays(IDBicikliste, IDSeason);
                treningDani.insertIntoDAL();

            };
            worker.RunWorkerCompleted += (o, ea) =>
            {
                IsBusy = false;
                msgBox.ShowNotification("Uspešno kreiran trening plan, možete se vratiti na prethodni prozor.");
            };

            worker.RunWorkerAsync();
        }

        private void LoadRacesList()
        {
            RacesInSeason seasonRaces = new RacesInSeason();
            RacesList = new ObservableCollection<dynamic>(seasonRaces.getDataFromDALWithJoin(IDBicikliste, IDSeason));
        }

        private void PredlogDuzineTreninga()
        {
            Season sezona = new Season();
            Time = sezona.GetTime(IDBicikliste);
        }

        private void NewSeason()
        {
            Season sezona = new Season();
            sezona.InsertIntoDAL(IDBicikliste);
            Properties.Settings.Default.SezonaID = sezona.GetSeasonID(IDBicikliste);
            Properties.Settings.Default.Save();
            IDSeason = Properties.Settings.Default.SezonaID;
        }

        public void ShowWindow(Object obj)
        {
            service.showWindow(new RacesInSeasonViewModel(), "Trke u sezoni");
            LoadRacesList();
        }

        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
