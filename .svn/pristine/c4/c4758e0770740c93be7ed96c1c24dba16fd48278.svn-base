using Newtonsoft.Json.Bson;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AForgeRequestLibrary
{
    interface IBsonSerializable
    {
        /// <summary>
        /// Writes the object to a stream in the Bson format
        /// </summary>
        /// <param name="oWriter">An instance of a BsonWriter</param>
        void ToBson(BsonWriter oWriter);

        /// <summary>
        /// Populates an object with values from a stream in the Bson format
        /// </summary>
        /// <param name="oReader">An instance of a BsonReader</param>
        void FromBson(BsonReader oReader);
    }
}
