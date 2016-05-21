using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfService.Model
{
    [KnownType(typeof(TutoringTime))]
    [DataContract]
    public class TutoringTime
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public string Time { get; set; }
        [DataMember]
        public Teacher Teacher { get; set; }
        [DataMember]
        public Child Child { get; set; }
    }
}