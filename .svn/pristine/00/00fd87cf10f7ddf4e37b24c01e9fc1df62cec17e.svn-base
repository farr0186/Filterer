using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AForgeRequestLibrary.filter;
using AForgeRequestLibrary;
using AForge;
using AForge.Imaging;
using AForge.Imaging.Filters;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Interop;
using System.Windows;

namespace AForgeViewer
{
    public class Filters
    {
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

        /*public static void applyFilter(ref AForgeData input)
        {
            DateTime startComputationTime = DateTime.UtcNow;

            if (input is GaussianBlurFilterData)
            {
                GaussianBlurFilterData data = input as GaussianBlurFilterData;
                GaussianBlurFunc(ref data);
            }
            else if (input is GrayscaleFilterData)
            {
                GrayscaleFilterData data = input as GrayscaleFilterData;
                GrayscaleFunc(ref data);
            }
            else if (input is OilPaintingFilterData)
            {
                //cast the input. I don't know why but you can't cast it inside the OilPaintingFunc call
                OilPaintingFilterData data = input as OilPaintingFilterData;
                OilPaintingFunc(ref data);
            }
            else if (input is PixellateFilterData)
            {
                PixellateFilterData data = input as PixellateFilterData;
                PixellateFunc(ref data);
            }
            else if (input is SepiaFilterData)
            {
                SepiaFilterData data = input as SepiaFilterData;
                SepiaFunc(ref data);
            }
            else if (input is SharpenFilterData)
            {
                SharpenFilterData data = input as SharpenFilterData;
                SharpenFunc(ref data);
            }
            else if (input is IAForgeData)
            {
                // ERROR
            }

            DateTime endComputationTime = DateTime.UtcNow;

            input.Stats.ComputationTime = (int)(endComputationTime - startComputationTime).TotalMilliseconds;
        }*/

        public static void GaussianBlurFunc(ref GaussianBlurFilterData input)
        {
            GaussianBlur filter = new GaussianBlur(input.GaussiaSigma, input.KernelSize);
            Bitmap oBitmap = new Bitmap(input.Image);
            filter.ApplyInPlace(oBitmap);
            /*
            // Converting this to a writeablebitmap
            // I have a bit map, I need to convert it to a writeablebitmap
            // I do that by making it a BitMapImage
            // Then using the constructor from bitmapimage for writeablebitmap
            //BitmapImage oBitMapImage = Bitmap2BitmapImage(oBitmap);
            //oBitmap = BitmapImage2Bitmap(oBitMapImage);
            WriteableBitmap wrbitmap = new WriteableBitmap(Bitmap2BitmapImage(oBitmap));
            PerformanceTestFilters.GaussianBlurEffect ptgblur = new PerformanceTestFilters.GaussianBlurEffect();

            wrbitmap = ptgblur.Process(wrbitmap);

            BitmapImage oBitmapImage = ConvertWriteableBitmapToBitmapImage(wrbitmap);

            oBitmap = BitmapImage2Bitmap(oBitmapImage);
            */
            Stream oBitmapStream = new MemoryStream();
            oBitmap.Save(oBitmapStream, ImageFormat.Jpeg);
            input.Image = oBitmapStream;
        }

        public static BitmapImage GrayscaleFunc(BitmapImage input)
        {
            Bitmap output = BitmapImage2Bitmap(input);
            Grayscale filter = new Grayscale(0.2125, 0.7154, 0.0721);
            output = filter.Apply(output);
            BitmapImage bmioutput = Bitmap2BitmapImage(output);
            return bmioutput;
        }

        /*public static void GrayscaleFunc(ref GrayscaleFilterData input)
        {
            Grayscale filter = new Grayscale(input.Red, input.Green, input.Blue);
            Bitmap oBitmap = new Bitmap(input.Image);
            oBitmap = filter.Apply(oBitmap);

            Stream oBitmapStream = new MemoryStream();
            oBitmap.Save(oBitmapStream, ImageFormat.Jpeg);
            input.Image = oBitmapStream;
        }*/

        public static BitmapImage OilPaintingFunc(BitmapImage input)
        {

            Bitmap output = BitmapImage2Bitmap(input);
            OilPainting filter = new OilPainting(12);
            filter.ApplyInPlace(output);
            BitmapImage bmioutput = Bitmap2BitmapImage(output);
            return bmioutput;
        }

        /*
        public static void OilPaintingFunc(ref OilPaintingFilterData input)
        {
            //create the filter and image just like you did before
            OilPainting filter = new OilPainting(input.BrushSize);
            Bitmap oBitmap = new Bitmap(input.Image);

            //apply the filter in place. I think its slightly more efficent to do it this way
            filter.ApplyInPlace(oBitmap);

            //copy the image into a stream and set it in the return object.
            //I am going to need to modify the AForgeRequestLibrary to correctly dispose of the image..
            Stream oBitmapStream = new MemoryStream();
            oBitmap.Save(oBitmapStream, ImageFormat.Jpeg);
            input.Image = oBitmapStream;
        }*/

        public static void PixellateFunc(ref PixellateFilterData input)
        {
            Pixellate filter = new Pixellate();
            Bitmap oBitmap = new Bitmap(input.Image);
            filter.ApplyInPlace(oBitmap);

            Stream oBitmapStream = new MemoryStream();
            oBitmap.Save(oBitmapStream, ImageFormat.Jpeg);
            input.Image = oBitmapStream;
        }

        public static BitmapImage SepiaFunc(BitmapImage input)
        {
            Bitmap output = BitmapImage2Bitmap(input);
            Sepia filter = new Sepia();
            filter.ApplyInPlace(output);
            BitmapImage bmioutput = Bitmap2BitmapImage(output);
            return bmioutput;
        }

        /*public static void SepiaFunc(ref SepiaFilterData input)
        {
            Sepia filter = new Sepia();
            Bitmap oBitmap = new Bitmap(input.Image);
            filter.ApplyInPlace(oBitmap);

            Stream oBitmapStream = new MemoryStream();
            oBitmap.Save(oBitmapStream, ImageFormat.Jpeg);
            input.Image = oBitmapStream;
        }*/

        public static void SharpenFunc(ref SharpenFilterData input)
        {
            Sharpen filter = new Sharpen();
            Bitmap oBitmap = new Bitmap(input.Image);
            filter.ApplyInPlace(oBitmap);

            Stream oBitmapStream = new MemoryStream();
            oBitmap.Save(oBitmapStream, ImageFormat.Jpeg);
            input.Image = oBitmapStream;
        }
    }
}
