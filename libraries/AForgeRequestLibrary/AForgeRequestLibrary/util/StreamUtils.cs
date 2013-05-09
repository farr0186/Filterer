using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AForgeRequestLibrary.util
{
    class StreamUtils
    {

        /// <summary>
        /// Copies an instance of a Stream into another stream
        /// </summary>
        /// <param name="oSourceStream">The stream to be copied</param>
        /// <param name="oDestStream">The stream to copy the sourceStream into</param>
        public static void StreamCopy(Stream oSourceStream, Stream oDestStream)
        {
            byte[] aBuffer = new byte[4096];
            int iRead;
            while ((iRead = oSourceStream.Read(aBuffer, 0, aBuffer.Length)) > 0)
            {
                oDestStream.Write(aBuffer, 0, iRead);
            }
        }
    }
}