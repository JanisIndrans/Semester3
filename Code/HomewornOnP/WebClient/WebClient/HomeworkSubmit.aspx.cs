using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebClient.WCFWebReference;

namespace WebClient
{
    public partial class HomeworkSubmit : System.Web.UI.Page
    {
        private string diskName = "";
        private Assignment[] asgs;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (LogIn.child == null)
            {
                Response.Redirect("LogIn.aspx");
            }
                
            getAssignments();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string userName = LogIn.child.Name;
            string fileExtension = System.IO.Path.GetExtension(FileUpload1.FileName);
            string fileName = Guid.NewGuid().ToString();
            string newFileName = fileName + fileExtension;
            string directoryName = Server.MapPath(userName);
            if (!System.IO.Directory.Exists(directoryName))
            {
                System.IO.Directory.CreateDirectory(directoryName);
            }
            diskName = System.IO.Path.Combine(userName, newFileName);
            diskName = Server.MapPath(diskName);
            string friendlyName = FileUpload1.FileName;
            int size = FileUpload1.FileBytes.Length;
            //save on disk
            //save in database
            //save user id in database
            FileUpload1.SaveAs(diskName);

            if (SaveToDatabase() == 1)
            {
                Response.Write("<script>alert('The file has been successufully uploaded')</script>");
                assignmentTB.Text = "";
            }
            else
            {
                Response.Write("<script>alert('An error occured. Your files has not been uploaded')</script>");
            }

        }

        private int SaveToDatabase()
        {
            int childId = LogIn.child.Id;
            int assignmentId = Convert.ToInt32(assignmentList.SelectedValue.Split(' ')[0]);
            DateTime date = DateTime.Now;

            Service1Client client = new Service1Client();

            return client.SubmitHomework(childId, assignmentId, date, diskName);
        }

        private void getAssignments()
        {
            Service1Client client = new Service1Client();
            asgs = client.GetAllAssignments();
            List<String> asgsList = new List<String>();
            foreach (Assignment a in asgs)
            {
                asgsList.Add(a.Id + " . " + a.title);
            }

            if (asgs != null && !IsPostBack)
            {
                assignmentList.DataSource = asgsList;
                assignmentList.DataBind();
                assignmentList.Items.Insert(0, new ListItem("--Select--", "0"));
            }
        }

        protected void assignmentList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Assignment selectedAssignment;

            int index = assignmentList.SelectedIndex;
            if (asgs != null)
            {
                if (index > 0)
                {
                    selectedAssignment = asgs[index - 1];
                }
                else
                {
                    selectedAssignment = asgs[index];
                }

                assignmentTB.Text = "Title: " + selectedAssignment.title + "\nAssignment: " + selectedAssignment.exercise;
            }

        }
    }
}