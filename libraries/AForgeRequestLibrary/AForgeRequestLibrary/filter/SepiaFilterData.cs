using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AForgeRequestLibrary;

namespace AForgeRequestLibrary.filter
{
    public class SepiaFilterData : AForgeData
    {

        #region Constructors

        public SepiaFilterData()
            : base(Imaging.Filters.SEPIA)
        {
            Init();
        }

        public SepiaFilterData(Stream oImage, string szFileFormat) 
            : base(oImage, szFileFormat, Imaging.Filters.SEPIA)
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
            ClassType = typeof(SepiaFilterData).FullName;
        }

        #endregion
    }
}
