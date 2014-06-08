using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AvioBileti.User
{
    public partial class MyProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(Session["user"] as string))
            {
                Response.Redirect("~/Public/Login.aspx?access=no", true);
            }
            else
            {
                //ako admin probuva da pristapi do profilot na userot .. moze i da se trgne ova bidejki e admin 
                //pa moze da ima privilegii
                string userType = Session["userType"] as string;
                if (userType == "admin")
                {
                    Response.Redirect("~/Admin/MyProfile.aspx", true);
                }
                else if(Convert.ToBoolean(Session["makeAreservation"]))
                {
                     //Ne bil logiran a rezerviral let po logiranje da go prenasoci direktno na make a reservation
                        Session["makeAreservation"] = false;
                        Response.Redirect("~/User/MakeAreservation.aspx", true);
                }
            }
        }
    }
}