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
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSaveRegistration_Click(object sender, EventArgs e)
        {
            //TODO:  validaciski kontroli
            string korisnichkoI = tbKorisnichkoIme.Text,
                   ime = tbIme.Text, prezime = tbPrezime.Text,
                   pol = rbPol.SelectedValue, adresa = tbAdresa.Text,
                   grad = tbGrad.Text, drzava = tbDrzava.Text, mobilen = tbMobTel.Text,
                   email = tbEmail.Text, lozinka = tbPassword.Text, lozinkaCheck = tbPasswordCheck.Text;

            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;
            string query = "INSERT INTO korisnici"
                +" (korisnichkoIme, ime, prezime, pol, adresa, grad, drzava, mobtelefon, email, lozinka, tipID) "
                +" VALUES ('"+korisnichkoI+"','"+ime+"','"+prezime+"','"+pol+"','"+adresa+"','"+grad+"','"+drzava+"','"+mobilen+"','"+email+"','"+lozinka+"',2);";
            
            SqlCommand komanda = new SqlCommand(query, konekcija);
            try
            {
                konekcija.Open();
                int status = komanda.ExecuteNonQuery();
                if (status == 0)
                {
                    lblError.Text = "  Неуспешна регистрација!";
                }
                else
                {
                    Session["user"] = korisnichkoI;
                    Session["userType"] = "user";
                    lblError.Text = " Успешно се регистриравте!";
                    //TODO: da se iscistat kontrolite po uspesna registracija 
                    //     ili da se skrie tabelata(malce potesko poso e html samo)
                    
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