using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Drawing;

namespace AvioBileti.User
{   
    public partial class ShowReservationInAProcess : System.Web.UI.Page
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
                string userType = Session["userType"] as string;
                if (userType == "admin")
                {
                    Response.Redirect("~/Admin/AdminHome.aspx", true);
                }
               
            }
        }

        /// <summary>
        /// For the button control event to fire,
        /// it needs to be generated on every page initialization
        /// </summary>
        public void Page_Init(object sender, EventArgs e)
        {
            showReservation();
        }

        /// <summary>
        /// Generate controls to preview the data from the current reservation stored in Session
        /// </summary>
        protected void showReservation()
        {
            Dictionary<String, ArrayList> patnici = (Dictionary<String, ArrayList>)Session["patnici"];
            int brVozrasni = (int)Session["brojVozrasni"];
            int brDeca = (int)Session["brojDeca"];
            int brBebinja = (int)Session["brojBebinja"];

            PlaceHolder1.Controls.Clear();
            int vkupnoPatnici = (brVozrasni + brDeca + brBebinja);

            Table tbl = new Table();
            // tbl.BackColor = Color.LightBlue;
            tbl.CellSpacing = 30;
            tbl.CellPadding = 25;
            //tbl.BorderWidth = 5;


            PlaceHolder1.Controls.Add(tbl);

            for (int i = 0; i < vkupnoPatnici; i++)
            {
                ArrayList data = patnici["patnik_" + i];
                String ime = (String)data[0];
                String prezime = (String)data[1];
                DropDownList ddlMobilnost = (DropDownList)data[2];
                DropDownList ddlPrijavuvanje = (DropDownList)data[3];
                DropDownList ddlmalbagaz = (DropDownList)data[4];
                DropDownList ddlgolembagaz = (DropDownList)data[5];


                //empty row  - columnspan and cellspasing dont work!!
                TableRow trEmpty = new TableRow();
                TableCell tcEmpty = new TableCell();
                trEmpty.Height = 25;
                tcEmpty.ColumnSpan = 10;
                trEmpty.Cells.Add(tcEmpty); trEmpty.Cells.Add(new TableCell());
                tbl.Rows.Add(trEmpty);


                TableRow tr0 = new TableRow();
                tr0.Height = 25;
                tr0.HorizontalAlign = HorizontalAlign.Left;
                TableCell tc0 = new TableCell();
                tc0.ColumnSpan = 10;
                Label lbluser = new Label();
                lbluser.Font.Bold = true; lbluser.ForeColor = Color.Blue;
                lbluser.Text = "Патник " + (i + 1) + " :";
                tc0.Controls.Add(lbluser);
                tr0.Cells.Add(tc0); tr0.Cells.Add(new TableCell());
                tbl.Rows.Add(tr0);

                //ROWS filled with data about passangers
                TableRow tr1 = new TableRow();
                tr1.Height = 25;
                tr1.HorizontalAlign = HorizontalAlign.Left;

                TableCell tcLabels1 = new TableCell();
                tcLabels1.ColumnSpan = 10;
                Label lblime = new Label();
                TableCell tcLabels11 = new TableCell();
                tcLabels11.ColumnSpan = 10;
                Label lblime1 = new Label();
                lblime.Text = "Име:   "; lblime.Font.Bold = true;
                lblime1.Text = ime;
                tcLabels1.Controls.Add(lblime);
                tcLabels11.Controls.Add(lblime1);
                tr1.Cells.Add(tcLabels1);
                tr1.Cells.Add(tcLabels11);

                TableRow tr2 = new TableRow();
                TableCell tcLabels2 = new TableCell();
                TableCell tcLabels21 = new TableCell();
                tcLabels2.ColumnSpan = 10;
                tcLabels21.ColumnSpan = 10;
                tr2.HorizontalAlign = HorizontalAlign.Left;
                Label lblPrezime = new Label();
                Label lblPrezime1 = new Label();
                lblPrezime.Text = "Презиме:   "; lblPrezime.Font.Bold = true;
                lblPrezime1.Text = prezime;
                tcLabels2.Controls.Add(lblPrezime);
                tcLabels21.Controls.Add(lblPrezime1);
                tr2.Cells.Add(tcLabels2);
                tr2.Cells.Add(tcLabels21);

                TableRow tr3 = new TableRow();
                TableCell tcLabels3 = new TableCell();
                TableCell tcLabels31 = new TableCell();
                tcLabels3.ColumnSpan = 10;
                tcLabels31.ColumnSpan = 10;
                tr3.HorizontalAlign = HorizontalAlign.Left;
                Label lblmob = new Label();
                Label lblmob1 = new Label();
                lblmob.Text = "Моблиност:  "; lblmob.Font.Bold = true;
                lblmob1.Text = ddlMobilnost.SelectedItem.Text;
                tcLabels3.Controls.Add(lblmob);
                tcLabels31.Controls.Add(lblmob1);
                tr3.Cells.Add(tcLabels3);
                tr3.Cells.Add(tcLabels31);

                TableRow tr4 = new TableRow();
                TableCell tcLabels4 = new TableCell();
                TableCell tcLabels41 = new TableCell();
                tcLabels4.ColumnSpan = 10;
                tcLabels41.ColumnSpan = 10;
                tr4.HorizontalAlign = HorizontalAlign.Left;
                Label lblprijavuvanje = new Label();
                Label lblprijavuvanje1 = new Label();
                lblprijavuvanje.Text = "Пријавување:  "; lblprijavuvanje.Font.Bold = true;
                lblprijavuvanje1.Text = ddlPrijavuvanje.SelectedItem.Text;
                tcLabels4.Controls.Add(lblprijavuvanje);
                tcLabels41.Controls.Add(lblprijavuvanje1);
                tr4.Cells.Add(tcLabels4);
                tr4.Cells.Add(tcLabels41);

                TableRow tr5 = new TableRow();
                tr5.HorizontalAlign = HorizontalAlign.Left;
                TableCell tcLabels5 = new TableCell();
                TableCell tcLabels51 = new TableCell();
                tcLabels5.ColumnSpan = 10;
                tcLabels51.ColumnSpan = 10;
                Label lblmalbagaz = new Label();
                Label lblmalbagaz1 = new Label();
                lblmalbagaz.Text = "Мал багаж:  "; lblmalbagaz.Font.Bold = true;
                lblmalbagaz1.Text = ddlmalbagaz.SelectedItem.Text;
                tcLabels5.Controls.Add(lblmalbagaz);
                tcLabels51.Controls.Add(lblmalbagaz1);
                tr5.Cells.Add(tcLabels5);
                tr5.Cells.Add(tcLabels51);

                TableRow tr6 = new TableRow();
                TableCell tcLabels6 = new TableCell();
                TableCell tcLabels61 = new TableCell();
                tcLabels6.ColumnSpan = 10;
                tcLabels61.ColumnSpan = 10;
                tr6.HorizontalAlign = HorizontalAlign.Left;
                Label lblgolembagaz = new Label();
                Label lblgolembagaz1 = new Label();
                lblgolembagaz.Text = "Голем багаж:  "; lblgolembagaz.Font.Bold = true;
                lblgolembagaz1.Text = ddlgolembagaz.SelectedItem.Text;
                tcLabels6.Controls.Add(lblgolembagaz);
                tcLabels61.Controls.Add(lblgolembagaz1);
                tr6.Cells.Add(tcLabels6);
                tr6.Cells.Add(tcLabels61);


                tbl.Rows.Add(tr1);
                tbl.Rows.Add(tr2);
                tbl.Rows.Add(tr3);
                tbl.Rows.Add(tr4);
                tbl.Rows.Add(tr5);
                tbl.Rows.Add(tr6);



            }
            //empty row 
            TableRow trEmpty1 = new TableRow();
            TableCell tcEmpty1 = new TableCell();
            trEmpty1.Height = 25;
            trEmpty1.Cells.Add(tcEmpty1); trEmpty1.Cells.Add(new TableCell());
            tbl.Rows.Add(trEmpty1);

            TableRow tr = new TableRow();
            tr.Height = 25;
            TableCell tcSubmit = new TableCell();
            tcSubmit.ColumnSpan = 10;
            Button submit = new Button();
            submit.Text = "Продолжи";
            submit.Click += new EventHandler(this.submit_OnClientClick1);
            tcSubmit.Controls.Add(submit);
            tr.Cells.Add(tcSubmit); tr.Cells.Add(new TableCell());
            tbl.Rows.Add(tr);

            //empty row
            TableRow trEmpty2 = new TableRow();
            TableCell tcEmpty2 = new TableCell();
            tcEmpty2.ColumnSpan = 10;
            trEmpty2.Height = 25;
            trEmpty2.Cells.Add(tcEmpty2); trEmpty2.Cells.Add(new TableCell());
            tbl.Rows.Add(trEmpty2);

        }

        /// <summary>
        /// Call a function that will insert the data into database
        /// </summary>
        protected void submit_OnClientClick1(object sender, EventArgs e)
        {
            insertData();
        }

        /// <summary>
        /// Insert data from the current reservation controls in database
        /// </summary>
        void insertData()
        {
            PlaceHolder1.Controls.Clear();
            Dictionary<String, ArrayList> patnici = (Dictionary<String, ArrayList>)Session["patnici"];
            int brVozrasni = (int)Session["brojVozrasni"];
            int brDeca = (int)Session["brojDeca"];
            int brBebinja = (int)Session["brojBebinja"];
            int vkupnoPatnici = (brVozrasni + brDeca + brBebinja);
            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;
            int id = (int)Session["userID"];
            int trgnuvanjeID=(int)Session["trgnuvanjeLetID"];
            int vrakjanjeID=0;
            if(Session["vrakjanjeLetID"]!=null)
                 vrakjanjeID = (int)Session["vrakjanjeLetID"];

            //Reduce available seats in database
            string query1 = "UPDATE  dostapnostNaLetovi  SET slobodniMesta=slobodniMesta-"+vkupnoPatnici
                            +"  WHERE  letID="+trgnuvanjeID+ ";";
            SqlCommand command = new SqlCommand(query1, konekcija);

            try
            {
                konekcija.Open();
                command.ExecuteNonQuery();
              
            }
            catch (Exception ex)
            {
                PlaceHolder1.Controls.Clear();
                Label lblError = new Label();
                lblError.Text = ex.Message;
                PlaceHolder1.Controls.Add(lblError);
            }
            finally
            {
                konekcija.Close();
            }
            //Reduce the number of seats on the return flight
            if (Session["vrakjanjeLetID"] != null)
            {
                string q = "UPDATE  dostapnostNaLetovi  SET slobodniMesta=slobodniMesta-" + vkupnoPatnici
                                           + "  WHERE  letID=" + vrakjanjeID + ";";
                SqlCommand command1 = new SqlCommand(q, konekcija);

                try
                {
                    konekcija.Open();
                    command1.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    PlaceHolder1.Controls.Clear();
                    Label lblError = new Label();
                    lblError.Text = ex.Message;
                    PlaceHolder1.Controls.Add(lblError);
                }
                finally
                {
                    konekcija.Close();
                }

            }



            for (int i = 0; i < vkupnoPatnici; i++)
            {
                ArrayList data = patnici["patnik_" + i];
                String ime = (String)data[0];
                String prezime = (String)data[1];
                DropDownList ddlMobilnost = (DropDownList)data[2];
                DropDownList ddlPrijavuvanje = (DropDownList)data[3];
                DropDownList ddlmalbagaz = (DropDownList)data[4];
                DropDownList ddlgolembagaz = (DropDownList)data[5];
                int letid = (int)Session["trgnuvanjeLetID"];

                //Make a reservation
                string query = "INSERT INTO  bileti (korisnikID,ime,prezime,tipMalBagazID,tipGolemBagazID,tipPosebniPotrebiID,tipCheckInID,IDL)"
                               + " VALUES(" + id + ",'" + ime + "','" + prezime + "'," + ddlmalbagaz.SelectedValue + "," + ddlgolembagaz.SelectedValue + "," + ddlMobilnost.SelectedValue + "," + ddlPrijavuvanje.SelectedValue + "," + letid + ");";
                SqlCommand komanda = new SqlCommand(query, konekcija);

                try
                {
                    konekcija.Open();
                    komanda.ExecuteNonQuery();

                    Label lblError = new Label();
                    lblError.Font.Bold = true;
                    lblError.Text = "Успешно резервиравте билети!";
                    PlaceHolder1.Controls.Add(lblError);
                }
                catch (Exception ex)
                {
                    PlaceHolder1.Controls.Clear();
                    Label lblError = new Label();
                    lblError.Text = ex.Message;
                    PlaceHolder1.Controls.Add(lblError);
                }
                finally
                {
                    konekcija.Close();
                }

                //insert data if a return ticket is also selected
                if (ViewState["vrakjanjeLetID"] != null)
                {
                    letid = (int)Session["vrakjanjeLetID"];
                    query = "INSERT INTO bileti (korisnikID,ime,prezime,tipMalBagazID,tipGolemBagazID,tipPosebniPotrebiID,tipCheckInID,IDL) "
                             + " VALUES(" + id + ",'" + ime + "','" + prezime + "'," + ddlmalbagaz.SelectedValue + "," + ddlgolembagaz.SelectedValue + "," + ddlMobilnost.SelectedValue + "," + ddlPrijavuvanje.SelectedValue + "," + letid + ");";
                    SqlCommand komanda1 = new SqlCommand(query, konekcija);

                    try
                    {
                        konekcija.Open();
                        komanda1.ExecuteNonQuery();
                        PlaceHolder1.Controls.Clear();
                        Label lblError = new Label();
                        lblError.Font.Bold = true;
                        //lblError.Text = "Успешно резервиравте билети!";
                        PlaceHolder1.Controls.Add(lblError);

                    }
                    catch (Exception ex)
                    {
                        PlaceHolder1.Controls.Clear();
                        Label lblError = new Label();
                        lblError.Font.Bold = true;
                        lblError.Text = ex.Message;
                        PlaceHolder1.Controls.Add(lblError);
                    }
                    finally
                    {
                        konekcija.Close();
                    }
                }


            }
        }
    }
}