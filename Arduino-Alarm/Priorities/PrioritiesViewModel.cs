using Arduino_Alarm.EnterSettings;
using Arduino_Alarm.SetAlarm.GetSchedule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace Arduino_Alarm
{
    class PrioritiesViewModel : Factory //переделать немного поля
    {
      
        public List<string> List1 { get; set; }
        public List<string> ItemsSelected = new List<string>();

        FinalSchedule sched = Factory.GetIt();
        SettingsView viewset = new SettingsView();
        
 
        public PrioritiesViewModel()
        {
            
            var set = Factory.GetSettings();
            List1 = GetList1();

        }

        public void WorkWithList()
        {

            if (ItemsSelected != null && ItemsSelected.Count != 0)
            {
                foreach (KeyValuePair<DayOfWeek, List<ScheduleEntity>> pair in sched.Classes)
                {
                    foreach (ScheduleEntity se in pair.Value)
                        foreach (string s in ItemsSelected)
                            if (s == se.Name)
                            {
                                se.Priority = 1;
                            }
                }
            }

        }

        public List<string> GetList1()
        {
            List1 = new List<string>();
            

            foreach (KeyValuePair<DayOfWeek, List<ScheduleEntity>> pair in sched.Classes)
            {
                foreach (ScheduleEntity se in pair.Value)
                    if(!List1.Contains(se.Name))
                            List1.Add(se.Name);
            }
            return List1;

        } 

    }
}
