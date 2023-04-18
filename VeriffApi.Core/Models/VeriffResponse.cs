using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace VeriffApi.Core.Models
{
    [DataContract]
    public class VeriffResponse
    {
        [DataMember]
        public string status { get; set; }
        [DataMember]
        public verificationStatus verification { get; set; }
    }

    [Serializable]
    [DataContract]
    public class verificationStatus
    {
        [DataMember]
        public string id { get; set; }
        [DataMember]
        public string url { get; set; }
        [DataMember]
        public string vendorData { get; set; }
        [DataMember]
        public string host { get; set; }
        [DataMember]
        public string status { get; set; }
        [DataMember]
        public string sessionToken { get; set; }
    }
}
