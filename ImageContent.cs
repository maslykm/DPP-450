namespace ConsoleApp
{
    public class ImageContent
    {
        public ImageContent(byte[] bytes, int width, int height)
        {
            Data = bytes;
            Width = width;
            Height = height;
        }

        public byte[] Data { get; }
        public int Width { get; }
        public int Height { get; }
    }
}