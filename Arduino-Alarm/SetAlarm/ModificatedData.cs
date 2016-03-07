using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arduino_Alarm.SetAlarm
{
    class ModificatedData
    {
        public DateTime _timeStart;
        public int _priority;

        public ModificatedData(DateTime timestart, int priority)
        {
            _timeStart = timestart;
            _priority = priority;

        }
    }
}
