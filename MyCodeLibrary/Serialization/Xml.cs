using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace MyCodeLibrary.Serialization
{
    public class Xml : ISerializationTemplate
    {
        public string Serialize(object obj)
        {
            XmlSerializer serializer = new XmlSerializer(obj.GetType());
            MemoryStream fs = new MemoryStream();
            serializer.Serialize(fs, obj);

            StreamReader sr = new StreamReader(fs);
            fs.Position = 0;
            string xml = sr.ReadToEnd();

            sr.Close();
            fs.Close();

            return xml;
        }

        public void Serialize(string path, object obj)
        {
            XmlSerializer serializer = new XmlSerializer(obj.GetType());
            FileStream fs = new FileStream(path, FileMode.Create);
            serializer.Serialize(fs, obj);
            fs.Close();
        }

        public object Deserialize(string path, Type type)
        {
            XmlSerializer serializer = new XmlSerializer(type);
            FileStream fs = new FileStream(path, FileMode.Open);
            object obj = serializer.Deserialize(fs);
            fs.Close();

            return obj;
        }

        public object Deserialize(object xml, Type type)
        {
            XmlSerializer serializer = new XmlSerializer(type);
            MemoryStream fs = new MemoryStream();

            XDocument xDoc = XDocument.Parse(xml.ToString());
            xDoc.Save(fs);

            fs.Position = 0;

            object obj = serializer.Deserialize(fs);
            fs.Close();

            return obj;
        }
    }
}
