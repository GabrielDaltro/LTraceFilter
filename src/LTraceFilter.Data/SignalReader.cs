using System.Globalization;
using System.Text;
using LTraceFilter.Business.Application.Abstractions;

namespace LTraceFilter.Data
{
    public class SignalReader : ISignalReader
    {
        public float[] ReadSignalFromFile(string path)
        {
            List<float> signal = new List<float>();
            using (var fileStream = File.OpenRead(path))
            {
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true))
                {
                    String line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        signal.Add(float.Parse(line, CultureInfo.InvariantCulture));
                    }
                }
            }
            return signal.ToArray();
        }
    }
}