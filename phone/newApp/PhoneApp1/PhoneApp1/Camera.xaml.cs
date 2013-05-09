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
using Microsoft.Devices;
using System.IO;
using System.IO.IsolatedStorage;
using Microsoft.Xna.Framework.Media;
using PhoneApp1;

namespace UserInterface
{
    public partial class CameraPage : PhoneApplicationPage
    {
        PhotoCamera cam;
        MediaLibrary library = new MediaLibrary();

        private String currentFlashMode;
        private int currentResIndex = 0;
        public CameraPage()
        {
            InitializeComponent();
        }
        void cam_Initialized(object sender, Microsoft.Devices.CameraOperationCompletedEventArgs e)
        {
            if (e.Succeeded)
            {
                this.Dispatcher.BeginInvoke(delegate()
                {
                    //txtDebug.Text = "Camera initialized.";
                });
            }
        }

        protected override void OnOrientationChanged(OrientationChangedEventArgs e)
        {
            if (cam != null)
            {
                int landscapeRightRotation = 180;
                if (cam.CameraType == CameraType.FrontFacing) landscapeRightRotation = -180;
                if (e.Orientation == PageOrientation.LandscapeRight)
                {
                    viewfinderBrush.RelativeTransform =
                        new CompositeTransform() { CenterX = 0.5, CenterY = 0.5, Rotation = landscapeRightRotation };

                }
                else
                {
                    viewfinderBrush.RelativeTransform =
                        new CompositeTransform() { CenterX = 0.5, CenterY = 0.5, Rotation = 0 };
                }
            }
            base.OnOrientationChanged(e);
        }

        private void ShutterButton_Click(object sender, RoutedEventArgs e)
        {
            if (cam != null)
            {
                try
                {
                    cam.CaptureImage();
                }
                catch (Exception ex)
                {
                    this.Dispatcher.BeginInvoke(delegate()
                    {
                        //txtDebug.Text = ex.Message;
                    });
                }
            }
        }
        // Provide auto-focus in the viewfinder.
        private void focus_Clicked(object sender, System.Windows.RoutedEventArgs e)
        {
            if (cam.IsFocusSupported == true)
            {
                //Focus when a capture is not in progress.
                try
                {
                    cam.Focus();
                }
                catch (Exception focusError)
                {
                    // Cannot focus when a capture is in progress.
                    this.Dispatcher.BeginInvoke(delegate()
                    {
                        //txtDebug.Text = focusError.Message;
                    });
                }
            }
            else
            {
                // Write message to UI.
                this.Dispatcher.BeginInvoke(delegate()
                {
                    //txtDebug.Text = "Camera does not support programmable auto focus.";
                });
            }
        }

        private void changeRes_Clicked(object sender, System.Windows.RoutedEventArgs e)
        {
            // Variables
            IEnumerable<Size> resList = cam.AvailableResolutions;
            int resCount = resList.Count<Size>();
            Size res;

            // Poll for available camera resolutions.
            for (int i = 0; i < resCount; i++)
            {
                res = resList.ElementAt<Size>(i);
            }

            // Set the camera resolution.
            res = resList.ElementAt<Size>((currentResIndex + 1) % resCount);
            cam.Resolution = res;
            currentResIndex = (currentResIndex + 1) % resCount;

            // Update the UI.
            //txtDebug.Text = String.Format("Setting capture resolution: {0}x{1}", res.Width, res.Height);
            ResButton.Content = "R" + res.Width;
        }

