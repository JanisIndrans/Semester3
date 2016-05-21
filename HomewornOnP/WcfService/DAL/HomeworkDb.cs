using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WcfService.Model;

namespace WcfService.DAL
{
    public class HomeworkDb
    {
        private SqlCommand comm;
        private DbConnection dbCon;
        int result;

        public int SubmitHomework(Homework hw)
        {
            try
            {
                comm = new SqlCommand();
                comm.CommandText = "INSERT INTO Homework(childId, assignmentId, date, diskName) VALUES(@childId, @assignmentId, @date, @diskName)";
                comm.Parameters.AddWithValue("childId", hw.Child.Id);
                comm.Parameters.AddWithValue("assignmentId", hw.Assignment.Id);
                comm.Parameters.AddWithValue("date", hw.Date);
                comm.Parameters.AddWithValue("diskName", hw.DiskName);

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
        public ListForObjects GetAllHomeworksById(int assignmentId)
        {
            ListForObjects homeworkList = new ListForObjects();
            try
            {
                comm = new SqlCommand();
                comm.CommandText = "SELECT * FROM Homework WHERE assignmentId = " + assignmentId;
                

                dbCon = new DbConnection();
                comm.Connection = dbCon.GetConnection();
                comm.Connection.Open();

                comm.CommandType = CommandType.Text;
                SqlDataReader dr = comm.ExecuteReader();
                
                while (dr.Read())
                {
                    Homework h = new Homework();
                    h.Id = Convert.ToInt32(dr["hid"]);
                    Assignment a = new Assignment();
                    a.Id = Convert.ToInt32(dr["assignmentId"]);
                    h.Assignment = a;
                    Child c = new Child();
                    c.Id = Convert.ToInt32(dr["childId"]);
                    h.Child = c;
                    h.Date = Convert.ToDateTime(dr["date"]);
                    h.DiskName = Convert.ToString(dr["diskName"]);
                    homeworkList.AddObj(h);
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
            return homeworkList;
        }
        public Homework GetHomeworkById(int id)
        {
             try
            {
                comm = new SqlCommand();
                comm.CommandText = "SELECT * FROM Homework WHERE hid = " + id;
                

                dbCon = new DbConnection();
                comm.Connection = dbCon.GetConnection();
                comm.Connection.Open();

                comm.CommandType = CommandType.Text;
                SqlDataReader dr = comm.ExecuteReader();
                
                while (dr.Read())
                {
                    Homework h = new Homework();
                    h.Id = Convert.ToInt32(dr["hid"]);
                    Assignment a = new Assignment();
                    a.Id = Convert.ToInt32(dr["aid"]);
                    h.Assignment = a;
                    Child c = new Child();
                    c.Id = Convert.ToInt32(dr["childId"]);
                    h.Child = c;
                    h.Date = Convert.ToDateTime(dr["date"]);
                    h.DiskName = Convert.ToString(dr["diskName"]);
                    return h;
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
            return null;
        }
        public List<Homework> GetAllHomeworksByChildId(int childId)
        {
            List<Homework> hwList = new List<Homework>();

            try
            {
                comm = new SqlCommand();
                comm.CommandText = "SELECT * FROM Homework WHERE childId = " + childId;

                dbCon = new DbConnection();
                comm.Connection = dbCon.GetConnection();
                comm.Connection.Open();

                comm.CommandType = CommandType.Text;
                SqlDataReader dr = comm.ExecuteReader();

                while (dr.Read())
                {
                    Homework hw = new Homework();
                    hw.DiskName = dr["diskName"].ToString();
                    hw.Date = Convert.ToDateTime(dr["date"]);
                    Child child = new Child();
                    child.Id = Convert.ToInt32(dr["childId"]);
                    hw.Child = child;

                    hwList.Add(hw);
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

            return hwList;
        }
    }
}