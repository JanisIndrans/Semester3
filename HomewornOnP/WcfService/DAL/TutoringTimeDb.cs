using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using WcfService.Model;

namespace WcfService.DAL
{
    public class TutoringTimeDb
    {
        private SqlCommand comm;
        private DbConnection dbCon;
        int result;

        public int CreateTutoringTime(TutoringTime tt)
        {
            try
            {
                comm = new SqlCommand();
                comm.CommandText = "INSERT INTO TutoringTime(date, teacherId, time) VALUES(@date, @teacherId, @time)";
                comm.Parameters.AddWithValue("date", tt.Date);
                comm.Parameters.AddWithValue("teacherId", tt.Teacher.Id);
                comm.Parameters.AddWithValue("time", tt.Time);

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

        public TutoringTime GetTtTimesByTime(DateTime date, string time, int teacherId)
        {

            try
            {
                comm = new SqlCommand();
                string testDate = date.ToString("yyyy/MM/dd");
                comm.CommandText = "SELECT * FROM TutoringTime WHERE date  = '" + testDate + "'" + "AND time= '" + time + "'" + "AND teacherId= '" + teacherId + "'";

                dbCon = new DbConnection();
                comm.Connection = dbCon.GetConnection();
                comm.Connection.Open();

                comm.CommandType = CommandType.Text;
                SqlDataReader dr = comm.ExecuteReader();

                while (dr.Read())
                {
                    TutoringTime tt = new TutoringTime();
                    tt.Id = Convert.ToInt32(dr["tid"]);
                    tt.Time = Convert.ToString(dr["time"]);
                    tt.Date = Convert.ToDateTime(dr["date"]);
                    Teacher teacher = new Teacher();
                    teacher.Id = Convert.ToInt32(dr["teacherId"]);
                    tt.Teacher = teacher;

                    return tt;


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

        public List<TutoringTime> GetTtTimesByTeacherId(int teacherId)
        {
            List<TutoringTime> ttTimes = new List<TutoringTime>();
            try
            {
                comm = new SqlCommand();
                comm.CommandText = "SELECT * FROM TutoringTime WHERE teacherId = '" + teacherId + "'";

                dbCon = new DbConnection();
                comm.Connection = dbCon.GetConnection();
                comm.Connection.Open();

                comm.CommandType = CommandType.Text;
                SqlDataReader dr = comm.ExecuteReader();

                while (dr.Read())
                {
                    TutoringTime tt = new TutoringTime();
                    tt.Id = Convert.ToInt32(dr["tid"]);
                    tt.Time = Convert.ToString(dr["time"]);
                    tt.Date = Convert.ToDateTime(dr["date"]);
                    Teacher teacher = new Teacher();
                    teacher.Id = Convert.ToInt32(dr["teacherId"]);
                    tt.Teacher = teacher;

                    ttTimes.Add(tt);
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

            return ttTimes;
        }

        public int RemoveTutoringTime(int teacherId, DateTime date, string time)
        {
            string testDate = date.ToString("yyyy/MM/dd");

            try
            {
                comm = new SqlCommand();
                comm.CommandText = "DELETE FROM TutoringTime WHERE date  = '" + testDate + "'" + "AND teacherId= '" + teacherId + "'" + "AND time= '" + time + "'";

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

        public List<TutoringTime> GetTtByDate(DateTime date)
        {
            List<TutoringTime> ttTimes = new List<TutoringTime>();
            string testDate = date.ToString("yyyy/MM/dd");
            try
            {
                comm = new SqlCommand();
                comm.CommandText = "SELECT * FROM TutoringTime WHERE date = '" + testDate + "'";

                dbCon = new DbConnection();
                comm.Connection = dbCon.GetConnection();
                comm.Connection.Open();

                comm.CommandType = CommandType.Text;
                SqlDataReader dr = comm.ExecuteReader();

                while (dr.Read())
                {
                    TutoringTime tt = new TutoringTime();
                    tt.Id = Convert.ToInt32(dr["tid"]);
                    tt.Time = Convert.ToString(dr["time"]);
                    tt.Date = Convert.ToDateTime(dr["date"]);
                    Teacher teacher = new Teacher();
                    teacher.Id = Convert.ToInt32(dr["teacherId"]);
                    tt.Teacher = teacher;

                    ttTimes.Add(tt);
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

            return ttTimes;
        }

        public TutoringTime GetTtByTtId(int ttId)
        {
            SqlTransaction sqlTrans = null;
            try
            {
                comm = new SqlCommand();
                dbCon = new DbConnection();
                comm.Connection = dbCon.GetConnection();
                comm.Connection.Open();

                sqlTrans = comm.Connection.BeginTransaction(IsolationLevel.Serializable);

                using (comm)
                {

                    comm.CommandText = "SELECT * FROM TutoringTime WHERE tid  = '" + ttId + "'";
                    comm.CommandType = CommandType.Text;
                    SqlDataReader dr = comm.ExecuteReader();
                    TutoringTime tt = new TutoringTime();

                    while (dr.Read())
                    {

                        tt.Id = Convert.ToInt32(dr["tid"]);
                    }
                    return tt;
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

        }

        public int RegisterBooking(TutoringTime tt)
        {
            SqlTransaction sqlTrans = null;

            try
            {
                comm = new SqlCommand();
                dbCon = new DbConnection();
                comm.Connection = dbCon.GetConnection();
                comm.Connection.Open();

                sqlTrans = comm.Connection.BeginTransaction(IsolationLevel.Serializable);

                using (comm)
                {
                    comm.CommandText = "UPDATE TutoringTime set childId=(@childId) WHERE tid =(@tutoringTimeId)";

                    comm.Parameters.AddWithValue("childId", tt.Child.Id);
                    comm.Parameters.AddWithValue("tutoringTimeId", tt.Id);

                    comm.CommandType = CommandType.Text;

                    comm.Transaction = sqlTrans;
                    result = comm.ExecuteNonQuery();
                    if (result == 1)
                    {
                        sqlTrans.Commit();
                    }
                }
            }
            catch (Exception)
            {
                sqlTrans.Rollback();
                throw;
            }

            finally
            {
                comm.Connection.Close();
            }

            return result;
        }

        //Gets all the TutoringTime objects that has childId = null (which means that it
        //is available to book)
        public List<TutoringTime> GetAllAvailableTutoringTimes()
        {
            List<TutoringTime> ttTimes = new List<TutoringTime>();
            try
            {
                comm = new SqlCommand();
                comm.CommandText = "SELECT * FROM TutoringTime WHERE childId is null";

                dbCon = new DbConnection();
                comm.Connection = dbCon.GetConnection();
                comm.Connection.Open();

                comm.CommandType = CommandType.Text;
                SqlDataReader dr = comm.ExecuteReader();

                while (dr.Read())
                {
                    TutoringTime tt = new TutoringTime();
                    tt.Id = Convert.ToInt32(dr["tid"]);
                    tt.Time = Convert.ToString(dr["time"]);
                    tt.Date = Convert.ToDateTime(dr["date"]);
                    Teacher teacher = new Teacher();
                    teacher.Id = Convert.ToInt32(dr["teacherId"]);
                    tt.Teacher = teacher;

                    ttTimes.Add(tt);
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

            return ttTimes;
        }

    }
}
