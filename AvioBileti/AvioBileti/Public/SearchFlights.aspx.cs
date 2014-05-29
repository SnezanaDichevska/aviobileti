using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AvioBileti
{
    public partial class SearchFlights : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //na postback da nema access=no 
            if (IsPostBack && Request.QueryString["access"] == "no")
            {
                Response.Redirect("~/Public/SearchFlights.aspx", true);
            }
            //ako probuva nenajaven da pristapi preku url do MyProfile.aspx
            if (Request.QueryString["access"] == "no")
            {
                lblAccessMessage.Visible = true;
                lblAccessMessage.Text = "Не сте најавени!!!";
            }
            else lblAccessMessage.Visible = false;
        }

        protected void fromCalendar_SelectionChanged(object sender, EventArgs e)
        {
            tbFrom.Text = fromCalendar.SelectedDate.ToShortDateString();
        }

        protected void btnCal1_Click(object sender, ImageClickEventArgs e)
        {
            fromCalendar.Enabled = !fromCalendar.Enabled;
            fromCalendar.Visible = !fromCalendar.Visible;
        }

        protected void btnCal2_Click(object sender, ImageClickEventArgs e)
        {
            toCalendar.Enabled = !toCalendar.Enabled;
            toCalendar.Visible = !toCalendar.Visible;
        }

        protected void toCalendar_SelectionChanged(object sender, EventArgs e)
        {
            tbTo.Text = toCalendar.SelectedDate.ToShortDateString();
        }
    }
}