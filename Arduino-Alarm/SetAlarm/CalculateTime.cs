using Arduino_Alarm.SetAlarm.GetGoogle;
using Arduino_Alarm.SetAlarm.GetSchedule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Arduino_Alarm.SetAlarm
{
    class CalculateTime //доделать с ошибками
    {
        static FinalSchedule _schedule=Factory.GetIt();
        Settings set = Factory.GetSettings();

        public ConnectArduino ardu;
        
       
        public CalculateTime()
        {
            
        }

        
        private List<ModificatedData> _finaldata;

        public async  void Calculate()
        {
        
                if (_finaldata == null)
                {
                    _finaldata = new List<ModificatedData>();

                    if (Factory.Time != null&&Factory.Day.ToString()!=null)
                    {

                    ModificatedData newdata = new ModificatedData()
                    {
                        day = Factory.Day,
                        hour = Convert.ToInt16((Factory.Time.Split(new char[] { ':' }))[0]),
                        min= Convert.ToInt16((Factory.Time.Split(new char[] { ':' }))[1]),
                        _priority = 1,
                        _address = null                             
                        };
                        _finaldata.Add(newdata);
                    }

                else
                {
                    GetGoogleMap google = new GetGoogleMap();

                    foreach (KeyValuePair<DayOfWeek, List<ScheduleEntity>> data in _schedule.Classes)
                    {
                        foreach (ScheduleEntity sentity in data.Value)
                        {
                           string time= await google.GetGoogleInformation(sentity.Adress);
                            var t = Time(sentity, time);
                            ModificatedData md = new ModificatedData()
                            {
                                day = sentity.Start.DayOfWeek,
                                hour = t.Item1,
                                min=t.Item2,
                                _priority = sentity.Priority,
                                _address=sentity.Adress             
                            };
                            _finaldata.Add(md);
                        }
                    }
                }
            }
        
        }
  
        private Tuple<int,int> Time(ScheduleEntity ent, string time)
        {
            string[] st= time.Split(new char[] { ' ' });

            int hour = ent.Start.Hour;
            int min = ent.Start.Minute;

            int hourGoogle = 0;
            int minGoogle;

            if (time.Contains("hour"))
            {
                 hourGoogle = Convert.ToInt16(st[0]);
                 minGoogle = Convert.ToInt16(st[4]);
            }
            else
            {
                minGoogle = Convert.ToInt16(st[0]);

            }

            string[] timetoready = set.TimeToReady.Split(new char[] { ':' });

            int readyHour = Convert.ToInt16(timetoready[0]);
            int readyMin = Convert.ToInt16(timetoready[1]);


            int finalhour = hour + readyHour + hourGoogle;
            if (finalhour > 24)
                MessageBox.Show("Oooops! You need more than 24 hours to get to the university. If it is true, please set alarm manualy", "Ooops!", MessageBoxButton.OK, MessageBoxImage.Warning);

            int finalminutes = min + minGoogle + readyMin;
            if (finalminutes > 59)
            {
                double d = finalminutes / 60;
                finalhour = (int)d;
                finalminutes = finalminutes - (finalhour * 60);
            }

            return Tuple.Create<int,int>(finalhour,finalminutes);
        }

    public void Run()
        {
            foreach (ModificatedData day in _finaldata)
            {
                if (day.day == DateTime.Now.DayOfWeek)
                {
                    while (true)
                    {
                        if (day.hour==DateTime.Now.Hour&&day.min==DateTime.Now.Minute)
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
            