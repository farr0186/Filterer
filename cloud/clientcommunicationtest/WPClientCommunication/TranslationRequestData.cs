using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Runtime.Serialization;
using Newtonsoft.Json.Bson;
using System.IO;

namespace WPClientCommunication
{


    public class TranslationRequestData : IBsonSerializable
    {

        private int iVersion = 1;
        public int Version
        {
            get { return iVersion; }
        }

        private string szSourceLanguage;
        public string SourceLanguage
        {
            get { return szSourceLanguage; }
            set { szSourceLanguage = value; }
        }

        private string szTargetLanguage;
        public string TargetLanguage
        {
            get { return szTargetLanguage; }
            set { szTargetLanguage = value; }
        }

        private Image oSourceImage;
        public Image SourceImage
        {
            get { return oSourceImage; }
            set { oSourceImage = value; }
        }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public TranslationRequestData()
        {

        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="sourceLanguage">The language the text of the image is in</param>
        /// <param name="targetLanguage">The language to translate the source into</param>
        /// <param name="sourceImage">The image containing the source text</param>
        public TranslationRequestData(string sourceLanguage, string targetLanguage, Bitmap sourceImage)
        {
            this.SourceLanguage = sourceLanguage;
            this.TargetLanguage = targetLanguage;
            this.SourceImage = sourceImage;
        }

        
        public void writeBson(BsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("SourceLanguage");
            writer.WriteValue(this.szSourceLanguage);
            writer.WritePropertyName("TargetLanguage");
            writer.WriteValue(this.szTargetLanguage);
            writer.WritePropertyName("Version");
            writer.WriteValue(this.iVersion);
            writer.WritePropertyName("Image");

            MemoryStream ms = new MemoryStream();
            this.oSourceImage.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            writer.WriteValue(ms.ToArray());

            writer.WriteEndObject();
        }

        public void readBson(BsonReader reader)
        {
            while (reader.Read())
            {
                if (reader.TokenType == Newtonsoft.Json.JsonToken.PropertyName)
                {
                    if (String.Equals(reader.Value, "SourceLanguage"))
                    {
                        szSourceLanguage = reader.ReadAsString();
                    }
                    else if (String.Equals(reader.Value, "TargetLanguage"))
                    {
                        szTargetLanguage = reader.ReadAsString();
                    }
                    else if (String.Equals(reader.Value, "Version"))
                    {
                        iVersion = (int)reader.ReadAsInt32();
                    }
                    else if (String.Equals(reader.Value, "Image"))
                    {
                        byte[] imgByteArr = reader.ReadAsBytes();
                        MemoryStream ms = new MemoryStream(imgByteArr);
                        oSourceImage = Image.FromStream(ms);
                    }
                }
            }
        }
    }
}
