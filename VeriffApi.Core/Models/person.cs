using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace VeriffApi.Core.Models
{
    [DataContract]
    public class person
    {
        [DataMember()]
        public string firstName { get; set; }
        [DataMember()]
        public string lastName { get; set; }
        [DataMember()]
        public string dateOfBirth { get; set; }
        [DataMember()]
        public string gender { get; set; }
    }
}
