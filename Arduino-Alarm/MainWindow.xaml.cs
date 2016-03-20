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
            mv.OnOpenSettings += Hello;
            
                  
        }

        public void Hello()
        {
            MessageBox.Show("Hello! Try our alarm. Fisrt open settings.", "Hello!", MessageBoxButton.OK, MessageBoxImage.Information);
            
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

        private async void Set_Alarm_Click(object sender, RoutedEventArgs e)
        {
            var start = new CalculateTime();
            await start.Calculate();
            MessageBox.Show("Your alarm had been set. Good night", "All right", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
