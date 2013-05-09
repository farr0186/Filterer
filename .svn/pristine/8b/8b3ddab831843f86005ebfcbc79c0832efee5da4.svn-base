using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace AForgeRequestLibrary.web
{
    public interface IAzureWebRequestHandler
    {
        void HandleRequestAsync(ref Stream oStream);
        void HandleResponseAsync(HttpStatusCode eStatusCode, HttpWebResponse oWebResponse);
    }
}
