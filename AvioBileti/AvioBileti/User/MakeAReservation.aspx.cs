using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace AvioBileti.User
{
    
    public partial class MakeAReservation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(Session["user"] as string))
            {
                Response.Redirect("~/Public/SearchFlights.aspx?access=no", true);
            }
            else
            {
                string userType = Session["userType"] as string;
                if (userType == "admin")
                {
                    Response.Redirect("~/Admin/MyProfile.aspx", true);
                }
                else
                {
                    if (!IsPostBack)
                    {
                        loadReservationTable();
                    }
                }
            }
        }
       

        protected void loadReservationTable()
        {
            int brVozrasni = (int)Session["brojVozrasni"];
            int brDeca=(int)Session["brojDeca"];
            int brBebinja = (int)Session["brojBebinja"];
           
            PlaceHolder1.Controls.Clear();           
            int vkupnoPatnici = (brVozrasni + brDeca + brBebinja) ;
         
            Table tbl = new Table();
            tbl.BackColor = Color.FloralWhite;
            tbl.CellSpacing =30;
            tbl.CellPadding = 25;
            PlaceHolder1.Controls.Add(tbl);
           for (int i = 0; i < vkupnoPatnici; i++)
            {
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
                lbluser.Text = "Патник "+(i+1) +" :";
                tc0.Controls.Add(lbluser);
                tr0.Cells.Add(tc0);
                tbl.Rows.Add(tr0);

                //1 ROW labels ime,Prezime
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
                tr.Cells.Add(tcLabels2);
                tr.Cells.Add(tcLabels3);

                tbl.Rows.Add(tr);

                //2ROW
                TableRow tr1 = new TableRow();
                tr1.Height = 25;
                tr1.Width = 200;
              
                TableCell tcTB1 = new TableCell();
                TextBox tbime = new TextBox();
                tbime.ID = "ime_" + i;
                tcTB1.Controls.Add(tbime);

                TableCell tcTB2= new TableCell();
                TextBox tbPrezime = new TextBox();
                tbPrezime.ID = "prezime_" + i;
                tcTB2.Controls.Add(tbPrezime);

                TableCell tcTB3 = new TableCell();
                DropDownList ddlMobilnost = new DropDownList();
                ddlMobilnost.ID="mobilnost_"+i;
                ListItem l1 = new ListItem("нема", "4",true);
                ListItem l2 = new ListItem("слаб слух", "1");
                ListItem l3 = new ListItem("нарушен вид", "2");
                ListItem l4 = new ListItem("инвалидска количка", "3");
                ddlMobilnost.Items.Add(l1);
                ddlMobilnost.Items.Add(l2);
                ddlMobilnost.Items.Add(l3);
                ddlMobilnost.Items.Add(l4);
                tcTB3.Controls.Add(ddlMobilnost);

                tr1.Cells.Add(tcTB1);
                tr1.Cells.Add(tcTB2);
                tr1.Cells.Add(tcTB3);

                tbl.Rows.Add(tr1);

                //3 ROW 
                TableRow tr2 = new TableRow();
                tr2.Height = 25;
                tr2.Width = 200;
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
                tr2.Cells.Add(tcLabels22);
                tr2.Cells.Add(tcLabels23);

                tbl.Rows.Add(tr2);

                //4 ROW
                TableRow tr3 = new TableRow();
                tr3.Height = 25;
                tr3.Width = 200;
                TableCell tc1 = new TableCell();
                TableCell tc2 = new TableCell();
                TableCell tc3 = new TableCell();

                DropDownList ddlMalbagaz = new DropDownList();
                ddlMalbagaz.ID="malbagaz_" + i;
                ListItem i1 = new ListItem("Мала кабинска торба", "1", true);
                ListItem i2 = new ListItem("Голема кабинска торба", "2");

                ddlMalbagaz.Items.Add(i1);
                ddlMalbagaz.Items.Add(i2);
                tc1.Controls.Add(ddlMalbagaz);

                DropDownList ddlGolembagaz = new DropDownList();
                ddlGolembagaz.ID = "golembagaz_" + i;
                ListItem it1 = new ListItem("1 парче", "1", true);
                ListItem it2 = new ListItem("2 парчиња", "2");
                ListItem it3 = new ListItem("3 парчиња", "3");
                ListItem it4 = new ListItem("4 парчиња", "4");

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
                tr3.Cells.Add(tc2);
                tr3.Cells.Add(tc3);

                tbl.Rows.Add(tr3);
            }
            //LAST ROW - SUBMIT
            
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
              submit.OnClientClick += new EventHandler(this.submit_OnClientClick);
              tcSubmit.Controls.Add(submit);
              tr4.Cells.Add(tcSubmit);
              tbl.Rows.Add(tr4);
        }

        protected void submit_OnClientClick(object sender, EventArgs e)
        {
          //Make a reservation
            //(TextBox)FindControl("ime_");
            //(TextBox)FindControl("prezime_");
            //(DropDownList)FindControl("mobilnost_");
            //(DropDownList)FindControl("prijavuvanje_");
            //(DropDownList)FindControl("malbagaz_");
            //(DropDownList)FindControl("golembagaz_");
        }
    }
}