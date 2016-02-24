using Arduino_Alarm.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arduino_Alarm
{
    class ScheduleEntity
    {
        public Place place { get; set; }
        public Subjects Subject { get; set; }
        public Teachers Teachet { get; set; }
        public DateTime Time { get; set; }
    }
}
