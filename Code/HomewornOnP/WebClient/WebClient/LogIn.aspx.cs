using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebClient.WCFWebReference;


namespace WebClient
{
    public partial class LogIn : System.Web.UI.Page
    {
        public static Child child;

        protected void Page_Load(object sender, EventArgs e)
        {
            

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Service1Client service = new WCFWebReference.Service1Client();
            
            string userName = UserNameTB.Text;
            string password = service.GetHashedPassword(UserPasswordTB.Text);
            Person obj = service.Login(userName, password);

            if (obj != null)
            {
                if (obj.GetType() == typeof(Child))
                {
                    child = (Child)obj;
                    Response.Redirect("Default.aspx");
                }
                else 
                {
                    Response.Write("<script>alert('Teachers cannot log in using this platform. /nPlease use the windows software')</script>");
                }
            }
            else 
            {
                Response.Write("<script>alert('No user found')</script>");
            }       
           
        }
    }
}