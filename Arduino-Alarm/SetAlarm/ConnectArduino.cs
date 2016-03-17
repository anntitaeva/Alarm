using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace Arduino_Alarm.SetAlarm
{
    class ConnectArduino
    {
        SerialPort arduinoBoard = new SerialPort();
        bool ArduinoPortFound = false;
        public int Prior { get; set; }

        
        public ConnectArduino(int prior)
        {
            DetectArduino();
            arduinoBoard.Write(Prior.ToString());

            System.Threading.Thread.Sleep(500);
            arduinoBoard.Close();

        }

        private void DetectArduino()
        {
            try
            {
                string[] ports = SerialPort.GetPortNames();
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
            }
            catch { }

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
            catch (Exception e)
            {
                return false;
            }
        }
    }

}


