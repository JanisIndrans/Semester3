using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfService.Model
{
    [KnownType(typeof(Assignment))]
    [DataContract]
    public class Assignment
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string subject { get; set; }
        [DataMember]
        public string title { get; set; }
        [DataMember]
        public string exercise { get; set; }
        [DataMember]
        public DateTime date { get; set; }
        [DataMember]
        public DateTime deadline { get; set; }
        [DataMember]
        public Teacher teacher { get; set; }


        public Assignment(int id)
        {
            this.Id = id;
        }

        public Assignment()
        {

        }
    }
}