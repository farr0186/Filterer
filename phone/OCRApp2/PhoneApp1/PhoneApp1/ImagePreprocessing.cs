using System;

using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Media.Imaging;
using Microsoft.Phone.Shell;
using System.IO;
using BsonCommunicationLibrary;
using System.Diagnostics;

namespace PhoneApp1
{
    public class ImagePreprocessing
    {
        string translateFrom;
        string translateTo;
        string response = "Test Response";
        private Boolean hasReturned = false;
        private BitmapImage pic;
        TranslationRequestData translationRequestData;
        TranslateOptions translateOptions;
        public ImagePreprocessing(BitmapImage pic, string translateFrom, string translateTo, TranslateOptions tO)
        {
            this.translateFrom = translateFrom;
            this.translateTo = translateTo;
            this.pic = pic;
            this.changeResolution();
            this.translateOptions = tO;
        }

        public void changeResolution()
        {
            Stream stream = new MemoryStream();
            
            //StreamWriter s = new StreamWriter(stream);

            WriteableBitmap bitMap = new WriteableBitmap(this.pic);
            
            //find getting the BitmapImage into the WriteableBitmap
            bitMap.SaveJpeg(stream, 800, 600, 0, 70);

            //try to rebuild the image from the stream here
            //BitmapImage newImage = new BitmapImage();
            //newImage.SetSource(stream);
            this.translationRequestData = new TranslationRequestData(this.translateFrom, this.translateTo, stream);
        }
        public void sendTranslationRequest(){
            TranslationRequest tr = new TranslationRequest(this.translationRequestData);
            tr.OnTranslationSuccess += new TranslationRequest.OnTranslationSuccessEventHandler(onSuccess);
            tr.OnTranslationFailure += new TranslationRequest.OnTranslationFailureEventHandler(onFailure);
            tr.SendTranslationRequestAsync();
            //set a message that says waiting
        }
        public string getTranslation()
        {
            //sets the screen to not turn off
            PhoneApplicationService phoneAppService = PhoneApplicationService.Current;
            phoneAppService.UserIdleDetectionMode = IdleDetectionMode.Disabled;
            //while (!this.hasReturned);
            phoneAppService.UserIdleDetectionMode = IdleDetectionMode.Enabled;
            return this.response;
        }

        private void onFailure(System.Net.HttpStatusCode statusCode, string statusDescription)
        {
            this.response = "The request failed. Error Code: {0} Message: {1}" + statusCode + statusDescription;
            Debug.WriteLine("The request failed. Error Code: {0} Message: {1}", statusCode, statusDescription);
            this.translateOptions.openPopup(this.response);
        }

        void onSuccess(TranslationResponseData responseData)
        {
            this.response = responseData.Text;
            Debug.WriteLine("Response Version: {0}", responseData.Version);
            Debug.WriteLine("Response Text: {0}", responseData.Text);
            this.translateOptions.openPopup(this.response);
        }
    }
}
