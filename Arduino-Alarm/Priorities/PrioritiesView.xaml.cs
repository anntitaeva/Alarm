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
    /// Логика взаимодействия для PrioritiesView.xaml
    /// </summary>
    public partial class PrioritiesView : Window
    {
        PrioritiesViewModel _pw = new PrioritiesViewModel();
        public PrioritiesView()
        {
            InitializeComponent();
            DataContext = _pw;
            _pw.GetList1();
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            _pw.GetList2();
            listBox_Copy.Visibility = Visibility.Visible;
            listBox.Visibility = Visibility.Hidden;
            button2.Content = "<<";
        }
    }
}
