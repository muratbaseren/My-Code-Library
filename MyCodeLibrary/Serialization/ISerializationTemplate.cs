using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCodeLibrary.Serialization
{
    public interface ISerializationTemplate
    {
        string Serialize(object obj);
        void Serialize(string path, object obj);
        object Deserialize(string path, Type type);
        object Deserialize(object obj, Type type);
    }
}
