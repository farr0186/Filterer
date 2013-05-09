using AForgeRequestLibrary.util;
using Newtonsoft.Json.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AForgeRequestLibrary.stat
{
    public class BasicStats : IBsonSerializable
    {
        /* Date times are all in Utc - Like Utcnow, as below */
        //DateTime regular = DateTime.UtcNow;
        #region Public Properties

        /// <summary>
        /// The time the request was initiated from the phone
        /// </summary>
        public DateTime BeginRequestTime { get; set; }

        /// <summary>
        /// The time the request was received on azure
        /// </summary>
        public DateTime EndRequestTime { get; set; }

        /// <summary>
        /// The total time in MS that the request took
        /// </summary>
        public int TotalTime
        {
            get
            {
                return (int)(EndResponseTime - BeginRequestTime).TotalMilliseconds;
            }
        }

        /// <summary>
        /// The time in MS that the request took to be computed on Azure
        /// </summary>
        public int ComputationTime { get; set; }

        /// <summary>
        /// The time in MS that it took to upload the message from the phone to azure
        /// </summary>
        public int UploadTime 
        {
            get
            {
                return (int)(EndRequestTime - BeginRequestTime).TotalMilliseconds;
            }
        }

        /// <summary>
        /// The time in MS that it took to download the message from azure to the phone
        /// </summary>
        public int DownloadTime
        {
            get
            {
                return (int)(EndResponseTime - BeginResponseTime).TotalMilliseconds;
            }
        }

        /// <summary>
        /// The time the response was begun to get sent back by azure
        /// </summary>
        public DateTime BeginResponseTime { get; set; }

        /// <summary>
        /// The time the response was recieved by the phone
        /// </summary>
        public DateTime EndResponseTime { get; set; }

        /// <summary>
        /// The estimated time difference between running the filter locally vs on Azure
        /// </summary>
        public float EstimatedSpeedDifferenceVsLocal
        {
            get
            {
                return (ComputationTime * 10.5f) / TotalTime;
            }
        }

        #endregion

        #region Bson

        public void ToBson(BsonWriter oWriter)
        {
            oWriter.WritePropertyName("BeginRequestTime");
            oWriter.WriteValue(BeginRequestTime);
            oWriter.WritePropertyName("EndRequestTime");
            oWriter.WriteValue(EndRequestTime);
            oWriter.WritePropertyName("ComputationTime");
            oWriter.WriteValue(ComputationTime);
            oWriter.WritePropertyName("BeginResponseTime");
            oWriter.WriteValue(BeginResponseTime);
            oWriter.WritePropertyName("EndResponseTime");
            oWriter.WriteValue(EndResponseTime);
        }

        public void FromBson(BsonReader oReader)
        {
            while (oReader.Read())
            {
                if (oReader.TokenType == Newtonsoft.Json.JsonToken.PropertyName)
                {
                    if (String.Equals(oReader.Value, "BeginRequestTime"))
                    {
                        BeginRequestTime = (DateTime)oReader.ReadAsDateTime();
                    }
                    else if (String.Equals(oReader.Value, "EndRequestTime"))
                    {
                        EndRequestTime = (DateTime)oReader.ReadAsDateTime();
                    }
                    else if (String.Equals(oReader.Value, "ComputationTime"))
                    {
                        ComputationTime = (int)oReader.ReadAsInt32();
                    }
                    else if (String.Equals(oReader.Value, "BeginResponseTime"))
                    {
                        BeginResponseTime = (DateTime)oReader.ReadAsDateTime();
                    }
                    else if (String.Equals(oReader.Value, "EndResponseTime"))
                    {
                        EndResponseTime = (DateTime)oReader.ReadAsDateTime();
                        return;
                    }
                }
            }
        }

        #endregion
    }
}
