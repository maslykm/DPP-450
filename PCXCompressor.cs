using System.Collections.Generic;

namespace ConsoleApp
{
    internal class PCXCompressor
    {
        private int _value = -1;
        private int _counter;

        public List<byte> Buffer = new List<byte>();

        public void Compress(byte[] buffer, int offset, int count)
        {
            for (int index = offset; index < count; index++)
                Compress(buffer[index]);

            FlushCompress();
        }

        private void Compress(byte b)
        {
            if (_value != b)
                FlushCompress();

            _value = b;
            _counter += 1;

            if (_counter > 60)
                FlushCompress();
        }

        private void FlushCompress()
        {
            if (_counter > 0)
            {
                if (_counter == 1)
                {
                    if ((_value & 0x80) == 0 || (_value & 0x40) == 0)
                    {
                        Buffer.Add((byte)_value);
                    }
                    else
                    {
                        byte maskedCounter = (byte)(_counter | 0xC0);
                        Buffer.Add(maskedCounter);
                        Buffer.Add((byte)_value);
                    }
                }
                else
                {
                    byte maskedCounter = (byte)(_counter | 0xC0);
                    Buffer.Add(maskedCounter);
                    Buffer.Add((byte)_value);
                }
            }

            _value = -1;
            _counter = 0;
        }
    }
}
