using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Arduino_Alarm.Manual_Settings;

namespace UnitTestProject1
{
    [TestClass]
    public class ManualViewModel_Tests
    {
        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void Need_only_int()
        {
            ManualViewModel mw = new ManualViewModel();
            mw.SetTime = "4w5et";
            mw.Check();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Not_null_to_check()
        {
            ManualViewModel mw = new ManualViewModel();
            mw.SetTime = null;
            mw.Check();
        }
    }
}
