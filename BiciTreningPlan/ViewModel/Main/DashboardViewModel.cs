using BiciTreningPlan.Command;
using BiciTreningPlanBLL;
using ProjectDBDataModel.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BiciTreningPlan.ViewModel.Main
{
    class DashboardViewModel:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

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

        private ObservableCollection<Vreme> vreme;// = new ObservableCollection<ProjectDBDataModel.Entity.Vreme>() { new Vreme() {Slika="" } };
        public ObservableCollection<Vreme> Vreme
        {
            get { return vreme; }
            set
            {
                vreme = value;
                RaisePropertyChanged("Vreme");
            }
        }
        public ICommand Loaded { get; set; }

        public DashboardViewModel()
        {
            Loaded = new RelayCommand(Load);
            Vreme = new ObservableCollection<Vreme> { NewVreme(), NewVreme(), NewVreme(), NewVreme(), NewVreme() };
        }

        private Vreme NewVreme()
        {
            Vreme vreme = new Vreme()
            {
                Brzina_vetra = 0,
                Temperatura = 0,
                Smer_vetra=0,
                Vlaznost_vazduha =0,
                Oblacnost=0,
                Opis="N/A",
                Slika="N/A"
            };
            return vreme;
        }

        private void Load(object obj)
        {
            IsBusy = true;

            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += (o, ea) =>
            {
                Weather vreme = new Weather();
                try
                {
   //                 vreme.GetWeatherFromServer();                   
                }
                finally
                {
                    Vreme = new ObservableCollection<Vreme>(vreme.GetTop6());
                }
            };
            worker.RunWorkerCompleted += (o, ea) =>
            {
                IsBusy = false;
            };

            worker.RunWorkerAsync();
        }
        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
