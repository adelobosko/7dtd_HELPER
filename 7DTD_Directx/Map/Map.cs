using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7DTD_Directx.Map
{
    internal class Map
    {
        public string Name { get; private set; }
        public string Path { get; private set; }
        public (string IP, string Port) Host { get; private set; }
        public int Size { get; internal set; }

        public Map(string name, string path, (string IP, string Port) host)
        {
            Name = name;
            Path = path;
            Host = host;
        }
    }
}
