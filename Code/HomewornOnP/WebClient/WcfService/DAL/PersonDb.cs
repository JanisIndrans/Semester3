using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WcfService.Model;

namespace WcfService.DAL
{
    public class PersonDb
    {
        private SqlCommand comm;
        private DbConnection dbCon;

        public Person Login(Person p)
        {
            comm = new SqlCommand();
            comm.CommandText = "SELECT * FROM Person WHERE userName=(@userName) AND password=(@password)";
            comm.Parameters.AddWithValue("userName", p.UserName);
            comm.Parameters.AddWithValue("password", p.Password);
            dbCon = new DbConnection();
            comm.Connection = dbCon.GetConnection();
            comm.Connection.Open();

            comm.CommandType = CommandType.Text;
            SqlDataReader dr = comm.ExecuteReader();


            if (dr.Read() && dr.HasRows)
            {
                Person pers = new Person();
                pers.UserType = Convert.ToInt32(dr["userType"]);
                if (pers.UserType == 1)
                {
                    Teacher teacher = new Teacher();
                    teacher.Id = Convert.ToInt32(dr["pid"]);
                    teacher.Name = dr["name"].ToString();
                    teacher.Email = dr["email"].ToString();
                    teacher.Phone = dr["phone"].ToString();
                    teacher.Subject = dr["subject"].ToString();

                    comm.Connection.Close();
                    return teacher;
                }
                else
                {
                    Child child = new Child();
                    child.Id = Convert.ToInt32(dr["pid"]);
                    child.Name = dr["name"].ToString();
                    child.Email = dr["email"].ToString();
                    child.Phone = dr["phone"].ToString();
                    child.Grade = dr["grade"].ToString();

                    comm.Connection.Close();
                    return child;
                }
            }
            else
            {
                comm.Connection.Close();
                return null;
            }
        }

        public Object GetPerson(Person p)
        {
            comm = new SqlCommand();
            comm.CommandText = "SELECT * FROM Person WHERE pid=(@personId)";
            comm.Parameters.AddWithValue("personId", p.Id);
            dbCon = new DbConnection();
            comm.Connection = dbCon.GetConnection();
            comm.Connection.Open();

            comm.CommandType = CommandType.Text;
            SqlDataReader dr = comm.ExecuteReader();

            if (dr.Read() && dr.HasRows)
            {
                Person pers = new Person();
                pers.UserType = Convert.ToInt32(dr["userType"]);

                if (pers.UserType == 1)
                {
                    Teacher teacher = new Teacher();
                    teacher.Id = Convert.ToInt32(dr["pid"]);
                    teacher.Name = dr["name"].ToString();
                    teacher.Email = dr["email"].ToString();
                    teacher.Phone = dr["phone"].ToString();
                    teacher.Subject = dr["subject"].ToString();

                    comm.Connection.Close();
                    return teacher;
                }
                else
                {
                    Child child = new Child();
                    child.Id = Convert.ToInt32(dr["pid"]);
                    child.Name = dr["name"].ToString();
                    child.Email = dr["email"].ToString();
                    child.Phone = dr["phone"].ToString();
                    child.Grade = dr["grade"].ToString();

                    comm.Connection.Close();
                    return child;
                }
            }
            else
            {
                comm.Connection.Close();
                return null;
            }
        }

        public List<Teacher> GetAllTeachers()
        {
            List<Teacher> teachers = new List<Teacher>();

            comm = new SqlCommand();
            comm.CommandText = "SELECT * FROM Person";
            dbCon = new DbConnection();
            comm.Connection = dbCon.GetConnection();
            comm.Connection.Open();

            comm.CommandType = CommandType.Text;
            SqlDataReader dr = comm.ExecuteReader();

            while (dr.Read())
            {
                Person pers = new Person();
                pers.UserType = Convert.ToInt32(dr["userType"]);

                if (pers.UserType == 1)
                {
                    Teacher teacher = new Teacher();
                    teacher.Id = Convert.ToInt32(dr["pid"]);
                    teacher.Name = dr["name"].ToString();
                    teacher.Email = dr["email"].ToString();
                    teacher.Phone = dr["phone"].ToString();
                    teacher.Subject = dr["subject"].ToString();

                    teachers.Add(teacher);
                }
            }
            comm.Connection.Close();
            return teachers;
        }
    }
}