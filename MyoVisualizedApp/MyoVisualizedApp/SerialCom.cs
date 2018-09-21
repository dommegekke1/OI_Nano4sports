using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace MyoVisualizedApp
{
    class SerialCom
    {
        private SerialPort SerialPort;

        public SerialCom()
        {
            
        }

        public String[] GetPorts()
        {
            return SerialPort.GetPortNames();
        }

        public void OpenPort(SerialPort serialPort, int baudRate)
        {
            SerialPort = serialPort;
            SerialPort.BaudRate = baudRate;
            SerialPort.Open();
        }

        public void ClosePort()
        {
            SerialPort.Close();
        }

        public string Read()
        {
            return SerialPort.ReadLine();
        }

        public void Write(string text)
        {
            SerialPort.WriteLine(text);
        }
    }
}
