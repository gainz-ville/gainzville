using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Gainzville.Shared
{
    [DataContract]
    public class Profile
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public DateTime CreatedDate { get; set; }

        [DataMember]
        public DateTime DateOfBirth { get; set; }

        [DataMember]
        public float Height { get; set; }

        [DataMember]
        public string Aim { get; set; }
    }
}
