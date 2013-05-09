using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Bson;

namespace WPClientCommunication
{
    interface IBsonSerializable
    {
        /// <summary>
        /// Writes an object to Bson
        /// </summary>
        /// <param name="writer">An instance of BsonWriter</param>
        void writeBson(BsonWriter writer);

        /// <summary>
        /// Populates an object with values from Bson
        /// </summary>
        /// <param name="reader">An instance of BsonReader</param>
        void readBson(BsonReader reader);
    }
}
