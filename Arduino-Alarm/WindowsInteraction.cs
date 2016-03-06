using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Arduino_Alarm
{
   public interface IWindowsService

        { bool? ShowDialog(string title); }

    public class WindowsInteraction:IWindowsService
    {
        public bool? ShowDialog(string title)
        {
            var window = new Window();
            window.Title = title;
            return window.ShowDialog();
        }

    }
}
