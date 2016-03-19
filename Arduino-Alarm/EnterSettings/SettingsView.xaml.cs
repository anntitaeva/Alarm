using Arduino_Alarm.SetAlarm;
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
using System.Windows.Shapes;

namespace Arduino_Alarm.EnterSettings
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class SettingsView : Window
    {
        SettingsViewModel setalarm = new SettingsViewModel();
        public SettingsView()
        {
            DataContext = setalarm;
            InitializeComponent();
            
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (setalarm.Check())
                {
                    setalarm.SaveChanges();
                    this.Close();
                }
                else setalarm.Error();
            }
            catch
            {
                setalarm.Error();
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
