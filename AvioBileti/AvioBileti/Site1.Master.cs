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
                btnSignOut.Visible = false;
                btnSignOut.Enabled = false;
                hlUser.Enabled = false;
                hlUser.Visible = false;
            }
            else
            {
                string user = Session["user"] as string;
                btnSignOut.Visible = true;
                btnSignOut.Enabled = true;
                hlUser.Enabled = true;
                hlUser.Visible = true;
                hlUser.Text = user;
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = tbUsername.Text;
            /*Regex r = new Regex(@"^[a-zA-Z0-9_\-@\*]*$", RegexOptions.IgnoreCase);
            Match m = r.Match(username);  // proveri dali e validno korisnickoto ime 

            if (username.Length != 0 && m.Success)
            {*/
            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;
           string query = "SELECT lozinka, tipID FROM korisnici where korisnichkoime= '" + username + "';";
          // string query = "UPDATE korisnici SET ID='1', korisnichkoime='user1',ime='user',prezime='user',pol='f',ulica='',broj='1',grad='Skopje',drzava='Makedonija',mobtelefon='077111222',email='user@mail.com',tipID='2',lozinka='123' "
          //  +"WHERE ID='1';";
            SqlCommand komanda = new SqlCommand(query, konekcija);
            try
            {
                konekcija.Open();
                SqlDataReader citac = komanda.ExecuteReader();
                if (citac.Read() == false)
                { 
                    lblError.Text = "Погрешно корисничко име !";
                }
                else
                {
                    string password = citac.GetString(0).Trim(); // samo 1 lozinka treba da vrati query-to
                   
                    if (!password.Equals(tbPassword.Text))
                    {
                        lblError.Text = "Погрешнa лозинка !" + password + ":" + tbPassword.Text;
                    }
                    else
                    {
                        int tip =  (int)citac.GetValue(1);
                        if (tip == 1)
                        {
                            Session["user"] = username;
                            Session["userType"] = "admin";
                            Response.Redirect("~/Admin/MyProfile.aspx", true);
                        }
                        else
                        {
                            Session["user"] = username;
                            Session["userType"] = "user";
                            Response.Redirect("~/User/MyProfile.aspx", true);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
            finally
            {
                konekcija.Close();
            }

           
        }

        protected void btnSignOut_Click(object sender, EventArgs e)
        {
            btnSignOut.Visible = false;
            btnSignOut.Enabled = false;
            hlUser.Enabled = false;
            hlUser.Visible = false;
            Session["user"] = null;
            Response.Redirect("~/Public/SearchFlights.aspx", true);
        }
    }
}