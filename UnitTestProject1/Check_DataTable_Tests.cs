using System;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Arduino_Alarm.SetAlarm.GetSchedule;

namespace UnitTestProject1
{
    [TestClass]
    public class Check_DataTable_Tests
    {
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Check_DoesNot_Accept_Null()
        {
            DataRow dt=null;
            bool check = Check.CheckRow(dt);
        }
    }
}
