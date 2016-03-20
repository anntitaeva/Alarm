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
        public async void Cannot_put_null_in_Start()
        {
            var ardu=new ConnectArduino();
            await ardu.Start(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public async void Cannot_put_anything_but_int_in_Start()
        {
            var ardu = new ConnectArduino();
           await ardu.Start("vwtrni");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public async void Cannot_connect_arduino()
        {
            var ardu = new ConnectArduino();
            await ardu.Start(0);
        }

    }
}
