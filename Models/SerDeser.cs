using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PW6CSharpWPF.Models
{
    public static class SerializationHelper
    {
        public static void Serialize<T>(string filename, T data)
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                string json = JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.Indented);
                writer.Write(json);
            }
        }

        public static T Deserialize<T>(string filename)
        {
            using (StreamReader reader = new StreamReader(filename))
            {
                string json = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<T>(json);
            }
        }
    }
}
