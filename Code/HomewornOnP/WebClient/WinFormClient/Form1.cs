using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormClient.WinformReference;

namespace WinFormClient
{
    public partial class Form1 : Form
    {
        private string[] subjects = { "Math", "Literature", "English" };
        private string[] scTime = { "", "10:00", "12:00", "14:00", "16:00" };
        public static Teacher teacher;
        private TutoringTime tt;
        private ListForObjects list;
        private List<String> strings;
        private int selectedIndexComB1;
        
        public Form1()
        {
            InitializeComponent();
            tabControl1.TabPages.Remove(tabAssignments);
            tabControl1.TabPages.Remove(tabHomeworks);
            tabControl1.TabPages.Remove(tabSchedule);
            cbSubject.DataSource = subjects;
            cbScTime.DataSource = scTime;
            
            

            
          
            

            //Removes the anoying first empty column in table
            dataGridView1.RowHeadersVisible = false;

        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            LogIn();
            fillBoldDates();
        }

        private void LogIn()
        {
            Service1Client winService = new Service1Client();

            string userName = tbUsername.Text;
            string password = winService.GetHashedPassword(tbPass.Text);
            
            Person obj = winService.Login(userName, password);

            if (obj != null)
            {
                if (obj.GetType() == typeof(Teacher))
                {
                    teacher = (Teacher)obj;
                    tabControl1.TabPages.Remove(tabLogin);
                    tabControl1.TabPages.Add(tabAssignments);
                    tabControl1.TabPages.Add(tabHomeworks);
                    tabControl1.TabPages.Add(tabSchedule);

                    populateAssignmentCB();
                }
                else
                {
                    MessageBox.Show("Children cannot log in using this platform. Please use the web platform");
                }
            }
            else
            {
                MessageBox.Show("Username or password is incorrect, please try again :)");
            }
        }

        private void btnCreateAss_Click(object sender, EventArgs e)
        {
            CreateAssignment();
        }

        private void CreateAssignment()
        {
            int teacherId = teacher.Id;
            string title = tbTitle.Text;
            string subject = cbSubject.SelectedValue.ToString();
            string exercise = tbExercise.Text;
            DateTime date = startDate.Value;
            DateTime deadline = deadlineDate.Value;
            
            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(exercise)) 
            {
                MessageBox.Show("Please fill in all the fields.");
            }
            else 
            {
                if (deadline < date)
                {
                    MessageBox.Show("Deadline must be greater than Starting Date");
                }
                else
                {
                    Service1Client winService = new Service1Client();
                    int i = winService.CreateAssignment(teacherId, subject, title, exercise, date, deadline);

                    if (i == 1)
                    {
                        MessageBox.Show("Assignment Succesfully created");
                        tbTitle.Text = "";
                        cbSubject.ResetText();
                        tbExercise.Text = "";
                        startDate.ResetText();
                        deadlineDate.ResetText();

                        populateAssignmentCB();
                    }
                    else
                    {
                        MessageBox.Show("Something went wrong");
                    }
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedIndexComB1 = comboBox1.SelectedIndex;
            Object o = list.Asl.ElementAt(selectedIndexComB1);
            Assignment a = (Assignment)o;
            int assignmentIndex = a.Id;
            Service1Client winService = new Service1Client();
            ListForObjects hl = winService.GetAllHomeworksById(assignmentIndex);
            List<Homework> homeworks = new List<Homework>();
            foreach (Object ob in hl.Asl)
            {
                Homework h = (Homework)ob;
                homeworks.Add(h);
                
            }

            //makes a new List with two attributes of childs name and the path
            //To avoid makeing a new wrapper and instead of child objects address it displays its name
            List<Tuple<string, string>> nameList = new List<Tuple<string, string>>();
            foreach(Homework hmw in homeworks)
            {
                nameList.Add(new Tuple<string, string>(hmw.Child.Name, hmw.DiskName));
            }

            //If there are columns it removes the last button column so that the other columns
            //don't lose their indexes after data change
            if (dataGridView1.Columns.Count > 0)
            {
                dataGridView1.Columns.Remove("Download");
            }

            //Creates new data and replaces the data in the table
            DataSet ds = new DataSet();
            BindingSource bs = new BindingSource();
            bs.DataSource = nameList;
            dataGridView1.DataSource = bs;
            dataGridView1.Columns[0].HeaderText = "Name";
            dataGridView1.Columns[1].HeaderText = "Path";

            //Adds the button column as the last column
            DataGridViewButtonColumn btnCol = new DataGridViewButtonColumn();
            btnCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            btnCol.Text = "Download";
            btnCol.Name = "Download";
            btnCol.UseColumnTextForButtonValue = true;
            btnCol.HeaderText = "Download";
            dataGridView1.Columns.Add(btnCol);
            
        }

        private List<String> populateAssignmentCB()
        {
            Service1Client winService = new Service1Client();

            strings = new List<string>();
            list = winService.GetAllAssignmentsForTeacherById(teacher.Id);
            foreach (Object o in list.Asl)
            {
                Assignment a = (Assignment)o;
                strings.Add(a.title);

            }

            //creates new data and replaces the data in drop down list
            DataSet ds = new DataSet();
            BindingSource bs = new BindingSource();
            bs.DataSource = strings;
            comboBox1.DataSource = bs;

            return strings;
        }
        //Need to clean up a code a bit for the method below
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedIndexComB1 = comboBox1.SelectedIndex;
            Object o = list.Asl.ElementAt(selectedIndexComB1);
            Assignment a = (Assignment)o;
            int assignmentIndex = a.Id;

            Service1Client winService = new Service1Client();
            ListForObjects hl = winService.GetAllHomeworksById(assignmentIndex);

            var gridSender = (DataGridView)sender;

            if (gridSender.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                int index = e.RowIndex;
                Object ob = hl.Asl.ElementAt(index);
                Homework homework = (Homework)ob;
                //Simulating download by showing download path...
                MessageBox.Show("The file is downloaded. Path of download was : " + homework.DiskName);
            }
        }

