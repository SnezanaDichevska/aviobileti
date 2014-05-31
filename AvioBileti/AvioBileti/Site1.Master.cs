using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace AvioBileti
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(Session["user"] as string))
            {
                //btnSignOut.Visible = false;
                //btnSignOut.Enabled = false;
                //hlUser.Enabled = false;
                //hlUser.Visible = false;
            }
            else
            {
                string user = Session["user"] as string;
                //btnSignOut.Visible = true;
                //btnSignOut.Enabled = true;
                //hlUser.Enabled = true;
                //hlUser.Visible = true;
                //hlUser.Text = user;
            }
        }

        protected void btnSignOut_Click(object sender, EventArgs e)
        {
         //   HeadLoginStatus.Visible = false;
         //   btnSignOut.Enabled = false;
         //   hlUser.Enabled = false;
         //   hlUser.Visible = false;
            Session["user"] = null;
            Response.Redirect("~/Public/SearchFlights.aspx", true);
        }
     

    }
}