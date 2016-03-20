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
    public class CalculateTime //доделать с ошибками
    {
        static FinalSchedule _schedule = Factory.GetIt();
        Settings set = Factory.GetSettings();
        private int i;

        public ConnectArduino ardu;
        public Action OnReady;


        private IList<ModificatedData> _finaldata;

        public async Task Calculate()
        {

            _finaldata = new List<ModificatedData>();

            if (Factory.Time != null && Factory.Day.ToString() != null)
            {
                try {
                    
                    var newdata = new ModificatedData()
                    {
                        day = Factory.Day,
                        hour = Convert.ToInt16((Factory.Time.Split(new char[] { ':' }))[0]),
                        min = Convert.ToInt16((Factory.Time.Split(new char[] { ':' }))[1]),
                        _priority = 1,
                        _address = null
                    };

                    _finaldata.Add(newdata);
                    Factory.Time = null;
                    
                   await Run();
                }
                catch { throw new ArgumentException(); }
            }

            else
            {
                try
                {

                    var google = new GetGoogleMap();

                    foreach (KeyValuePair<DayOfWeek, List<ScheduleEntity>> data in _schedule.Classes)
                    {

                        string time = null;
                        Tuple<int, int> t;

                        google.OnReadyTime += (c => time = c);
                        await google.GetGoogleInformation("Москва," + data.Value.FirstOrDefault().Adress);

                        System.Threading.Thread.Sleep(500);

                        if (time != null)
                        {
                            t = Time(data.Value.FirstOrDefault(), time);

                            var md = new ModificatedData()
                            {
                                day = data.Value.FirstOrDefault().Start.DayOfWeek,
                                hour = t.Item1,
                                min = t.Item2,
                                _priority = data.Value.FirstOrDefault().Priority,
                                _address = data.Value.FirstOrDefault().Adress
                            };

                            _finaldata.Add(md);
                            i++;

                        }

                        if (i == _schedule.Classes.Count())
                          await  Run();
                    }
                }



                catch { MessageBox.Show("Something went wrong with Google Information. Be sure that you have Internet connection. If no, set alarm manually.", "Error", MessageBoxButton.OK, MessageBoxImage.Error); }

            }
        }




        public Tuple<int, int> Time(ScheduleEntity ent, string time)
        {

            if (ent == null || time == null)
            { throw new ArgumentNullException(); }
            

            string[] st = time.Split(new char[] { ' ' });

            int hour = ent.Start.Hour;
            int min = ent.Start.Minute;

            int hourGoogle = 0;
            int minGoogle = 0;

            if (time.Contains("day"))
                MessageBox.Show("Please enter address correctly or set alarm manually", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

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

            try {
                int readyHour = Convert.ToInt16(timetoready[0]);
                int readyMin = Convert.ToInt16(timetoready[1]);



                int finalhour = hour - readyHour - hourGoogle;
                if (finalhour < 0)
                    MessageBox.Show("Oooops! You need more than 24 hours to get to the university. If it is true, please set alarm manualy or write address more correct", "Ooops!", MessageBoxButton.OK, MessageBoxImage.Warning);

                int finalminutes = min - minGoogle - readyMin - 20;

                var finaltime = finalhour * 60 + finalminutes;
                finalhour = (int)(finaltime / 60);
                finalminutes = finaltime - finalhour * 60;
            


            return Tuple.Create<int, int>(finalhour, finalminutes);
        }
            catch { throw new ArgumentException(); }
        }

    


    public async Task Run()
        {
            bool stop = false;

            if (OnReady != null)
                OnReady();

            foreach (var day in _finaldata)
            {
                if (day.day == DateTime.Now.DayOfWeek)
                {
                    while (true)
                    {
                        if (day.hour == DateTime.Now.Hour && day.min == DateTime.Now.Minute)
                        {
                            if (!stop)
                            {
                                ardu = new ConnectArduino();
                                await ardu.Start(day._priority);
                                stop = true;
                            }
                        }
                        else stop = false;
                        
                        await Task.Delay(500);
                    }
                }
            }
        }
     
                
            }
           

        }
            
