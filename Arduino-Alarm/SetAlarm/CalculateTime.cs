using Arduino_Alarm.SetAlarm.GetSchedule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arduino_Alarm.SetAlarm
{
    class CalculateTime: Factory
    {
        static FinalSchedule _schedule=Factory.GetIt();

        //запускает гетгугл, использует данные из сеттингс для подсчета времени

        private static List<ModificatedData> _finaldata;
        public static List<ModificatedData> Calculate()
        {
            if (_finaldata == null)
                _finaldata = new List<ModificatedData>();//не доделано
            return _finaldata;

        }
            
    }
}
