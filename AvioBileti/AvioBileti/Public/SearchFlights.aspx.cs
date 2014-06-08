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
        /// <summary>
        /// Setting the viewstate ids for stored flights on null 
        /// and call to a method for generating data for Calendars
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadFromDestionations();
               // ViewState["trgnuvanjeLetID"] = null;
                ViewState["vrakjanjeLetID"] = null;
                Session["makeAreservation"] = false;
            }
            getCalendarData();
        }


        /// <summary>
        /// Retrives dates for flights from database and loads the Calendars with them
        /// </summary>
        public void getCalendarData()
        {
            string SqlConnectionString = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString; 
            SqlConnection mySqlConnection = new SqlConnection(SqlConnectionString);
            string queryTrgnuvanjeCalendar, queryVrakjanjeCalendar;

            //if both destinations are selected retrive flight from database
            if (ddToDestination.SelectedValue != "" && ddFromDestination.SelectedValue != "")
            {
                queryTrgnuvanjeCalendar = "SELECT datum "
              + " FROM letovi "
              + " WHERE pojdovnaDestID=" + ddFromDestination.SelectedValue + " and krajnaDestID= " + ddToDestination.SelectedValue + " ;";


                queryVrakjanjeCalendar = "SELECT datum "
              + " FROM letovi "
              + " WHERE pojdovnaDestID=" + ddToDestination.SelectedValue + " and krajnaDestID= " + ddFromDestination.SelectedValue + " ;";

                SqlCommand mySqlCommand = new SqlCommand(queryTrgnuvanjeCalendar, mySqlConnection);
                SqlCommand mySqlCommand2 = new SqlCommand(queryVrakjanjeCalendar, mySqlConnection);
                try
                {
                    //Get dates for first Calendar and highlight them (add to selectedDates)
                    mySqlConnection.Open();
                    SqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
                    SelectedDatesCollection datesCollection1 = trgnuvanjeCalendar.SelectedDates;

                    // Clear all the previously stored Dates  
                    datesCollection1.Clear();
                    trgnuvanjeCalendar.VisibleDate = DateTime.Today; //set vidible date from Today

                    while (mySqlDataReader.Read())
                    {
                        int day = mySqlDataReader.GetSqlDateTime(0).Value.Day;
                        datesCollection1.Add(mySqlDataReader.GetSqlDateTime(0).Value);
                    }  
                    mySqlDataReader.Close();

                    //Get dates for second Calendar and highlight them (add to selectedDates)
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
                    lblError.Visible = true;
                    lblError.Text = "EX0: " + ex.Message;
                }
                finally
                {
                    mySqlConnection.Close();
                }
            }
            
            
        }

        /// <summary>
        /// Apply color to selected(highlighted) dates in Calendar
        /// </summary>
        protected void trgnuvanjeCalendar_DayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.IsSelected)
            {
                Style vacationStyle = new Style();
                vacationStyle.BackColor = System.Drawing.Color.Violet;
                e.Cell.ApplyStyle(vacationStyle);
            }

        }

        /// <summary>
        /// Retrives destinations from database for the dropdown list with starting destinations
        /// </summary>
        protected void loadFromDestionations()
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
                lblError.Visible = true;
                lblError.Text = "EX1: " + ex.Message;
            }
            finally
            {
                konekcija.Close();
            }
        }

        /// <summary>
        /// Adds date to the corresponding text box when a date is selected on the calendar
        /// </summary>
        protected void trgnuvanjeCalendar_SelectionChanged(object sender, EventArgs e)
        {
            tbTrgnuvanjeDatum.Text = trgnuvanjeCalendar.SelectedDate.ToShortDateString();

        }

        /// <summary>
        ///  Adds date to the corresponding text box when a date is selected on the calendar
        /// </summary>
        protected void vrakjanjeCalendar_SelectionChanged(object sender, EventArgs e)
        {
            tbVrakjanjeDatum.Text = vrakjanjeCalendar.SelectedDate.ToShortDateString();
        }


        /// <summary>
        ///  Opens/Hides the calendar on click and fills/clears the corresponding text box if a date is/isn't selected
        /// </summary>
        protected void btnCal1_Click(object sender, ImageClickEventArgs e)
        {
            trgnuvanjeCalendar.Enabled = !trgnuvanjeCalendar.Enabled;
            trgnuvanjeCalendar.Visible = !trgnuvanjeCalendar.Visible;
            if (trgnuvanjeCalendar.SelectedDates.Count == 0)
                tbVrakjanjeDatum.Text = "";
            else 
                tbTrgnuvanjeDatum.Text = trgnuvanjeCalendar.SelectedDate.ToShortDateString();

        }

        /// <summary>
        ///  Opens/Hides the calendar on click and fills/clears the corresponding text box if a date is/isn't selected
        /// </summary>
        protected void btnCal2_Click(object sender, ImageClickEventArgs e)
        {
            vrakjanjeCalendar.Enabled = !vrakjanjeCalendar.Enabled;
            vrakjanjeCalendar.Visible = !vrakjanjeCalendar.Visible;
            if (vrakjanjeCalendar.SelectedDates.Count == 0) 
                tbVrakjanjeDatum.Text = "";
            else
                tbVrakjanjeDatum.Text = vrakjanjeCalendar.SelectedDate.ToShortDateString();

        }

        /// <summary>
        /// Retrives destinations from database for the dropdown list with ending destinations
        /// </summary>
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
                lblError.Visible = true;
                lblError.Text = "EX2: " + ex.Message;
            }
            finally
            {
                konekcija.Close();
            }
        }

        /// <summary>
        /// Updates/Clears date TextBox if another starting destination is selected
        /// </summary>
        protected void ddFromDestination_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadToDestinations();
            if (!trgnuvanjeCalendar.Enabled)
               tbTrgnuvanjeDatum.Text = "";
            else 
                tbTrgnuvanjeDatum.Text = trgnuvanjeCalendar.SelectedDate.ToShortDateString();
            if (tbTrgnuvanjeDatum.Text == "01.01.0001")
                tbTrgnuvanjeDatum.Text = "";
        }

        /// <summary>
        /// Updates/Clears date TextBox if another ending destination is selected
        /// </summary>
        protected void ddToDestination_SelectedIndexChanged(object sender, EventArgs e)
         {
            if (!vrakjanjeCalendar.Enabled)
               tbVrakjanjeDatum.Text = "";
            else
                tbVrakjanjeDatum.Text = vrakjanjeCalendar.SelectedDate.ToShortDateString();
            if(tbVrakjanjeDatum.Text=="01.01.0001")
                 tbVrakjanjeDatum.Text = "";
        }

        /// <summary>
        /// Calls functions that update the grids with flights' information with corresponding data
        /// </summary>
        protected void btnSearchFlights_Click(object sender, EventArgs e)
        {
            if (tbTrgnuvanjeDatum.Text != "")
            {
                loadgvLetoviTrgnuvanje();
                //Clearing the date textbox and previous grid information
                //if the returning dates are not selected from calendar 
                if (!vrakjanjeCalendar.Enabled)
                {
                    tbVrakjanjeDatum.Text = "";
                    gvLetoviVrakjanje.DataSource = null;
                    gvLetoviVrakjanje.DataBind();
                }
                else
                {
                    tbVrakjanjeDatum.Text = vrakjanjeCalendar.SelectedDate.ToShortDateString();
                    loadgvLetoviVrakjanje();
                }
            } 
             //Show message if a starting date is not selected
            //Clearing the previous grid information
            else
            {
                lblError.Visible = true;
                lblError.Text = "Одберете датум на тргнување!";
                gvLetoviTrgnuvanje.DataSource = null;
                gvLetoviTrgnuvanje.DataBind();
            }
        }

        /// <summary>
        /// Update the grid with  information about one way flights
        /// </summary>
        private void loadgvLetoviTrgnuvanje()
        {
            int pocetnaId = Convert.ToInt32(ddFromDestination.SelectedValue);
            int krajnaId = Convert.ToInt32(ddToDestination.SelectedValue);
            String datumTrgnuvanje = tbTrgnuvanjeDatum.Text;
            String datumVrakjanje = tbVrakjanjeDatum.Text;
            int sumPassangers=Convert.ToInt32(ddlBrojVozrasni.SelectedValue)+Convert.ToInt32(ddlBrojDeca.SelectedValue)+Convert.ToInt32(ddlBrojBebe.SelectedValue);
            //Check if both destinations are seletected and a date
            if (pocetnaId != 0 && krajnaId != 0 && datumTrgnuvanje != "")
            {
                SqlConnection konekcija = new SqlConnection();
                konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

                string query = "SELECT destinacii.gradd + ',' + destinacii.aerodrom as KGRAD,l.IDL as IDL,let.gradd + ', ' +let.aerodrom as PGRAD,vremes,vremep,CONVERT(VARCHAR(10),cena*" + sumPassangers + ") +' '+ valuta as cena,let.datum as datumLet"
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
                    lblError.Visible = true;
                    lblError.Text = "EX3: "+ex.Message;
                }
                finally
                {
                    konekcija.Close();
                }
            }

        }

        /// <summary>
        /// Update the grid with  information about returning flights
        /// </summary>
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

                string query = "SELECT destinacii.gradd + ',' + destinacii.aerodrom as KGRAD,l.IDL as IDL,let.gradd + ', ' +let.aerodrom as PGRAD,vremes,vremep,CONVERT(VARCHAR(10),cena*" + sumPassangers + ")+' '+  valuta as cena,let.datum as datumLet"
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
                    lblError.Visible = true;
                    lblError.Text = "EX4: " + ex.Message;
                }
                finally
                {
                    konekcija.Close();
                }
            }

        }


        /// <summary>
        /// Stores the flights' information in Session and redirects to the next page to
        /// complete the reservation process
        /// </summary>
        protected void btnRezerviraj_Click(object sender, EventArgs e)
        {
            if (ViewState["trgnuvanjeLetID"] != null)
            {
                Session["trgnuvanjeLetID"] = (int)ViewState["trgnuvanjeLetID"];
                Session["brojVozrasni"] = Convert.ToInt32(ddlBrojVozrasni.SelectedValue);
                Session["brojDeca"] = Convert.ToInt32(ddlBrojDeca.SelectedValue);
                Session["brojBebinja"] = Convert.ToInt32(ddlBrojBebe.SelectedValue);
                Session["makeAreservation"] = true;
                //if a returning ticket is reserved
                if (ViewState["vrakjanjeLetID"] != null)
                {
                    Session["vrakjanjeLetID"] = (int)ViewState["vrakjanjeLetID"];
                }
                //Redirect user that is not loged in to the Login page
                if (String.IsNullOrEmpty(Session["user"] as string))
                {
                    Response.Redirect("~/Public/Login.aspx?", true);
                }
                else
                {   
                    //Check if the user has administrative privileges or is just a user
                    string userType = Session["userType"] as string;
                    if (userType == "admin")
                    {
                        Response.Redirect("~/Admin/MyProfile.aspx", true);
                    }
                    else
                    {
                        Response.Redirect("~/User/MakeAReservation.aspx", true);
                    }
                }
            }
            else
            {
                lblError.Visible = true;
                lblError.Text = "Одберете лет!";
            }
        }

        /// <summary>
        /// Stores the one way flight's ID in Session when the rezervation link is clicked in the grid
        /// </summary>
        protected void gvLetoviTrgnuvanje_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewState["trgnuvanjeLetID"] = gvLetoviTrgnuvanje.DataKeys[gvLetoviTrgnuvanje.SelectedIndex].Value;
        }

        /// <summary>
        /// Stores the return flight's ID in Session when the rezervation link is clicked in the grid
        /// </summary>
        protected void gvLetoviVrakjanje_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewState["vrakjanjeLetID"] = gvLetoviVrakjanje.DataKeys[gvLetoviVrakjanje.SelectedIndex].Value;
        }
        

    }
}