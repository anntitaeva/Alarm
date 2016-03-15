using Arduino_Alarm.Manual_Settings;
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
using Arduino_Alarm.SetAlarm;
using Arduino_Alarm.SetAlarm.GetSchedule;
using Arduino_Alarm.EnterSettings;

namespace Arduino_Alarm
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Window _iwindow;
        MainWindowModel mv = new MainWindowModel();
       
                  
        public MainWindow()
        {
           
            InitializeComponent();
            DataContext = mv;
            
                  
        }
        public void FirstTime()
        {
            Manual_Set.IsEnabled = false;
            Set_priorities.IsEnabled = false;
            MessageBox.Show("Welcome! Please, first of all,enter data into 'Settings'. You also can change them whenever you want.", "Welcome!", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        private void Manual_Set_Click(object sender, RoutedEventArgs e)
        {
            (_iwindow = new ManualView()).ShowDialog();
        }

        private void Set_priorities_Click(object sender, RoutedEventArgs e)
        {
            (_iwindow = new PrioritiesView()).ShowDialog();
        }

        private void Initial_Set_Click(object sender, RoutedEventArgs e)
        {
            (_iwindow = new SettingsView()).ShowDialog();
        }


    }
}
