using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WcfService.BLL;
using WcfService.Model;

namespace WcfService
{
   
    public class Service1 : IService1
    {
        public Person Login(string User, string Password)
        {
         PersonCtrl userCtrl = new PersonCtrl();

         return userCtrl.Login(User, Password);
        }

        public List<Teacher> GetAllTeachers()
        {
            PersonCtrl pCtrl = new PersonCtrl();

            return pCtrl.GetAllTeachers();
        }

        public int SubmitHomework(int childId, int assignmentId, DateTime date, string diskName)
        {
            HomeworkCtrl hwCtrl = new HomeworkCtrl();

            return hwCtrl.SubmitHomework(childId, assignmentId, date, diskName);
        }

        public int CreateAssignment(int teacherId, string subject, string title, string exercise, DateTime date, DateTime deadline)
        {
            AssignmentCtrl assCtrl = new AssignmentCtrl();

            return assCtrl.CreateAssignment(teacherId, subject, title, exercise, date, deadline);
        }
        
        public ListForObjects GetAllHomeworksById(int assignmentId)
        {
            HomeworkCtrl hmwCtrl = new HomeworkCtrl();

            return hmwCtrl.GetAllHomeworksByID(assignmentId);
        }

        public ListForObjects GetAllAssignmentsForTeacherById(int teacherId)
        {
            AssignmentCtrl asCtrl = new AssignmentCtrl();

            return asCtrl.GetAllAssignmentsByTeacherId(teacherId);
        }

        public List<Assignment> GetAllAssignments()
        {
            AssignmentCtrl asCtrl = new AssignmentCtrl();
            return asCtrl.GetAllAssignments();
        }

        public Homework GetHomeworkById(int id)
        {
            HomeworkCtrl hwCtrl = new HomeworkCtrl();
            return hwCtrl.GetHomeworkById(id);
        }

        public List<Homework> GetAllHomeworksByChildId(int childId)
        {
            HomeworkCtrl hwCtrl = new HomeworkCtrl();

            return hwCtrl.GetAllHomeworksByChildId(childId);
        }

        public int CreateTutoringTime(DateTime date, int teacherId, string time)
        {
            TutoringTimeCtrl ttCtrl = new TutoringTimeCtrl();

            return ttCtrl.CreateTutoringTime(date, teacherId, time);
        }

        public TutoringTime GetTtTimesByTime(DateTime date, string time, int teacherId)
        {
            TutoringTimeCtrl ttCtrl = new TutoringTimeCtrl();

            return ttCtrl.GetTtTimesByTime(date, time, teacherId);
        }

        public List<TutoringTime> GetTtTimesByTeacherId(int teacherId)
        {
            TutoringTimeCtrl ttCtrl = new TutoringTimeCtrl();

            return ttCtrl.GetTtTimesByTeacherId(teacherId);
        }

        public List<TutoringTime> GetTtTimesByDate(DateTime date)
        {
            TutoringTimeCtrl ttCtrl = new TutoringTimeCtrl();

            return ttCtrl.GetTtTimesByDate(date);
        }

        public int RemoveTutoringTime(int teacherId, DateTime date, string time)
        {
            TutoringTimeCtrl ttCtrl = new TutoringTimeCtrl();

            return ttCtrl.RemoveTutoringTime(teacherId, date, time);
        }

        public int RegisterBooking(int childId, int tutoringTimeId)
        {
            TutoringTimeCtrl ttCtrl = new TutoringTimeCtrl();

            return ttCtrl.RegisterBooking(childId, tutoringTimeId);
        }

        public string GetHashedPassword(string password)
        {
            PassHash ph = new PassHash();

            return ph.GetHashedPassword(password);
        }
        public List<TutoringTime> GetAllAvailableTutoringTimes()
        {
            TutoringTimeCtrl ttCtrl = new TutoringTimeCtrl();
            return ttCtrl.GetAllAvailableTutoringTimes();
        }
        public List<TutoringTime> GetAllAvailableTutoringTimesBySubject(string subject)
        {
            TutoringTimeCtrl ttCtrl = new TutoringTimeCtrl();
            return ttCtrl.GetAllAvailableTutoringTimesBySubject(subject);
        }
    }
}
