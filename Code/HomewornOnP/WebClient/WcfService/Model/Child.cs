using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Services;

namespace WcfService.Model
{
    [KnownType(typeof(Child))]
    [DataContract]
    public class Child : Person
    {
        [DataMember]
        public string Grade { get; set; }


        public Child()
        {

        }

        public Child(int id)
        {
            this.Id = id;
        }

        public Child(string UserName, string Name, string Phone, string Email, string Password, string Grade, int Type)
        {
            this.UserName = UserName;
            this.Name = Name;
            this.Phone = Phone;
            this.Email = Email;
            this.Password = Password;
            this.Grade = Grade;
            this.UserType = Type;
        }
    }
}