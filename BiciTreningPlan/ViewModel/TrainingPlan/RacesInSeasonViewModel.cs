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
    class RacesInSeasonViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        WindowService service = new WindowService();

        private DateTime raceDate = DateTime.Now;
        public DateTime RaceDate
        {
            get { return raceDate; }
            set
            {
                raceDate = value;
                RaisePropertyChanged("StartDate");
            }
        }

        public long SelectedTrkaID { get; set; }

        private ObservableCollection<Lista_Trka> trke;
        public ObservableCollection<Lista_Trka> Trke
        {
            get { return trke; }
            set
            {
                trke = value;
                RaisePropertyChanged("Trke");
            }
        }

        private object selectedTrkaUSezoni;
        public object SelectedTrkaUSezoni
        {
            get { return selectedTrkaUSezoni; }
            set
            {
                selectedTrkaUSezoni = value;
                RaisePropertyChanged("SelectedTrkaUSezoni");
            }
        }

        private ObservableCollection<dynamic> listaTrkaUSezoni;
        public ObservableCollection<dynamic> ListaTrkaUSezoni
        {
            get { return listaTrkaUSezoni; }
            set
            {
                listaTrkaUSezoni = value;
                RaisePropertyChanged("ListaTrkaUSezoni");
            }
        }

        private long IDBicikliste;
        private long IDSezone;

        public ICommand OpenAddNewRaces { get; set; }
        public ICommand Loaded { get; set; }
        public ICommand Save { get; set; }
        public ICommand Delete { get; set; }
        private IMsgBoxService msgBox;
        public RacesInSeasonViewModel()
        {            
            IDSezone = Properties.Settings.Default.SezonaID;
            IDBicikliste = Properties.Settings.Default.BiciklistaID;
            OpenAddNewRaces = new RelayCommand(ShowWindow);
            Loaded = new RelayCommand(Load);
            Save = new RelayCommand(SaveRace);
            Delete = new RelayCommand(DeleteRace);
            SelectedTrkaID = 0;
            msgBox = new MsgBoxService();
        }

        private void DeleteRace(object obj)
        {
            try
            {
                if (msgBox.AskForConfirmation("Da li ste sigurni da želite da obrišete trku?") == true)
                {
                    var IDTrke = (long)SelectedTrkaUSezoni.GetType().GetProperty("ID").GetValue(SelectedTrkaUSezoni, null);

                    RacesInSeason trka = new RacesInSeason();
                    trka.deleteIntoDAL(IDSezone, IDBicikliste, IDTrke);
                    LoadTrkeUSezoni();
                    msgBox.ShowNotification("Uspešno ste obrisali trku");
                }
            }
            catch (Exception)
            {
                msgBox.ShowError("Došlo je do greške!");
            }
        }

        private void SaveRace(object obj)
        {
            RacesInSeason trkeUSezoni = new RacesInSeason();
            trkeUSezoni.insertIntoDAL(IDBicikliste, IDSezone, SelectedTrkaID, RaceDate);
            LoadTrkeUSezoni();
        }

        private void Load(object obj)
        {
            LoadTrkeUSezoni();
            LoadTrke();
        }

        private void LoadTrke()
        {
            RacesList listaTrka = new RacesList();
            Trke = new ObservableCollection<Lista_Trka>(listaTrka.getDataFromDAL(IDBicikliste));
        }

        private void LoadTrkeUSezoni()
        {
            RacesInSeason trkeUSezoni = new RacesInSeason();
            ListaTrkaUSezoni = new ObservableCollection<dynamic>(trkeUSezoni.getDataFromDALWithJoin(IDBicikliste, IDSezone));
        }

        public void ShowWindow(Object obj)
        {
            service.showWindow(new RacesViewModel(), "Trke");
            LoadTrke();
        }
        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }    
}
