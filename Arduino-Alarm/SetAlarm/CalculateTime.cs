using Arduino_Alarm.SetAlarm.GetSchedule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arduino_Alarm.SetAlarm
{
    class CalculateTime: Factory //может надо будет переписать в зависимости от логики работы проги
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

                    if (Factory.Time != null&&Factory.Day.ToString()!=null)
                    {

                        ModificatedData newdata = new ModificatedData()
                        {
                            day = Factory.Day,
                            _timeStart = Factory.Time,
                            _priority = 1
                        };
                        _finaldata.Add(newdata);
                    }
                else { 
                    foreach (KeyValuePair<DayOfWeek, List<ScheduleEntity>> data in _schedule.Classes)
                    {
                        foreach (ScheduleEntity sentity in data.Value)
                        {
                            ModificatedData md = new ModificatedData()
                            {
                                day = sentity.Start.DayOfWeek,
                                _timeStart = sentity.Start.TimeOfDay.ToString(),
                                _priority = sentity.Priority
                            };
                            _finaldata.Add(md);
                        }
                    }
                }
            }
            return _finaldata;

        }
  

    public void Run()
        {
            foreach (ModificatedData day in _finaldata)
            {
                if (day.day == DateTime.Now.DayOfWeek)
                {
                    while (true)
                    {
                        if (day._timeStart == DateTime.Now.TimeOfDay.ToString())
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
            