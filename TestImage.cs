using System.Collections.Generic;

namespace ConsoleApp
{
    internal class TestImage
    {
        public static ImageContent Image24()
        {
            var buffer = new List<byte>();
            for (int i = 0; i < 12; i++)
            {
                buffer.AddRange(LiniaSzachownica1());
            }

            for (int i = 0; i < 12; i++)
            {
                buffer.AddRange(LiniaSzachownica2());
            }

            byte[] data = buffer.ToArray();
            return new ImageContent(data, 832, 24);
        }

        public static ImageContent Image12V1()
        {
            var buffer = new List<byte>();
            for (int i = 0; i < 12; i++)
            {
                buffer.AddRange(LiniaSzachownica1());
            }

            byte[] data = buffer.ToArray();
            return new ImageContent(data, 832, 12);
        }

        public static ImageContent Image12V2()
        {
            var buffer = new List<byte>();
            for (int i = 0; i < 12; i++)
            {
                buffer.AddRange(LiniaSzachownica2());
            }

            byte[] data = buffer.ToArray();
            return new ImageContent(data, 832, 12);
        }

        private static byte[] LiniaSzachownica1()
        {
            byte[] imageLine = new byte[104];
            imageLine[0] = 0xFF; //szachownica: czarny kwadrat + biały kwadrat itd (6 czarnych kwadratów)
            imageLine[1] = 0xF0;
            imageLine[2] = 0x00;
            imageLine[3] = 0xFF;
            imageLine[4] = 0xF0;
            imageLine[5] = 0x00;
            imageLine[6] = 0xFF;
            imageLine[7] = 0xF0;
            imageLine[8] = 0x00;
            imageLine[9] = 0xFF;
            imageLine[10] = 0xF0;
            imageLine[11] = 0x00;
            imageLine[12] = 0xFF;
            imageLine[13] = 0xF0;
            imageLine[14] = 0x00;
            imageLine[15] = 0xFF;
            imageLine[16] = 0xF0;

            imageLine[96] = 0x0F;//3 czarne paski na końcu
            imageLine[97] = 0xFF;
            imageLine[98] = 0x00;
            imageLine[99] = 0x0F;
            imageLine[100] = 0xFF;
            imageLine[101] = 0x00;
            imageLine[102] = 0x0F;
            imageLine[103] = 0xFF;
            return imageLine;
        }

        private static byte[] LiniaSzachownica2()
        {
            byte[] imageLine = new byte[104];
            imageLine[0] = 0x00;//szachwnica: biały kwadrat + czarny kwadrat itd (5 czarnych kwadratów)
            imageLine[1] = 0x0F;
            imageLine[2] = 0xFF;
            imageLine[3] = 0x00;
            imageLine[4] = 0x0F;
            imageLine[5] = 0xFF;
            imageLine[6] = 0x00;
            imageLine[7] = 0x0F;
            imageLine[8] = 0xFF;
            imageLine[9] = 0x00;
            imageLine[10] = 0x0F;
            imageLine[11] = 0xFF;
            imageLine[12] = 0x00;
            imageLine[13] = 0x0F;
            imageLine[14] = 0xFF;

            imageLine[96] = 0xFF;//3 czarne paski na końcu
            imageLine[97] = 0xF0;
            imageLine[98] = 0x00;
            imageLine[99] = 0xFF;
            imageLine[100] = 0xF0;
            imageLine[101] = 0x00;
            imageLine[102] = 0x0F;
            imageLine[103] = 0xFF;
            return imageLine;
        }
    }
}
