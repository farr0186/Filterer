using Newtonsoft.Json.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AForgeRequestLibrary.error
{
    public class AForgeError : IAForgeData
    {

        /// <summary>
        /// An error code associated with the error
        /// </summary>
        public string ErrorCode { get; set; }

        /// <summary>
        /// A message associated with the error
        /// </summary>
        public string Message { get; set; }


        public AForgeError(string szErrorCode)
        {
            ClassType = typeof(AForgeError).AssemblyQualifiedName;
        }

        public AForgeError(string ezErrorCode, string szMessage)
        {
            ErrorCode = ezErrorCode;
            Message = szMessage;
            ClassType = typeof(AForgeError).AssemblyQualifiedName;
        }

        public override void ToBson(BsonWriter oWriter)
        {
            base.ToBson(oWriter);

            oWriter.WritePropertyName("ErrorCode");
            oWriter.WriteValue(ErrorCode);
            oWriter.WritePropertyName("Message");
            oWriter.WriteValue(Message);
        }

        public override void FromBson(BsonReader oReader)
        {
            base.FromBson(oReader);

            while (oReader.Read())
            {
                if (oReader.TokenType == Newtonsoft.Json.JsonToken.PropertyName)
                {
                    if (String.Equals(oReader.Value, "ErrorCode"))
                    {
                        ErrorCode = oReader.ReadAsString();
                    }
                    else if (String.Equals(oReader.Value, "Message"))
                    {
                        Message = oReader.ReadAsString();
                        return;
                    }
                }
            }
        }
    }
}