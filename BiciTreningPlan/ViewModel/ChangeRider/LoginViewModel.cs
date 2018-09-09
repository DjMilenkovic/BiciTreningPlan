using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectDBDataModel.Entity;
using System.Collections.ObjectModel;
using System.Windows.Input;
using BiciTreningPlan.Command;
using BiciTreningPlan.Services;
using BiciTreningPlanBLL;
using System.ComponentModel;

namespace BiciTreningPlan.ViewModel.ChangeRider
{
    class LoginViewModel : INotifyPropertyChanged
    {
        IMsgBoxService msgBox;

        public event PropertyChangedEventHandler PropertyChanged;

        public Biciklista SelectedCyclist { get; set; }
        private ObservableCollection<Biciklista> listaBiciklista;
        public ObservableCollection<Biciklista> ListaBiciklista
        {
            get { return listaBiciklista; }
            set
            {
                listaBiciklista = value;
                RaisePropertyChanged("ListaBiciklista");
            }
        }
      
        private long IDBicikliste;

        
        public ICommand Loaded { get; set; }
        public ICommand Login { get; set; }
        public ICommand Delete { get; set; }
        public LoginViewModel()
        {
            IDBicikliste = Properties.Settings.Default.BiciklistaID;
            Loaded = new RelayCommand(LoadList);
            Login = new RelayCommand(LoginUser);
            Delete = new RelayCommand(DeleteUser);
            msgBox = new MsgBoxService();
        }

        private void DeleteUser(object obj)
        {
            if (SelectedCyclist != null)
            {
                if (SelectedCyclist.ID == Properties.Settings.Default.BiciklistaID)
                {
                    msgBox.ShowError("Nije moguće obrisati samog sebe!");
                }
                else
                {

                    LoadList(null);
                    msgBox.ShowNotification("Uspešno ste obrisali korisnika.");
                }
            }
        }

        private void LoginUser(object obj)
        {
            if (SelectedCyclist != null)
            {
                Properties.Settings.Default.BiciklistaID = SelectedCyclist.ID;
                Properties.Settings.Default.Ime = SelectedCyclist.Ime + " "+ SelectedCyclist.Prezime;
                Properties.Settings.Default.Slika = SelectedCyclist.Slika;
                Properties.Settings.Default.Save();
                msgBox.ShowNotification("Uspešno ste se prijavili.");
            }
        }

        private void LoadList(object obj)
        {
            RiderProfile biciklista = new RiderProfile();
            ListaBiciklista = new ObservableCollection<Biciklista>(biciklista.getDataFromDAL());
        }

        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
