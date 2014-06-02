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
               lbOdjaviSe.Visible = false;
               lbOdjaviSe.Enabled = false;
               lbNajaviSe.Text = "Најави се";
               lbNajaviSe.PostBackUrl = "~/Public/Login.aspx";
            }
            else
            {
                string user = Session["user"] as string;
                lbOdjaviSe.Visible = true;
                lbOdjaviSe.Enabled = true;
                lbNajaviSe.Text = user;
                lbNajaviSe.PostBackUrl = "~/User/MyProfile.aspx";
            }
        }


        protected void lbOdjaviSe_Click(object sender, EventArgs e)
        {
            Session["user"] = null;
            Response.Redirect("~/Public/SearchFlights.aspx", true);
        }
     

    }
}