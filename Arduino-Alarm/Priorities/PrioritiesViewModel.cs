using Arduino_Alarm.EnterSettings;
using Arduino_Alarm.SetAlarm.GetSchedule;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Arduino_Alarm
{
    class PrioritiesViewModel:Factory,INotifyPropertyChanged //переделать немного поля, добавить айнотифай
    {
        public List<string> List1 { get; set; }
        public List<string> ItemsSelected = new List<string>();
        public List<string> ItemsSelected2 { get; set; }
        private List<string> _list2;

      
      
    

    public List<string> List2
        {
            get { return _list2;}
            set {
                _list2 = value;
                OnPropertyChanged("List2");
            }
        }

      
        public event PropertyChangedEventHandler PropertyChanged;
        FinalSchedule sched;
        
 
        public PrioritiesViewModel()
        {
            sched = Factory.GetIt();
            List1=GetList1();
       
        }
        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        public void Update()
        {
            WorkWith2Lists(1, ItemsSelected);
            WorkWith2Lists(0, ItemsSelected2);
        }

        public void WorkWith2Lists(int i, List<string> list)
        {

            if (list != null && list.Count != 0)
            {
                foreach (KeyValuePair<DayOfWeek, List<ScheduleEntity>> pair in sched.Classes)
                {
                    foreach (ScheduleEntity se in pair.Value)
                        foreach (string s in list)
                            if (s == se.Name)
                                se.Priority = i;
                }
            }
        }

        public List<string> GetList1()
        {
            List1 = new List<string>();
            foreach (KeyValuePair<DayOfWeek, List<ScheduleEntity>> pair in sched.Classes)
            {
                foreach (ScheduleEntity se in pair.Value)
                    List1.Add(se.Name);
            }
            return List1;

        }

        public void GetList2()
        {
            List2 = new List<string>();
            if (ItemsSelected != null)
            {
                foreach (string s in List1)
                {
                    foreach (string i in ItemsSelected)
                    {
                        if (s != i)
                            List2.Add(s);
                        
                    }               
                }
             
            }
            else { MessageBox.Show("Error"); }
            
        }
    }
}
