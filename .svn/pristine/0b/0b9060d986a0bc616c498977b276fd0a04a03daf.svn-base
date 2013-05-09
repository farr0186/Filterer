using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AForgeRequestLibrary.web
{
    public interface IAzureWebRequest
    {
        /// <summary>
        /// The HttpRequest timeout in milliseconds
        /// </summary>
        int Timeout { get; set; }

        IAzureWebRequestHandler Handler { get; set; }

        void BeginRequestAsync();
    }
}
