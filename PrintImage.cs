using System;
using System.Collections.Generic;
using System.IO.Ports;

namespace ConsoleApp
{
    internal class PrintImage
    {
        public static void Mode10(SerialPort port, ImageContent image)
        {
            if (image.Height != 24)
                throw new InvalidOperationException();

            byte[] data = image.Data;
            Reverse(data);

            var printGraphicsSequence = new byte[] { 0x1B, 0x2A, 0x10, (byte)(image.Width / 8) };

            var buffer = new List<byte>();
            buffer.AddRange(printGraphicsSequence);
            buffer.AddRange(data);

            byte[] printBuffer = buffer.ToArray();
            port.Write(printBuffer, 0, printBuffer.Length);
        }

        public static void Mode12(SerialPort port, ImageContent image)
        {
            var data = image.Data;
            Reverse(data);

            var compressor = new PCXCompressor();
            compressor.Compress(data, 0, data.Length);
            byte[] imageData = compressor.Buffer.ToArray(); ;

            var printGraphicsSequence = new byte[] { 0x1B, 0x2A, 0x12, (byte)(image.Width / 8), (byte)image.Height, 0 };

            var buffer = new List<byte>();
            buffer.AddRange(printGraphicsSequence);
            buffer.AddRange(imageData);
            buffer.Add(0x0A);

            byte[] printBuffer = buffer.ToArray();
            port.Write(printBuffer, 0, printBuffer.Length);
        }

        private static void Reverse(byte[] bytes)
        {
            byte[] reversed = new byte[256];
            for (int i = 0; i < 256; i++)
            {
                reversed[i] = Reverse((byte)i);
            }

            for (int i = 0; i < bytes.Length; i++)
            {
                bytes[i] = reversed[bytes[i]];
            }
        }

        private static byte Reverse(byte b)
        {
            int rev = (b >> 4) | ((b & 0xf) << 4);
            rev = ((rev & 0xcc) >> 2) | ((rev & 0x33) << 2);
            rev = ((rev & 0xaa) >> 1) | ((rev & 0x55) << 1);

            return (byte)rev;
        }
    }
}
