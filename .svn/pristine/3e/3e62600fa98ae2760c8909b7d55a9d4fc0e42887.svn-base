using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Newtonsoft.Json.Bson;
using AForgeRequestLibrary;
using AForgeRequestLibrary.filter;

namespace AForgeRequestLibraryTest
{
    [TestClass]
    public class SerializationTests
    {

        static bool ByteArrayCompare(byte[] aA1, byte[] aA2)
        {
            if (aA1.Length != aA2.Length)
                return false;

            for (int i = 0; i < aA1.Length; i++)
                if (aA1[i] != aA2[i])
                    return false;

            return true;
        }

        [TestMethod]
        public void AForgeImagingDataSerialization_Success()
        {

            //load an image from a file
            MemoryStream oImgStream = null;
            using (FileStream oFileStream = new FileStream(@"TestData\test_image_1.png", FileMode.Open))
            {
                oImgStream = new MemoryStream();
                oImgStream.SetLength(oFileStream.Length);
                oFileStream.CopyTo(oImgStream);
            }

            
            AForgeData oData = new AForgeData(oImgStream, Imaging.ImageFormats.PNG);
           
            Stream oStream = new MemoryStream();
            //convert the AForgeData object to Bson. The stream contains the
            //Bson representation of the AForgeData object
            using (BsonWriter oWriter = new BsonWriter(oStream))
            {
                //this is only needed in test cases
                oWriter.CloseOutput = false;

                oWriter.WriteStartObject();
                oWriter.WritePropertyName("ClassType");
                oWriter.WriteValue(oData.ClassType);
                oWriter.WritePropertyName("Data");
                oWriter.WriteStartObject();
                oData.ToBson(oWriter);
                oWriter.WriteEndObject();
                oWriter.WriteEndObject();
            }

            AForgeData odata2 = (AForgeData)AForgeFactory.Create(ref oStream);
            oStream.Dispose();

            //check that the values in data and data2 are identical
            Assert.AreEqual(oData.ClassType, odata2.ClassType);
            Assert.AreEqual(1, odata2.Version);
            Assert.AreEqual(Imaging.ImageFormats.PNG, odata2.FileFormat);          
            Assert.AreEqual(null, odata2.ProcessingType);
            Assert.IsTrue(ByteArrayCompare(((MemoryStream)oImgStream).ToArray(), ((MemoryStream)odata2.Image).ToArray()));
      
        }

        [TestMethod]
        public void SepiaFilterDataSerialization_Success()
        {

            //load an image from a file
            MemoryStream oImgStream = null;
            using (FileStream oFileStream = new FileStream(@"TestData\test_image_1.png", FileMode.Open))
            {
                oImgStream = new MemoryStream();
                oImgStream.SetLength(oFileStream.Length);
                oFileStream.CopyTo(oImgStream);
            }


            SepiaFilterData oData = new SepiaFilterData(oImgStream, Imaging.ImageFormats.PNG);

            Stream oStream = new MemoryStream();
            //convert the AForgeData object to Bson. The stream contains the
            //Bson representation of the AForgeData object
            using (BsonWriter oWriter = new BsonWriter(oStream))
            {
                //this is only needed in test cases
                oWriter.CloseOutput = false;

                oWriter.WriteStartObject();
                oWriter.WritePropertyName("ClassType");
                oWriter.WriteValue(oData.ClassType);
                oWriter.WritePropertyName("Data");
                oWriter.WriteStartObject();
                oData.ToBson(oWriter);
                oWriter.WriteEndObject();
                oWriter.WriteEndObject();
            }

            AForgeData oData2 = (AForgeData)AForgeFactory.Create(ref oStream);
            oStream.Dispose();
            

            //SepiaFilterData data3 = data2 as SepiaFilterData;

            //check that the values in data and data2 are identical
            Assert.AreEqual(oData.ClassType, oData2.ClassType);
            Assert.AreEqual(1, oData2.Version);
            Assert.AreEqual(Imaging.ImageFormats.PNG, oData2.FileFormat);
            Assert.AreEqual(Imaging.Filters.SEPIA, oData2.ProcessingType);
            Assert.IsTrue(ByteArrayCompare(((MemoryStream)oImgStream).ToArray(), ((MemoryStream)oData2.Image).ToArray()));

        }
    }
}
