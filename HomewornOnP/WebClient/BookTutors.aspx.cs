using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using WebClient.WCFWebReference;
using WebClient.VModel;

namespace WebClient
{
    public partial class BookTutors : System.Web.UI.Page
    {
        private List<TutoringTime> allTutoringTimes;
        private List<Teacher> allTutoringTeachers = new List<Teacher>();
        private List<string> allTutoringSubjects = new List<string>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (LogIn.child == null)
            {
                Response.Redirect("LogIn.aspx");
            }

            //On every postback it retrieves data from DB, so every time it provides the 
            //update of available tutoring times
            Service1Client service = new Service1Client();
            allTutoringTimes = service.GetAllAvailableTutoringTimes().OfType<TutoringTime>().ToList();
            SetAllTutorsAndSubjects(allTutoringTimes);

            //Checking for postback so the chosen data in combo boxes does not dissapear
            if (!Page.IsPostBack)
            {

                SetSubjectsToComboBox(allTutoringSubjects);

                SetTeachersToComboBox(allTutoringTeachers);

                SetDataToTutorTable(new List<TutorTableView>());
                DisplayMessageIfNoTutorsAvailable("Sorry, at this time there are no tutoring times provided by any teacher! Try again later!");
            }


        }
        //This method happens every time when the page is reloaded or there was a postback
        //And updates the calendar. Here you provide all the information about how does the 
        //calendar should look in any situation
        protected void BookingCalendar_DayRender(object sender, DayRenderEventArgs e)
        {
            DateTime daySelected = BookingCalendar.SelectedDate;
            BookingCalendar.SelectedDates.Clear();

            e.Day.IsSelectable = false;
            if (e.Day.Date < DateTime.Today)
            {
                e.Cell.Font.Italic = true;
                e.Cell.BackColor = System.Drawing.Color.DimGray;
                e.Cell.BorderColor = System.Drawing.Color.Gray;
                e.Cell.ForeColor = System.Drawing.Color.Gray;
                e.Cell.Font.Name = "Courier New";
            }

            if (e.Day.Date.DayOfWeek == DayOfWeek.Saturday || e.Day.Date.DayOfWeek == DayOfWeek.Sunday)
            {
                if (e.Day.Date == daySelected)
                {
                    e.Cell.ForeColor = System.Drawing.Color.Yellow;
                }
                else
                {
                    e.Cell.ForeColor = System.Drawing.Color.Red;
                }

            }

            Service1Client service = new Service1Client();

            if (!Page.IsPostBack)
            {
                foreach (DateTime d in GetAllAvailableTutoringDates(allTutoringTimes))
                {
                    if (e.Day.Date.Equals(d))
                    {
                        e.Cell.BackColor = System.Drawing.Color.Green;
                        e.Day.IsSelectable = true;
                    }
                }
            }
            else
            {
                //Select available dates by subject
                if (SubjectDrL.SelectedValue != "Select subject")
                {

                    foreach (DateTime d in GetAllAvailableTutoringDates(GetAllAvailableTutoringTimesForSubject(SubjectDrL.SelectedValue)))
                    {
                        if (e.Day.Date.Equals(d))
                        {
                            e.Cell.BackColor = System.Drawing.Color.Green;
                            e.Day.IsSelectable = true;
                        }
                    }
                }
                //If the selection is Select subject it changes color to green to all available   
                //tutoring times dates no matter what subject it is 
                else
                {
                    foreach (DateTime d in GetAllAvailableTutoringDates(allTutoringTimes))
                    {
                        if (e.Day.Date.Equals(d))
                        {
                            e.Cell.BackColor = System.Drawing.Color.Green;
                            e.Day.IsSelectable = true;
                        }
                    }
                }
                //Select available dates by teacher
                //If the teacher is selected than it changes color to green to all 
                //dates which have that speciffic teachers tuturing dates
                if (TeacherDrL.SelectedValue != "Select teacher")
                {
                    e.Day.IsSelectable = false;
                    e.Cell.BackColor = System.Drawing.Color.White;
                    if (e.Day.Date < DateTime.Today)
                    {
                        e.Cell.Font.Italic = true;
                        e.Cell.BackColor = System.Drawing.Color.DimGray;
                        e.Cell.BorderColor = System.Drawing.Color.Gray;
                        e.Cell.ForeColor = System.Drawing.Color.Gray;
                        e.Cell.Font.Name = "Courier New";
                    }

                    foreach (DateTime d in GetAllAvailableTutoringDates(GetAllAvailableTutoringTimesForTeacher(TeacherDrL.SelectedValue)))
                    {
                        if (e.Day.Date.Equals(d))
                        {
                            e.Cell.BackColor = System.Drawing.Color.Green;
                            e.Day.IsSelectable = true;
                        }
                    }
                }
            }
            BookingCalendar.SelectedDate = daySelected;
            BookingCalendar.SelectedDayStyle.ForeColor = System.Drawing.Color.Yellow;

        }

