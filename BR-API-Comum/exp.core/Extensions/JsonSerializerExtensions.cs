using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace exp.core
{
    public static class JsonSerializerExtensions
    {
        public static string ToJson<T>(this T obj)
        {
            MemoryStream stream;

            using (stream = new MemoryStream())
            {
                var serializer = new DataContractJsonSerializer(typeof(T));
                serializer.WriteObject(stream, obj);
            }

            return Encoding.Default.GetString(stream.ToArray());
        }

        public static T FromJson<T>(this string json)
        {
            T obj;

            using (var stream = new MemoryStream(Encoding.Default.GetBytes(json)))
            {
                var serializer = new DataContractJsonSerializer(typeof(T));
                obj = (T)serializer.ReadObject(stream);
            }

            return obj;
        }
    }
}