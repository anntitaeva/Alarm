using Arduino_Alarm.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arduino_Alarm.SetAlarm
{
    class SetAlarmViewModel:Factory, INotifyPropertyChanged //наследует первоначальные настройки, если изменяются, то файл перезаписывается, только это доделать
    {
        InitialData data = new InitialData();

        public string Address { get; set; }
        public List<string> Transport { get; set; }
        public string TimeToReady { get; set; }
        public List<string> Minor { get; set; }
        public List<int> Subgroup { get; set; }

        public int SelectedTransport { get; set;}
        public int SelectedMinor { get; set; }
        public int SelectedGroup { get ; set; }

        

        public event PropertyChangedEventHandler PropertyChanged;

        

        public SetAlarmViewModel()
        {
            Transport = data._transportMode;
            OnPropertyChanged("Transport");
            Minor = data._mainors;
            OnPropertyChanged("Minor");
            Subgroup = data._groups;
            OnPropertyChanged("Subgroup");
            SelectedGroup = -1;
            SelectedMinor = -1;
            SelectedTransport = -1;
  
        }

        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

    }
}
