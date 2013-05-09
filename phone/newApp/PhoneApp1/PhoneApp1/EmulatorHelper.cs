using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using Microsoft.Xna.Framework.Media;
using System.IO;
using System.Windows.Media.Imaging;

namespace PhoneApp1
{
    /// <summary>
    /// Source: http://www.softwareisinthedetails.com/2012/11/add-test-images-on-windows-phone-emulator.html
    /// </summary>
    public static class EmulatorHelper
    {
        const string flagName = "__emulatorTestImagesAdded";

        public static void AddDebugImages()
        {
            bool alreadyAdded = CheckAlreadyAdded();
            if (!alreadyAdded)
            {
                AddImages();
                SetAddedFlag();
            }
        }

        private static bool CheckAlreadyAdded()
        {
            IsolatedStorageSettings userSettings = IsolatedStorageSettings.ApplicationSettings;

            try
            {
                bool alreadyAdded = (bool)userSettings[flagName];
                return alreadyAdded;
            }
            catch (KeyNotFoundException)
            {
                return false;
            }
            catch (ArgumentException)
            {
                return false;
            }
        }

        private static void SetAddedFlag()
        {
            IsolatedStorageSettings userSettings = IsolatedStorageSettings.ApplicationSettings;
            userSettings.Add(flagName, true);
            userSettings.Save();
        }

        private static void AddImages()
        {
            string[] fileNames = { "american_flag" };
            foreach (var fileName in fileNames)
            {
                var myStore = IsolatedStorageFile.GetUserStoreForApplication();
                Uri myUri = new Uri(String.Format(@"TestImages/{0}.jpg", fileName), UriKind.Relative);
                Stream photoStream = App.GetResourceStream(myUri).Stream;
                BitmapImage bitmap = new BitmapImage();
                bitmap.CreateOptions = BitmapCreateOptions.None;
                bitmap.SetSource(photoStream);
                WriteableBitmap wb = new WriteableBitmap(bitmap);
                IsolatedStorageFileStream myFileStream = myStore.CreateFile("tempJPEG");
                wb.SaveJpeg(myFileStream, wb.PixelWidth, wb.PixelHeight, 0, 85);
                myFileStream.Close();
    
                myFileStream = myStore.OpenFile("tempJPEG", FileMode.Open, FileAccess.Read);
                
                MediaLibrary myMediaLibrary = new MediaLibrary();
    
                //byte[] buffer = new byte[photoStream.Length];
                //photoStream.Read(buffer, 0, Convert.ToInt32(photoStream.Length));
                myMediaLibrary.SavePictureToCameraRoll("american_flag2.jpg",myFileStream);
                myFileStream.Close();
                photoStream.Close();
            }
        }
    }
}
