using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Globalization;

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

            if (!IsPostBack)
            {
                loadDestionations();

            }
            //koga ke izbere destinacii mu gi dava datite za tie letovite so takvi destinacii
            //ima opcija samo po pojdovna i opcija po 2 da bara
            getCalendarData();

        }


        public void getCalendarData()
        {
            // SQL Connection String  
            string SqlConnectionString = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

            // Initializing the SQL Database connection  
            SqlConnection mySqlConnection = new SqlConnection(SqlConnectionString);
            string queryTrgnuvanjeCalendar, queryVrakjanjeCalendar;
            //ako nema selektirano krajna daj mu datumi pocetni za pojdovna destinacija
            if (ddToDestination.SelectedValue == "")
            {
                queryTrgnuvanjeCalendar = "SELECT datum "
                + " FROM letovi "
                + " WHERE pojdovnaDestID=" + ddFromDestination.SelectedValue + ";";

                queryVrakjanjeCalendar = "SELECT datum "
                + " FROM letovi "
                + " WHERE krajnaDestID=" + ddFromDestination.SelectedValue + ";";

            } //TODO: da mora 2 da selektira validacija i prviot if da se izbrise
            // gi ima 2te destinacii selektirano
            else
            {
                queryTrgnuvanjeCalendar = "SELECT datum "
              + " FROM letovi "
              + " WHERE pojdovnaDestID=" + ddFromDestination.SelectedValue + " and krajnaDestID= " + ddToDestination.SelectedValue + ";";


                queryVrakjanjeCalendar = "SELECT datum "
              + " FROM letovi "
              + " WHERE pojdovnaDestID=" + ddToDestination.SelectedValue + " and krajnaDestID= " + ddFromDestination.SelectedValue + ";";


            }


            // Initialzing SQL Command by passing the above SQL Query  
            // that is to be executed.  
            SqlCommand mySqlCommand = new SqlCommand(queryTrgnuvanjeCalendar, mySqlConnection);
            SqlCommand mySqlCommand2 = new SqlCommand(queryVrakjanjeCalendar, mySqlConnection);
            try
            {
                mySqlConnection.Open();
                // FIRST CALENDAR selected dates
                SqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
                SelectedDatesCollection datesCollection1 = trgnuvanjeCalendar.SelectedDates;

                // Clear all the previously stored Dates  
                datesCollection1.Clear();

                trgnuvanjeCalendar.VisibleDate = DateTime.Today;

                while (mySqlDataReader.Read())
                {
                    int day = mySqlDataReader.GetSqlDateTime(0).Value.Day;
                    datesCollection1.Add(mySqlDataReader.GetSqlDateTime(0).Value);
                }

                // close the data reader  
                mySqlDataReader.Close();

                //SECOND Calendar
                SqlDataReader mySqlDataReader2 = mySqlCommand2.ExecuteReader();
                SelectedDatesCollection datesCollection2 = vrakjanjeCalendar.SelectedDates;
                datesCollection2.Clear();
                vrakjanjeCalendar.VisibleDate = DateTime.Today;
                while (mySqlDataReader2.Read())
                {
                    int day = mySqlDataReader2.GetSqlDateTime(0).Value.Day;
                    datesCollection2.Add(mySqlDataReader2.GetSqlDateTime(0).Value);
                }
                mySqlDataReader2.Close();

            }
            catch (Exception ex)
            {
                lblAccessMessage.Visible = true;
                lblAccessMessage.Text = ex.Message;
            }
            finally
            {
                mySqlConnection.Close();
            }
        }

        protected void trgnuvanjeCalendar_DayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.IsSelected)
            {
                Style vacationStyle = new Style();
                vacationStyle.BackColor = System.Drawing.Color.Violet;
                e.Cell.ApplyStyle(vacationStyle);
            }

        }




        protected void loadDestionations()
        {
            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;
            string query = "select distinct letovi.pojdovnaDestID as PID, destinacii.gradd + ', ' + destinacii.aerodrom as dest"
                         + " from destinacii"
                         + " join letovi"
                         + " on destinacii.IDD= letovi.pojdovnaDestID ;";
            SqlCommand komanda = new SqlCommand(query, konekcija);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = komanda;
            DataSet ds = new DataSet();

            try
            {
                konekcija.Open();
                adapter.Fill(ds, "destinacii");
                ddFromDestination.DataTextField = "dest";
                ddFromDestination.DataValueField = "PID";
                ddFromDestination.DataSource = ds;
                ddFromDestination.DataBind();

            }
            catch (Exception ex)
            {
                //lblError.Text = ex.Message;
                lblAccessMessage.Visible = true;
                lblAccessMessage.Text = ex.Message;
            }
            finally
            {
                konekcija.Close();
            }
        }

        protected void trgnuvanjeCalendar_SelectionChanged(object sender, EventArgs e)
        {
            tbTrgnuvanjeDatum.Text = trgnuvanjeCalendar.SelectedDate.ToShortDateString();

        }

        protected void vrakjanjeCalendar_SelectionChanged(object sender, EventArgs e)
        {

            tbVrakjanjeDatum.Text = vrakjanjeCalendar.SelectedDate.ToShortDateString();
        }

        protected void btnCal1_Click(object sender, ImageClickEventArgs e)
        {
            trgnuvanjeCalendar.Enabled = !trgnuvanjeCalendar.Enabled;
            trgnuvanjeCalendar.Visible = !trgnuvanjeCalendar.Visible;
            if (trgnuvanjeCalendar.SelectedDates.Count == 0) tbVrakjanjeDatum.Text = "";
            else tbTrgnuvanjeDatum.Text = trgnuvanjeCalendar.SelectedDate.ToShortDateString();

        }

        protected void btnCal2_Click(object sender, ImageClickEventArgs e)
        {
            vrakjanjeCalendar.Enabled = !vrakjanjeCalendar.Enabled;
            vrakjanjeCalendar.Visible = !vrakjanjeCalendar.Visible;
            if (vrakjanjeCalendar.SelectedDates.Count == 0) tbVrakjanjeDatum.Text = "";
            else tbVrakjanjeDatum.Text = vrakjanjeCalendar.SelectedDate.ToShortDateString();

        }





        protected void loadToDestinations()
        {
            string value = ddFromDestination.SelectedValue;
            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;
            string query = "select distinct letovi.krajnaDestID as KID , destinacii.gradd + ',' + destinacii.aerodrom as dest"
                         + " from destinacii"
                         + " join letovi"
                         + " on destinacii.IDD= letovi.krajnaDestID "
                         + " and letovi.pojdovnaDestID=" + value + ";";
            SqlCommand komanda = new SqlCommand(query, konekcija);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = komanda;
            DataSet ds = new DataSet();
            try
            {
                konekcija.Open();
                adapter.Fill(ds, "destinacii");
                ddToDestination.DataTextField = "dest";
                ddToDestination.DataValueField = "KID";
                ddToDestination.DataSource = ds;
                ddToDestination.DataBind();
            }
            catch (Exception ex)
            {
                //lblError.Text = ex.Message;
                lblAccessMessage.Visible = true;
                lblAccessMessage.Text = ex.Message;
            }
            finally
            {
                konekcija.Close();
            }
        }

        protected void ddFromDestination_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadToDestinations();
            if (!trgnuvanjeCalendar.Enabled) tbTrgnuvanjeDatum.Text = "";
            else tbTrgnuvanjeDatum.Text = trgnuvanjeCalendar.SelectedDate.ToShortDateString();
        }

        protected void btnSearchFlights_Click(object sender, EventArgs e)
        {
            if (tbTrgnuvanjeDatum.Text != "")
            {
                loadgvLetoviTrgnuvanje();
                //Grid so povratni letovi
                if (!vrakjanjeCalendar.Enabled) tbVrakjanjeDatum.Text = "";
                else
                {
                    tbVrakjanjeDatum.Text = vrakjanjeCalendar.SelectedDate.ToShortDateString();
                    loadgvLetoviVrakjanje();
                }
            } //ОPTIONAL
            else
            {
                lblAccessMessage.Visible = true;
                lblAccessMessage.Text = "Одберете датум!";
                gvLetoviTrgnuvanje.DataSource = null;
                gvLetoviTrgnuvanje.DataBind();
            }



        }

        private void loadgvLetoviTrgnuvanje()
        {
            int pocetnaId = Convert.ToInt32(ddFromDestination.SelectedValue);
            int krajnaId = Convert.ToInt32(ddToDestination.SelectedValue);
            String datumTrgnuvanje = tbTrgnuvanjeDatum.Text;
            String datumVrakjanje = tbVrakjanjeDatum.Text;
            int sumPassangers=Convert.ToInt32(ddlBrojVozrasni.SelectedValue)+Convert.ToInt32(ddlBrojDeca.SelectedValue)+Convert.ToInt32(ddlBrojBebe.SelectedValue);

            if (pocetnaId != 0 && krajnaId != 0 && datumTrgnuvanje != "")
            {
                SqlConnection konekcija = new SqlConnection();
                konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

                lblAccessMessage.Visible = true;
                lblAccessMessage.Text = datumTrgnuvanje; //datumTrgnuvanje



                string query = "SELECT destinacii.gradd + ',' + destinacii.aerodrom as KGRAD,l.IDL as IDL,let.gradd + ', ' +let.aerodrom as PGRAD,vremes,vremep,CONVERT(VARCHAR(10),cena) +' '+ valuta as cena,let.datum as datumLet"
                             + " from letovi l join destinacii on l.krajnaDestID=destinacii.IDD"
                             + " join (select IDL,gradd,datum,aerodrom"
                             + "    from letovi"
                             + "    join destinacii"
                             + "    on destinacii.IDD= letovi.pojdovnaDestID"
                             + "     and pojdovnaDestID=" + pocetnaId
                             + "  and CONVERT(VARCHAR(10),datum,104) like '" + datumTrgnuvanje + "%') as let" //and datum='" + date + "'
                             + " on l.IDL=let.IDL  and destinacii.IDD=" + krajnaId
                             + " join dostapnostNaLetovi on letID=l.IDL and slobodniMesta > "+sumPassangers+" ;";

                SqlCommand komanda = new SqlCommand(query, konekcija);
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = komanda;
                DataSet ds = new DataSet();
                try
                {
                    konekcija.Open();
                    adapter.Fill(ds, "letovi");
                    gvLetoviTrgnuvanje.DataSource = ds;
                    gvLetoviTrgnuvanje.DataBind();
                    gvLetoviTrgnuvanje.Enabled = true;
                    gvLetoviTrgnuvanje.Visible = true;
                }
                catch (Exception ex)
                {
                    //lblError.Text = ex.Message;
                    lblAccessMessage.Visible = true;
                    lblAccessMessage.Text = ex.Message;
                }
                finally
                {
                    konekcija.Close();
                }
            }

        }


        private void loadgvLetoviVrakjanje()
        {
            int krajnaId = Convert.ToInt32(ddFromDestination.SelectedValue);
            int pocetnaId = Convert.ToInt32(ddToDestination.SelectedValue);

            String datumVrakjanje = tbVrakjanjeDatum.Text;


            if (pocetnaId != 0 && krajnaId != 0 && datumVrakjanje != "")
            {
                SqlConnection konekcija = new SqlConnection();
                konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;
                int sumPassangers = Convert.ToInt32(ddlBrojVozrasni.SelectedValue) + Convert.ToInt32(ddlBrojDeca.SelectedValue) + Convert.ToInt32(ddlBrojBebe.SelectedValue);



                lblAccessMessage.Visible = true;
                lblAccessMessage.Text = datumVrakjanje; //datumTrgnuvanje


                string query = "SELECT destinacii.gradd + ',' + destinacii.aerodrom as KGRAD,l.IDL as IDL,let.gradd + ', ' +let.aerodrom as PGRAD,vremes,vremep,CONVERT(VARCHAR(10),cena)+' '+  valuta as cena,let.datum as datumLet"
                             + " from letovi l join destinacii on l.krajnaDestID=destinacii.IDD"
                             + " join (select IDL,gradd,datum,aerodrom"
                             + "    from letovi"
                             + "    join destinacii"
                             + "    on destinacii.IDD= letovi.pojdovnaDestID"
                             + "     and pojdovnaDestID=" + pocetnaId
                             + "  and CONVERT(VARCHAR(10),datum,104) like '" + datumVrakjanje + "%') as let" //and datum='" + date + "'
                             + " on l.IDL=let.IDL  and destinacii.IDD=" + krajnaId
                              + " join dostapnostNaLetovi on letID=l.IDL and slobodniMesta > " + sumPassangers + " ;";

                SqlCommand komanda = new SqlCommand(query, konekcija);
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = komanda;
                DataSet ds = new DataSet();
                try
                {
                    konekcija.Open();
                    adapter.Fill(ds, "letovi");
                    gvLetoviVrakjanje.DataSource = ds;
                    gvLetoviVrakjanje.DataBind();
                    gvLetoviVrakjanje.Enabled = true;
                    gvLetoviVrakjanje.Visible = true;
                }
                catch (Exception ex)
                {
                    //lblError.Text = ex.Message;
                    lblAccessMessage.Visible = true;
                    lblAccessMessage.Text = ex.Message;
                }
                finally
                {
                    konekcija.Close();
                }
            }

        }

        protected void btnRezerviraj_Click(object sender, EventArgs e)
        {
            Session["trgnuvanjeLetID"] = (int)ViewState["trgnuvanjeLetID"];
            Session["vrakjanjeLetID"] = (int)ViewState["vrakjanjeLetID"];
            Session["brojVozrasni"] = Convert.ToInt32(ddlBrojVozrasni.SelectedValue);
            Session["brojDeca"] = Convert.ToInt32(ddlBrojDeca.SelectedValue);
            Session["brojBebinja"] = Convert.ToInt32(ddlBrojBebe.SelectedValue);

            if (String.IsNullOrEmpty(Session["user"] as string))
            {
                
                Response.Redirect("~/Public/Login.aspx?", true);
            }
            else
            {
                string userType = Session["userType"] as string;
             
                //Logiran admin KE MOZE DA REZERVIRA ADMIN?
                if (userType == "admin")
                {
                    Response.Redirect("~/Admin/MyProfile.aspx", true);
                }
                //Logiran user
                else
                {
                    //Za vo MakeAReservation transfer
               
       
                    Response.Redirect("~/User/MakeAReservation.aspx", true);
                }


            }
        }

        protected void gvLetoviTrgnuvanje_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblAccessMessage.Visible = true;

            lblAccessMessage.Text = Convert.ToString(gvLetoviTrgnuvanje.DataKeys[gvLetoviTrgnuvanje.SelectedIndex].Value);
            ViewState["trgnuvanjeLetID"] = gvLetoviTrgnuvanje.DataKeys[gvLetoviTrgnuvanje.SelectedIndex].Value;
        }

        protected void gvLetoviVrakjanje_SelectedIndexChanged(object sender, EventArgs e)
        {

            ViewState["vrakjanjeLetID"] = gvLetoviVrakjanje.DataKeys[gvLetoviVrakjanje.SelectedIndex].Value;

        }

    }
}