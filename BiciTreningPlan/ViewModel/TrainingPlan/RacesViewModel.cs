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
    class RacesViewModel : INotifyPropertyChanged
    {
        WindowService service = new WindowService();

        public event PropertyChangedEventHandler PropertyChanged;

        public Putanja SelectedPutanja { get; set; }

        private ObservableCollection<Putanja> putanje;
        public ObservableCollection<Putanja> Putanje
        {
            get { return putanje; }
            set
            {
                putanje = value;
                RaisePropertyChanged("Putanje");
            }
        }

        private object selectedTrka;
        public object SelectedTrka
        {
            get { return selectedTrka; }
            set
            {
                selectedTrka = value;
                RaisePropertyChanged("SelectedTrka");
            }
        }

        private ObservableCollection<dynamic> listaTrka;
        public ObservableCollection<dynamic> ListaTrka
        {
            get { return listaTrka; }
            set
            {
                listaTrka = value;
                RaisePropertyChanged("ListaTrka");
            }
        }

        private string nazivTrke;
        public string NazivTrke
        {
            get { return nazivTrke; }
            set
            {
                nazivTrke = value;
                RaisePropertyChanged("NazivTrke");
            }
        }

        private long IDBicikliste;
        private IMsgBoxService msgBox;
        public ICommand OpenAddNewRoutes { get; set; }

        public ICommand Loaded { get; set; }
        public ICommand Save { get; set; }
        public ICommand Delete { get; set; }

        public RacesViewModel()
        {
            IDBicikliste = Properties.Settings.Default.BiciklistaID;
            OpenAddNewRoutes = new RelayCommand(ShowWindow);
            Save = new RelayCommand(insertIntoDAL);
            Loaded = new RelayCommand(loaded);
            Delete = new RelayCommand(delete);
            msgBox = new MsgBoxService();
            SelectedPutanja = new Putanja();
            ListaTrka = new ObservableCollection<dynamic>();
        }

        private void delete(object obj)
        {
            try
            {
                if (msgBox.AskForConfirmation("Da li ste sigurni da želite da obrišete trku?") == true)
                {
                    var m = (long)SelectedTrka.GetType().GetProperty("ID").GetValue(SelectedTrka, null);

                    RacesList trka = new RacesList();
                    trka.deleteIntoDAL(m);
                    LoadTrke();
                    msgBox.ShowNotification("Uspešno ste obrisali trku");
                }
            }
            catch (Exception)
            {
                msgBox.ShowError("Došlo je do greške!");
            }
        }

        private void loaded(object obj)
        {
            LoadPutanje();
            LoadTrke();
        }

        private void insertIntoDAL(object obj)
        {
            if (SelectedPutanja != null)
            {
                Lista_Trka trka = new Lista_Trka();
                trka.ID_Bicikliste = IDBicikliste;
                trka.Naziv_trke = NazivTrke;
                trka.ID_Putanje = SelectedPutanja.ID;

                try
                {
                    if (msgBox.AskForConfirmation("Da li ste sigurni da želite da dodate trku?") == true)
                    {
                        RacesList race = new RacesList();
                        race.insertIntoDAL(trka);
                        msgBox.ShowNotification("Uspešno ste dodali trku.");
                        LoadTrke();
                    }
                }
                catch (Exception)
                {
                    msgBox.ShowError("Došlo je do greške!");
                }
            }
            else
            {
                msgBox.ShowError("Morate izabrati putanju!");
            }
        }

        private void LoadPutanje()
        {
            Routes route = new Routes();
            Putanje = new ObservableCollection<Putanja>(route.getPutanje(IDBicikliste));
        }

        private void LoadTrke()
        {
            RacesList trka = new RacesList();
            ListaTrka = new ObservableCollection<dynamic>(trka.getDataFromDALWithJoin(IDBicikliste));
        }

        public void ShowWindow(Object obj)
        {
            service.showWindow(new RoutesViewModel(), "Putanje");
            LoadPutanje();
        }

        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
