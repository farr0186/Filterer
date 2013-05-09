using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AForgeRequestLibrary;
using System.IO;
using AForgeRequestLibrary.filter;
using AForgeRequestLibrary.error;
using System.Threading;

namespace AForgeRequestLibraryTest
{
    [TestClass]
    public class WebRequestTests
    {
        private AutoResetEvent _TestTrigger;
        private bool passed = false;
        private IAForgeData oReturnData;

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
        public void SepiaWebRequestTest()
        {
            //load an image from a file
            MemoryStream oImgStream = null;
            using (FileStream oFileStream = new FileStream(@"TestData\test_image_1.png", FileMode.Open))
            {
                oImgStream = new MemoryStream();
                oImgStream.SetLength(oFileStream.Length);
                oFileStream.CopyTo(oImgStream);
            }

            //wait for the Async request to complete
            this._TestTrigger = new AutoResetEvent(false);
            

            SepiaFilterData oData = new SepiaFilterData(oImgStream, Imaging.ImageFormats.PNG);
            AForgeRequest oRequest = new AForgeRequest(oData);
            oRequest.OnAForgeSuccess += OnSuccess;
            oRequest.OnAForgeFailure += OnFailure;
            oRequest.Timeout = 1000 * 60;
            oRequest.SendRequestAsync();

            this._TestTrigger.WaitOne();
            Assert.IsTrue(passed);

            SepiaFilterData oData2 = oReturnData as SepiaFilterData;

            Assert.AreEqual(oData.ClassType, oData2.ClassType);
            Assert.AreEqual(1, oData2.Version);
            Assert.AreEqual(Imaging.ImageFormats.PNG, oData2.FileFormat);
            Assert.AreEqual(Imaging.Filters.SEPIA, oData2.ProcessingType);
            Assert.IsTrue(ByteArrayCompare(((MemoryStream)oImgStream).ToArray(), ((MemoryStream)oData2.Image).ToArray()));
        }

        private void OnFailure(AForgeError oError)
        {
            passed = false;
            oReturnData = oError;
            this._TestTrigger.Set();
        }

        private void OnSuccess(IAForgeData oResponseData)
        {
            passed = true;
            oReturnData = oResponseData;
            this._TestTrigger.Set();
        }
    }
}
