using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;

namespace Veriff.Core.Model
{
    [DataContract]
    public class verification
    {
        [DataMember()]
        public string callback { get; set; }
        [DataMember()]
        public person person { get; set; }
        [DataMember()]
        public document document { get; set; }
        [DataMember()]
        public string vendorData { get; set; }
    }
}
