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
            InitializeComponent();
            DataContext = _pw;
            listBox.SelectionChanged += ListBoxSelectionChanged;
        }

        private void ListBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listBox = sender as ListBox;
            if (listBox == null) return;

            var viewModel = listBox.DataContext as PrioritiesViewModel;
            if (viewModel == null) return;

            viewModel.ItemsSelected.Clear();

            foreach (string item in listBox.SelectedItems)
            {
                viewModel.ItemsSelected.Add(item);
            }
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            if (OnSelectionChanged != null)
                OnSelectionChanged();
            _pw.Update();

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
