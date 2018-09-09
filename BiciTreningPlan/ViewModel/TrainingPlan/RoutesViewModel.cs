using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectDBDataModel.Entity;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Input;
using BiciTreningPlan.Command;
using BiciTreningPlan.Services;
using BiciTreningPlanBLL;

namespace BiciTreningPlan.ViewModel.TrainingPlan
{
    public class RoutesViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        
        public Tip_putanje SelectedTipPutanje { get; set; }

        private ObservableCollection<Tip_putanje> tipPutanje;
        public ObservableCollection<Tip_putanje> TipPutanje
        {
            get { return tipPutanje; }
            set
            {
                tipPutanje = value;
                RaisePropertyChanged("TipPutanje");
            }
        }

        private Putanja putanja { get; set; }
        public Putanja Putanja
        {
            get { return putanja; }
            set
            {
                putanja = value;                
                RaisePropertyChanged("Putanja");
            }
        }

        private object selectedPutanja;
        public object SelectedPutanja
        {
            get { return selectedPutanja; }
            set
            {
                selectedPutanja = value;
                RaisePropertyChanged("SelectedPutanja");
            }
        }

        private ObservableCollection<dynamic> listaPutanji;
        public ObservableCollection<dynamic> ListaPutanji
        {
            get { return listaPutanji; }
            set
            {
                listaPutanji = value;
                RaisePropertyChanged("ListaPutanji");
            }
        }

        private long IDBicikliste;
        private IMsgBoxService msgBox;

        public ICommand Loaded { get; set; }
        public ICommand Save { get; set; }
        public ICommand Delete { get; set; }

        public RoutesViewModel()
        {
            IDBicikliste = Properties.Settings.Default.BiciklistaID;
            Save = new RelayCommand(insertIntoDAL);
            Loaded = new RelayCommand(loaded);
            Delete = new RelayCommand(delete);
            msgBox = new MsgBoxService();
            SelectedTipPutanje = new Tip_putanje();
            ListaPutanji = new ObservableCollection<dynamic>();
        }

        private void delete(object obj)
        {
            try
            {
                if (msgBox.AskForConfirmation("Da li ste sigurni da želite da dodate test?") == true)
                {
                    var m = (long)SelectedPutanja.GetType().GetProperty("ID").GetValue(SelectedPutanja, null);

                    Routes route = new Routes();
                    route.deleteIntoDAL(m);
                    ListaPutanji = new ObservableCollection<dynamic>(route.getPutanjeWithJoin(IDBicikliste));
                }
            }
            catch (Exception)
            {
                msgBox.ShowError("Došlo je do greške!");
            }
        }

        private void loaded(object obj)
        {            
            Putanja = new Putanja();
            getRoutesAndRoutesType();
        }

        private void getRoutesAndRoutesType()
        {
            Routes route = new Routes();
            TipPutanje = new ObservableCollection<Tip_putanje>(route.getTipPutanje());
            ListaPutanji = new ObservableCollection<dynamic>(route.getPutanjeWithJoin(IDBicikliste));
        }

        private void insertIntoDAL(object obj)
        {
            Putanja putanja = new Putanja();
            putanja.ID_Bicikliste = IDBicikliste;
            putanja.Pocetno_odrediste = Putanja.Pocetno_odrediste;
            putanja.Odrediste_izmedju = Putanja.Odrediste_izmedju;
            putanja.Krajnje_odrediste = Putanja.Krajnje_odrediste;
            putanja.Cela_putanja = putanja.Pocetno_odrediste + " - " + putanja.Odrediste_izmedju + " - " + putanja.Krajnje_odrediste;
            putanja.ID_Tip_putanje = SelectedTipPutanje.ID;

            try
            {
                if (msgBox.AskForConfirmation("Da li ste sigurni da želite da dodate test?") == true)
                {     
                    Routes route = new Routes();
                    route.insertIntoDAL(putanja);
                    msgBox.ShowNotification("Uspešno ste dodali test.");
                    ListaPutanji = new ObservableCollection<dynamic>(route.getPutanjeWithJoin(IDBicikliste));
                }
            }
            catch (Exception)
            {
                msgBox.ShowError("Došlo je do greške!");
            }
        }

        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
