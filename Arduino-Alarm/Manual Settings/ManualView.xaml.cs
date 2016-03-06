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
        private bool isClosed = false;

        public ManualView()
        {
            InitializeComponent();
            DataContext = new ManualViewModel();
            this.Closed += DialogWindowClosed;
        }

       

        void DialogWindowClosed(object sender, EventArgs e)
        {
            this.isClosed = true;
        }


    }
}
