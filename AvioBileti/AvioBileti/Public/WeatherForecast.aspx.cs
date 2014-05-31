using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Xml;
using System.Data;
using System.Collections;
using System.Text;
using System.IO;

namespace AvioBileti.Public
{
    public partial class Information : System.Web.UI.Page
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!this.IsPostBack)
            {
                //Create a new global weather object
                globalWeather.GlobalWeather proxy = new globalWeather.GlobalWeather();
                //Create a new xml document object. We need xml implementation since the data is in xml format.
                XmlDocument xmlDoc = new XmlDocument();
                //Load all country/city names in to the xml document.
                xmlDoc.LoadXml(proxy.GetCitiesByCountry(""));
                //Query only country names and put them in to xml node list
                XmlNodeList xmlNodes = xmlDoc.GetElementsByTagName("Country");
                List<string> countryList = new List<string>();
                foreach (XmlNode node in xmlNodes)
                {
                    if (!countryList.Contains(node.InnerText))
                    {
                        //Loop through the country names and put them in to a list object
                        countryList.Add(node.InnerText);
                    }
                }
                countryList.Sort();
                //Bind the CountryDropDownList control.
                this.ddlDrzavi.DataSource = countryList;
                this.ddlDrzavi.DataBind();
                this.ddlDrzavi.SelectedIndex = 112;
                this.ddlGradovi.SelectedIndex = 1;
                this.ddlDrzavi_SelectedIndexChanged(sender, e);
            }
        }

        protected void btnProveriVreme_Click(object sender, EventArgs e)
        {
            Label1.Text = "";
            Label2.Text = "";
            if ((ddlDrzavi.SelectedIndex == -1) || (ddlGradovi.SelectedIndex == -1))
            {
                return;
            }
            string xmlResult = null;
            string url;
            //url = "http://www.webservicex.net/globalweather.asmx/GetWeather?CityName=" + "Skopje" + "&CountryName=" + "Macedonia" + "";
            url = "http://www.webservicex.net/globalweather.asmx/GetWeather?CityName=" + ddlGradovi.SelectedItem.Text + "&CountryName=" + ddlDrzavi.SelectedItem.Text + "";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader resStream = new StreamReader(response.GetResponseStream());
            XmlDocument doc = new XmlDocument();
            xmlResult = resStream.ReadToEnd();
            doc.LoadXml(xmlResult);
            try
            {
                XmlDocument xl = new XmlDocument();
                xl.LoadXml(doc.GetElementsByTagName("string").Item(0).InnerText);
                XmlNodeList xnList = xl.SelectNodes("CurrentWeather");
                foreach (XmlNode xn in xnList)
                {
                    Label1.Text = "Локација: " + xn["Location"].InnerText;
                    Label2.Text = "Време:" + xn["Time"].InnerText;
                    Label3.Text = "Температура: " + xn["Temperature"].InnerText;
                    Label4.Text = "Влажност на воздухот: " + xn["RelativeHumidity"].InnerText;
                    Label5.Text = xn["SkyConditions"].InnerText;
                    Label6.Text = "Притисок" + xn["Pressure"].InnerText;
                }
            }
            catch
            {
                Label1.Text = "City Name Not match with our site!";
                Label2.Text = "";
                return;
            }
        }

        protected void ddlDrzavi_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Create a new global weather object
            globalWeather.GlobalWeather proxy = new globalWeather.GlobalWeather();
            //Create a new xml document object. We need xml implementation since the data is in xml format.
            XmlDocument xmlDoc = new XmlDocument();
            //Load all country/city names in to the xml document.
            xmlDoc.LoadXml(proxy.GetCitiesByCountry(ddlDrzavi.SelectedItem.Text));
            //Query only country names and put them in to xml node list
            XmlNodeList xmlNodes = xmlDoc.GetElementsByTagName("City");
            List<string> countryList = new List<string>();
            foreach (XmlNode node in xmlNodes)
            {
                if (!countryList.Contains(node.InnerText))
                {
                    //Loop through the country names and put them in to a list object
                    countryList.Add(node.InnerText);
                }
            }
            countryList.Sort();
            //Bind the CountryDropDownList control.

            this.ddlGradovi.DataSource = countryList;
            this.ddlGradovi.DataBind();
        }
    }
}