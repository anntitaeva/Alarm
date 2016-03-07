using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arduino_Alarm.SetAlarm
{
    class SetAlarmViewModel:Factory //наследует первоначальные настройки, если изменяются, то файл перезаписывается
    {
        ConnectArduino ardu = new ConnectArduino();

        public void StartArdu()
        {
            if (Factory.Time != null) { }
                
        }
    }
}
