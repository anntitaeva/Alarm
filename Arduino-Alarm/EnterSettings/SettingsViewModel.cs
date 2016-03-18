﻿using Arduino_Alarm.Entities;
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
    class SettingsViewModel:Factory, INotifyPropertyChanged //наследует первоначальные настройки, если изменяются, то файл перезаписывается, только это доделать
    { //переделать, не загонять все в конструктор
        InitialData data = new InitialData();

        public string Address { get; set; }
        public List<string> Transport { get; set; }
        public string TimeToReady { get; set; }
        public List<string> Minor { get; set; }
        public List<int> Subgroup { get; set; }

        Settings set = Factory.GetSettings();

        public int SelectedTransport { get; set;}
        public int SelectedMinor { get; set; }
        public int SelectedGroup { get ; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public SettingsViewModel()
        {
            Transport = data._transportMode;
            OnPropertyChanged("Transport");
            Minor = data._mainors;
            OnPropertyChanged("Minor");
            Subgroup = data._groups;
            OnPropertyChanged("Subgroup");

            if (set.Subgroup != 0)
                SelectedGroup = Subgroup.FindIndex(c => c == set.Subgroup);
            else SelectedGroup = -1;
            if (set.Minor != null)
                SelectedMinor = Minor.FindIndex(c => c == set.Minor);
            else
            SelectedMinor = -1;
            if (set.Transport != null)
                SelectedTransport = Transport.FindIndex(c => c == set.Transport);
            else
            SelectedTransport = -1;
  
        }

        public void SaveChanges()
        {
            set = new Settings() { Address = Address, Transport = Transport[SelectedTransport], Minor = Minor[SelectedMinor], Subgroup = Subgroup[SelectedGroup], TimeToReady = TimeToReady };

            set.ChangeSettings(set);
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

        public bool Check()
        {
            if (SelectedGroup != -1 && SelectedMinor != -1 && SelectedTransport != -1 && Address != null && Address.Count() != 0 && TimeToReady != null && TimeToReady.Count() != 0)
                return true;
            else return false;
        }

    }
}
