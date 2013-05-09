using AForgeRequestLibrary;
using AForgeRequestLibrary.error;
using AForgeRequestLibrary.filter;
using AForgeViewer.dialogs;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Drawing;

namespace AForgeViewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        #region Init

        private BitmapImage m_oImage;
        private static Uri oLocalRequestUri = new Uri("http://127.0.0.1:81/test.rest");
<<<<<<< .mine
        //private static Uri oAzureRequestUri = new Uri("http://1241052test.cloudapp.net/whatever.rest");
        private static Uri oAzureRequestUri = new Uri("http://ImageProc2.cloudapp.net/whatever.rest");
=======
        private static Uri oAzureRequestUri = new Uri("http://imageproc2.cloudapp.net/whatever.rest");
>>>>>>> .r113

        public MainWindow()
        {
            InitializeComponent();
            AForgeRequest.RequestUri = oLocalRequestUri;
            miLocal.IsChecked = true;
            miAzure.IsChecked = false;
        }

        #endregion

        #region Menu - File

        private void MenuItem_Click_Load_Image(object sender, RoutedEventArgs e)
        {
            OpenFileDialog oFileDialog = new OpenFileDialog();
            oFileDialog.Filter = "Image Files (*.bmp, *.jpg, *.png, *.jpeg)|*.bmp;*.jpg;*.png;*.jpeg";

            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> bResult = oFileDialog.ShowDialog();

            if (bResult == true)
            {
                string filename = oFileDialog.FileName;
                m_oImage = new BitmapImage(new Uri(filename));
                displayImage.Source = m_oImage;
                StatusBarPageInfo.Content = "Image Loaded";
            }

        }

        private void MenuItem_Click_Exit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        #endregion

        #region Menu - Filter

        private void MenuItem_Click_Filter_Sepia(object sender, RoutedEventArgs e)
        {
            //when adding new filters you don't have to set the image source or image filetype
            SepiaFilterData oRequestData = new SepiaFilterData();
            SendRequest(oRequestData);
        }

        private void MenuItem_Click_Filter_Pixellate(object sender, RoutedEventArgs e)
        {
            PixellateFilterData oRequestData = new PixellateFilterData();
            SendRequest(oRequestData);
        }

        private void MenuItem_Click_Filter_Oil_Painting(object sender, RoutedEventArgs e)
        {
            BrushSizeInputDialog oDialog = new BrushSizeInputDialog();
            Nullable<bool> oResult = oDialog.ShowDialog();
            if (oResult == true)
            {
                if (oDialog.BrushSize >= 1)
                {
                    OilPaintingFilterData oRequestData = new OilPaintingFilterData();
                    SendRequest(oRequestData);
                }
                else
                {
                    MessageBox.Show("Invalid Arguments.");
                }
            }
        }

        private void MenuItem_Click_Filter_Grayscale(object sender, RoutedEventArgs e)
        {
            RGBInputDialog oDialog = new RGBInputDialog();
            Nullable<bool> oResult = oDialog.ShowDialog();
            if (oResult == true)
            {
                if (oDialog.Red >= 0 && oDialog.Green >= 0 && oDialog.Blue >= 0)
                {
                    GrayscaleFilterData oRequestData = new GrayscaleFilterData(oDialog.Red, oDialog.Green, oDialog.Blue);
                    SendRequest(oRequestData);
                }
                else
                {
                    MessageBox.Show("Invalid Arguments.");
                }
            }
        }

        private void MenuItem_Click_Filter_Gaussian_Blur(object sender, RoutedEventArgs e)
        {
            KernelSizeGaussiaSigmaInputDialog oDialog = new KernelSizeGaussiaSigmaInputDialog();
            Nullable<bool> oResult = oDialog.ShowDialog();
            if (oResult == true)
            {
                if (oDialog.KernelSize >= 0 && oDialog.GaussiaSigma >= 0)
                {
                    GaussianBlurFilterData oRequestData = new GaussianBlurFilterData(oDialog.KernelSize, oDialog.GaussiaSigma);
                    SendRequest(oRequestData);
                }
                else
                {
                    MessageBox.Show("Invalid Arguments.");
                }
            }
        }

        private void MenuItem_Click_Filter_Sharpen(object sender, RoutedEventArgs e)
        {
            SharpenFilterData oRequestData = new SharpenFilterData();
            SendRequest(oRequestData);
        }

        #endregion

        #region Servers

        private void MenuItem_Checked_Azure(object sender, RoutedEventArgs e)
        {
            AForgeRequest.RequestUri = oAzureRequestUri;
            StatusBarPageInfo.Content = "Requests are now being sent to " + oAzureRequestUri.AbsoluteUri;
            miLocal.IsChecked = false;
        }

        private void MenuItem_Checked_Local(object sender, RoutedEventArgs e)
        {
            AForgeRequest.RequestUri = oLocalRequestUri;
            StatusBarPageInfo.Content = "Requests are now being sent to " + oLocalRequestUri.AbsoluteUri;
            miAzure.IsChecked = false;
        }

        #endregion

        #region Azure Web Request

        private void SendRequest(AForgeData oRequestData)
        {
            try
            {
                StatusBarPageInfo.Content = "Starting AForge request";
                oRequestData.Image = getJPGFromImageControl(m_oImage);
                oRequestData.FileFormat = Imaging.ImageFormats.JPEG;
                AForgeRequest oRequest = new AForgeRequest(oRequestData);
                oRequest.OnAForgeSuccess += OnSuccess;
                oRequest.OnAForgeFailure += OnFailure;
                oRequest.SendRequestAsync();
                StatusBarPageInfo.Content = string.Format("Request sent. Waiting for response.");
            }
            catch (Exception oException)
            {
                MessageBox.Show(oException.ToString());
            }
        }

        private void OnFailure(AForgeError oError)
        {
            // Invokation required
            StatusBarPageInfo.Dispatcher.Invoke(delegate
            {
                StatusBarPageInfo.Content = String.Format("AForge request Failed in {0} ms. Error: {1}", oError.Stats.TotalTime, oError.ErrorCode);
            });
        }

        private void OnSuccess(IAForgeData oResponseData)
        {
            // Invokation required
            StatusBarPageInfo.Dispatcher.Invoke(delegate
            {
                try
                {                    
                    AForgeData oData = oResponseData as AForgeData;
                    StatusBarPageInfo.Content = String.Format("AForge request completed. Upload Time: {0} ms, " +
                        "Download Time: {1} ms, Computation Time: {2} ms, Total Time: {3} ms", oResponseData.Stats.UploadTime, 
                        oResponseData.Stats.DownloadTime, oResponseData.Stats.ComputationTime, oResponseData.Stats.TotalTime);
                    m_oImage = new BitmapImage();
                    m_oImage.BeginInit();
                    m_oImage.StreamSource = oData.Image;
                    m_oImage.EndInit();
                    displayImage.Source = m_oImage;
                }
                catch (Exception oException)
                {
                    MessageBox.Show(oException.ToString());
                }
            });
        }

        private Stream getJPGFromImageControl(BitmapImage imageC)
        {
            MemoryStream memStream = new MemoryStream();
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(imageC));
            encoder.Save(memStream);
            return memStream;
        }

        #endregion

        private void MenuItem_Click_Convert(object sender, RoutedEventArgs e)
        {
            Bitmap bmap = BitmapImage2Bitmap(m_oImage);
            WriteableBitmap wrbitmap = new WriteableBitmap(Bitmap2BitmapImage(bmap));
            m_oImage = ConvertWriteableBitmapToBitmapImage(wrbitmap);
            //m_oImage = Bitmap2BitmapImage(bmap);
            
            //displayImage.Source = m_oImage;
            displayImage.Source = m_oImage;
            StatusBarPageInfo.Content = "Image Converted";
        }


        private void MenuItem_Click_Local_Grayscale(object sender, RoutedEventArgs e)
        {
            StatusBarPageInfo.Content = "Starting AForge request";
            DateTime startComputationTime = DateTime.UtcNow;
            m_oImage = Filters.GrayscaleFunc(m_oImage);
            DateTime endComputationTime = DateTime.UtcNow;
            int computationTime = (int)(endComputationTime - startComputationTime).TotalMilliseconds;

            StatusBarPageInfo.Content = String.Format("AForge request completed. Upload Time: {0}, " +
                        "Download Time: {1}, Computation Time: {2}, Total Time: {3}", 0,
                        0, computationTime, computationTime);

            displayImage.Source = m_oImage;
        }

        private void MenuItem_Click_Local_Sepia(object sender, RoutedEventArgs e)
        {
            StatusBarPageInfo.Content = "Starting AForge request";
            DateTime startComputationTime = DateTime.UtcNow;
            m_oImage = Filters.SepiaFunc(m_oImage);
            DateTime endComputationTime = DateTime.UtcNow;
            int computationTime = (int)(endComputationTime - startComputationTime).TotalMilliseconds;

            StatusBarPageInfo.Content = String.Format("AForge request completed. Upload Time: {0}, " +
                        "Download Time: {1}, Computation Time: {2}, Total Time: {3}", 0,
                        0, computationTime, computationTime);

            displayImage.Source = m_oImage;
        }

        private void MenuItem_Click_Local_Oil_Painting(object sender, RoutedEventArgs e)
        {
            StatusBarPageInfo.Content = "Starting AForge request";
            DateTime startComputationTime = DateTime.UtcNow;
            m_oImage = Filters.OilPaintingFunc(m_oImage);
            DateTime endComputationTime = DateTime.UtcNow;
            int computationTime = (int)(endComputationTime - startComputationTime).TotalMilliseconds;

            StatusBarPageInfo.Content = String.Format("AForge request completed. Upload Time: {0}, " +
                        "Download Time: {1}, Computation Time: {2}, Total Time: {3}", 0,
                        0, computationTime, computationTime);

            displayImage.Source = m_oImage;
        }


        private static BitmapImage ConvertWriteableBitmapToBitmapImage(WriteableBitmap wbm)
        {
            BitmapImage bmImage = new BitmapImage();
            using (MemoryStream stream = new MemoryStream())
            {
                JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(wbm));
                encoder.Save(stream);
                bmImage.BeginInit();
                bmImage.CacheOption = BitmapCacheOption.OnLoad;
                stream.Seek(0, SeekOrigin.Begin);
                bmImage.StreamSource = stream;
                bmImage.EndInit();
                bmImage.Freeze();
            }
            return bmImage;
        }

        private static BitmapImage Bitmap2BitmapImage(Bitmap bitmap)
        {
                using (MemoryStream ms = new MemoryStream())
                {
                    //System.Drawing.Bitmap dImg = SystemIcons.ToBitmap();
                    bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    System.Windows.Media.Imaging.BitmapImage bImg = new System.Windows.Media.Imaging.BitmapImage();
                    bImg.BeginInit();
                    bImg.StreamSource = new MemoryStream(ms.ToArray());
                    bImg.EndInit();
                    return bImg;
                }
        }


        private static Bitmap BitmapImage2Bitmap(BitmapImage bitmapImage)
        {
            // BitmapImage bitmapImage = new BitmapImage(new Uri("../Images/test.png", UriKind.Relative));

            using (MemoryStream outStream = new MemoryStream())
            {
                BitmapEncoder enc = new JpegBitmapEncoder();
                enc.Frames.Add(BitmapFrame.Create(bitmapImage));
                enc.Save(outStream);
                System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(outStream);

                // return bitmap; <-- leads to problems, stream is closed/closing ...
                return new Bitmap(bitmap);
            }
        }

    }
}
