using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Veriff.Core.Model
{
    [DataContract]
    public class VerificationData
    {
        [DataMember]
        public string callback { get; set; }
        [DataMember]
        public string vendorData { get; set; }
        [DataMember()]
        public string firstName { get; set; }
        [DataMember()]
        public string lastName { get; set; }
        [DataMember()]
        public string dateOfBirth { get; set; }
        [DataMember()]
        public string gender { get; set; }
        [DataMember]
        public string Dtype { get; set; }
        [DataMember]
        public string country { get; set; }
    }
}
