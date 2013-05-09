using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace PerformanceTestFilters.Composite_Effects
{
   /// <summary>
   /// Black & White conversion effect.
   /// </summary>
   public class BlackWhiteEffect : IEffect
   {
      readonly TintEffect tintFx;
      readonly BrightnessContrastEffect contrastFx;

      public string Name { get { return "Black & White"; } }

      /// <summary>
      /// The contrast factor. 
      /// Should be in the range [-1, 1]. 
      /// Default is 0.15
      /// </summary>
      public float ContrastFactor 
      {
         get { return contrastFx.ContrastFactor; }
         set { contrastFx.ContrastFactor = value; }
      }

      public BlackWhiteEffect()
      {
         tintFx = TintEffect.White;
         contrastFx = new BrightnessContrastEffect { ContrastFactor = 0.15f };
      }

      /// <summary>
      /// Processes a bitmap and returns a new processed WriteabelBitmap.
      /// </summary>
      /// <param name="input">The input bitmap.</param>
      /// <returns>The result of WriteabelBitmap processing.</returns>
      public WriteableBitmap Process(WriteableBitmap input)
      {
         // Prepare some variables
         var width = input.PixelWidth;
         var height = input.PixelHeight;
         return Process(input.Pixels, width, height).ToWriteableBitmap(width, height);
      }

      /// <summary>
      /// Processes an ARGB32 integer bitmap and returns the new processed bitmap data.
      /// </summary>
      /// <param name="inputPixels">The input bitmap as integer array.</param>
      /// <param name="width">The width of the bitmap.</param>
      /// <param name="height">The height of the bitmap.</param>
      /// <returns>The result of the processing.</returns>
      public int[] Process(int[] inputPixels, int width, int height)
      {
         var resultPixels = tintFx.Process(inputPixels, width, height);
         resultPixels = contrastFx.Process(resultPixels, width, height);
         return resultPixels;
      }
   }
}
