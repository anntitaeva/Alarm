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
        public Action<string> OnReadyTime;
        

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
            return string.Format("https://maps.googleapis.com/maps/api/distancematrix/json?units=imperial&origins={0}&destinations={1}&mode={2}&key=AIzaSyDQdP6s9dA_RXoqh6NbkCKKvu2WMQi2rFo", from, to, mode);
        }

        public async Task GetGoogleInformation(string to)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    
                    HttpResponseMessage response = await client.GetAsync(URL(Factory.GetSettings().Address, to, mode));
                    response.EnsureSuccessStatusCode();

                    
                    var jsonString = await response.Content.ReadAsStringAsync();
                    System.Threading.Thread.Sleep(500);
                    var rows = JsonConvert.DeserializeObject<RootObject>(jsonString);

                  try
                    {

                        foreach (var row in rows.rows)
                        {
                            foreach (var element in row.elements)
                            {

                                var time = element.duration.text;
                                if (OnReadyTime != null)
                                    OnReadyTime(time);

                            }
                        }
                        
                    }

                    catch { MessageBox.Show("Be sure that you entered your city","Error",MessageBoxButton.OK,MessageBoxImage.Error);  }


                }
            }
            catch { MessageBox.Show("Something went wrong.","Error",MessageBoxButton.OK,MessageBoxImage.Error); }
            }
        }
    }

