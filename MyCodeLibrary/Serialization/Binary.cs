using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCodeLibrary.Serialization
{
    public class Binary : ISerializationTemplate
    {
        public object Deserialize(object obj, Type type)
        {
            throw new NotImplementedException();
        }

        public object Deserialize(string path, Type type)
        {
            throw new NotImplementedException();
        }

        public string Serialize(object obj)
        {
            throw new NotImplementedException();
        }

        public void Serialize(string path, object obj)
        {
            throw new NotImplementedException();
        }
    }
}
