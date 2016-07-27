using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCodeLibrary.Serialization
{
    public class Json : ISerializationTemplate
    {
        public object Deserialize(object obj, Type type)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject(obj.ToString(), type);
        }

        public object Deserialize(string path, Type type)
        {
            // Dosyadan json okunur.
            string json = System.IO.File.ReadAllText(path);
            object obj = json;

            // Deserialize metodu ile json metnini type parametresi ile deserialize ediyorum.
            return Deserialize(obj, type);
        }

        public string Serialize(object obj)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(obj);
        }

        public void Serialize(string path, object obj)
        {
            // Önce json olarak obj serialize edip metni elde ediyorum.
            string json = Serialize(obj);

            // Sonra dosyaya json metnini yazıyorum.
            System.IO.File.WriteAllText(path, json);
        }
    }
}
