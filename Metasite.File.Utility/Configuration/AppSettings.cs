using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Metasite.File.Utility.Configuration
{
    public class AppSettings
    {
        public string FilesLocation { get; set; }
        public Dictionary<string, string> MimeTypes { get; set; }
    }
}
