using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Arduino_Alarm;
using Arduino_Alarm.SetAlarm;
using Arduino_Alarm.SetAlarm.GetSchedule;

namespace UnitTestProject1
{
    [TestClass]
    public class CalculateTime_Tests
    {


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Cannot_be_not_string()
        {
            Factory.Time = "3455";
            Factory.Day = DayOfWeek.Friday;
            var s = new CalculateTime();
            s.Calculate();

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Cannot_put_null_to_time()
        {

            var s = new CalculateTime();
            s.Time(null, null);

        }


    }
}
