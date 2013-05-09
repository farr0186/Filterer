#region Header
//
//   Project:           PicFx - Windows Phone 7 image effects app.
//
//   Changed by:        $Author$
//   Changed on:        $Date$
//   Changed in:        $Revision$
//   Project:           $URL$
//   Id:                $Id$
//
//
//   Copyright (c) 2010 Rene Schulte
//
//   This program is open source software. Please read the License.txt.
//
#endregion

using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace PicFx.Effects
{
   /// <summary>
   /// Applys a watermark logo a bitmap.
   /// </summary>
   public class Watermarker
   {
      /// <summary>
      /// A watermark
      /// </summary>
      public WriteableBitmap Watermark { get; private set; }

      /// <summary>
      /// The relative size of the watermark in proportion to the input image.
      /// </summary>
      public float RelativeSize { get; set; }

      /// <summary>
      /// Initializes a new instance of the <see cref="Watermarker"/> class.
      /// </summary>
      /// <param name="relativeResourcePath">The relative resource path.</param>
      public Watermarker(string relativeResourcePath)
      {
         Watermark = new WriteableBitmap(0, 0).FromResource(relativeResourcePath);
         RelativeSize = 0.5f;
      }

      /// <summary>
      /// Applies a watermark bitmap and returns a new processed WriteabelBitmap.
      /// </summary>
      /// <param name="input">The input bitmap.</param>
      /// <returns>The result WriteableBitmap with the watermark.</returns>
      public WriteableBitmap Apply(WriteableBitmap input)
      {
         // Resize watermark
         var w = Watermark.PixelWidth;
         var h = Watermark.PixelHeight;
         var ratio = (float) w / h;
         if (ratio > 1)
         {
            w = (int)(input.PixelWidth * RelativeSize);
            h = (int)(w / ratio);
         }
         else
         {
            h = (int)(input.PixelHeight * RelativeSize);
            w = (int)(h * ratio);
         }
         var watermark = Watermark.Resize(w, h, WriteableBitmapExtensions.Interpolation.Bilinear);

         // Blit watermark into copy of the input 
         // Bottom right corner
         var result = input.Clone();
         var position = new Rect(input.PixelWidth - w, input.PixelHeight - h, w, h);
         result.Blit(position, watermark, new Rect(0, 0, w, h));

         return result;
      }
   }
}
