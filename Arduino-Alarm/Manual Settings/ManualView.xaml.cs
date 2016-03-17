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
using Xceed.Wpf.Toolkit;

namespace Arduino_Alarm.Manual_Settings
{
    /// <summary>
    /// Логика взаимодействия для ManualView.xaml
    /// </summary>
    public partial class ManualView : Window
    {
        ManualViewModel _vm = new ManualViewModel();
        
        public ManualView()
        {
            InitializeComponent();
            DataContext = _vm;
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            _vm.SaveChanges();
            if (_vm.close == true)
            {
                this.Close();
                
            }
           
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