        private void CreateTutoringTime()
        {

            DateTime date = calendar.SelectionRange.Start;
            string time = cbScTime.Text;
            int teacherId = teacher.Id;
            if (date < DateTime.Today)
            {
                MessageBox.Show("Not possible to set available date and time");
            }
            else
            {
                if (string.IsNullOrEmpty(time))
                {
                    MessageBox.Show("Please select the time");
                }


                else
                {

                    Service1Client winService = new Service1Client();

                    tt = winService.GetTtTimesByTime(date, time, teacherId);

                    if (tt != null)
                    {

                        if (tt.Date == date)
                        {
                            if (String.Equals(tt.Time, time))
                            {

                                MessageBox.Show("Selected time is already in use");


                            }
                            else
                            {
                                winService.CreateTutoringTime(date, teacherId, time);
                                MessageBox.Show("Tutor time succesfully inserted");
                            }
                        }
                    }

                    else
                    {

                        winService.CreateTutoringTime(date, teacherId, time);
                        MessageBox.Show("Tutor time succesfully inserted");

                    }
                }
            }
        }
                 
        private void btnSaveSchedule_Click(object sender, EventArgs e)
        {
            CreateTutoringTime();
            cbScTime.ResetText();
            
        }

        private void fillBoldDates()
        {
            Service1Client winService = new Service1Client();
            if (teacher != null) 
            {  
            List<DateTime> ttDates = new List<DateTime>();
            TutoringTime[] ttTimeObj = winService.GetTtTimesByTeacherId(teacher.Id);
            foreach (TutoringTime tt in ttTimeObj)
            {
                DateTime ttDate = tt.Date;
                if (tt.Date == DateTime.Today || tt.Date > DateTime.Today)
                {
                    ttDates.Add(ttDate);

                    calendar.BoldedDates = ttDates.ToArray();
                }
            }
            }

          }

        private void RemoveTutoringTime()
        {
            int teacherId = teacher.Id;
            DateTime date = calendar.SelectionRange.Start;
            string time = cbScTime.Text;

            Service1Client winService = new Service1Client();

            if (winService.RemoveTutoringTime(teacherId, date, time) == 1)
            {
                MessageBox.Show("Selected time was removed from your schedule");
            }
            else
            {
                MessageBox.Show("Selected time does not exist in the database");
            }
        }

        private void btnRemoveTT_Click(object sender, EventArgs e)
        {
            RemoveTutoringTime();
            cbScTime.ResetText();
         }
    }
}
