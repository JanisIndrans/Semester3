using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using WcfService.DAL;
using WcfService.Model;

namespace WcfService.BLL
{
    public class TutoringTimeCtrl
    {
        public int CreateTutoringTime(DateTime date, int teacherId, string time)
        {
            TutoringTime tt = new TutoringTime();
            tt.Date = date;
            tt.Teacher = new Teacher(teacherId);
            tt.Time = time;

            TutoringTimeDb ttDb = new TutoringTimeDb();

            return ttDb.CreateTutoringTime(tt);
        }

        public TutoringTime GetTtTimesByTime(DateTime date, string time, int teacherId)
        {
            TutoringTimeDb ttDb = new TutoringTimeDb();

            //Constructs and adds complete Teacher object to TutoringTime
            //Returns improved object
            PersonCtrl pCtrl = new PersonCtrl();
            TutoringTime tt = ttDb.GetTtTimesByTime(date, time, teacherId);
            TutoringTime completeTt = new TutoringTime();
            completeTt = tt;
            if (tt != null)
            {
                completeTt.Teacher = (Teacher)pCtrl.GetPerson(teacherId);
            }
            return completeTt;
        }

        public List<TutoringTime> GetTtTimesByTeacherId(int teacherId)
        {
            TutoringTimeDb ttDb = new TutoringTimeDb();
            return CompleteTeacherObjectsInList(ttDb.GetTtTimesByTeacherId(teacherId));
        }

        public List<TutoringTime> GetTtTimesByDate(DateTime date)
        {
            TutoringTimeDb ttDb = new TutoringTimeDb();
            return CompleteTeacherObjectsInList(ttDb.GetTtByDate(date));
        }

        public int RemoveTutoringTime(int teacherId, DateTime date, string time)
        {
            TutoringTimeDb ttDb = new TutoringTimeDb();

            return ttDb.RemoveTutoringTime(teacherId, date, time);
        }

        public int RegisterBooking(int childId, int tutoringTimeId)
        {
            TutoringTime tt = new TutoringTime();
            tt.Id = tutoringTimeId;
            tt.Child = new Child(childId);

            TutoringTimeDb ttDb = new TutoringTimeDb();

            return ttDb.RegisterBooking(tt);
        }
        //Returns list of TutoringTimes which are available for booking
        public List<TutoringTime> GetAllAvailableTutoringTimes()
        {
            TutoringTimeDb ttDb = new TutoringTimeDb();
            return CompleteTeacherObjectsInList(ttDb.GetAllAvailableTutoringTimes());
        }
        //Uses the list from GetAllAvailableTutoringTimes(), sorts it according
        //to subject given and returns the sorted list of TutorinTime
        public List<TutoringTime> GetAllAvailableTutoringTimesBySubject(string subject)
        {
            List<TutoringTime> all = GetAllAvailableTutoringTimes();
            List<TutoringTime> sorted = new List<TutoringTime>();
            foreach (TutoringTime tt in all)
            {
                if (tt.Teacher.Subject == subject)
                {
                    sorted.Add(tt);
                }
            }
            return sorted;
        }

        //Constructs and adds complete object of Teacher to every TutoringTime object in the list
        //Returns improved list
        public List<TutoringTime> CompleteTeacherObjectsInList(List<TutoringTime> list)
        {
            PersonCtrl pCtrl = new PersonCtrl();
            List<TutoringTime> listWithPartialyBuiltObjects = list;
            List<TutoringTime> listWithCompletelyBuitltObjects = new List<TutoringTime>();
            foreach (TutoringTime tt in listWithPartialyBuiltObjects)
            {
                Teacher pt = (Teacher)pCtrl.GetPerson(tt.Teacher.Id);
                tt.Teacher = pt;
                listWithCompletelyBuitltObjects.Add(tt);

            }
            return listWithCompletelyBuitltObjects;
        }
    }
}