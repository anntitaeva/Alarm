using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Arduino_Alarm.SetAlarm.GetSchedule;

namespace UnitTestProject1
{
    [TestClass]
    public class Settings_Tests
    {

        [TestMethod]
        public void Subgroup_IsNot_Over_2()
        {
            Settings set = new Settings();

            int sub = set.Subgroup;

            if (sub > 2)
                Assert.Fail("Error");
        }
    }
}
