using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiciTreningPlan.Services
{
    interface IMsgBoxService
    {
        void ShowNotification(string message);
        void ShowError(string message);
        bool AskForConfirmation(string message);
    }
}
