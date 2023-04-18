using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;

namespace Veriff.Core.Model
{
    [DataContract]
    public class document
    {
        [DataMember()]
        public string type { get; set; }
        [DataMember()]
        public string country { get; set; }
    }
}
