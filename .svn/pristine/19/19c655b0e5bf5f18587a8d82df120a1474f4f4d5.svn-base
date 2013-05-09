using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading;
using System.IO;
using System.Diagnostics;

namespace AForgeRequestLibrary.web
{
    class AzureWebRequest : IAzureWebRequest
    {

        private HttpWebRequest oAzureWebRequest;

        public string ContentType 
        {
            get
            {
                if (oAzureWebRequest != null)
                {
                    return oAzureWebRequest.ContentType;
                }
                return null;
            }
            set
            {
                if (oAzureWebRequest != null)
                {
                    oAzureWebRequest.ContentType = value;
                }
                else
                {
                    throw new ArgumentNullException(string.Format("Cannot set the Content type of AzureWebRequest to '{0}'. The AzureWebRequest is null.", value));
                }
            }
        }

        public string Method
        {
            get
            {
                if (oAzureWebRequest != null)
                {
                    return oAzureWebRequest.Method;
                }
                return null;
            }
            set
            {
                if (oAzureWebRequest != null)
                {
                    oAzureWebRequest.Method = value;
                }
                else
                {
                    throw new ArgumentNullException("Cannot set the Method of AzureWebRequest to '{0}'. The AzureWebRequest is null.", value);
                }
            }
        }

        /// <summary>
        /// The HttpRequest timeout in milliseconds
        /// </summary>
        public int Timeout { get; set; }

        private Uri oUri;
        public Uri Uri { get; set; }

        public IAzureWebRequestHandler Handler { get; set; }
        
        private Timer oTimeoutTimer;
        private HttpWebRequest oRequest;
        
        public void BeginRequestAsync()
        {
            oTimeoutTimer = new Timer(TimeoutTimerCallback, null, Timeout, -1);

            oAzureWebRequest.BeginGetRequestStream(new AsyncCallback(GetRequestStreamCallback), oAzureWebRequest);
        }

        public void HandleWebResponse(HttpWebResponse oWebResponse)
        {
            if (Handler != null)
            {
                Handler.HandleResponseAsync(oWebResponse.StatusCode, oWebResponse);
            }
            else
            {
                throw new NullReferenceException("The Helper is null. Check that it was set before calling BeginRequestAsync()");
            }
        }

        /// <summary>
        /// Asynchronously sends the requestData to Azure
        /// </summary>
        /// <param name="oAsynchronousResult">The method that should be called when the request finishes</param>
        private void GetRequestStreamCallback(IAsyncResult oAsynchronousResult)
        {
            oRequest = (HttpWebRequest)oAsynchronousResult.AsyncState;

            Stream oStream = oRequest.EndGetRequestStream(oAsynchronousResult);
            if (Handler != null)
            {
                Handler.HandleRequestAsync(ref oStream);
            }
            else
            {
                throw new NullReferenceException("The Helper is null. Check that it was set before calling BeginRequestAsync()");
            }
            oStream.Dispose();
            // Start the asynchronous operation to get the response
            oRequest.BeginGetResponse(new AsyncCallback(GetResponseCallback), oRequest);
        }

        /// <summary>
        /// Recieves the translation result from Azure
        /// </summary>
        /// <param name="oAsynchronousResult"></param>
        private void GetResponseCallback(IAsyncResult oAsynchronousResult)
        {
            Debug.WriteLine("Starting GetResponseCallback");

            HttpWebRequest oRequest = (HttpWebRequest)oAsynchronousResult.AsyncState;

            // End the operation
            HttpWebResponse oResponse = null;
            try
            {
                oResponse = (HttpWebResponse)oRequest.EndGetResponse(oAsynchronousResult);
            }
            catch (Exception oException)
            {
                Debug.WriteLine("Failed to retrieve the response from the server. Exception: {0} {1}", oException.Message, oException.StackTrace);

                if (Handler != null)
                {
                    Handler.HandleResponseAsync(HttpStatusCode.ServiceUnavailable, null);
                }
                else
                {
                    throw new NullReferenceException("The Helper is null. Check that it was set before calling BeginRequestAsync()");
                }

                return;
            }
            finally
            {
                oTimeoutTimer.Dispose();
            }

            //if we got the response back let the handler handle it
            if (Handler != null)
            {
                Handler.HandleResponseAsync(oResponse.StatusCode, oResponse);
            }
            else
            {
                throw new NullReferenceException("The Helper is null. Check that it was set before calling BeginRequestAsync()");
            }

            // Release the HttpWebResponse
            oResponse.Dispose();
        }

        /// <summary>
        /// Called when the HttpWebRequest times out
        /// </summary>
        private void TimeoutTimerCallback(object oState)
        {
            if (oRequest != null)
                oRequest.Abort();
            oTimeoutTimer.Dispose();

            if (Handler != null)
            {
                Handler.HandleResponseAsync(HttpStatusCode.RequestTimeout, null);
            }
            else
            {
                throw new NullReferenceException("The Helper is null. Check that it was set before calling BeginRequestAsync()");
            }
        }

        #region Constructors

        /// <summary>
        /// Create a WebRequestHelper with the ContentType = "application/bson"
        /// and Method = "POST";
        /// </summary>
        /// <param name="oUri">The web Uri</param>
        public AzureWebRequest(Uri oUri)
        {
            oAzureWebRequest = (HttpWebRequest)WebRequest.Create(oUri);
            oAzureWebRequest.ContentType = "application/bson";
            oAzureWebRequest.Method = "POST";
            Timeout = 1000 * 120;
        }

        /// <summary>
        /// Create a WebRequestHelper with the given HttpWebRequest values
        /// </summary>
        /// <param name="oWebRequest"></param>
        public AzureWebRequest(HttpWebRequest oWebRequest)
        {
            oAzureWebRequest = oWebRequest;
            Timeout = 1000 * 120;
        }

        #endregion
    }
}
