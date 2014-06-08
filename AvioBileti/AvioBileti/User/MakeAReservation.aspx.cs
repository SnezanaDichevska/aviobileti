using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Collections;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace AvioBileti.User
{

    public partial class MakeAReservation : System.Web.UI.Page
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
                    Response.Redirect("~/Admin/MyProfile.aspx", true);
                }
               
            }
            Session["makeAreservation"] = false;
        }


        /// <summary>
        /// For the controls to be found when data needs to be retrived from them,
        /// they need to be generated on every page initialization
        /// </summary>
        public void Page_Init(object sender, EventArgs e)
        {
             loadReservationTable();
        }

        /// <summary>
        /// Generate controls for the passangers' reservation details 
        /// </summary>
        protected void loadReservationTable()
        {
            int brVozrasni = (int)Session["brojVozrasni"];
            int brDeca = (int)Session["brojDeca"];
            int brBebinja = (int)Session["brojBebinja"];

            PlaceHolder1.Controls.Clear();
            int vkupnoPatnici = (brVozrasni + brDeca + brBebinja);

            Table tbl = new Table();
            tbl.BackColor = Color.Coral;
            tbl.CellSpacing = 30;
            tbl.CellPadding = 25;
            PlaceHolder1.Controls.Add(tbl);
            for (int i = 0; i < vkupnoPatnici; i++)
            {
                //CONTROLS for passangers' data
                TableRow trEmpty = new TableRow();
                TableCell tcEmpty = new TableCell();
                trEmpty.Height = 25;
                trEmpty.Cells.Add(tcEmpty);
                tbl.Rows.Add(trEmpty);

                TableRow tr0 = new TableRow();
                tr0.Height = 25;
                tr0.Width = 200;
                TableCell tc0 = new TableCell();
                Label lbluser = new Label();
                lbluser.Text = "Патник " + (i + 1) + " :";
                lbluser.Font.Bold = true;
                tc0.Controls.Add(lbluser);
                tr0.Cells.Add(tc0);
                tbl.Rows.Add(tr0);

                //1 ROW labels
                TableRow tr = new TableRow();
                tr.Height = 25;
                tr.Width = 200;
                TableCell tcLabels1 = new TableCell();
                Label lblime = new Label();
                lblime.Text = "Име:";
                tcLabels1.Controls.Add(lblime);


                TableCell tcLabels2 = new TableCell();
                Label lblPrezime = new Label();
                lblPrezime.Text = "Презиме:";
                tcLabels2.Controls.Add(lblPrezime);

                TableCell tcLabels3 = new TableCell();
                tr.Cells.Add(tcLabels1);
                tr.Cells.Add(new TableCell());
                tr.Cells.Add(tcLabels2);
                tr.Cells.Add(new TableCell());
                tr.Cells.Add(tcLabels3);
                tbl.Rows.Add(tr);

                //2 ROW
                TableRow tr1 = new TableRow();
                tr1.Height = 25;

                TableCell tcTB1 = new TableCell(); TableCell tcimeVal = new TableCell();
                TextBox tbime = new TextBox();
                tbime.ID = "ime_" + i;
                Label valIme = new Label(); valIme.ForeColor = Color.Red; valIme.Text = " Внесете Име!"; valIme.Visible = false;
                valIme.ID = "valIme_" + i;
                tcTB1.Controls.Add(tbime);
                tcimeVal.Controls.Add(valIme);

                TableCell tcTB2 = new TableCell(); TableCell tcprezimeVal = new TableCell();
                TextBox tbPrezime = new TextBox();
                tbPrezime.ID = "prezime_" + i;
                Label valPrezime = new Label(); valPrezime.ForeColor = Color.Red; valPrezime.Text = " Внесете Презиме!"; valPrezime.Visible = false;
                valPrezime.ID = "valPrezime_" + i;
                tcTB2.Controls.Add(tbPrezime);
                tcprezimeVal.Controls.Add(valPrezime);

                TableCell tcTB3 = new TableCell();
                DropDownList ddlMobilnost = new DropDownList();
                ddlMobilnost.ID = "mobilnost_" + i;
                ListItem l1 = new ListItem("нема", "4", true);
                ListItem l2 = new ListItem("слаб слух", "1");
                ListItem l3 = new ListItem("нарушен вид", "2");
                ListItem l4 = new ListItem("инвалидска количка", "3");
                ddlMobilnost.Items.Add(l1);
                ddlMobilnost.Items.Add(l2);
                ddlMobilnost.Items.Add(l3);
                ddlMobilnost.Items.Add(l4);
                tcTB3.Controls.Add(ddlMobilnost);

                tr1.Cells.Add(tcTB1);
                tr1.Cells.Add(tcimeVal);
                tr1.Cells.Add(tcTB2);
                tr1.Cells.Add(tcprezimeVal);
                tr1.Cells.Add(tcTB3);

                tbl.Rows.Add(tr1);

                //3 ROW 
                TableRow tr2 = new TableRow();
                tr2.Height = 25;

                TableCell tcLabels21 = new TableCell();
                Label lblmalbagaz = new Label();
                lblmalbagaz.Text = "Одбери тип на мал багаж:";
                tcLabels21.Controls.Add(lblmalbagaz);

                TableCell tcLabels22 = new TableCell();
                Label lblgolembagaz = new Label();
                lblgolembagaz.Text = "Одбери тип на голем багаж:";
                tcLabels22.Controls.Add(lblgolembagaz);

                TableCell tcLabels23 = new TableCell();
                Label lblcheckin = new Label();
                lblcheckin.Text = "Одбери начин на пријавување:";
                tcLabels23.Controls.Add(lblcheckin);

                tr2.Cells.Add(tcLabels21);
                tr2.Cells.Add(new TableCell());
                tr2.Cells.Add(tcLabels22);
                tr2.Cells.Add(new TableCell());
                tr2.Cells.Add(tcLabels23);

                tbl.Rows.Add(tr2);

                //4 ROW
                TableRow tr3 = new TableRow();
                tr3.Height = 25;

                TableCell tc1 = new TableCell();
                TableCell tc2 = new TableCell();
                TableCell tc3 = new TableCell();

                DropDownList ddlMalbagaz = new DropDownList();
                ddlMalbagaz.ID = "malbagaz_" + i;
                ListItem i1 = new ListItem("Мала кабинска торба", "1", true);
                ListItem i2 = new ListItem("Голема кабинска торба", "2");

                ddlMalbagaz.Items.Add(i1);
                ddlMalbagaz.Items.Add(i2);
                tc1.Controls.Add(ddlMalbagaz);

                DropDownList ddlGolembagaz = new DropDownList();
                ddlGolembagaz.ID = "golembagaz_" + i;
                ListItem it1 = new ListItem("1 парче", "1");
                ListItem it2 = new ListItem("2 парчиња", "4");
                ListItem it3 = new ListItem("3 парчиња", "5");
                ListItem it4 = new ListItem("нема", "6", true);

                ddlGolembagaz.Items.Add(it1);
                ddlGolembagaz.Items.Add(it2);
                ddlGolembagaz.Items.Add(it3);
                ddlGolembagaz.Items.Add(it4);
                tc2.Controls.Add(ddlGolembagaz);

                DropDownList ddlPrijavuvanje = new DropDownList();
                ddlPrijavuvanje.ID = "prijavuvanje_" + i;
                ListItem item1 = new ListItem("Аеродром", "1", true);
                ListItem item2 = new ListItem("Веб", "2");

                ddlPrijavuvanje.Items.Add(item1);
                ddlPrijavuvanje.Items.Add(item2);

                tc3.Controls.Add(ddlPrijavuvanje);
                tr3.Cells.Add(tc1);
                tr3.Cells.Add(new TableCell());
                tr3.Cells.Add(tc2);
                tr3.Cells.Add(new TableCell());
                tr3.Cells.Add(tc3);

                tbl.Rows.Add(tr3);
            }
            //LAST ROW - SUBMIT BUTTON
            TableRow trEmpty1 = new TableRow();
            TableCell tcEmpty1 = new TableCell();
            trEmpty1.Height = 25;

            trEmpty1.Cells.Add(tcEmpty1);
            tbl.Rows.Add(trEmpty1);

            TableRow tr4 = new TableRow();
            tr4.Height = 25;

            TableCell tcSubmit = new TableCell();
            Button submit = new Button();
            submit.Text = "Продолжи";
            submit.Click += new EventHandler(this.submit_OnClientClick);
            tcSubmit.Controls.Add(submit);
            tr4.Cells.Add(tcSubmit);
            tbl.Rows.Add(tr4);
        }


        /// <summary>
        /// Validates and Stores the reservation details in a Session and redirects to the next 
        /// site in the registration process
        /// </summary>
        protected void submit_OnClientClick(object sender, EventArgs e)
        {
            //Make a reservation
            Boolean validated = false;
            int brVozrasni = (int)Session["brojVozrasni"];
            int brDeca = (int)Session["brojDeca"];
            int brBebinja = (int)Session["brojBebinja"];

            int vkupnoPatnici = (brVozrasni + brDeca + brBebinja);
            Dictionary<String, ArrayList> patnici = new Dictionary<String, ArrayList>();
            for (int i = 0; i < vkupnoPatnici; i++)
            {
                TextBox ime = (TextBox)PlaceHolder1.FindControl("ime_" + i);
                TextBox prezime = (TextBox)PlaceHolder1.FindControl("prezime_" + i);
                DropDownList ddlMobilnost = (DropDownList)PlaceHolder1.FindControl("mobilnost_" + i);
                DropDownList ddlPrijavuvanje = (DropDownList)PlaceHolder1.FindControl("prijavuvanje_" + i);
                DropDownList ddlmalbagaz = (DropDownList)PlaceHolder1.FindControl("malbagaz_" + i);
                DropDownList ddlgolembagaz = (DropDownList)PlaceHolder1.FindControl("golembagaz_" + i);

                //validation labels
                Label valIme = (Label)PlaceHolder1.FindControl("valIme_" + i);
                Label valPrezime = (Label)PlaceHolder1.FindControl("valPrezime_" + i);

                if (ime.Text == "")
                {
                    valIme.Visible = true;
                    validated = false;
                }
                if (prezime.Text == "")
                {
                    valPrezime.Visible = true;
                    validated = false;
                }
                if (ime.Text != "" && prezime.Text != "")
                {
                    validated = true; valIme.Visible = false;
                    ArrayList podatoci = new ArrayList();
                    podatoci.Add(ime.Text); podatoci.Add(prezime.Text);
                    podatoci.Add(ddlMobilnost); podatoci.Add(ddlPrijavuvanje);
                    podatoci.Add(ddlmalbagaz); podatoci.Add(ddlgolembagaz);
                    patnici.Add("patnik_" + i, podatoci);
                }
            }
            if (validated)
            {
                Session["patnici"] = patnici;
                Response.Redirect("~/User/ShowReservationInAProcess.aspx");
            }


        }


       

       

      
    }
}