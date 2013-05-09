﻿using AForgeRequestLibrary.stat;
using Newtonsoft.Json.Bson;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AForgeRequestLibrary
{
    public abstract class IAForgeData : IBsonSerializable
    {
        /// <summary>
        /// The current version format of the class
        /// </summary>
        public int Version { get; set; }

        /// <summary>
        /// The assembly qualified name of the class.
        /// </summary>
        public string ClassType { get; set; }

        /// <summary>
        /// A set of stats 
        /// </summary>
        public BasicStats Stats { get; set; }

        /// <summary>
        /// The default constructor
        /// </summary>
        public IAForgeData()
        {
            Version = 1;
            ClassType = string.Empty;
            Stats = new BasicStats();
        }

        public virtual void ToBson(BsonWriter oWriter)
        {
            oWriter.WritePropertyName("Version");
            oWriter.WriteValue(Version);
            Stats.ToBson(oWriter);
        }

        public virtual void FromBson(BsonReader oReader)
        {
            while (oReader.Read())
            {
                if (oReader.TokenType == Newtonsoft.Json.JsonToken.PropertyName)
                {
                    if (String.Equals(oReader.Value, "Version"))
                    {
                        Version = (int)oReader.ReadAsInt32();
                        Stats.FromBson(oReader);
                        return;
                    }
                }
            }
            
        }
    }
}