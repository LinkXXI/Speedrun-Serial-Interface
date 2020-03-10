using System;
using System.IO.Ports;

namespace Speedrun_Serial_Interface
{
    class Program
    {

        public enum ardunioFunction : int
        {
            FOOT_SWITCH_ON  = 101,
            FOOT_SWITCH_NC  = 102,
            GREEN_BUTTON_ON = 111,
            GREEN_BUTTON_NC = 112,
            GREEN_LGIHT     = 113,
            RED_BUTTON_ON   = 121,
            RED_BUTTON_NC   = 122,
            RED_LIGHT       = 123,
        }

        static void Main(string[] args)
        {
            SerialPortInfo.GetPortInformation();
            string[] ports = SerialPort.GetPortNames();

            Console.WriteLine("Please choose a Serial Port:");
            
            int i = 0;

            foreach(SerialPortInfo port in SerialPortInfo.serialPorts)
            {
                i++;
                Console.WriteLine("[{0}] - {1} ({2})", i, port.Caption, port.Manufacturer);
            }


            string portInput = "";
            int portNumber = 0;

            while(portInput == "")
            {
                Console.Write("Enter Port Number: ");
                portInput = Console.ReadLine();

                try
                 {
                    portNumber = int.Parse(portInput);

                    if(portNumber > i || portNumber < 1)
                    {
                        throw new Exception("Port Number not in expected range");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: {0}", ex.Message);
                    portInput = "";
                }
            }

            SerialPortInfo connectionPort = SerialPortInfo.serialPorts[portNumber -1];

            Console.WriteLine("Connecting to {0}", connectionPort.Caption);

            SerialPort arduinoConnection = new SerialPort();
            arduinoConnection.BaudRate = 9600;
            arduinoConnection.PortName = connectionPort.COMPortName;
            arduinoConnection.Open();

            while (arduinoConnection.IsOpen)
            {
                ardunioFunction output = int.Parse(arduinoConnection.ReadLine();

                switch (output){
                    case ardunioFunction.FOOT_SWITCH_ON:

                        break;
                    case ardunioFunction.FOOT_SWITCH_NC:

                        break;
                    case ardunioFunction.GREEN_BUTTON_ON:

                        break;
                    case ardunioFunction.GREEN_BUTTON_NC:

                        break;
                    case ardunioFunction.RED_BUTTON_ON:

                        break;
                    case ardunioFunction.RED_BUTTON_NC:

                        break;
                }
            }

            arduinoConnection.Close();
           
        }
    }
}
