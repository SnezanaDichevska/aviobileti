using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace AvioBileti.Public
{
    public partial class Login : System.Web.UI.Page
    {
        /// <summary>
        /// When redirected to Login.aspx from another site it shows a message that
        /// the attemt to access pages without being loged in is forbidden
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            //Remove access attribute from url on postback call
            if (IsPostBack && Request.QueryString["access"] == "no")
            {
                Response.Redirect("~/Public/Login.aspx", true);
            }
            
            if (Request.QueryString["access"] == "no")
            {
                lblAccessMessage.Visible = true;
                lblAccessMessage.Text = "Не сте најавени!!!";
            }
            else lblAccessMessage.Visible = false;
        }

        /// <summary>
        /// Validate the input and redirect to the corresponding site,
        /// show message if input is invalid
        /// </summary>
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = tbUsername.Text;
            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;
            string query = "SELECT lozinka,ID, tipID FROM korisnici where korisnichkoime= '" + username + "';";
           
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
                    string password = citac.GetString(0).Trim(); //only 1 entry will be returned

                    if (!password.Equals(tbPassword.Text))
                    {
                        lblError.Text = "Погрешнa лозинка !";
                    }
                    else
                    {
                        int tip = (int)citac.GetValue(2);
                        int id = (int)citac.GetValue(1);
                        if (tip == 1)
                        {
                            Session["user"] = username;
                            Session["userID"] = id;
                            Session["userType"] = "admin";
                            Response.Redirect("~/Admin/MyProfile.aspx", true);
                        }
                        else
                        {
                            Session["user"] = username;
                            Session["userID"] = id;
                            Session["userType"] = "user";
                            //if user wanted to make a reservation redirect him/her to the next site for
                            //completing the reservation process
                            if(Convert.ToBoolean(Session["makeAreservation"]))
                                Response.Redirect("~/User/MakeAReservation.aspx", true);
                            else
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

       
    }
}