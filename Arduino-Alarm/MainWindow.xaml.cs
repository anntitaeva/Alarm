﻿using Arduino_Alarm.Manual_Settings;
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
            if (Factory.Time== null)
                MessageBox.Show("Wait a second...We need to check your schedule!", "Checking...", MessageBoxButton.OK, MessageBoxImage.Information);
            var start = new CalculateTime();

            start.OnReady += Message;
            try
            {
                await start.Calculate();
            }
            catch { MessageBox.Show("Connection with Arduino is not established.Please connect your Arduino to the computer.", "Error", MessageBoxButton.OK, MessageBoxImage.Error); }
            
        }
        public void Message()
        {
            MessageBox.Show("Be sure that you have connected arduino.\n\nYour alarm will be set. Good night!", "All right", MessageBoxButton.OK, MessageBoxImage.Information);
            this.WindowState = WindowState.Minimized;
        }
     

        private void button_Click(object sender, RoutedEventArgs e)
        {
            string info = "The program is developed by Higher School of Economics students\n\n1. Set initial settings or set the time manually\n2. Set important subjects by choosing them in priority list. For these subjects alarm will work twice.\n3. Click Set Alarm button.";
            MessageBox.Show(info, "Help", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
