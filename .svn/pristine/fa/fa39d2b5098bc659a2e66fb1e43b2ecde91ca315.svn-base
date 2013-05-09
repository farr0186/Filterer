using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AForgeRequestLibrary.filter
{
    public class SharpenFilterData : AForgeData
    {

        #region Constructors

        public SharpenFilterData()
            : base(Imaging.Filters.SHARPEN)
        {
            Init();
        }

        public SharpenFilterData(Stream oImage, string szFileFormat)
            : base(oImage, szFileFormat, Imaging.Filters.SHARPEN)
        {
            Init();
        }

        #endregion

        #region Init

        /// <summary>
        /// Initialize all of the default values of this object
        /// </summary>
        private void Init()
        {
            ClassType = typeof(SharpenFilterData).FullName;
        }

        #endregion
    }
}
