﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arduino_Alarm
{
   public class ScheduleEntity
    {
        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Adress { get; set; }
        public string Room { get; set; }
        public string Tutor { get; set; }
        public string Group { get; set; }
        public int SubGroup { get; set; }
        public string Minor { get; set; }
        public int Priority;

    }
}