        private void backClicked(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

        // Activate a flash mode.
        // Cycle through flash mode options when the flash button is pressed.
        private void changeFlash_Clicked(object sender, RoutedEventArgs e)
        {

            switch (cam.FlashMode)
            {
                case FlashMode.Off:
                    if (cam.IsFlashModeSupported(FlashMode.On))
                    {
                        // Specify that flash should be used.
                        cam.FlashMode = FlashMode.On;
                        FlashButton.Content = "Flash:On";
                        currentFlashMode = "Flash mode: On";
                    }
                    break;
                case FlashMode.On:
                    if (cam.IsFlashModeSupported(FlashMode.RedEyeReduction))
                    {
                        // Specify that the red-eye reduction flash should be used.
                        cam.FlashMode = FlashMode.RedEyeReduction;
                        FlashButton.Content = "Flash:RER";
                        currentFlashMode = "Flash mode: RedEyeReduction";
                    }
                    else if (cam.IsFlashModeSupported(FlashMode.Auto))
                    {
                        // If red-eye reduction is not supported, specify automatic mode.
                        cam.FlashMode = FlashMode.Auto;
                        FlashButton.Content = "Flash:Auto";
                        currentFlashMode = "Flash mode: Auto";
                    }
                    else
                    {
                        // If automatic is not supported, specify that no flash should be used.
                        cam.FlashMode = FlashMode.Off;
                        FlashButton.Content = "Flash:Off";
                        currentFlashMode = "Flash mode: Off";
                    }
                    break;
                case FlashMode.RedEyeReduction:
                    if (cam.IsFlashModeSupported(FlashMode.Auto))
                    {
                        // Specify that the flash should be used in the automatic mode.
                        cam.FlashMode = FlashMode.Auto;
                        FlashButton.Content = "Flash:Auto";
                        currentFlashMode = "Flash mode: Auto";
                    }
                    else
                    {
                        // If automatic is not supported, specify that no flash should be used.
                        cam.FlashMode = FlashMode.Off;
                        FlashButton.Content = "Flash:Off";
                        currentFlashMode = "Flash mode: Off";
                    }
                    break;
                case FlashMode.Auto:
                    if (cam.IsFlashModeSupported(FlashMode.Off))
                    {
                        // Specify that no flash should be used.
                        cam.FlashMode = FlashMode.Off;
                        FlashButton.Content = "Flash:Off";
                        currentFlashMode = "Flash mode: Off";
                    }
                    break;
            }

            // Display current flash mode.
            this.Dispatcher.BeginInvoke(delegate()
            {
                //txtDebug.Text = currentFlashMode;
            });
        }


        void cam_CaptureCompleted(object sender, CameraOperationCompletedEventArgs e)
        {
            App.nextImageNum();
        }

        void cam_CaptureImageAvailable(object sender, Microsoft.Devices.ContentReadyEventArgs e)
        {
            string filename = "ocrAppImage" + App.getImageNum() + ".jpg";
            MediaPlayer.Queue.ToString();
            foreach (MediaSource source in MediaSource.GetAvailableMediaSources())
            {
                if (source.MediaSourceType == MediaSourceType.LocalDevice)
                {
                    library = new MediaLibrary(source);
                }
            }
            try
            {
                Deployment.Current.Dispatcher.BeginInvoke(delegate()
                {
                    //txtDebug.Text = "Captured image available, saving photo.";
                });
                library.SavePictureToCameraRoll(filename, e.ImageStream);
                Deployment.Current.Dispatcher.BeginInvoke(delegate()
                {
                    //txtDebug.Text = "Photo has been saved to camera roll.";
                });
                e.ImageStream.Seek(0, SeekOrigin.Begin);

                using (IsolatedStorageFile isStore = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    using (IsolatedStorageFileStream targetStream = isStore.OpenFile(filename, FileMode.Create, FileAccess.Write))
                    {
                        byte[] readBuffer = new byte[4096];
                        int bytesRead = -1;
                        while ((bytesRead = e.ImageStream.Read(readBuffer, 0, readBuffer.Length)) > 0)
                        {
                            targetStream.Write(readBuffer, 0, bytesRead);
                        }
                    }
                }
                Deployment.Current.Dispatcher.BeginInvoke(delegate()
                {
                    //txtDebug.Text = "Photo has been saved to the local folder.";
                });
            }
            finally
            {
                e.ImageStream.Close();
            }
        }

        public void cam_CaptureThumbnailAvailable(object sender, ContentReadyEventArgs e)
        {
            string filename = App.getImageNum() + "_th.jpg";

            try
            {
                Deployment.Current.Dispatcher.BeginInvoke(delegate()
                {
                    //txtDebug.Text = "Captured image available, saving thumbnail.";
                });
                using (IsolatedStorageFile isStore = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    using (IsolatedStorageFileStream targetStream = isStore.OpenFile(filename, FileMode.Create, FileAccess.Write))
                    {
                        byte[] readbuffer = new byte[4096];
                        int bytesRead = -1;
                        while ((bytesRead = e.ImageStream.Read(readbuffer, 0, readbuffer.Length)) > 0)
                        {
                            targetStream.Write(readbuffer, 0, bytesRead);
                        }
                    }
                }
                Deployment.Current.Dispatcher.BeginInvoke(delegate()
                {
                    //txtDebug.Text = "thumbnail has been saved to the local folder.";
                });
            }
            finally
            {
                e.ImageStream.Close();
            }
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            if ((PhotoCamera.IsCameraTypeSupported(CameraType.Primary) == true))
            {
                cam = new Microsoft.Devices.PhotoCamera(CameraType.Primary);
                cam.Initialized += new EventHandler<Microsoft.Devices.CameraOperationCompletedEventArgs>(cam_Initialized);
                cam.CaptureCompleted += new EventHandler<CameraOperationCompletedEventArgs>(cam_CaptureCompleted);
                cam.CaptureImageAvailable += new EventHandler<ContentReadyEventArgs>(cam_CaptureImageAvailable);
                cam.CaptureThumbnailAvailable += new EventHandler<ContentReadyEventArgs>(cam_CaptureThumbnailAvailable);
                viewfinderBrush.SetSource(cam);
            }
            else
            {
                this.Dispatcher.BeginInvoke(delegate()
                {
                    //txtDebug.Text = "A Camera is not available on this phone.";
                });
                ShutterButton.IsEnabled = false;
            }

        }

        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {
            if (cam != null)
            {
                cam.Dispose();
                cam.Initialized -= cam_Initialized;
                cam.CaptureCompleted -= cam_CaptureCompleted;
                cam.CaptureImageAvailable -= cam_CaptureImageAvailable;
                cam.CaptureThumbnailAvailable -= cam_CaptureThumbnailAvailable;
            }
        }

    }
}