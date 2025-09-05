using System.IO;
using System.Xml.Serialization;

namespace exp.core
{
    public static class ObjectExtensions
    {
        public static string ToXML<T>(this T obj) where T : new()
        {
            string retVal;
            using (var ms = new MemoryStream())
            {
                var xs = new XmlSerializer(typeof(T));
                xs.Serialize(ms, obj);
                ms.Flush();
                ms.Position = 0;
                var sr = new StreamReader(ms);
                retVal = sr.ReadToEnd();
            }

            return retVal;
        }
    }
}