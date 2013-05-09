using Newtonsoft.Json.Bson;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AForgeRequestLibrary
{
    public static class AForgeSerializer
    {

        public static void SerializeToBson(IAForgeData oData, ref Stream oStream)
        {
            using (BsonWriter oWriter = new BsonWriter(oStream))
            {
                oWriter.CloseOutput = false;
                oWriter.WriteStartObject();
                oWriter.WritePropertyName("ClassType");
                oWriter.WriteValue(oData.ClassType);
                oWriter.WritePropertyName("Data");
                oWriter.WriteStartObject();
                oData.ToBson(oWriter);
                oWriter.WriteEndObject();
                oWriter.WriteEndObject();
            }
        }
    }
}
