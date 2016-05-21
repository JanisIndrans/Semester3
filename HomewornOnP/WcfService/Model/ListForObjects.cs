using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;
using System.Web;

namespace WcfService.Model
{
    [KnownType(typeof(ListForObjects))]
    [DataContract]
    public class ListForObjects
    {
        [DataMember]
        public List<Object> Asl { get; set; }
        public ListForObjects()
        {
            Asl = new List<Object>();
        }
        public void AddObj(Object o)
        {
            Object obj = o;
            Asl.Add(obj);
        }
        public Object GetObjectByIndex(int index)
        {
            return (Object)Asl.ElementAt(index);
        }
    }
}