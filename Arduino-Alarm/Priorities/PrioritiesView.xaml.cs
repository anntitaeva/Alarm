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

            
            if (_pw == null) return;

            if(_pw.ItemsSelected!=null)
                _pw.ItemsSelected.Clear();

            foreach (string item in listBox.SelectedItems)
            {
                _pw.ItemsSelected.Add(item);
                _pw.WorkWithList();
            }
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

   

    }
}
