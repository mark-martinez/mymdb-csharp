using MyMDB.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMDB.Core.Model;

namespace MyMDB.Core.API
{
    public sealed class Configuration
    {
        private static readonly Configuration instance = new Configuration();
        private static ConfigurationModel config = new ConfigurationModel();

        static Configuration() { }

        private Configuration()
        {
            APICaller.UpdateConfiguration();
        }

        public static Configuration Instance
        {
            get { return instance; }
        }

        public static ConfigurationModel Set
        {
            set { config = value; }
        }
    }
}
