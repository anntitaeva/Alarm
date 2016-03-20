using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Arduino_Alarm.Manual_Settings
{
    public class ManualViewModel:Factory
    {
        public string SetTime { get; set; }
        public bool close;
        int Hours;
        int Min;


        public bool Check()
        {
            if (SetTime == null)
                throw new ArgumentNullException();
            try
            {
               string[] st = SetTime.Split(new char[] { ':' });
                int Hours = Convert.ToInt16(st[0]);
                int Min = Convert.ToInt16(st[1]);
                if (Hours > 24 || (Min > 59))
                {
                    MessageBox.Show("Error! Enter time in format '23:15'", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    close = false;
                }
                return close=true;
            }
            catch
            {
                throw new ArgumentException();
            }
        }

        public void SaveChanges()
        {
            close = Check();
            Factory.Time = SetTime;

            if (Hours < DateTime.Now.Hour|| (Hours==DateTime.Now.Hour&& Min <= DateTime.Now.Minute))
                Factory.Day = DateTime.Now.AddDays(1).DayOfWeek;
            else Factory.Day = DateTime.Now.DayOfWeek;
        }

        public void Error()
        {
            MessageBox.Show("Error! Fill the field", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

    }
}
