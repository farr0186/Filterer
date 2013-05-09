using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AForgeRequestLibrary
{
    public static class Imaging
    {

        public class ImageFormats
        {
            public const string PNG = "png";
            public const string JPEG = "jpeg";
        }

        public class Filters
        {
            public const string SEPIA = "Sepia";
            public const string PIXELLATE = "Pixellate";
            public const string OIL_PAINTING = "OilPainting";
            public const string GRAYSCALE = "Grayscale";
            public const string GAUSSIAN_BLUR = "GaussianBlur";
            public const string SHARPEN = "Sharpen";
        }

    }

    public static class Errors
    {
        public const string BsonDeserializationError = "BsonDeserializationError";
    }
}
