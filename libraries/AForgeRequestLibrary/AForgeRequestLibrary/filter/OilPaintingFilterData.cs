using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AForgeRequestLibrary;
using Newtonsoft.Json.Bson;

namespace AForgeRequestLibrary.filter
{
    public class OilPaintingFilterData : AForgeData
    {
        #region Public Properties

        /// <summary>
        /// The brush size of the oil painting
        /// </summary>
        public int BrushSize { get; set; }

        #endregion

        #region Constructors

        public OilPaintingFilterData()
            : base(Imaging.Filters.OIL_PAINTING)
        {
            Init();
        }

        public OilPaintingFilterData(int iBrushSize)
            : base(Imaging.Filters.OIL_PAINTING)
        {
            Init();
            BrushSize = iBrushSize;
        }

        public OilPaintingFilterData(Stream oImage, string szFileFormat)
            : base(oImage, szFileFormat, Imaging.Filters.OIL_PAINTING)
        {
            Init();
        }

        public OilPaintingFilterData(Stream oImage, string szFileFormat, int iBrushSize)
            : base(oImage, szFileFormat, Imaging.Filters.OIL_PAINTING)
        {
            Init();
            BrushSize = iBrushSize;
        }

        #endregion

        #region Init

        /// <summary>
        /// Initialize all of the default values of this object
        /// </summary>
        private void Init()
        {
            ClassType = typeof(OilPaintingFilterData).FullName;
            BrushSize = 12;
        }

        #endregion

        #region Bson

        public override void ToBson(BsonWriter oWriter)
        {
            base.ToBson(oWriter);

            oWriter.WritePropertyName("BrushSize");
            oWriter.WriteValue(BrushSize);
        }

        public override void FromBson(BsonReader oReader)
        {
            base.FromBson(oReader);
            while (oReader.Read())
            {
                if (oReader.TokenType == Newtonsoft.Json.JsonToken.PropertyName)
                {
                    if (String.Equals(oReader.Value, "BrushSize"))
                    {
                        BrushSize = (int)oReader.ReadAsInt32();
                        return;
                    }
                }
            }
        }

        #endregion

    }
}
