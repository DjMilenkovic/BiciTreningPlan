using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BiciTreningPlan.Services
{
    public class WindowService : IWindowService
    {        
        public void showWindow(object viewModel, string title)
        {
            var win = new Window();
            win.Title=title;
            win.Content = viewModel;
            win.SizeToContent = SizeToContent.WidthAndHeight;
            win.ResizeMode = ResizeMode.NoResize;
            win.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            win.ShowDialog();
        }
    }
}
