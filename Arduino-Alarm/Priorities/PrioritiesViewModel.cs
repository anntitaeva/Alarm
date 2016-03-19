using Arduino_Alarm.EnterSettings;
using Arduino_Alarm.SetAlarm.GetSchedule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.ComponentModel;

namespace Arduino_Alarm
{
    class PrioritiesViewModel : Factory, INotifyPropertyChanged //переделать немного поля, добавить айнотифай
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public List<string> List1 { get; set; }
        public List<string> ItemsSelected { get; set; }


        public List<string> ItemsSelected2 { get; set; }
        public List<string> List2 { get; set; }

       // PrioritiesView view = new PrioritiesView();
        FinalSchedule sched = Factory.GetIt();
        SettingsView viewset = new SettingsView();
        
 
        public PrioritiesViewModel()
        {
            //view.OnSelectionChanged += Update;
            var set = Factory.GetSettings();
            List1 = GetList1();
            List2 = GetList2();
            set.OnOpenSettings += Open;
        }

        private void Open()
        {
            viewset.ShowDialog();
        }
        //public void Update()
        //{
        //    WorkWith2Lists(1, ItemsSelected);
        //    WorkWith2Lists(0, ItemsSelected2);
        //}

        //public void WorkWith2Lists(int i,List<string> list)
        //{

        //    if (list != null && list.Count != 0)
        //    {
        //        foreach (KeyValuePair<DayOfWeek, List<ScheduleEntity>> pair in sched.Classes)
        //        {
        //            foreach (ScheduleEntity se in pair.Value)
        //                foreach (string s in list)
        //                    if (s == se.Name)
        //                        se.Priority = i;
        //        }
        //    }
        //}

        public List<string> GetList1()
        {
            List<string> list = new List<string>();
            foreach (KeyValuePair<DayOfWeek, List<ScheduleEntity>> pair in sched.Classes)
            {
                foreach (ScheduleEntity se in pair.Value)
                    list.Add(se.Name);
            }
            return list;

        }

        public List<string> GetList2()
        {
            List<string> list = new List<string>();
            //foreach (string s in List1)
            //{
            //    foreach (string i in ItemsSelected)
            //    {
            //        if (s != i)
            //            list.Add(s);
            //    }
            //}

            //foreach (var s in ItemsSelected)
            //    list.Add(s);
            return list;
        }

        public void GetFinalList()
        {
            List2 = GetList2();
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
