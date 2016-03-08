using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arduino_Alarm.Entities
{
    class InitialData
    {
        public List<string> _transportMode=new List<string>() { "Driving", "Bicycling", "Only subway", "All public transport" };
        public List<string> _mainors= new List<string>() { "Урб", "Флс", "ММК", "НТ", "ПСБ", "ИАД", "Псх", "Лог", "Мен", "ФЭ" };
        public List<int> _groups= new List<int>() { 1, 2 };
        
    }
}
