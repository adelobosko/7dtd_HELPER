using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _7dtd_HELP
{
    class Config
    {
        public PrefabsConfig PrefabsConfig { get; set; }

        public Config()
        {
            PrefabsConfig = new PrefabsConfig();
        }
    }
}
