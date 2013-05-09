using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AForgeRequestLibrary.filter
{
    public class PixellateFilterData : AForgeData
    {

        #region Constructors

        public PixellateFilterData()
            : base(Imaging.Filters.PIXELLATE)
        {
            Init();
        }

        public PixellateFilterData(Stream oImage, string szFileFormat)
            : base(oImage, szFileFormat, Imaging.Filters.PIXELLATE)
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
            ClassType = typeof(PixellateFilterData).FullName;
        }

        #endregion
    
    }
}
