using BiciTreningPlan.Command;
using BiciTreningPlan.Services;
using BiciTreningPlanBLL;
using ProjectDBDataModel.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BiciTreningPlan.ViewModel.Tests
{
    class SprintTestViewModel : INotifyPropertyChanged
    {
        private int maxPower;
        public int MaxPower
        {
            get { return maxPower; }
            set
            {
                maxPower = value;
                RaisePropertyChanged("MaxPower");
            }
        }
        private int avgPower;
        public int AvgPower
        {
            get { return avgPower; }
            set
            {
                avgPower = value;
                RaisePropertyChanged("AvgPower");
            }
        }
        public ICommand Save { get; set; }
        private long IDBicikliste;
        private IMsgBoxService msgBox;

        public event PropertyChangedEventHandler PropertyChanged;

        public SprintTestViewModel()
        {
            IDBicikliste = Properties.Settings.Default.BiciklistaID;
            Save = new RelayCommand(insertIntoDAL);
            msgBox = new MsgBoxService();
        }

        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void insertIntoDAL(object obj)
        {
            if (AvgPower != 0 && MaxPower != 0)
            {
                Sprint_Test testResult = new Sprint_Test();
                testResult.ID_Bicikliste = IDBicikliste;
                testResult.Datum_testiranja = DateTime.Today;
                testResult.Maksimalna_Snaga = MaxPower;
                testResult.Prosecna_Snaga = AvgPower;
                try
                {
                    if (msgBox.AskForConfirmation("Da li ste sigurni da želite da dodate test?") == true)
                    {
                        SprintTest test = new SprintTest();
                        test.insertDataToDAL(testResult);
                        msgBox.ShowNotification("Uspešno ste dodali test.");
                        AvgPower = 0;
                        MaxPower = 0;
                    }
                }
                catch (Exception)
                {
                    msgBox.ShowError("Došlo je do greške!");
                }
            }
        }
    }
}
