using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Windows;

namespace Arduino_Alarm.SetAlarm
{
    public class ConnectArduino
    {
        SerialPort arduinoBoard = new SerialPort();
        bool ArduinoPortFound = false;
        

        
        public void Start(object prior)
        {
            
                if (prior == null)
                    throw new NullReferenceException();
            if ((prior is int))
            {

                try
                {
                    DetectArduino();
                    arduinoBoard.Write(prior.ToString());
                }

                catch { throw new InvalidOperationException(); }
                System.Threading.Thread.Sleep(500);
                arduinoBoard.Close();
            }
            else throw new ArgumentException();
                
            
            
            

        }

        private void DetectArduino()
        {
           
                string[] ports = SerialPort.GetPortNames();
                if (ports.Count() == 0)
                    throw new InvalidOperationException();

                foreach (string port in ports)
                {
                    arduinoBoard = new SerialPort(port, 9600);
                    
                    if (ArduinoDetected())
                    {
                        ArduinoPortFound = true;

                        break;
                    }
                    else
                    {
                        ArduinoPortFound = false;
                    }
                }
            
            
       

            if (ArduinoPortFound == false) return;
            System.Threading.Thread.Sleep(500);

            arduinoBoard.BaudRate = 9600;
            arduinoBoard.ReadTimeout = 1000;
            arduinoBoard.WriteTimeout = 1000;


            try
            {
                arduinoBoard.Open();
            }
            catch { }

        }



        private bool ArduinoDetected()
        {
            try
            {
                arduinoBoard.Open();
                System.Threading.Thread.Sleep(1000);

                string returnMessage = arduinoBoard.ReadLine();
                arduinoBoard.Close();

                if (returnMessage.Contains("Info from Arduino"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch 
            {
                MessageBox.Show("The programm cannot connect Arduino. Be sure that it is connected to your computer", "Error", MessageBoxButton.OK, MessageBoxImage.Error); return false;
            }
        }
    }

}


