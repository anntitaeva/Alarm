using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arduino_Alarm.SetAlarm
{
    class ModificatedData
    {
        public int hour { get; set; }
        public int min { get; set; }
        public int _priority { get; set; }
        public DayOfWeek day { get; set; }
        public string _address { get; set; }

        
    }
}
