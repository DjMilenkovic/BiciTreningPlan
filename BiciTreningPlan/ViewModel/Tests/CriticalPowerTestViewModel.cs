using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BiciTreningPlanBLL;
using ProjectDBDataModel.Entity;
using System.Windows.Input;
using BiciTreningPlan.Command;
using System.ComponentModel;

namespace BiciTreningPlan.ViewModel.Tests
{
    class CriticalPowerTestViewModel : INotifyPropertyChanged
    {
        private CriticalPowerTest cpw;

        private double cp0;
        public double CP0
        {
            get { return cp0; }
            set
            {
                cp0 = value;
                RaisePropertyChanged("CP0");
            }
        }

        private double cp1;
        public double CP1
        {
            get { return cp1; }
            set
            {
                cp1 = value;
                RaisePropertyChanged("CP1");
            }
        }

        private double cp6;
        public double CP6
        {
            get { return cp6; }
            set
            {
                cp6 = value;
                RaisePropertyChanged("CP6");
            }
        }

        private double cp12;
        public double CP12
        {
            get { return cp12; }
            set
            {
                cp12 = value;
                RaisePropertyChanged("CP12");
            }
        }

        private double cp30;
        public double CP30
        {
            get { return cp30; }
            set
            {
                cp30 = value;
                RaisePropertyChanged("CP30");
            }
        }

        private double cp60;
        public double CP60
        {
            get { return cp60; }
            set
            {
                cp60 = value;
                RaisePropertyChanged("CP60");
            }
        }

        private double cp90;
        public double CP90
        {
            get { return cp90; }
            set
            {
                cp90 = value;
                RaisePropertyChanged("CP90");
            }
        }

        private double cp180;
        public double CP180
        {
            get { return cp180; }
            set
            {
                cp180 = value;
                RaisePropertyChanged("CP180");
            }
        }

        private SeriesCollection seriesCollection;
        public SeriesCollection SeriesCollection
        {
            get
            {
                return seriesCollection;
            }
            set
            {
                seriesCollection = value;
                RaisePropertyChanged("SeriesCollection");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string[] Labels { get; set; }
        public Func<double, string> YFormatter { get; set; }
        
        public ICommand Loaded { get; set; }
        public ICommand Save { get; set; }
        public long IDBicikliste { get; set; }

        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public CriticalPowerTestViewModel()
        {           
            Loaded = new RelayCommand(loadScreen);
            Save = new RelayCommand(insertTestResult);
            cpw = new CriticalPowerTest();
        }

        public void loadScreen(object obj)
        {
            formatStartChart();
                      
            List<Test_Kriticne_Snage> testList = cpw.getDataFromDAL(1);
            foreach (var test in testList)
            {
                SeriesCollection.Add(new LineSeries
                {
                    Title = test.Datum_testiranja.ToShortDateString(),
                    Values = new ChartValues<double> { test.CP0, test.CP1, test.CP6, test.CP12, test.CP30, test.CP60, test.CP90, test.CP180 },
                    LabelPoint = point => point.Y + "W",
                });
            }

            YFormatter = value => value.ToString();
        }        

        public void insertTestResult(object obj)
        {
            
            cp60 = Math.Round(cp30 - cp30 / 100 * 5);
            cp90 = Math.Round(cp60 - cp60 / 100 * 5);
            cp180 = Math.Round(cp90 - cp90 / 100 * 5);

            Test_Kriticne_Snage test = new Test_Kriticne_Snage();
            test.ID_Bicikliste = 1; //IDBicikliste
            test.Datum_testiranja = DateTime.Today;
            test.CP0 = (int)CP0;
            test.CP1 = (int)CP1;
            test.CP6 = (int)CP6;
            test.CP12 = (int)CP12;
            test.CP30 = (int)CP30;
            test.CP60 = (int)CP60;
            test.CP90 = (int)CP90;
            test.CP180 = (int)CP180;

            try
            {
                cpw.insertIntoDAL(test);

                SeriesCollection.Add(new LineSeries
                {
                    Title = DateTime.Today.ToShortDateString(),
                    Values = new ChartValues<double> { cp0, cp1, cp6, cp12, cp30, cp60, cp90, cp180 },
                    LabelPoint = point => point.Y + "W",
                });
            }
            catch(Exception ex)
            {
            }
        }

        public void formatStartChart()
        {
            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Datum",
                    Values = new ChartValues<double> { 0, 0, 0, 0, 0,0.0001, 0.0001, 0.0001},
                    LabelPoint = point => {
                        if(point.Y ==0)
                            return "Testirano";
                        else
                        {
                            return "Procena";
                        }
                    }
                },
            };
            Labels = new[] { "0.20 sec", "1 min", "6 min", "12 min", "30 min", "60 min", "90 min", "180 min" };
        }
    }
}
