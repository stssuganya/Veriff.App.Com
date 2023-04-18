using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;

namespace Veriff.Core.Model
{
    [Serializable]
    public class VeriffResponse
    {
        [XmlElement]
        public string status { get; set; }
        [XmlElement]
        public verificationStatus verification { get; set; }
    }

    [Serializable]
    [DataContract]
    public class verificationStatus
    {
        [XmlElement]
        [DataMember]
        public string id { get; set; }
        [XmlElement]
        [DataMember]
        public string url { get; set; }
        [XmlElement]
        [DataMember]
        public string vendorData { get; set; }
        [XmlElement]
        [DataMember]
        public string host { get; set; }
        [XmlElement]
        [DataMember]
        public string status { get; set; }
        [DataMember]
        public string sessionToken { get; set; }
    }
}
