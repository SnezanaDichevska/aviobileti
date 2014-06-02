using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

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
                string queryTrgnuvanjeCalendar,queryVrakjanjeCalendar;
                //ako nema selektirano krajna daj mu datumi pocetni za pojdovna destinacija
                if (ddToDestination.SelectedValue == "")
                {
                    queryTrgnuvanjeCalendar = "SELECT datum "
                    + " FROM letovi "
                    + " WHERE pojdovnaDestID=" + ddFromDestination.SelectedValue +  ";";

                    queryVrakjanjeCalendar = "SELECT datum "
                    + " FROM letovi "
                    + " WHERE krajnaDestID=" + ddFromDestination.SelectedValue + ";";

                } 
                    // gi ima 2te destinacii selektirano
                else {
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
                    // Execute Reader  
                    SqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
                   
                    // Getting Collection of Selected Dates of Calendar control  
                    SelectedDatesCollection datesCollection = trgnuvanjeCalendar.SelectedDates;
                    
                    // Clear all the previously stored Dates  
                    datesCollection.Clear();
                   
                    // Here we have set the Visible month of the Calendar control  
                    // to 1st September 2009  
                    trgnuvanjeCalendar.VisibleDate = DateTime.Today;                    
                    // loop over the Sql DataReader to read the values retrieved from  
                    // the SQL Database  
                    while (mySqlDataReader.Read())
                    {
                        // integer variable to get the Day number of the month  
                        // from the publish date value of posting  
                        int day = mySqlDataReader.GetSqlDateTime(0).Value.Day;

                        // add the date value to the SelectedDatesCollection of the Calendar control  
                        // to display the selected dates  
                        datesCollection.Add(mySqlDataReader.GetSqlDateTime(0).Value);
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
                    // integer variable to get the Day number of the month  
                    // from the publish date value of posting  
                    int day = mySqlDataReader2.GetSqlDateTime(0).Value.Day;

                    // add the date value to the SelectedDatesCollection of the Calendar control  
                    // to display the selected dates  
                    datesCollection2.Add(mySqlDataReader2.GetSqlDateTime(0).Value);
                }
                mySqlDataReader2.Close();



               
            }
            catch (Exception ex)
                {
                    lblAccessMessage.Visible = true;
                    lblAccessMessage.Text =ex.Message;
            }
                finally
               {
                    mySqlConnection.Close();
                }
        }

        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            // Check if the month is September or not  
            // This is required if the User is allowed to navigate the months  
            if (e.Day.IsOtherMonth)
            {
                // clear the modified controls or items from the date cell  
                e.Cell.Controls.Clear();
            }
            else
            {
                // create a label control dynamically  
                Label lbl = new Label();

              
                    lbl.Text = "<br />";
                    lbl.Text += "f";
                    e.Cell.Controls.Add(lbl);
                
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
            DataSet ds= new DataSet();

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
            tbFrom.Text = trgnuvanjeCalendar.SelectedDate.ToShortDateString();
        }

        protected void btnCal1_Click(object sender, ImageClickEventArgs e)
        {
            trgnuvanjeCalendar.Enabled = !trgnuvanjeCalendar.Enabled;
            trgnuvanjeCalendar.Visible = !trgnuvanjeCalendar.Visible;
        }

        protected void btnCal2_Click(object sender, ImageClickEventArgs e)
        {
            vrakjanjeCalendar.Enabled = !vrakjanjeCalendar.Enabled;
            vrakjanjeCalendar.Visible = !vrakjanjeCalendar.Visible;
        }

        protected void vrakjanjeCalendar_SelectionChanged(object sender, EventArgs e)
        {
            tbTo.Text = vrakjanjeCalendar.SelectedDate.ToShortDateString();
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

        }
    }
}