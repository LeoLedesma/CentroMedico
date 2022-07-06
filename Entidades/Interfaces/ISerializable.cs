using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    
    public interface ISerializable
    {
        public void SerializarToXML(string fullPath);

        public void SerializarToJSON(string fullPath);
        
       
    }
}
