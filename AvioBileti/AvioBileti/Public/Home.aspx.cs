using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace AvioBileti.Public
{
    public partial class Home : System.Web.UI.Page
    {
        /// <summary>
        /// Call a function to load flights and set the default value to the makeAReservation property
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
           if(!IsPostBack) 
               loadAllFlights();
           Session["makeAreservation"] = false;
        }


          /// <summary>
        /// Loads the grid with all flights from database
        /// </summary>
        protected void loadAllFlights()
        {
           
            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;
            string query = "select IDL, vremes, vremep, pd.gradd +' , '+pd.aerodrom as pojdovna,kd.gradd +' , '+ kd.aerodrom as krajna,CONVERT(VARCHAR(10),letovi.datum,104) as date,CONVERT(VARCHAR(10),letovi.cena) +' '+ valuta as price"
                         + " from letovi"
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
                gvLetovi.DataSource = ds;
                gvLetovi.DataBind();

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

          /// <summary>
         ///OPTION1: JUST redirect to SearchFlights
         ///OPTION2: SET 1 ADULT and redirect to MakeAreservation only for 1
         ///OPTION3: NOT RECOMDENDED - Adopt the dropdown lists in SearchFlights according to the flight
        ///                            chosen in this site
        /// </summary>
        protected void gvLetovi_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("~/Public/SearchFlights.aspx", true);

            /// Stores the flight id number if the user wants to make a reservation.
            /// If the user is not loged in he/she is redirected to the Login page
            /// and if otherwise, then he/she is redirected to the next page of the reservation making process
            /// 
            /* 
                if (String.IsNullOrEmpty(Session["user"] as string))
                {
                    Response.Redirect("~/Public/Login.aspx?", true);
                }
                else
                {   
                    //Check if the user has administrative privileges or is just a user
                    string userType = Session["userType"] as string;
                    Session["makeAreservation"] = true;
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
            */
        }

      }

    }



