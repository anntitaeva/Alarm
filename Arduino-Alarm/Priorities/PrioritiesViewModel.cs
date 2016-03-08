using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arduino_Alarm
{
    class PrioritiesViewModel:Factory
    {
        public List<string> List1 { get; set; }
        public List<string> ItemsSelected { get; set; }
        public List<string> ItemsSelected2 { get; set; }
        public List<string> List2 { get; set; }

        public List<string> GetList1()
        {
            foreach(KeyValuePair<DayOfWeek,List<ScheduleEntity>> pair in Factory._schedule.Classes)
            {
                foreach (ScheduleEntity se in pair.Value)
                    List1.Add(se.Name);
            }
            return List1;

        }

        public List<string> GetList2()
        {
            foreach(string s in List1)
            {
                foreach(string i in ItemsSelected)
                {
                    if (s != i)
                        List2.Add(s);
                }
            }
            return List2;
        }
    }
}
