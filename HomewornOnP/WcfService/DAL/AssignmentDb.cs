using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WcfService.Model;
using System.Runtime.Serialization;

namespace WcfService.DAL
{
    
    public class AssignmentDb
    {
        private SqlCommand comm;
        private DbConnection dbCon;
        //[DataMember]
        //List<Assignment> al = new List<Assignment>();
        int result;


        public int CreateAssignment(Assignment ass)
        {
            try
            {
                comm = new SqlCommand();
                comm.CommandText = "INSERT INTO Assignment(subject, title, exercise, date, deadline, pid) VALUES(@subject, @title, @exercise, @date, @deadline, @pid)";
                comm.Parameters.AddWithValue("subject", ass.subject);
                comm.Parameters.AddWithValue("title", ass.title);
                comm.Parameters.AddWithValue("exercise", ass.exercise);
                comm.Parameters.AddWithValue("date", ass.date);
                comm.Parameters.AddWithValue("deadline", ass.deadline);
                comm.Parameters.AddWithValue("pid", ass.teacher.Id);

                dbCon = new DbConnection();
                comm.Connection = dbCon.GetConnection();
                comm.Connection.Open();

                comm.CommandType = CommandType.Text;
                result = comm.ExecuteNonQuery();

            }
            catch (Exception)
            {

                throw;
            }

            finally
            {
                comm.Connection.Close();
            }
            return result;
        }

        //Retrieving all the assignments
        public List<Assignment> GetAllAssignments()
        {
            List<Assignment> asgs = new List<Assignment>();

            try
            {
                comm = new SqlCommand();
                comm.CommandText = "SELECT * FROM Assignment";

                dbCon = new DbConnection();
                comm.Connection = dbCon.GetConnection();
                comm.Connection.Open();

                comm.CommandType = CommandType.Text;
                SqlDataReader dr = comm.ExecuteReader();

                while (dr.Read())
                {
                    Assignment asg = new Assignment();
                    asg.Id = Convert.ToInt32(dr["aid"]);
                    asg.subject = dr["subject"].ToString();
                    asg.title = dr["title"].ToString();
                    asg.exercise = dr["exercise"].ToString();
                    asg.teacher = new Teacher(Convert.ToInt32(dr["pid"].ToString()));

                    asgs.Add(asg);
                }
            }
            catch (Exception)
            {
                throw;
            }

            finally
            {
                comm.Connection.Close();
            }

            return asgs;
        }

        public ListForObjects GetAllAssignmentsByTeacherId(int teacherId)
        {
            ListForObjects al = new ListForObjects();
            try
            {
                comm = new SqlCommand();
                comm.CommandText = "SELECT * FROM Assignment WHERE pid = " + teacherId;

                dbCon = new DbConnection();
                comm.Connection = dbCon.GetConnection();
                comm.Connection.Open();

                comm.CommandType = CommandType.Text;
                SqlDataReader dr = comm.ExecuteReader();

                while (dr.Read())
                {
                    Assignment a = new Assignment();
                    a.Id = Convert.ToInt32(dr["aid"]);
                    a.exercise = Convert.ToString(dr["exercise"]);
                    a.date = Convert.ToDateTime(dr["date"]);
                    a.deadline = Convert.ToDateTime(dr["deadLine"]);
                    a.subject = Convert.ToString(dr["subject"]);
                    Teacher t = new Teacher();
                    t.Id = Convert.ToInt32(dr["pid"]);
                    a.teacher = t;
                    a.title = Convert.ToString(dr["title"]);
                    al.AddObj(a);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                comm.Connection.Close();
            }
            return al;
        }

    }
}