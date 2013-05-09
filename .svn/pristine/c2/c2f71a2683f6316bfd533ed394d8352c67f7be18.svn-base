using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using WPClientCommunication;
using Newtonsoft.Json.Bson;
using System.Drawing;
using System.IO;
using Newtonsoft.Json;
using System.Web;
using System.Net;
using BsonCommunicationLibrary;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            
            TranslationRequestData trd = new TranslationRequestData();

            trd.SourceLanguage = "Spanish";
            trd.TargetLanguage = "English";
            
            //trd.SourceImage = Image.FromFile("C:\\Users\\Patrick\\Pictures\\Penguins.jpg");
            //Console.WriteLine(trd.SourceImage.Width);

            using (FileStream fs = new FileStream("C:\\Users\\Tom\\Pictures\\hax.jpg", FileMode.Open))
            {
                MemoryStream imgStream = new MemoryStream();
                imgStream.SetLength(fs.Length);
                fs.CopyTo(imgStream);
                trd.Image = imgStream;
            }

            // serialize product to BSON
            Stream ms = new MemoryStream();
            //BsonWriter writer = new BsonWriter(ms);
            //trd.writeBson(writer);
            trd.ToBson(ref ms);

            WebRequest request = WebRequest.Create("http://localhost:81/whatever.rest");
            //WebRequest request = WebRequest.Create("http://1241052test.cloudapp.net/whatever.rest");
            request.Method = "POST";
            BinaryReader binaryReader = new BinaryReader(ms);
            int payloadLength = (int) ms.Length;
            ms.Seek(0, SeekOrigin.Begin);
            byte[] payload = binaryReader.ReadBytes(payloadLength);

            request.ContentLength = payload.Length;

            // This isn't right, but does it matter?  Only if I'm using it.
            request.ContentType = "application/x-www-form-urlencoded";

            Stream dataStream = request.GetRequestStream();

            dataStream.Write(payload, 0, payload.Length);

            dataStream.Close();

            WebResponse response = request.GetResponse();

            Stream responseStream = response.GetResponseStream();

            StreamReader responseReader = new StreamReader(responseStream);

            string responseText = responseReader.ReadToEnd();
            Console.WriteLine(responseText);

            response.Close();

            ms.Seek(0, SeekOrigin.Begin);

            /*
            // deserialize product from BSON
            //BsonReader reader = new BsonReader(ms);
            

            TranslationRequestData trd2 = new TranslationRequestData();
            trd2.FromBson(ms);
            Console.WriteLine(trd2.SourceLanguage);
            Console.WriteLine(trd2.TargetLanguage);
            //Console.WriteLine(trd2.SourceImage.Width);
            string x = Console.ReadLine();

            //WebRequest request = WebRequest.Create("http://localhost:81/whatever.rest");
            WebRequest request = WebRequest.Create("http://1241052test.cloudapp.net/whatever.rest");
            request.Method = "POST";
            BinaryReader binaryReader = new BinaryReader(ms);
            int payloadLength = (int) ms.Length;
            ms.Seek(0, SeekOrigin.Begin);
            //String payloadString = "Je pense, donc je suis.";
            //int payLoadLength = Encoding.UTF8.GetByteCount(payloadString);
            //byte[] payload = Encoding.UTF8.GetBytes(payloadString);
            //binaryReader.ReadBytes(payloadLength);

            request.ContentLength = payload.Length;

            // This isn't right, but does it matter?  Only if I'm using it.
            request.ContentType = "application/x-www-form-urlencoded";

            Stream dataStream = request.GetRequestStream();

            dataStream.Write(payload, 0, payload.Length);

            dataStream.Close();

            WebResponse response;

            response = request.GetResponse();

            Stream responseStream = response.GetResponseStream();

            StreamReader responseReader = new StreamReader(responseStream);

            string responseText = responseReader.ReadToEnd();
            Console.WriteLine(responseText);

            response.Close();

            //ms.Seek(0, SeekOrigin.Begin);

            // deserialize product from BSON
            //BsonReader reader = new BsonReader(ms);
            //TranslationRequestData trd2 = new TranslationRequestData();
            //trd2.FromBson(ms);
            Console.WriteLine(responseText);
            //Console.WriteLine(trd2.TargetLanguage);
            //Console.WriteLine(trd2.SourceImage.Width);
            */
            string x = Console.ReadLine();
        }
    }
}
