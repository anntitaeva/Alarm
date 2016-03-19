using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arduino_Alarm.SetAlarm.GetGoogle
{
    class RootObject
    {
        public string destination_addresses { get; set; }
        public string origin_addresses { get; set; }
        public List<Row> rows { get; set; }
        public string status { get; set; }
    }


    public class Distance
    {
        public string text { get; set; }
        public int value { get; set; }
    }

    public class Duration
    {
        public string text { get; set; }
        public int value { get; set; }
    }

    public class Element
    {
        public Distance distance { get; set; }
        public Duration duration { get; set; }
        public string status { get; set; }
    }

    public class Row
    {
        public List<Element> elements { get; set; }
    }

}
