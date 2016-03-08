using Arduino_Alarm.SetAlarm;
using Arduino_Alarm.SetAlarm.GetSchedule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arduino_Alarm
{
    class Factory
    {
        public static string Time { get; set; }
        public static DayOfWeek Day { get; set; }

        private static ConnectArduino _startconnection;

        public static ConnectArduino Start()
        {
            if (_startconnection == null)
                _startconnection = new ConnectArduino();
            return _startconnection;

        }

        public static FinalSchedule _schedule;

        public static FinalSchedule GetIt()
        {
            if (_schedule == null)
                _schedule = new FinalSchedule();
            return _schedule;

        }
    }
}
