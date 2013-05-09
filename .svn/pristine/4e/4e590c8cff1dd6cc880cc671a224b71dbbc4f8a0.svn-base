using Newtonsoft.Json.Bson;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AForgeRequestLibrary.filter
{
    public class GaussianBlurFilterData : AForgeData
    {
        #region Public Properties

        public int KernelSize { get; set; }

        public float GaussiaSigma { get; set; }

        #endregion

        #region Constructors

        public GaussianBlurFilterData()
            : base(Imaging.Filters.GAUSSIAN_BLUR)
        {
            Init();
        }

        public GaussianBlurFilterData(int iKernelSize, float fGaussiaSigma)
            : base(Imaging.Filters.GAUSSIAN_BLUR)
        {
            Init();
            KernelSize = iKernelSize;
            GaussiaSigma = fGaussiaSigma;
        }

        public GaussianBlurFilterData(Stream oImage, string szFileFormat)
            : base(oImage, szFileFormat, Imaging.Filters.GAUSSIAN_BLUR)
        {
            Init();
        }

        public GaussianBlurFilterData(Stream oImage, string szFileFormat, int iKernelSize, float fGaussiaSigma)
            : base(oImage, szFileFormat, Imaging.Filters.GAUSSIAN_BLUR)
        {
            Init();
            KernelSize = iKernelSize;
            GaussiaSigma = fGaussiaSigma;
        }

        #endregion

        #region Init

        /// <summary>
        /// Initialize all of the default values of this object
        /// </summary>
        private void Init()
        {
            ClassType = typeof(GaussianBlurFilterData).FullName;
            KernelSize = 11;
            GaussiaSigma = 4.0f;
        }

        #endregion

        #region Bson

        public override void ToBson(BsonWriter oWriter)
        {
            base.ToBson(oWriter);

            oWriter.WritePropertyName("KernelSize");
            oWriter.WriteValue(KernelSize);
            oWriter.WritePropertyName("GaussiaSigma");
            oWriter.WriteValue(GaussiaSigma);
        }

        public override void FromBson(BsonReader oReader)
        {
            base.FromBson(oReader);
            while (oReader.Read())
            {
                if (oReader.TokenType == Newtonsoft.Json.JsonToken.PropertyName)
                {
                    if (String.Equals(oReader.Value, "KernelSize"))
                    {
                        KernelSize = (int)oReader.ReadAsInt32();
                    }
                    else if (String.Equals(oReader.Value, "GaussiaSigma"))
                    {
                        GaussiaSigma = (float)oReader.ReadAsDecimal();
                        return;
                    }
                }
            }
        }

        #endregion

    }
}
