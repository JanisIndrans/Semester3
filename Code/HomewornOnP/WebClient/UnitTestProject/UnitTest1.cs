using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestProject.ServiceReference1;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void LoginTest()
        {
            Service1Client client = new ServiceReference1.Service1Client();

            Assert.IsNotNull(client.Login("Anna", client.GetHashedPassword("2222")));
        }

        [TestMethod]

        public void SubmitHomeworkTest()
        {

            ServiceReference1.Service1Client testService = new Service1Client();

            Assert.AreEqual(1, testService.SubmitHomework(2, 4, DateTime.Now, "Test Assignment"));
           
        }

        [TestMethod]

        public void CreateAssignmentTest()
        {
           
            ServiceReference1.Service1Client testService = new Service1Client();

            Assert.AreEqual(1, testService.CreateAssignment(1, "English", "TestAssignment", "Test", DateTime.Now, DateTime.Now));

        }

        [TestMethod]
        public void CreateTutoringTime()
        {
            ServiceReference1.Service1Client testService = new Service1Client();

            Assert.AreEqual(1, testService.CreateTutoringTime(DateTime.Now, 1, "10:00"));
        }

        [TestMethod]
        public void GetTtTimesByDate()
        {
            DateTime date = new DateTime(2016, 1, 14);

            Service1Client client = new Service1Client();

            TutoringTime[] tutoringTimes = client.GetTtTimesByDate(date);

            int items = tutoringTimes.Length;

            Assert.IsTrue(items > 0, "The returned list is empty.");
        }

        [TestMethod]
        public void RegisterBooking()
        {
            Service1Client client = new Service1Client();
            TutoringTime[] tt = client.GetAllAvailableTutoringTimes();
            int id = tt[tt.Length - 1].Id;
            Assert.AreEqual(1, client.RegisterBooking(2, id));
        }
    }
}
