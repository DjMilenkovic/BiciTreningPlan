using BiciTreningPlanBLL;
using LiveCharts;
using ProjectDBDataModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BiciTreningPlan.View.Main
{
    /// <summary>
    /// Interaction logic for RiderProfile.xaml
    /// </summary>
    public partial class RiderProfile : UserControl
    {
        public RiderProfile()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ProficienciesProfile profProfile = new ProficienciesProfile();
            Profilisanje_Profila_Vozaca profilisanjeVozaca = profProfile.getDataFromDAL(1);
            pieClimb.Values = new ChartValues<double> { profilisanjeVozaca.Brdo };
            pieSprint.Values = new ChartValues<double> { profilisanjeVozaca.Sprint };
            pieTT.Values = new ChartValues<double> { profilisanjeVozaca.Hronometar };
        }
    }
}
