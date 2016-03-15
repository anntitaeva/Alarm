using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Arduino_Alarm
{
    class MainWindowModel:Factory
    {
       // MainWindow view = new MainWindow();

        public MainWindowModel()
        {
            var set = Factory.GetSettings();
            set.OnOpenView += Info;
        }

        public void Info()
        {
            MessageBox.Show("Welcome! Please, first of all,enter data into 'Settings'. You also can change them whenever you want.", "Welcome!", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
