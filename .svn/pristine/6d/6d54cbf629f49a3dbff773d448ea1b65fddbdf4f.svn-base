using AForgeRequestLibrary;
using AForgeRequestLibrary.error;
using AForgeRequestLibrary.filter;
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
        private static int degreeRotated;
        private void init()
        {
            // Work around for known bug in the media framework.  Hits the static constructors
            // so the user does not need to go to the picture hub first.
            degreeRotated = 0;
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
                    //Microsoft.Phone.Shell.ApplicationBarMenuItem m = new Microsoft.Phone.Shell.ApplicationBarMenuItem("Option 7");
                    //m.Click += options1ButtonHandler;
                    //ApplicationBar.MenuItems.Add(m);//needs to be an ApplicationBarMenuItem object
                    
                }
            }

        }
        private static WriteableBitmap RotateBitmap(WriteableBitmap source, int width, int height)
        {
            var target = new WriteableBitmap(width, height);
            int sourceIndex = 0;
            int targetIndex = 0;
            for (int x = 0; x < source.PixelWidth; x++)
            {
                for (int y = 0; y < source.PixelHeight; y++)
                {
                    sourceIndex = x + y * source.PixelWidth;
                    targetIndex = (source.PixelHeight - y - 1) + x * target.PixelWidth;
                    target.Pixels[targetIndex] = source.Pixels[sourceIndex];
                }
            }
            return target;
        }
        private void displayImage(BitmapImage image)
        {
            imageWindow.Source = image;
        }
        private void rotateImage(object sender, RoutedEventArgs e)
        {
            BitmapImage image = (BitmapImage)imageWindow.Source;
            WriteableBitmap bitMap = new WriteableBitmap(image);
            WriteableBitmap newBitMap = RotateBitmap(bitMap, image.PixelHeight, image.PixelWidth);
            BitmapImage newImage = new BitmapImage();
            Stream stream = new MemoryStream();
            newBitMap.SaveJpeg(stream, image.PixelWidth, image.PixelHeight, 0, 100);

            newImage.SetSource(stream);
            imageWindow.Source = newImage;
            degreeRotated++;
            degreeRotated &= 3;

        }
        private void getNextImage()
        {
            if (cameraRoll != null && cameraRoll.Pictures.Count > 0)
            {
                noPictures.Visibility = System.Windows.Visibility.Collapsed;
                rotatetButton.Visibility = System.Windows.Visibility.Visible;
                imageWindow.Visibility = System.Windows.Visibility.Visible;
                nextButton.Visibility = System.Windows.Visibility.Visible;
                previousButton.Visibility = System.Windows.Visibility.Visible;
                picNum++;
                if (picNum == cameraRoll.Pictures.Count)
                    picNum = 0;
                Stream s = cameraRoll.Pictures[picNum].GetImage();
                BitmapImage image = new BitmapImage();
                image.SetSource(s);

                displayImage(image);
            }
            else
            {
                noPictures.Visibility = System.Windows.Visibility.Visible;
                imageWindow.Visibility = System.Windows.Visibility.Collapsed;
                nextButton.Visibility = System.Windows.Visibility.Collapsed;
                previousButton.Visibility = System.Windows.Visibility.Collapsed;
                editButton.Visibility = System.Windows.Visibility.Collapsed;
                rotatetButton.Visibility = System.Windows.Visibility.Collapsed;
            }
            degreeRotated = 0;
        }
        private void getPreviousImage()
        {
            picNum--;
            if (picNum == -1)
                picNum = cameraRoll.Pictures.Count - 1;
            Stream s = cameraRoll.Pictures[picNum].GetImage();
            BitmapImage image = new BitmapImage();
            image.SetSource(s);
                displayImage(image);

            degreeRotated = 0;
        }
        public static BitmapImage getCurrentImage()
        {
            Stream s;
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
                    }
                }
            }
            int tempInt = degreeRotated;
            BitmapImage image;
            s = cameraRoll.Pictures[picNum].GetImage();
            image = new BitmapImage();
            image.SetSource(s);
            WriteableBitmap newBitMap = new WriteableBitmap(image);
            for (int i = 0; i < degreeRotated; i++)
                newBitMap = RotateBitmap(newBitMap, image.PixelHeight, image.PixelWidth);
            BitmapImage newImage = new BitmapImage();
            Stream stream = new MemoryStream();
            newBitMap.SaveJpeg(stream, image.PixelWidth, image.PixelHeight, 0, 100);
            newImage.SetSource(stream);
            return newImage;

        }

        private void cameraRollButtonDispatch(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            switch (button.Name)
            {
                case "nextButton":
                    getNextImage();
                    break;
                case "previousButton":
                    getPreviousImage();
                    break;
                case "editButton":
                    NavigationService.Navigate(new Uri("/EditPicture.xaml", UriKind.Relative));
                    break;
            }
            //Microsoft.Phone.Shell.ApplicationBarMenuItem m = sender as Microsoft.Phone.Shell.ApplicationBarMenuItem;
        }

        public CameraRoll()
        {
            InitializeComponent();
            init();
            getNextImage();
        }
    }
}