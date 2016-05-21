using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebClient.WCFWebReference;

namespace WebClient
{
    public partial class SubmissionHistory : System.Web.UI.Page
    {
        private Homework[] hws;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (LogIn.child == null)
            {
                Response.Redirect("LogIn.aspx");
            }

            getHomeworksByChildId();
        }

        private void getHomeworksByChildId()
        {
            Service1Client client = new Service1Client();
            hws = client.GetAllHomeworksByChildId(LogIn.child.Id);
            if (hws != null)
            {
                foreach (Homework h in hws)
                {
                    TableRow row = new TableRow();
                    TableCell cell = new TableCell();
                    TableCell cell2 = new TableCell();
                    cell.Text = h.Date.ToString();
                    cell2.Text = h.DiskName;
                    row.Cells.Add(cell);
                    row.Cells.Add(cell2);
                    hwTable.Rows.Add(row);
                }
            }
            else
            {
                Response.Write("<script>alert('No submitted homeworks')</script>");
            }
                
          }

        
       }
    }
