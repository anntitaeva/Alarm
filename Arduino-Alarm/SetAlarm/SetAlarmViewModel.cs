using Arduino_Alarm.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arduino_Alarm.SetAlarm
{
    class SetAlarmViewModel:Factory //наследует первоначальные настройки, если изменяются, то файл перезаписывается
    {
        public string Address { get; set; }
        public List<string> Transport { get; set; }
        public string TimeToReady { get; set; }
        public List<string> Minor { get; set; }
        public List<int> Subgroup { get; set; }

        InitialData data = new InitialData();
        //если сеттинг не нал, то данные из сеттинга

        public SetAlarmViewModel()
        {
            Transport = data._transportMode;
            Minor = data._mainors;
            Subgroup = data._groups;
        }

    }
}
