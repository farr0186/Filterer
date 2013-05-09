﻿using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using Microsoft.Xna.Framework.Media;

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
            string[] fileNames = { "TEST_1", "TEST_2" };
            foreach (var fileName in fileNames)
            {
                MediaLibrary myMediaLibrary = new MediaLibrary();
                Uri myUri = new Uri(String.Format(@"TestImages/{0}.jpg", fileName), UriKind.Relative);

                System.IO.Stream photoStream = App.GetResourceStream(myUri).Stream;
                byte[] buffer = new byte[photoStream.Length];
                photoStream.Read(buffer, 0, Convert.ToInt32(photoStream.Length));
                myMediaLibrary.SavePicture(String.Format("{0}.jpg", fileName), buffer);
                photoStream.Close();
            }
        }
    }
}
