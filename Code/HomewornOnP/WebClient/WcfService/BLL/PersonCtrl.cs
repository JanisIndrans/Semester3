using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WcfService.DAL;


using WcfService.Model;
namespace WcfService.BLL
{
    public class PersonCtrl
    {
        public Person Login(string UserName, string Password)
        {
            Person p = new Person();
            p.UserName = UserName;
            p.Password = Password;
            PersonDb logDb = new PersonDb();

            return logDb.Login(p);
        }

        public Object GetPerson(int id)
        {
            Person p = new Person();
            p.Id = id;
            PersonDb logDb = new PersonDb();
            return logDb.GetPerson(p);
        }

        public List<Teacher> GetAllTeachers()
        {
            PersonDb pDb = new PersonDb();
            return pDb.GetAllTeachers();
        }
    }
}