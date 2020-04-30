using System;
using System.IO.Ports;
using NmeaParser;

namespace GpsCoordinatesSerialPortReader
{
    class Program
    {
        static void Main()
        {
            string portname = "COM7"; // Change to match the name of the port your device is connected to
            int baudrate = 115200; // Change to the baud rate your device communicates at (usually specified in the manual)
            SerialPort port = new SerialPort(portname, baudrate, Parity.None, 8, StopBits.One);
            SerialPortDevice device = new SerialPortDevice(port);
            device.MessageReceived += OnNmeaMessageReceived;
            device.OpenAsync();
            Console.ReadKey();
        }
        private static void OnNmeaMessageReceived(object sender, NmeaMessageReceivedEventArgs args)
        {
            // called when a message is received
            if (args.Message is NmeaParser.Messages.Rmc rmc)
            {
                Console.WriteLine($"Your current location is: {GpsCoordinatesFormatter.ParseLatitude(rmc.Latitude)} {GpsCoordinatesFormatter.ParseLongitude(rmc.Longitude)}");
            }
        }
    }
}
