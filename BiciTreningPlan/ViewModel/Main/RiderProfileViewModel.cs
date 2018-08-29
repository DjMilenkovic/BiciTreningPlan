using BiciTreningPlan.Model;
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

namespace BiciTreningPlan.ViewModel.Main
{
    class RiderProfileViewModel
    {
        public RiderProfile riderProfile;
        public ProficienciesProfile profProfile;
        public Biciklista Rider { get; set; }
        public ObservableCollection<Biciklista> Riders { get; set; }
        public ObservableCollection<Test_Ocenjivanja> GradedTest { get; set; }
        public ObservableCollection<Test_Kriticne_Snage> CriticalPowerTest { get; set; }
        public ObservableCollection<Sprint_Test> SprintTest { get; set; }
        public ObservableCollection<Profilisanje_Profila_Vozaca> ProficienciesProfile { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
        public string FavoriteRaceA { get; set; }
        public string FavoriteRaceB { get; set; }
        public string FavoriteRaceC { get; set; }
        public long MaxPower { get; set; }
   //    public string GradedExercise { get; set; }
        public string ProficienciesRiderProfile { get; set; }
        public int MentalSkills { get; set; }
        public int NaturalAbilitiesProfile { get; set; }
        public double Sprint { get; set; }
        public double Climb { get; set; }
        public double TimeTrial { get; set; }
        public Func<ChartPoint, string> PointLabel { get; set; }

        public RiderProfileViewModel()
        {
            generateRiderInformation();
            generateRiderTests();

            PointLabel = chartPoint => string.Format("{0} ({1:P})", chartPoint.SeriesView.Title, chartPoint.Participation);
        }

        private void generateRiderInformation()
        {
            riderProfile = new RiderProfile();
            Rider = riderProfile.getDataFromDAL(1);
            Name = Rider.Ime;
            Surname = Rider.Prezime;
            BirthDate = Rider.Datum_Rodjenja;
            Address = Rider.Adresa;
            City = Rider.Grad;
            Country = Rider.Drzava;
            Weight = (int)Rider.Tezina;
            Height = (int)Rider.Visina;
            FavoriteRaceA = Rider.Omiljena_Trka_A;
            FavoriteRaceB = Rider.Omiljena_Trka_B;
            FavoriteRaceC = Rider.Omiljena_Trka_C;
        }

        private void generateRiderTests()
        {

            profProfile = new ProficienciesProfile();
            Profilisanje_Profila_Vozaca profilisanjeVozaca = profProfile.getDataFromDAL(1);
            Sprint = profilisanjeVozaca.Sprint;
            Climb = profilisanjeVozaca.Brdo;
            TimeTrial = profilisanjeVozaca.Hronometar;
            ProficienciesRiderProfile = profProfile.returnProficiencies(profilisanjeVozaca);

            SprintTest sprintTest = new BiciTreningPlanBLL.SprintTest();
            MaxPower = sprintTest.getDataFromDAL(1).Maksimalna_Snaga;

            MentalSkill mentalSkill = new MentalSkill();
            MentalSkills = mentalSkill.getDataFromDAL(1).Motivacija;

            NaturalAbilities naturalAbilities = new NaturalAbilities();
            NaturalAbilitiesProfile = naturalAbilities.getNaturalAbilite(ProficienciesRiderProfile, 1);
        }
    }
}