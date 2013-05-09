using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Xna.Framework.Media;
using System.Windows.Media.Imaging;
using System.Collections.ObjectModel;
using System.IO.IsolatedStorage;
using Microsoft.Phone;
using System.IO;
using System.Diagnostics;
using PhoneApp1;



namespace UserInterface
{
    public class PicSample
    {
        public BitmapImage ImageUrl { get; set; }
        public string ShortName { get; set; }
    }

    public partial class CameraRoll : PhoneApplicationPage
    {

        private static int picNum = -1;
        private static PictureAlbum cameraRoll = null;
        private static PictureAlbum savedPics = null;
        private void init()
        {
            // Work around for known bug in the media framework.  Hits the static constructors
            // so the user does not need to go to the picture hub first.
            MediaPlayer.Queue.ToString();

            MediaLibrary ml = null;
            foreach (MediaSource source in MediaSource.GetAvailableMediaSources())
            {
                if (source.MediaSourceType == MediaSourceType.LocalDevice)
                {
                    ml = new MediaLibrary(source);
                    PictureAlbumCollection allAlbums = ml.RootPictureAlbum.Albums;

                    foreach (PictureAlbum album in allAlbums)
                    {
                        if (album.Name == "Camera Roll")
                        {
                            cameraRoll = album;
                        }

                        if (album.Name == "Saved Pictures")
                        {
                            savedPics = album;
                        }
                    }
                }
            }

        }
        private void getNextImage()
        {
            picNum++;
            if (picNum == cameraRoll.Pictures.Count)
                picNum = 0;
            Stream s = cameraRoll.Pictures[picNum].GetImage();
            BitmapImage image = new BitmapImage();
            image.SetSource(s);
            imageWindow.Source = image;

        }
        private void getPreviousImage()
        {
            picNum--;
            if (picNum == -1)
                picNum = cameraRoll.Pictures.Count - 1;
            Stream s = cameraRoll.Pictures[picNum].GetImage();
            BitmapImage image = new BitmapImage();
            image.SetSource(s);
            imageWindow.Source = image;

        }
        public static BitmapImage getCurrentImage()
        {
            BitmapImage image = new BitmapImage();
            Stream s;
            try
            {
                s = cameraRoll.Pictures[picNum].GetImage();
                image = new BitmapImage();
                image.SetSource(s);
                return image;
            }
            catch (IsolatedStorageException e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }

        }

        private void cameraRollButtonDispatch(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            switch (button.Name)
            {
                case "next":
                    getNextImage();
                    break;
                case "previous":
                    getNextImage();
                    break;
                case "translate":
                    /*preprocess the image, and send the result to the translateResult page*/
                    NavigationService.Navigate(new Uri("/TranslateOptions.xaml", UriKind.Relative));
                    break;
            }
        }

        public CameraRoll()
        {
            InitializeComponent();
            init();
            getNextImage();
        }
    }
}