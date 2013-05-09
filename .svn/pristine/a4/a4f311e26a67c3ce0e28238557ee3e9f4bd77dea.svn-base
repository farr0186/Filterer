using Newtonsoft.Json.Bson;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AForgeRequestLibrary
{
    public class AForgeFactory
    {

        public static IAForgeData Create(ref Stream oStream)
        {
            oStream.Seek(0, SeekOrigin.Begin);
            IAForgeData oAForgeData = null;
            using (BsonReader oReader = new BsonReader(oStream))
            {
                string szClassType = string.Empty;
                while (oReader.Read())
                {
                    if (oReader.TokenType == Newtonsoft.Json.JsonToken.PropertyName)
                    {
                        if (String.Equals(oReader.Value, "ClassType"))
                        {
                            szClassType = oReader.ReadAsString();
                            Type oType = Type.GetType(szClassType);
                            oAForgeData = (IAForgeData)Activator.CreateInstance(oType);
                        }
                        else if (String.Equals(oReader.Value, "Data"))
                        {
                            if (oAForgeData != null)
                            {
                                oAForgeData.FromBson(oReader);
                            }
                        }
                    }
                }
            }
            return oAForgeData;
        }

    }
}