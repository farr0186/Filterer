using Newtonsoft.Json.Bson;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AForgeRequestLibrary.filter
{
    public class GrayscaleFilterData : AForgeData
    {
        #region Public Properties

        public float Red { get; set; }

        public float Green { get; set; }

        public float Blue { get; set; }

        #endregion

        #region Constructors

        public GrayscaleFilterData()
            : base(Imaging.Filters.GRAYSCALE)
        {
            Init();
        }

        public GrayscaleFilterData(float fRed, float fGreen, float fBlue)
            : base(Imaging.Filters.GRAYSCALE)
        {
            Init();
            Red = fRed;
            Green = fGreen;
            Blue = fBlue;
        }

        public GrayscaleFilterData(Stream oImage, string szFileFormat)
            : base(oImage, szFileFormat, Imaging.Filters.GRAYSCALE)
        {
            Init();
        }

        public GrayscaleFilterData(Stream oImage, string szFileFormat, float fRed, float fGreen, float fBlue)
            : base(oImage, szFileFormat, Imaging.Filters.GRAYSCALE)
        {
            Init();
            Red = fRed;
            Green = fGreen;
            Blue = fBlue;
        }

        #endregion

        #region Init

        /// <summary>
        /// Initialize all of the default values of this object
        /// </summary>
        private void Init()
        {
            ClassType = typeof(GrayscaleFilterData).FullName;
            Red = 0.2125f;
            Green = 0.7154f;
            Blue = 0.0721f;
        }

        #endregion

        #region Bson

        public override void ToBson(BsonWriter oWriter)
        {
            base.ToBson(oWriter);

            oWriter.WritePropertyName("Red");
            oWriter.WriteValue(Red);
            oWriter.WritePropertyName("Green");
            oWriter.WriteValue(Green);
            oWriter.WritePropertyName("Blue");
            oWriter.WriteValue(Blue);
        }

        public override void FromBson(BsonReader oReader)
        {
            base.FromBson(oReader);
            while (oReader.Read())
            {
                if (oReader.TokenType == Newtonsoft.Json.JsonToken.PropertyName)
                {
                    if (String.Equals(oReader.Value, "Red"))
                    {
                        Red = (float)oReader.ReadAsDecimal();
                    }
                    else if (String.Equals(oReader.Value, "Green"))
                    {
                        Green = (float)oReader.ReadAsDecimal();
                    }
                    else if (String.Equals(oReader.Value, "Blue"))
                    {
                        Blue = (float)oReader.ReadAsDecimal();
                        return;
                    }
                }
            }
        }

        #endregion

    }
}