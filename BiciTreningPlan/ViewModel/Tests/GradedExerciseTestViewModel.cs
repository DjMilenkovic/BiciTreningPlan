using BiciTreningPlan.Command;
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

namespace BiciTreningPlan.ViewModel.Tests
{
    class GradedExerciseTestViewModel : INotifyPropertyChanged
    {
        private long IDBicikliste;

        public ICommand Save { get; set; }
        public ObservableCollection<Test_Ocenjivanja> GradedTests { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
      
        public GradedExerciseTestViewModel()
        {
            IDBicikliste = Properties.Settings.Default.BiciklistaID;
            GradedTests = new ObservableCollection<Test_Ocenjivanja> { new Test_Ocenjivanja(), new Test_Ocenjivanja(), new Test_Ocenjivanja(), new Test_Ocenjivanja(), new Test_Ocenjivanja(), new Test_Ocenjivanja(), new Test_Ocenjivanja(), new Test_Ocenjivanja(), new Test_Ocenjivanja(), new Test_Ocenjivanja() };
            Save = new RelayCommand(insertTestResult);
        }

        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void insertTestResult(object obj)
        {
            GradedTest test = new GradedTest();
            test.insertIntoDAL(GradedTests, IDBicikliste);
        }
    }
}
