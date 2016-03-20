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
        

        public MainWindowModel()
        {
            var set = Factory.GetSettings();
            if (set.Address == "Например:Москва")
               
        {
            MessageBox.Show("Hello! Try our alarm. Fisrt open settings to enter necessary data.", "Hello!", MessageBoxButton.OK, MessageBoxImage.Information);

        }

    }

       
    }
}
