using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;
using System.Web;

namespace WcfService.Model
{
    [KnownType(typeof(Homework))]
    [DataContract]
    public class Homework
    {
        [DataMember]
        public Person Child { get; set; }
        [DataMember]
        public Assignment Assignment { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string DiskName { get; set; }
        public Homework()
        {

        }
    }
}