using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Arduino_Alarm.EnterSettings;

namespace UnitTestProject1
{
    [TestClass]
    public class Enter_settings_Tests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Should_be_int()
        {
            SettingsViewModel sv = new SettingsViewModel();
            sv.TimeToReady = "reyerh";
            sv.Check();
        }
    }
}
