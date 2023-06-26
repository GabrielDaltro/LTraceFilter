namespace LTraceFilter.Business.Core
{
    public static class MemoryStreamExtensions
    {
        public static float ReadFloat(this MemoryStream stream)
        {
            byte[] buffer = stream.ReadNBytes(4);
            return ToFloat(buffer[0], buffer[1], buffer[2], buffer[3]);
        }
        private static byte[] ReadNBytes(this MemoryStream stream, int bytesAmount)
        {
            byte[] buffer = new byte[bytesAmount];
            stream.Read(buffer, 0, buffer.Length);
            return buffer;
        }
        private static float ToFloat(byte b1, byte b2, byte b3, byte b4)
        {
            byte[] auxArray = new[] { b1, b2, b3, b4 };
            float result = BitConverter.ToSingle(auxArray, 0);
            return result;
        }
    }
}