using BiciTreningPlanBLL;
using ProjectDBDataModel.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiveCharts;
using LiveCharts.Wpf;
using System.Windows.Input;
using BiciTreningPlan.Command;

namespace BiciTreningPlan.ViewModel.Main
{
    class RiderProfileViewModel : INotifyPropertyChanged
    {
        private RiderProfile riderProfile;
        private ProficienciesProfile profProfile;
        private long IDBicikliste;
        public event PropertyChangedEventHandler PropertyChanged;

        private Biciklista rider;
        public Biciklista Rider
        {
            get { return rider; }
            set
            {
                rider = value;
                RaisePropertyChanged("Rider");
            }
        }
        private Mentalne_Sposobnosti mentalSkill;
        public Mentalne_Sposobnosti MentalSkill
        {
            get { return mentalSkill; }
            set
            {
                mentalSkill = value;
                RaisePropertyChanged("MentalSkill");
            }
        }

        private Test_Ocenjivanja gradedTest;
        public Test_Ocenjivanja GradedTest
        {
            get { return gradedTest; }
            set
            {
                gradedTest = value;
                RaisePropertyChanged("GradedTest");
            }
        }

        private Sprint_Test sprintTest;
        public Sprint_Test Sprint_Test
        {
            get { return sprintTest; }
            set
            {
                sprintTest = value;
                RaisePropertyChanged("Sprint_Test");
            }
        }

        private Profilisanje_Profila_Vozaca proficienciesProfile;
        public Profilisanje_Profila_Vozaca ProficienciesProfile
        {
            get { return proficienciesProfile; }
            set
            {
                proficienciesProfile = value;
                RaisePropertyChanged("ProficienciesProfile");
            }
        }

        private int prirodneSposobnosti;
        public int Prirodne_Sposobnosti
        {
            get { return prirodneSposobnosti; }
            set
            {
                prirodneSposobnosti = value;
                RaisePropertyChanged("Prirodne_Sposobnosti");
            }
        }

        private string profVozaca;
        public string ProfVozaca
        {
            get { return profVozaca; }
            set
            {
                profVozaca = value;
                RaisePropertyChanged("ProfVozaca");
            }
        }

        private ChartValues<double> sprint;
        public ChartValues<double> Sprint
        {
            get { return sprint; }
            set
            {
                sprint = value;
                RaisePropertyChanged("Sprint");
            }
        }

        private ChartValues<double> brdo;
        public ChartValues<double> Brdo
        {
            get { return brdo; }
            set
            {
                brdo = value;
                RaisePropertyChanged("Brdo");
            }
        }

        private ChartValues<double> hronometar;
        public ChartValues<double> Hronometar
        {
            get { return hronometar; }
            set
            {
                hronometar = value;
                RaisePropertyChanged("Hronometar");
            }
        }

        private Func<ChartPoint, string> pointLabel;
        public Func<ChartPoint, string> PointLabel
        {
            get { return pointLabel; }
            set
            {
                pointLabel = value;
                RaisePropertyChanged("PointLabel");
            }
        }
        private bool isBusy;
        public bool IsBusy
        {
            get
            {
                return isBusy;
            }
            set
            {
                isBusy = value;
                RaisePropertyChanged("IsBusy");
            }
        }
        public ICommand Loaded { get; set; }

        public RiderProfileViewModel()
        {
            IDBicikliste = Properties.Settings.Default.BiciklistaID;
            Sprint = new ChartValues<double> { 0 };
            Hronometar = new ChartValues<double> { 0 };
            Brdo = new ChartValues<double> { 0 };
            PointLabel = chartPoint => string.Format("{0} ({1:P})", chartPoint.SeriesView.Title, chartPoint.Participation);
            Loaded = new RelayCommand(loadScreen);

        }

      
        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void loadScreen(object obj)
        {
            IsBusy = true;

            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += (o, ea) =>
            {
                generateRiderInformation();
                generateRiderTests();
            };
            worker.RunWorkerCompleted += (o, ea) =>
            {
                IsBusy = false;
                Sprint = new ChartValues<double> { ProficienciesProfile.Sprint };
                Brdo = new ChartValues<double> { ProficienciesProfile.Brdo };
                Hronometar = new ChartValues<double> { ProficienciesProfile.Hronometar };
            };
         
            worker.RunWorkerAsync();
         }
        
        private void generateRiderInformation()
        {
            riderProfile = new RiderProfile();
            Rider = riderProfile.getDataFromDAL(IDBicikliste);          
        }

        private void generateRiderTests()
        {
            profProfile = new ProficienciesProfile();
            ProficienciesProfile = profProfile.getDataFromDAL(IDBicikliste);
            ProfVozaca = profProfile.returnProficiencies(ProficienciesProfile);

            SprintTest sprintTest = new SprintTest();
            Sprint_Test = sprintTest.getDataFromDAL(IDBicikliste);

            MentalSkill mentalSkill = new MentalSkill();
            MentalSkill = mentalSkill.getDataFromDAL(IDBicikliste);

            NaturalAbilities naturalAbilities = new NaturalAbilities();
            Prirodne_Sposobnosti = naturalAbilities.getNaturalAbilite(ProfVozaca, IDBicikliste);
        }
    }
}