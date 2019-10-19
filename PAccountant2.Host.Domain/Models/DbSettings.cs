using System;
using System.Collections.Generic;
using System.Text;

namespace PAccountant2.Host.Domain.Models
{
    public class DbSettings
    {
        public Dictionary<string, string> ConnectionStrings { get; set; }
        public string MigrationAssembly { get; set; }
        public string CurrentConnectionName { get; set; }
    }
}
