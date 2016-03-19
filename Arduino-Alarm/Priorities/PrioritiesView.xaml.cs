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
        public Action OnSelectionChanged;

        public PrioritiesView()
        {
            DataContext = _pw;
            InitializeComponent();
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            if (OnSelectionChanged != null)
                OnSelectionChanged();

            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            _pw.GetFinalList();
            listBox_Copy.ItemsSource = _pw.GetList2();

            listBox_Copy.Visibility = Visibility.Visible;
            listBox.Visibility = Visibility.Hidden;
            button2.Visibility = Visibility.Hidden;
            button.Visibility = Visibility.Visible;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            listBox_Copy.Visibility = Visibility.Hidden;
            listBox.Visibility = Visibility.Visible;
            button2.Visibility = Visibility.Visible;
            button.Visibility = Visibility.Hidden;
        }

    }
}
