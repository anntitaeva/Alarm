using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Arduino_Alarm.SetAlarm.GetSchedule;

namespace Arduino_Alarm.SetAlarm.GetGoogle //может конструктор сделать асинк
{
    class GetGoogleMap
    {
        private string mode;
        private string time;
        Settings set = Factory.GetSettings();
        public GetGoogleMap()
        { 
            TakeMode();
        }

        private string TakeMode()
        {
            switch(set.Transport)
            {
                case "Driving":
                    mode = "driving";
                    break;
                case "Bicycling":
                    mode = "bicycling";
                    break;
                case "All public transport":
                    mode = "transit";
                    break;
            }
            return mode;

        }
        private string URL(string from, string to, string mode)
        {
            return string.Format("https://maps.googleapis.com/maps/api/distancematrix/json?units=imperial&origins={0}&destinations={1}&mode={2}&key=AIzaSyDQdP6s9dA_RXoqh6NbkCKKvu2WMQi2rFo", from, to, mode);
        }

        public async Task<string> GetGoogleInformation(string to)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(URL(set.Address, to, mode));
                response.EnsureSuccessStatusCode();

                var jsonString = await response.Content.ReadAsStringAsync();
                var rows = JsonConvert.DeserializeObject<RootObject>(jsonString);

                foreach (var row in rows.rows)
                {
                    foreach (var element in row.elements)
                    {
                        time = element.duration.text;
                    }
                }
                return time;
            }
        }
    }
}
