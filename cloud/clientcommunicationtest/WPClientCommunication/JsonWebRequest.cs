using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WPClientCommunication
{

    class JsonWebRequest
    {
        public event EventHandler OnComplete;

        private string szJson;
        private SerializableAttribute oData; 

        public JsonWebRequest(Uri requestUri) {

        }

        public void beginResponseAsync()
        {

        }

        public void finishResponseAsync()
        {
            if (OnComplete != null)
                OnComplete(this, new EventArgs());
        }

        private string serializeJson(SerializableAttribute obj) 
        {
            return String.Empty;
        }

        public Boolean cancel()
        {
            return true;
        }

        public SerializableAttribute Data
        {
            get { return oData; }
            set
            {
                oData = value;
                szJson = serializeJson(oData);
            }
        }

        public string Json
        {
            get { return szJson; }
        }

    }
}
