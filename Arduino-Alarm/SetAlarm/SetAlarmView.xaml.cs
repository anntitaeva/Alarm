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

namespace Arduino_Alarm
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class SetAlarmView : Window
    {
        SetAlarmViewModel setalarm = new SetAlarmViewModel();
        public SetAlarmView()
        {
            DataContext = setalarm;
            InitializeComponent();
            
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
