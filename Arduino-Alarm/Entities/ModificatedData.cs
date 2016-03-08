using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arduino_Alarm.SetAlarm
{
    class ModificatedData
    {
        public string _timeStart { get; set; }
        public int _priority { get; set; }
        public DayOfWeek day { get; set; }

        
    }
}
