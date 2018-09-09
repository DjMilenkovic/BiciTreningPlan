using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using BiciTreningPlan.ViewModel.ChangeRider;
using BiciTreningPlan.ViewModel.Main;
using BiciTreningPlan.ViewModel.Tests;

namespace BiciTreningPlan.ViewModel
{
    class NavigationViewModel : INotifyPropertyChanged
    {
        //Main Views
        public ICommand ChangeUserCommand { get; set; }
        public ICommand DashboardCommand { get; set; }
        public ICommand RiderProfileCommand { get; set; }
        public ICommand TestsCommand { get; set; }
        public ICommand TrainingPlanCommand { get; set; }

        //ChangeUser
        public ICommand LoginCommand { get; set; }
        public ICommand NewRiderCommand { get; set; }

        //Tests
        public ICommand NaturalAbilitiesProfileCommand { get; set; }
        public ICommand MentalSkillsProfileCommand { get; set; }
        public ICommand ProficienciesProfileCommand { get; set; }
        public ICommand GradedExerciseTestCommand { get; set; }
        public ICommand SprintTestCommand { get; set; }
        public ICommand CriticalPowerTestCommand { get; set; }

        private object selectedViewModel;
        public event PropertyChangedEventHandler PropertyChanged;

        public string Ime
        {
            get { return Properties.Settings.Default.Ime; }            
        }

        public string Slika
        {
            get { return Properties.Settings.Default.Slika; }
        }

        public object SelectedViewModel
        {
            get { return selectedViewModel; }
            set { selectedViewModel = value; OnPropertyChanged("SelectedViewModel"); }
        }

        private void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        public NavigationViewModel()
        {
            SelectedViewModel = new DashboardViewModel();

            ChangeUserCommand = new Command(OpenChangeUser);
            DashboardCommand = new Command(OpenDashboard);
            RiderProfileCommand = new Command(OpenRiderProfile);
            TestsCommand = new Command(OpenTests);
            TrainingPlanCommand = new Command(OpenTrainingPlan);

            LoginCommand = new Command(OpenLogin);
            NewRiderCommand = new Command(OpenNewRider);

            NaturalAbilitiesProfileCommand = new Command(OpenNaturalAbilities);
            MentalSkillsProfileCommand = new Command(OpenMentalSkillsProfile);
            ProficienciesProfileCommand = new Command(OpenProficienciesProfile);
            GradedExerciseTestCommand = new Command(OpenGradedExerciseTest);
            SprintTestCommand = new Command(OpenSprintTest);
            CriticalPowerTestCommand = new Command(OpenCriticalPowerTest);
        }

        private void OpenChangeUser(object obj)
        {
            SelectedViewModel = new ChangeUserViewModel();
        }

        private void OpenDashboard(object obj)
        {
            SelectedViewModel = new DashboardViewModel();
        }

        private void OpenTrainingPlan(object obj)
        {
            SelectedViewModel = new TrainingPlanViewModel();
        }

        private void OpenTests(object obj)
        {
            SelectedViewModel = new TestsViewModel();
        }


        private void OpenRiderProfile(object obj)
        {
            SelectedViewModel = new RiderProfileViewModel();
        }

        private void OpenLogin(object obj)
        {
            SelectedViewModel = new LoginViewModel();
        }

        private void OpenNewRider(object obj)
        {
            SelectedViewModel = new NewRiderViewModel();
        }

        private void OpenNaturalAbilities(object obj)
        {
            SelectedViewModel = new NaturalAbilitiesProfileViewModel();
        }

        private void OpenMentalSkillsProfile(object obj)
        {
            SelectedViewModel = new MentalSkillsProfileViewModel();
        }

        private void OpenProficienciesProfile(object obj)
        {
            SelectedViewModel = new ProficienciesProfileViewModel();
        }

        private void OpenGradedExerciseTest(object obj)
        {
            SelectedViewModel = new GradedExerciseTestViewModel();
        }

        private void OpenSprintTest(object obj)
        {
            SelectedViewModel = new SprintTestViewModel();
        }

        private void OpenCriticalPowerTest(object obj)
        {
            SelectedViewModel = new CriticalPowerTestViewModel();
        }
        
    }
}
