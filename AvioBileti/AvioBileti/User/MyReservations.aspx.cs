using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace AvioBileti.User
{
    public partial class MyReservations : System.Web.UI.Page
    {
        /// <summary>
        /// Checking access privileges
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(Session["user"] as string))
            {
                Response.Redirect("~/Public/Login.aspx?access=no", true);
            }
            else
            {
                Session["makeAreservation"] = false;
                string userType = Session["userType"] as string;
                if (userType == "admin")
                {
                    Response.Redirect("~/Admin/MyProfile.aspx", true);
                }
                 //Loged in user
                else
                {
                    lblKorisnikLista.Text = "Листа на резервации за корисникот " + Session["user"] as string;
                    loadMyReservations();
                }
            }
        }



        /// <summary>
        /// Loads the grid with all the reservations from a specific user
        /// </summary>
        protected void loadMyReservations()
        {
            int userID=(int)Session["userID"];
            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;
            string query = "select IDB ,bileti.ime as name ,bileti.prezime as surname, pd.gradd as pojdovna,kd.gradd as krajna,CONVERT(VARCHAR(10),letovi.datum,104) as date,CONVERT(VARCHAR(10),letovi.cena) +' '+ valuta as price"
                         + " from bileti"
                         + " join korisnici"
                         + " on bileti.korisnikID=korisnici.ID "
                         + " and korisnikID="+userID
                         + " join letovi on bileti.IDL=letovi.IDL"
                         + " join destinacii as pd on letovi.pojdovnaDestID=pd.IDD"
                         + " join destinacii as kd on letovi.krajnaDestID=kd.IDD;";
            SqlCommand komanda = new SqlCommand(query, konekcija);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = komanda;
            DataSet ds = new DataSet();

            try
            {
                konekcija.Open();
                adapter.Fill(ds);
                gvRezervacii.DataSource = ds;
                gvRezervacii.DataBind();

            }
            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = "EX0: " + ex.Message;
            }
            finally
            {
                konekcija.Close();
            }
        }

    }
}