        protected void SubjectDrL_SelectedIndexChanged(object sender, EventArgs e)
        {
            BookingCalendar.SelectedDates.Clear();
            List<Teacher> sortedTeacherList = new List<Teacher>();
            if (!SubjectDrL.SelectedValue.Equals("Select subject"))
            {
                //Loops for all teachers who has tutoring dates available 
                //for that subject
                foreach (Teacher t in allTutoringTeachers)
                {
                    if (t.Subject == SubjectDrL.SelectedValue)
                    {
                        sortedTeacherList.Add(t);
                    }
                }
                if (sortedTeacherList.Count != 0)
                {
                    //sets the sorted list of teachers to combo box
                    SetTeachersToComboBox(sortedTeacherList);
                }
                else
                {
                    ResetAllData();
                    DisplayMessageIfNoTutorsAvailable("Sorry, someone just booked the last appointment for this subject! There are no more appointments available for any teacher. Please try again later!");
                    Response.Write("<script>alert('Sorry, someone just booked the last appointment for this subject!')</script>");
                }
                
            }
            else
            {
                SetTeachersToComboBox(allTutoringTeachers);
            }
            SetDataToTutorTable(new List<TutorTableView>());
        }

        protected void TeacherDrL_SelectedIndexChanged(object sender, EventArgs e)
        {
            BookingCalendar.SelectedDates.Clear();
            string name = TeacherDrL.SelectedValue;
            List<Teacher> sortedTeacherList = new List<Teacher>();
            foreach (Teacher t in allTutoringTeachers)
            {
                if (t.Name == name)
                {
                    //When teacher is selected it selects the teachers subject in subject box
                    SubjectDrL.SelectedValue = t.Subject;
                }
            }
            //after subject was selected it also updates teacher combo box and sets 
            //the co-workers with the same subject
            //So to get all teachers it will be required to change the subject in subject
            //combo box to "Select subject" or change the subject and get all tutors for 
            //speciffic subject
            foreach (Teacher t in allTutoringTeachers)
            {
                if (t.Subject == SubjectDrL.SelectedValue)
                {
                    sortedTeacherList.Add(t);
                }
            }
            if (sortedTeacherList.Count != 0)
            {
                SetTeachersToComboBox(sortedTeacherList);
                TeacherDrL.SelectedValue = name;
                SetDataToTutorTable(new List<TutorTableView>());
            }
            else
            {
                ResetAllData();
                DisplayMessageIfNoTutorsAvailable("Sorry all the appointments where just booked! There are no more appointments available for any teacher. Please try again later!");
                Response.Write("<script>alert('Sorry, someone just booked the last appointment for this teacher!')</script>");
            }
        }
        //Handels calendar selection action and populates the BookingTabel accordingly
        //to date considering all selections of combo boxes
        protected void BookingCalendar_SelectionChanged(object sender, EventArgs e)
        {
            List<TutorTableView> viewTable = new List<TutorTableView>();
            bool dateAvailable = false;
            if (TeacherDrL.SelectedValue != "Select teacher")
            {
                foreach (TutoringTime tt in allTutoringTimes)
                {
                    if (tt.Teacher.Name == TeacherDrL.SelectedValue && tt.Date == BookingCalendar.SelectedDate)
                    {
                        TutorTableView ttv = new TutorTableView();
                        ttv.Name = tt.Teacher.Name;
                        ttv.Subject = tt.Teacher.Subject;
                        ttv.Time = tt.Time;
                        viewTable.Add(ttv);
                        dateAvailable = true;
                    }
                }
            }
            else if (SubjectDrL.SelectedValue != "Select subject")
            {
                foreach (TutoringTime tt in allTutoringTimes)
                {
                    if (tt.Teacher.Subject == SubjectDrL.SelectedValue && tt.Date == BookingCalendar.SelectedDate)
                    {
                        TutorTableView ttv = new TutorTableView();
                        ttv.Name = tt.Teacher.Name;
                        ttv.Subject = tt.Teacher.Subject;
                        ttv.Time = tt.Time;
                        viewTable.Add(ttv);
                        dateAvailable = true;
                    }
                }
            }
            else
            {
                foreach (TutoringTime tt in allTutoringTimes)
                {
                    if (tt.Date == BookingCalendar.SelectedDate)
                    {
                        TutorTableView ttv = new TutorTableView();
                        ttv.Name = tt.Teacher.Name;
                        ttv.Subject = tt.Teacher.Subject;
                        ttv.Time = tt.Time;
                        viewTable.Add(ttv);
                        dateAvailable = true;
                    }
                }
            }
            SetDataToTutorTable(viewTable);
            if (!dateAvailable)
            {
                ResetAllData();
                DisplayMessageIfNoTutorsAvailable("Sorry, someone just booked the last tutor for this day! There are no more appointments available for any teacher. Try again later!");
                Response.Write("<script>alert('Sorry, someone just booked the last tutor for this day!')</script>");
            }
        }

