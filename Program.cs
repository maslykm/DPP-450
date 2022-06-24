using System;
using System.IO.Ports;
using System.Threading;

namespace ConsoleApp
{
    internal class Program
    {
        public static void Main()
        {
            using (SerialPort port = new SerialPort("COM11"))
            {
                port.Open();

                InitPrinter(port);
                ResetLineFeed(port);
                PrintImages(port);

                Thread.Sleep(TimeSpan.FromSeconds(3));
            }
        }

        private static void InitPrinter(SerialPort port)
        {
            byte[] initSequence = { 0x1B, 0x40 };
            port.Write(initSequence, 0, initSequence.Length);
        }

        private static void ResetLineFeed(SerialPort port)
        {
            byte[] resetLineFeedSequence = { 0x1B, 0x33, 0x00 };
            port.Write(resetLineFeedSequence, 0, resetLineFeedSequence.Length);
        }

        private static void PrintImages(SerialPort port)
        {
            ImageContent img = TestImage.Image24();
            PrintImage.Mode12(port, img);
        }
    }
}
