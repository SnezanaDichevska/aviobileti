using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace AvioBileti.Admin
{
    public partial class AdminHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (String.IsNullOrEmpty(Session["user"] as string))
                {
                    Response.Redirect("~/Public/Login.aspx?access=no", true);
                }
                else
                {
                    string userType = Session["userType"] as string;
                    if (userType == "user")
                    {
                        Response.Redirect("~/User/MyProfile.aspx", true);
                    }
                    else
                    {
                        ispolniDestinacii();
                        ispolniLetovi();
                    }
                }

                
            }

        }

        protected void ispolniDestinacii()
        {
            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;
            string sqlStr = "SELECT * FROM destinacii ORDER BY gradd";
            SqlCommand komanda = new SqlCommand(sqlStr, konekcija);
            SqlDataAdapter adapter = new SqlDataAdapter(komanda);
            DataSet ds = new DataSet();

            try
            {
                konekcija.Open();
                adapter.Fill(ds, "destinacii");
                gwDestinacii.DataSource = ds;
                gwDestinacii.DataBind();

                ViewState["dataset"] = ds;
            }
            catch (Exception err)
            {
                //lblPoraka.Text = err.Message;
            }
            finally
            {
                konekcija.Close();
            }
        }


        protected void gwDestinacii_RowEditing(object sender, GridViewEditEventArgs e)
        {
            DataSet ds = (DataSet)ViewState["dataset"];
            gwDestinacii.EditIndex = e.NewEditIndex;
            gwDestinacii.DataSource = ds;
            gwDestinacii.DataBind();
        }

        protected void gwDestinacii_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;
            string sqlUpdate = "UPDATE destinacii set gradd = @gradd, aerodrom = @aerodrom WHERE idd = @idd";
            SqlCommand updateKomanda = new SqlCommand(sqlUpdate, konekcija);
            TextBox tb = (TextBox)gwDestinacii.Rows[e.RowIndex].Cells[1].Controls[0];
            updateKomanda.Parameters.AddWithValue("@gradd", tb.Text);

            tb = (TextBox)gwDestinacii.Rows[e.RowIndex].Cells[2].Controls[0];
            updateKomanda.Parameters.AddWithValue("@aerodrom", tb.Text);

            updateKomanda.Parameters.AddWithValue("@idd", gwDestinacii.DataKeys[gwDestinacii.SelectedIndex].Value);
                //Rows[e.RowIndex].Cells[0].Text);

            int efekt = 0;
            try
            {
                konekcija.Open();
                efekt = updateKomanda.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                //lblPoraka.Text = err.Message;
            }
            finally
            {
                konekcija.Close();
                gwDestinacii.EditIndex = -1;
            }

            if (efekt != 0)
                ispolniDestinacii();
        }

        protected void btnDodadi_Click(object sender, EventArgs e)
        {
            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;
            string sqldodadi = "INSERT INTO destinacii (idd, gradd, aerodrom) VALUES (@idd, @gradd, @aerodrom)";
            SqlCommand dodadiKomanda = new SqlCommand(sqldodadi, konekcija);

            dodadiKomanda.Parameters.AddWithValue("@idd", txtID.Text);
            dodadiKomanda.Parameters.AddWithValue("@gradd", txtGrad.Text);
            dodadiKomanda.Parameters.AddWithValue("@aerodrom", txtAerodrom.Text);

            int efekt = 0;
            try
            {
                konekcija.Open();
                efekt = dodadiKomanda.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                //lblPoraka.Text = err.Message;
            }
            finally
            {
                konekcija.Close();
            }
            if (efekt != 0)
            {
                ispolniDestinacii();
                txtID.Text = "";
                txtGrad.Text = "";
                txtAerodrom.Text = "";
            }
        }

        protected void ispolniLetovi()
        {
            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;
            string sqlStr = "SELECT * FROM letovi ORDER BY idl";
            SqlCommand komanda = new SqlCommand(sqlStr, konekcija);
            SqlDataAdapter adapter = new SqlDataAdapter(komanda);
            DataSet ds = new DataSet();

            try
            {
                konekcija.Open();
                adapter.Fill(ds, "letovi");
                gwLetovi.DataSource = ds;
                gwLetovi.DataBind();

                ViewState["datasetLet"] = ds;
            }
            catch (Exception err)
            {
                //lblPoraka.Text = err.Message;
            }
            finally
            {
                konekcija.Close();
            }
        }



        protected void btnDodadiLet_Click(object sender, EventArgs e)
        {
            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;
            string sqldodadi = "INSERT INTO letovi (idl, datum, vremep, vremes, vremetraenje, tipavion, cenafix) VALUES (@idl, @datum, @vremep, @vremes, @vremetraenje, @tipavion, @cenafix)";
            SqlCommand dodadiKomanda = new SqlCommand(sqldodadi, konekcija);

            dodadiKomanda.Parameters.AddWithValue("@idl", txtID.Text);
            dodadiKomanda.Parameters.AddWithValue("@datum", txtDatum.Text);
            dodadiKomanda.Parameters.AddWithValue("@vremep", txtVremeP.Text);
            dodadiKomanda.Parameters.AddWithValue("@vremes", txtVremeS.Text);
            dodadiKomanda.Parameters.AddWithValue("@vremetraenje", txtVremetraenje.Text);
            dodadiKomanda.Parameters.AddWithValue("@tipavion", txtTipAvion.Text);
            dodadiKomanda.Parameters.AddWithValue("@cenafix", txtCena.Text);

            int efekt = 0;
            try
            {
                konekcija.Open();
                efekt = dodadiKomanda.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                //lblPoraka.Text = err.Message;
            }
            finally
            {
                konekcija.Close();
            }
            if (efekt != 0)
            {
                ispolniLetovi();
                txtID.Text = "";
                txtDatum.Text = "";
                txtVremeP.Text = "";
                txtVremeS.Text = "";
                txtVremetraenje.Text = "";
                txtTipAvion.Text = "";
                txtCena.Text = "";              
            }

        }

        protected void gwLetovi_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            DataSet ds = (DataSet)ViewState["datasetLet"];
            gwLetovi.EditIndex = -1;
            gwLetovi.DataSource = ds;
            gwLetovi.DataBind();

        }

        protected void gwLetovi_RowEditing(object sender, GridViewEditEventArgs e)
        {
            DataSet ds = (DataSet)ViewState["datasetLet"];
            gwLetovi.EditIndex = e.NewEditIndex;
            gwLetovi.DataSource = ds;
            gwLetovi.DataBind();

        }

        protected void gwLetovi_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;
            string sqlUpdate = "UPDATE letovi set datum = @datum, vremep = @vremep, vremes = @vremes, vremetraenje = @vremetraenje, tipavion = @tipavion, cenafix = @cenafix WHERE idl = @idl";

            
            SqlCommand updateKomanda = new SqlCommand(sqlUpdate, konekcija);
            TextBox tb = (TextBox)gwLetovi.Rows[e.RowIndex].Cells[1].Controls[0];
            updateKomanda.Parameters.AddWithValue("@datum", tb.Text);

            tb = (TextBox)gwLetovi.Rows[e.RowIndex].Cells[2].Controls[0];
            updateKomanda.Parameters.AddWithValue("@vremep", tb.Text);

            tb = (TextBox)gwLetovi.Rows[e.RowIndex].Cells[2].Controls[0];
            updateKomanda.Parameters.AddWithValue("@vremes", tb.Text);

            tb = (TextBox)gwLetovi.Rows[e.RowIndex].Cells[2].Controls[0];
            updateKomanda.Parameters.AddWithValue("@vremetraenje", tb.Text);

            tb = (TextBox)gwLetovi.Rows[e.RowIndex].Cells[2].Controls[0];
            updateKomanda.Parameters.AddWithValue("@tipavion", tb.Text);

            tb = (TextBox)gwLetovi.Rows[e.RowIndex].Cells[2].Controls[0];
            updateKomanda.Parameters.AddWithValue("@cenafix", tb.Text);

            updateKomanda.Parameters.AddWithValue("@idl", gwLetovi.DataKeys[gwLetovi.SelectedIndex].Value);
            //Rows[e.RowIndex].Cells[0].Text);

            int efekt = 0;
            try
            {
                konekcija.Open();
                efekt = updateKomanda.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                //lblPoraka.Text = err.Message;
            }
            finally
            {
                konekcija.Close();
                gwLetovi.EditIndex = -1;
            }

            if (efekt != 0)
                ispolniLetovi();
        }

       

        protected void gwDestinacii_RowCancelingEdit1(object sender, GridViewCancelEditEventArgs e)
        {
            DataSet ds = (DataSet)ViewState["dataset"];
            gwDestinacii.EditIndex = -1;
            gwDestinacii.DataSource = ds;
            gwDestinacii.DataBind();
        }

       
    }
}