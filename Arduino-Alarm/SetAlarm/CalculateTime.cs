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
        public ConnectArduino ardu;

        //запускает гетгугл, использует данные из сеттингс для подсчета времени

        private static List<ModificatedData> _finaldata;
        public static List<ModificatedData> Calculate()//изменить время с учетом гетгугл
        {
            if (_finaldata == null)
            {
                _finaldata = new List<ModificatedData>();
                foreach(KeyValuePair<DayOfWeek,List<ScheduleEntity>> data in _schedule.Classes)
                {
                    foreach(ScheduleEntity sentity in data.Value)
                    {
                        ModificatedData md = new ModificatedData()
                        {
                            day = sentity.Start.DayOfWeek,
                            _timeStart = sentity.Start.TimeOfDay,
                            _priority = sentity.Priority
                        };
                        _finaldata.Add(md);
                    }
                }
            }
            return _finaldata;

        }

       public void StartArdu()
        {

            if (Factory.Time != null)
            {
                ModificatedData newdata = new ModificatedData()
                {
                    day = Factory.Day,
                    // _timeStart = Factory.Time,
                    _priority = 1
                };
            }
            else
            {
                foreach (ModificatedData day in _finaldata)
                {
                    if (day.day == DateTime.Now.DayOfWeek)
                    {
                        while (true)
                        {
                            if (day._timeStart == DateTime.Now.TimeOfDay)
                            {
                                ardu = Factory.Start();
                                ardu.Prior = day._priority;
                            }

                            System.Threading.Thread.Sleep(1000);
                        }
                    }
                }

                
            }
           

        }
            
    }
}
