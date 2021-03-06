﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Arduino_Alarm.Manual_Settings
{
    public class ManualViewModel
    {
        public string SetTime { get; set; }
        public bool close;
        int Hours { get; set; }

        int Min
        {
            get; set;
        }



        public void Check()
        {
            if (SetTime == null)
            {
                throw new ArgumentNullException();
                
            }
                string[] st = SetTime.Split(new char[] { ':' });
                Hours = Convert.ToInt16(st[0]);
                Min = Convert.ToInt16(st[1]);

            if (Hours > 24 || (Min > 59))
            {
                MessageBox.Show("Error! Enter time in format '23:15'", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                close = false;
            }
            else close = true;
            }
           
        

        public void SaveChanges()
        {
            Check();
            if (close)
            {
                Factory.Time = SetTime;

                if (Hours < DateTime.Now.Hour || (Hours == DateTime.Now.Hour && Min <= DateTime.Now.Minute))
                    Factory.Day = DateTime.Now.AddDays(1).DayOfWeek;
                else Factory.Day = DateTime.Now.DayOfWeek;
            }
        }

        public void Error()
        {
            MessageBox.Show("Error! Fill the field", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

    }
}
