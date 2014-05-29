using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AvioBileti.User
{
    public partial class MyReservations : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(Session["user"] as string))
            {
                Response.Redirect("~/Public/SearchFlights.aspx?access=no", true);
            }
            else
            {
                string userType = Session["userType"] as string;
                if (userType == "admin")
                {
                    Response.Redirect("~/Admin/MyProfile.aspx", true);
                }
            }
        }
    }
}