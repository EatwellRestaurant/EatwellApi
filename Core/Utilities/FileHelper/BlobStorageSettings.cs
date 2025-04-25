using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.FileHelper
{
    public class BlobStorageSettings
    {
        public string ContainerName { get; set; }

        public string AccountName { get; set; }

        public string SasToken { get; set; }


    }
}
