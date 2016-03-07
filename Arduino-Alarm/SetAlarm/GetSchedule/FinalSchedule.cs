using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Arduino_Alarm.Entities;

namespace Arduino_Alarm.SetAlarm.GetSchedule
{
    class FinalSchedule
    {
         public Dictionary<DayOfWeek, List<ScheduleEntity>> Classes { get; set; }

        public FinalSchedule(DataTable dt)
        {
            Fill(dt);
        }

        void Fill(DataTable dt)
        {
            Classes = new Dictionary<DayOfWeek, List<ScheduleEntity>>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (Check.CheckRow(dt.Rows[i]))
                {

                    DayOfWeek day = GetDay(dt.Rows[i].ItemArray[0].ToString());
                    Settings set = new Settings();

                    string[] time_start = dt.Rows[i].ItemArray[1].ToString().Split(':');
                    string[] time_finish = dt.Rows[i].ItemArray[2].ToString().Split(':');
                    string name = dt.Rows[i].ItemArray[3].ToString();
                    string type = dt.Rows[i].ItemArray[4].ToString();
                    string adress = dt.Rows[i].ItemArray[5].ToString();
                    string room = dt.Rows[i].ItemArray[6].ToString();
                    string tutor = dt.Rows[i].ItemArray[7].ToString();

                    DateTime today = DateTime.Today;
                    int daysUntil = ((int)day - (int)today.DayOfWeek + 7) % 7;
                    DateTime nextDate = today.AddDays(daysUntil);

                    ScheduleEntity day_classes = new ScheduleEntity()
                    {
                        Start = new DateTime(nextDate.Year, nextDate.Month, nextDate.Day, int.Parse(time_start[0]), int.Parse(time_start[1]), 0),
                        Finish = new DateTime(nextDate.Year, nextDate.Month, nextDate.Day, int.Parse(time_finish[0]), int.Parse(time_finish[1]), 0),
                        Name = name,
                        Type = type,
                        Adress = adress,
                        Room = room,
                        Tutor = tutor,
                        Group = "ББИ145",
                        SubGroup = set.Subgroup,
                        Minor = set.Minor
                    };

                    if (Classes.ContainsKey(day))
                    {
                        Classes[day].Add(day_classes);
                    }
                    else
                        Classes.Add(day, new List<ScheduleEntity> { day_classes });
                }
            }
        }
        DayOfWeek GetDay(string day)
        {
            DayOfWeek day_of_week;
            switch (day)
            {
                case "Пн":
                    day_of_week = DayOfWeek.Monday;
                    break;

                case "Вт":
                    day_of_week = DayOfWeek.Tuesday;
                    break;

                case "Ср":
                    day_of_week = DayOfWeek.Wednesday;
                    break;

                case "Чт":
                    day_of_week = DayOfWeek.Thursday;
                    break;

                case "Пт":
                    day_of_week = DayOfWeek.Friday;
                    break;

                case "Сб":
                    day_of_week = DayOfWeek.Saturday;
                    break;

                case "Вс":
                    day_of_week = DayOfWeek.Sunday;
                    break;

                default: day_of_week = DayOfWeek.Sunday;
                    break;
            }
            return day_of_week;
        }
    }
}
