
using Arduino_Alarm.SetAlarm.GetSchedule;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Arduino_Alarm.EnterSettings
{
    class SettingsViewModel: INotifyPropertyChanged 
    { //переделать, не загонять все в конструктор


        public string Address { get; set; }
        public List<string> Transport { get; set; }
        public string TimeToReady { get; set; }
        public List<string> Minor { get; set; }
        public List<int> Subgroup { get; set; }
        bool close;

        public int SelectedTransport
        {
            get; set;
        }
        public int SelectedMinor
        {
            get; set;
        }
        public int SelectedGroup
        {
            get; set;
        }

        public event PropertyChangedEventHandler PropertyChanged;


        public SettingsViewModel()
        {
            var set = Factory.GetSettings();

            Transport = new List<string>() { "Driving", "Bicycling", "All public transport" };
            OnPropertyChanged("Transport");

            Minor = new List<string>() { "Урб", "Флс", "ММК", "НТ", "ПСБ", "ИАД", "Псх", "Лог", "Мен", "ФЭ" };
            OnPropertyChanged("Minor");

            Subgroup = new List<int>() { 1, 2 };
            OnPropertyChanged("Subgroup");

            if (set.Address != null)
                Address = set.Address;

            if (set.TimeToReady != null)
                TimeToReady = set.TimeToReady;

            if (set.Subgroup != 0)
                SelectedGroup = Subgroup.FindIndex(c => c == set.Subgroup);
            else SelectedGroup = -1;

            if (set.Minor != null)
                SelectedMinor = Minor.FindIndex(c => c == set.Minor);
            else SelectedMinor = -1;

            if (set.Transport != null)
                SelectedTransport = Transport.FindIndex(c => c == set.Transport);
            else SelectedTransport = -1;
  
        }

        public bool Check()
        {
            close = true;

            string[] st = TimeToReady.Split(new char[] { ':' });
            int Hours = Convert.ToInt16(st[0]);
            int Min = Convert.ToInt16(st[1]);
            if (Hours > 24 || (Min > 59))
            return false;

            else return true;
            
                //if (SelectedGroup != -1 && SelectedMinor != -1 && SelectedTransport != -1 && Address != null && Address.Count() != 0 && TimeToReady != null && TimeToReady.Count() != 0)
                //{
                //    set = new Settings() { Address = Address, Transport = Transport[SelectedTransport], Minor = Minor[SelectedMinor], Subgroup = Subgroup[SelectedGroup], TimeToReady = TimeToReady };

                //    set.ChangeSettings(set);
                //}
        }
                
        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        public void Error()
        {
                MessageBox.Show("Error.Please enter the data", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        

        //public bool Check()
        //{
        //    if (SelectedGroup != -1 && SelectedMinor != -1 && SelectedTransport != -1 && Address != null && Address.Count() != 0 && TimeToReady != null && TimeToReady.Count() != 0)
        //        return true;
        //    else return false;
        //}

        public void SaveChanges()//сделать изменение через ивент! 
        {
            if (Check())
            {
                if (SelectedGroup != -1 && SelectedMinor != -1 && SelectedTransport != -1 && Address != null && Address.Count() != 0 && TimeToReady != null && TimeToReady.Count() != 0)
                {
                    Factory._set = new Settings() { Address = Address, Transport = Transport[SelectedTransport], Minor = Minor[SelectedMinor], Subgroup = Subgroup[SelectedGroup], TimeToReady = TimeToReady };
                    Factory._set.ChangeSettings(Factory._set);

                }
                else
                    MessageBox.Show("Error.Please enter the data", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
