using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Arduino_Alarm.SetAlarm.GetSchedule
{
    public static class Check
    {
        public static bool CheckRow(DataRow row)
        {
            if (CheckSettings(row) && CheckGroup(row))
                return true;
            else return false;
        }

        private static bool CheckSettings(DataRow row)
        {
            Settings settings = new Settings();
            string subgroup = row.ItemArray[10].ToString();

            if (String.IsNullOrEmpty(subgroup) || subgroup.Contains(settings.Subgroup.ToString()))
                return true;
            else return false;
        }

        private static bool CheckGroup(DataRow row)
        {
            Settings settings = new Settings();
            string groups = row.ItemArray[9].ToString();
            string potok = row.ItemArray[8].ToString();

            if (groups.Contains("ББИ145") || potok.Contains("ББИ145") || potok.Contains(settings.Minor) || String.IsNullOrEmpty(potok) || String.IsNullOrEmpty(groups))
                return true;
            else return false;

        }
    }
}
