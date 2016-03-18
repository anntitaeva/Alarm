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
        public Action OnOpenSettings;

        public MainWindowModel()
        {
            var set = Factory.GetSettings();
            if (set.Address == "Например:Москва")
                if (OnOpenSettings != null)
                    OnOpenSettings();

        }

       
    }
}
