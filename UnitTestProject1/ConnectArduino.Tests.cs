using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Arduino_Alarm.SetAlarm;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Cannot_put_null_in_Start()
        {
            var ardu=new ConnectArduino();
            ardu.Start(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Cannot_put_anything_but_int_in_Start()
        {
            var ardu = new ConnectArduino();
            ardu.Start("vwtrni");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Cannot_connect_arduino()
        {
            var ardu = new ConnectArduino();
            ardu.Start(0);
        }

    }
}
