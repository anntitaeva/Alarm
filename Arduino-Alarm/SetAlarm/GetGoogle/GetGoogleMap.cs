using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace Arduino_Alarm.SetAlarm.GetGoogle
{
    class GetGoogleMap
    {
        private string URL(string from, string to, string mode)
        {
            return string.Format("https://maps.googleapis.com/maps/api/distancematrix/json?units=imperial&origins={0}&destinations={1}&mode={2}&key=AIzaSyDQdP6s9dA_RXoqh6NbkCKKvu2WMQi2rFo", from, to, mode);
        }

        public async Task<RootObject> GetGoogleInformation(string from, string to, string mode)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(URL(from, to, mode));
                response.EnsureSuccessStatusCode();

                var jsonString = await response.Content.ReadAsStringAsync();
                var rows = JsonConvert.DeserializeObject<RootObject>(jsonString);

                return rows;
            }
        }
    }
}
