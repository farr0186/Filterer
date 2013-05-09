using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Diagnostics;
using Microsoft.WindowsAzure.ServiceRuntime;
using Newtonsoft.Json;
using System.Net;
using System.Web;
using System.Text;
using System.Drawing;
using Newtonsoft.Json.Bson;
using AForgeRequestLibrary;
using AForgeRequestLibrary.filter;
using System.IO;
using FilterFunctions;

namespace WebRole1
{
    public class WebRole : RoleEntryPoint
    {
        public override bool OnStart()
        {
            // For information on handling configuration changes
            // see the MSDN topic at http://go.microsoft.com/fwlink/?LinkId=166357.
            WebRequest webRequest = WebRequest.Create("http://www.google.com");
            return base.OnStart();
        }
    }

    public class REST_Handler : IHttpHandler
    {
        #region HANDLER

        private ErrorHandler.ErrorHandler errHandler;

        private string translationData = "";

        public bool IsReusable
        {
            // Return false in case your Managed Handler cannot be reused for another request.
            // Usually this would be false in case you have some state information preserved per request.
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                string url = Convert.ToString(context.Request.Url);
                errHandler = new ErrorHandler.ErrorHandler();

                //Handling CRUD
                switch (context.Request.HttpMethod)
                {
                    case "GET":
                        //Perform READ Operation                   
                        READ(context);
                        break;
                    case "POST":
                        //Perform CREATE Operation
                        CREATE(context);
                        break;
                    case "PUT":
                        //Perform UPDATE Operation
                        //UPDATE(context);
                        break;
                    case "DELETE":
                        //Perform DELETE Operation
                        //DELETE(context);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {

                errHandler.ErrorMessage = ex.Message.ToString();
                context.Response.Write(errHandler.ErrorMessage);
            }
        }

        #endregion

        #region CRUD Functions

        private void READ(HttpContext context)
        {
            DateTime dt;
            String useUtc = context.Request.QueryString["utc"];
            if (!String.IsNullOrEmpty(useUtc) &&
                    useUtc.Equals("true"))
            {
                dt = DateTime.UtcNow;
            }
            else
            {
                dt = DateTime.Now;
            }
            context.Response.Write(
                String.Format("<h1>{0}</h1>",
                               dt.ToLongTimeString()
                               ));
            context.Response.Write(
                String.Format("<h1>{0}</h1>", translationData)
                );
        }

        private static string bytearraytohex(byte[] ba)
        {
            StringBuilder sb = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
            {
                sb.AppendFormat("{0:x2}", b);
            }
            return sb.ToString();
        }

        private void CREATE(HttpContext context)
        {
            // The message body is posted as bytes. read the bytes
            byte[] postData = context.Request.BinaryRead(context.Request.ContentLength);

            Stream memoryStream = new MemoryStream(postData);

            //once I make this implement disposable you should add this to a using block
            AForgeData input = (AForgeData)AForgeFactory.Create(ref memoryStream);

            //I think just moedifying the input and return taht is better. That way if the phone needs
            //to see any of its input info they can easily So that means this should be removed

            input.Stats.EndRequestTime = DateTime.UtcNow;

            Filters.applyFilter(ref input);

            input.Stats.BeginResponseTime = DateTime.UtcNow;
            //serialize response and send back to the client
            Stream oStream = new MemoryStream();
            AForgeSerializer.SerializeToBson(input, ref oStream);
            context.Response.BinaryWrite(((MemoryStream)oStream).ToArray());
            context.Response.Flush();
            oStream.Dispose();
            memoryStream.Dispose();


        }

        #endregion
    }
}

namespace ErrorHandler
{
    //Class responsible for handling error messages
    public class ErrorHandler
    {
        static StringBuilder errMessage = new StringBuilder();

        //Make class immutable
        static ErrorHandler()
        {
        }
        /// <summary>
        /// Prperty - holds exception messages encountered 
        /// at code execution
        /// </summary>
        public string ErrorMessage
        {
            get { return errMessage.ToString(); }
            set
            {
                errMessage.AppendLine(value);
            }
        }
    }
}