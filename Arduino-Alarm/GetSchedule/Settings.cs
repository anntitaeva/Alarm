﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Arduino_Alarm.SetAlarm.GetSchedule
{
    class Settings
    {

        public int Subgroup { get; set; }
        public string Minor { get; set; }
        public string Address { get; set;}
        public string TimeToReady { get; set; }
        public string Transport { get; set; }

        public Settings()
        {
            SubgroupAndMinor();
        }

        string[] GetSettings()
        {

            string[] settings;
            var list = new List<string>();
            try
            {
                Encoding enc = Encoding.GetEncoding(1251);
                var file = new FileStream(@"..\\..\\Settings.txt", FileMode.Open, FileAccess.Read);
                using (var streamReader = new StreamReader(file, enc))
                {
                    string line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        list.Add(line);
                    }
                }
                settings = list.ToArray();
            }
            catch
            {
                settings = null;
            }
            return settings;
        }

        public void ChangeSettings(Settings set)
        {
            Encoding enc = Encoding.GetEncoding(1251);
            try
            {
                string[] settings = new string[] { set.Subgroup.ToString(), set.Minor, set.Address, set.TimeToReady, set.Transport };
                File.WriteAllLines(@"..\\..\\Settings.txt", settings, enc);
            }
            catch { }

        }

        void SubgroupAndMinor()
        {
            string[] settings = GetSettings();
            try
            {
                Subgroup = Convert.ToInt16(settings[0]);
                Minor = settings[1];
                Address = settings[2];
                TimeToReady = settings[3];
                Transport = settings[4];
            }
            catch
            {

            }
        }
    }
}
