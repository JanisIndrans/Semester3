using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfService.Model
{
    [KnownType(typeof(Teacher))]
    [KnownType(typeof(Child))]
    [DataContract]
   // [Serializable]
    public class Person
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Phone { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public int UserType { get; set; }
        public override string ToString()
        {
            return Convert.ToString(Name);
        }

    }
}