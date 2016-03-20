using Arduino_Alarm.SetAlarm;
using Arduino_Alarm.SetAlarm.GetSchedule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arduino_Alarm
{
   public class Factory
    {
        public static string Time { get; set; }
        public static DayOfWeek Day { get; set; }
       

        private static FinalSchedule _schedule;

        internal static Settings _set;
        internal static Settings GetSettings()
        {
            if (_set == null)
                _set = new Settings();
            return _set;

        }
  

        internal static FinalSchedule GetIt()
        {
            if (_schedule == null)
                _schedule = new FinalSchedule();

            return _schedule;
        }

        private static void Update()
        {
            _set = null;
            GetSettings();

            _schedule = null;
            GetIt();
        }

       
        
    }
}
