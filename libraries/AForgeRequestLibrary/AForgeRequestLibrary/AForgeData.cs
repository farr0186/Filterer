using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Bson;
using System.Diagnostics;
using AForgeRequestLibrary.util;

namespace AForgeRequestLibrary
{
    public class AForgeData : IAForgeData
    {

        public Stream Image { get; set; }

        public string FileFormat { get; set; }

        public string ProcessingType { get; set; }

        public AForgeData()
        {
            ClassType = typeof(AForgeData).AssemblyQualifiedName;
        }

        public AForgeData(string szProcessingType)
        {
            ProcessingType = szProcessingType;
            ClassType = typeof(AForgeData).AssemblyQualifiedName;
        }

        public AForgeData(Stream oImage, string szFileFormat)
        {
            Image = oImage;
            FileFormat = szFileFormat;
            ClassType = typeof(AForgeData).AssemblyQualifiedName;
        }

        public AForgeData(Stream oImage, string szFileFormat, string szProcessingType)
        {
            Image = oImage;
            FileFormat = szFileFormat;
            ProcessingType = szProcessingType;
            ClassType = typeof(AForgeData).AssemblyQualifiedName;
        }

        ~AForgeData()
        {
            if (Image != null)
            {
                Image.Dispose();
            }
        }

        public override void ToBson(BsonWriter oWriter)
        {
            base.ToBson(oWriter);

            oWriter.WritePropertyName("FileFormat");
            oWriter.WriteValue(FileFormat);
            oWriter.WritePropertyName("ProcessingType");
            oWriter.WriteValue(ProcessingType);
            oWriter.WritePropertyName("Image");
            using (MemoryStream oMs = new MemoryStream())
            {
                try
                {
                    Image.Position = 0;
                    StreamUtils.StreamCopy(Image, oMs);
                    oWriter.WriteValue(oMs.ToArray());
                }
                catch (Exception oException)
                {
                    Debug.WriteLine("Failed to encode the image MemoryStream to Bson. Error: {0}", oException.Message);
                    throw oException;
                }
            }
        }

        public override void FromBson(BsonReader oReader)
        {
            base.FromBson(oReader);
            while (oReader.Read())
            {
                if (oReader.TokenType == Newtonsoft.Json.JsonToken.PropertyName)
                {
                    if (String.Equals(oReader.Value, "FileFormat"))
                    {
                        FileFormat = oReader.ReadAsString();
                    }
                    else if (String.Equals(oReader.Value, "ProcessingType"))
                    {
                        ProcessingType = oReader.ReadAsString();
                    }
                    else if (String.Equals(oReader.Value, "Image"))
                    {
                        try
                        {
                            Byte[] aBytes = oReader.ReadAsBytes();
                            Image = new MemoryStream(aBytes);
                        }
                        catch (ArgumentNullException oException)
                        {
                            Debug.WriteLine("Failed to decode the Bson into an image MemoryStream. Error: {0}", oException.Message);
                            throw oException;
                        }
                        return;
                    }
                }
            }
        }

    }
}