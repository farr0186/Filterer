using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AForgeViewer
{
    public static class AFConvert
    {

        /// <summary>
        /// Converts a string to an integer. If an error occurs -1 is returned.
        /// </summary>
        /// <param name="szInput">The string to parse</param>
        /// <returns></returns>
        public static int ToInt(string szInput)
        {
            int iResult;
            bool bSuccess = int.TryParse(szInput, out iResult);
            if (bSuccess)
            {
                return iResult;
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// Converts a string to an float. If an error occurs -1 is returned
        /// </summary>
        /// <param name="szInput">The string to parse</param>
        /// <returns></returns>
        public static float ToFloat(string szInput)
        {
            float fResult;
            bool bSuccess = float.TryParse(szInput, out fResult);
            if (bSuccess)
            {
                return fResult;
            }
            else
            {
                return -1f;
            }
        }
    }
}
