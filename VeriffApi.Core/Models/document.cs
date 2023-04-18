using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace VeriffApi.Core.Models
{
    [DataContract]
    public class document
    {
        [DataMember]
        public string type { get; set; }
        [DataMember]
        public string country { get; set; }
    }
}
