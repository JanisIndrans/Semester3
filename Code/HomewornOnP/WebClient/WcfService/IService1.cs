using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WcfService.Model;

namespace WcfService
{
   
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        Person Login(string User, string Password);

        [OperationContract]
        List<Teacher> GetAllTeachers();

        [OperationContract]
        int SubmitHomework(int childId, int assignmentId, DateTime date, string diskName);

        [OperationContract]
        int CreateAssignment(int teacherId, string subject, string title, string exercise, DateTime date, DateTime deadline);

        [OperationContract]
        ListForObjects GetAllHomeworksById(int assignmentId);

        [OperationContract]
        List<Homework> GetAllHomeworksByChildId(int childId);

        [OperationContract]
        ListForObjects GetAllAssignmentsForTeacherById(int teacherId);
        
        [OperationContract]
        List<Assignment> GetAllAssignments();

        [OperationContract]
        Homework GetHomeworkById(int id);

        [OperationContract]
        int CreateTutoringTime(DateTime date, int teacherId, string time);

        [OperationContract]
        TutoringTime GetTtTimesByTime(DateTime date, string time, int teacherId);

        [OperationContract]
        List<TutoringTime> GetTtTimesByTeacherId(int teacherId);

        [OperationContract]
        List<TutoringTime> GetTtTimesByDate(DateTime date);

        [OperationContract]
        int RemoveTutoringTime(int teacherId, DateTime date, string time);

        [OperationContract]
        int RegisterBooking(int childId, int tutoringTimeId);

        [OperationContract]
        string GetHashedPassword(string password);

        [OperationContract]
        List<TutoringTime> GetAllAvailableTutoringTimes();

        [OperationContract]
        List<TutoringTime> GetAllAvailableTutoringTimesBySubject(string subject);
    }


    
}
