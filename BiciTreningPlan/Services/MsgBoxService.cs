using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BiciTreningPlan.Services
{
    class MsgBoxService : IMsgBoxService
    {
        public void ShowNotification(string message)
        {
            MessageBox.Show(message, "Obaveštenje", MessageBoxButton.OK, MessageBoxImage.Information);
        }
               
        public void ShowError(string message)
        {
            MessageBox.Show(message, "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public bool AskForConfirmation(string message)
        {
            MessageBoxResult result = MessageBox.Show(message, "Da li ste sigurni?", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
                return true;
            else
                return false;
        }
    }
}