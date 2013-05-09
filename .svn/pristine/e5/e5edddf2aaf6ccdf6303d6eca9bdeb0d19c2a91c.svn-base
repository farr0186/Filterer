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
using System.Windows.Media.Imaging;
using System.Diagnostics;
using PicFx.Effects;
using PicFx.Effects.CompositeEffects;

namespace phone_peformance_test
{
    public partial class MainPage : PhoneApplicationPage
    {

        WriteableBitmap _original;

        // Constructor
        public MainPage()
        {
            InitializeComponent();
            _original = new WriteableBitmap(0, 0).FromContent("data/monkeys.jpg");
            // Apply Effect on int[] since WriteableBitmap can't be used in background thread

            IEffect effect = new PolaroidEffect();

            int width = _original.PixelWidth;
            int height = _original.PixelHeight;
            Stopwatch oStopwatch = Stopwatch.StartNew();
            WriteableBitmap resultPixels = null;
            for (int i = 0; i < 10; i++)
            {
                resultPixels = effect.Process(_original);
            }
            oStopwatch.Stop();
            Debug.WriteLine("Filter: PolaroidEffect. Image Size: {0}x{1}. Average process time for 10 iterations: {2} ms.", 
                width, height, oStopwatch.ElapsedMilliseconds / 10);

            effect = TintEffect.Sepia;
            oStopwatch = Stopwatch.StartNew();
            resultPixels = null;
            for (int i = 0; i < 10; i++)
            {
                resultPixels = effect.Process(_original);
            }
            oStopwatch.Stop();
            Debug.WriteLine("Filter: Sepia. Image Size: {0}x{1}. Average process time for 10 iterations: {2} ms.", 
                width, height, oStopwatch.ElapsedMilliseconds / 10);

            effect = new BlackWhiteEffect();
            oStopwatch = Stopwatch.StartNew();
            resultPixels = null;
            for (int i = 0; i < 10; i++)
            {
                resultPixels = effect.Process(_original);
            }
            oStopwatch.Stop();
            Debug.WriteLine("Filter: BlackWhite. Image Size: {0}x{1}. Average process time for 10 iterations: {2} ms.",
                width, height, oStopwatch.ElapsedMilliseconds / 10);

        }
    }
}