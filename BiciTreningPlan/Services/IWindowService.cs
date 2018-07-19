using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiciTreningPlan.Services
{
    public interface IWindowService
    {
       void showWindow(object dataContext, string title);
    }
}