        //Sets all the data to lists that are used to populate comboBoxes
        public void SetAllTutorsAndSubjects(List<TutoringTime> list)
        {
            foreach (TutoringTime tt in list)
            {
                //Checks if the date has not passed
                if (tt.Date >= DateTime.Today)
                {
                    //checks if teacher is not already added
                    //and adds it to list if it doesn't
                    if (!CheckIfTeacherExistsInList(tt))
                    {
                        allTutoringTeachers.Add(tt.Teacher);

                        //also checks for subjects so they don't repeat
                        //and adds it to list if it doesn't
                        if (!allTutoringSubjects.Contains(tt.Teacher.Subject))
                        {
                            allTutoringSubjects.Add(tt.Teacher.Subject);
                        }
                    }
                }
            }
        }
        //This method is used to check if the list of teachers for combo box 
        //allready contains the given teacher
        public bool CheckIfTeacherExistsInList(TutoringTime tt)
        {
            bool teacherExistsInList = false;
            foreach (Teacher t in allTutoringTeachers)
            {
                if (t.Id == tt.Teacher.Id)
                {
                    teacherExistsInList = true;
                }
            }
            return teacherExistsInList;
        }
        public List<DateTime> GetAllAvailableTutoringDates(List<TutoringTime> list)
        {
            List<DateTime> dateList = new List<DateTime>();
            foreach (TutoringTime tt in list)
            {
                if (tt.Date >= DateTime.Today)
                {
                    dateList.Add(tt.Date);
                }
            }
            return dateList;
        }
        public void SetTeachersToComboBox(List<Teacher> teachers)
        {
            List<string> teacherNames = new List<string>();
            teacherNames.Add("Select teacher");
            foreach (Teacher t in teachers)
            {
                teacherNames.Add(t.Name);
            }
            TeacherDrL.DataSource = teacherNames;
            TeacherDrL.DataBind();
        }
        public void SetSubjectsToComboBox(List<string> subjects)
        {
            List<string> list = new List<string>();
            list.Add("Select subject");
            foreach (string s in subjects)
            {
                list.Add(s);
            }
            SubjectDrL.DataSource = list;
            SubjectDrL.DataBind();
        }
        public void SetDataToTutorTable(List<TutorTableView> list)
        {
            TutorTable.DataSource = list;
            TutorTable.DataBind();
        }
        public List<TutoringTime> GetAllAvailableTutoringTimesForSubject(string subject)
        {
            List<TutoringTime> sorted = new List<TutoringTime>();
            foreach (TutoringTime tt in allTutoringTimes)
            {
                string sub = tt.Teacher.Subject;
                if (tt.Teacher.Subject == subject)
                {
                    sorted.Add(tt);
                }
            }
            return sorted;
        }
        public List<TutoringTime> GetAllAvailableTutoringTimesForTeacher(string teachersName)
        {
            List<TutoringTime> sorted = new List<TutoringTime>();
            foreach (TutoringTime tt in allTutoringTimes)
            {
                if (tt.Teacher.Name == teachersName)
                {
                    sorted.Add(tt);
                }
            }
            return sorted;
        }
        //Handels button press action
        protected void TutorTable_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Book")
            {
                int rowindex = Convert.ToInt32(e.CommandArgument);
                GridViewRow gvr = TutorTable.Rows[rowindex];
                string name = gvr.Cells[0].Text;
                string time = gvr.Cells[2].Text;
                Service1Client service = new Service1Client();
                int result = 0;
                foreach (TutoringTime tt in allTutoringTimes)
                {
                    if (tt.Time == time && tt.Teacher.Name == name && tt.Date == BookingCalendar.SelectedDate)
                    {
                        if (service.GetTtTimesByTime(tt.Date, time, tt.Teacher.Id).Child == null)
                        {
                            result = service.RegisterBooking(LogIn.child.Id, tt.Id);
                            ResetAllData();
                            if (allTutoringTeachers.Count < 1 && result == 1)
                            {
                                Response.Write("<script>alert('You booked the last appointment! No more appointments available for any teacher. If you would like to make another appointment, try again later!')</script>");
                                Server.Transfer("Default.aspx", true);
                            }
                            //Returns message of transaction if it was successful or not
                            if (result == 1)
                            {
                                Response.Write("<script>alert('Your booking was successful!')</script>");
                            }
                            else
                            {
                                Response.Write("<script>alert('Sorry, something went wrong! Please contact us if you see this message!')</script>");
                            }   
                        }
                    }
                }
                //Returns message if someone made a booking before current user did
                if (result == 0)
                {
                    ResetAllData();
                    DisplayMessageIfNoTutorsAvailable("Sorry, someone made this booking faster than you and there are no more appointments available for any teacher. Try again later!");
                    Response.Write("<script>alert('Sorry, someone made this booking faster than you!')</script>");
                }
            }
        }
        public void ResetAllData()
        {
            Service1Client service = new Service1Client();
            BookingCalendar.SelectedDates.Clear();
            allTutoringSubjects = new List<string>();
            allTutoringTeachers = new List<Teacher>();
            allTutoringTimes = service.GetAllAvailableTutoringTimes().OfType<TutoringTime>().ToList();
            SetAllTutorsAndSubjects(allTutoringTimes);
            SetSubjectsToComboBox(allTutoringSubjects);
            SetTeachersToComboBox(allTutoringTeachers);
            SetDataToTutorTable(new List<TutorTableView>());
            SubjectDrL.SelectedValue = "Select subject";
            TeacherDrL.SelectedValue = "Select teacher";
        }
        //This method checks if any teacher is available for booking
        //and if not it shows a message with explanation and
        //transfers the user tu default page
        public void DisplayMessageIfNoTutorsAvailable(string message)
        {
            if (allTutoringTeachers.Count < 1)
            {
                Response.Write("<script>alert('" + message + "')</script>");
                Server.Transfer("Default.aspx", true);
            }
        }
    }
}