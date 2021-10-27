using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace flytt2021.Data
{
    public class AzureKeyVaultSettings
    {
        /*
    "UseAzureKeyVault": false,
    "AzureKeyVaultUri": "",
    "SendGridKey": "SendGridKey"
        */

        public bool UseAzureKeyVault { get; set; }
        public string AzureKeyVaultUri { get; set; }

        public string SendGridKey { get; set; }
    }
}
