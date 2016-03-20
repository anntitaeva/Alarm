using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Arduino_Alarm.SetAlarm.GetSchedule;
using System.Windows;

namespace Arduino_Alarm.SetAlarm.GetGoogle //может конструктор сделать асинк
{
    class GetGoogleMap
    {
        private string mode;
        private string time;

        

        public GetGoogleMap()
        { 
            TakeMode();
        }

        private string TakeMode()
        {
            var set = Factory.GetSettings();
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
            return string.Format("https://maps.googleapis.com/maps/api/distancematrix/json?units=imperial&origin={0}&destination={1}&mode={2}&key=AIzaSyDQdP6s9dA_RXoqh6NbkCKKvu2WMQi2rFo", from, to, mode);
        }

        public async Task<string> GetGoogleInformation(string to)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(URL(Factory.GetSettings().Address, to, mode));
                    response.EnsureSuccessStatusCode();

                   
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var rows = JsonConvert.DeserializeObject<RootObject>(jsonString);
                    

                    //try
                    //{
                    //    foreach (var row in rows.rows)
                    //    {
                    //        foreach (var element in row.elements)
                    //        {
                    //            MessageBox.Show(element.duration.text);
                    //            var time = element.duration.text;
                    //            MessageBox.Show(time);
                    //            return time;
                    //        }
                    //    }
                      return null;
                    //}

                    //catch { MessageBox.Show("here"); return null; }
            
       
                          
                }
            }
            catch { return null; }
            }
        }
    }

