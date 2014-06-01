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
                this.btnProveriVreme_Click(sender, e);
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
                    Label2.Text = xn["Location"].InnerText;
                    Label3.Text = xn["Time"].InnerText;
                    Label4.Text = xn["Temperature"].InnerText;
                    Label5.Text = xn["RelativeHumidity"].InnerText;                    
                    Label6.Text = xn["Pressure"].InnerText;

                    string cond = xn["SkyConditions"].InnerText;
                    if (cond.Equals(" mostly cloudy"))
                    {
                        weatherImage.ImageUrl = "~/Images/Weather/Status-weather-many-clouds-icon.png";
                        Label1.Text = "Облачно";
                    }
                    else if (cond.Contains("showers") || cond.Contains("rain"))
                    {
                        weatherImage.ImageUrl = "~/Images/Weather/Status-weather-showers-icon.png";
                        Label1.Text = "Врнежливо";
                    }
                    else if (cond.Contains("clear") || cond.Contains("sun"))
                    {
                        weatherImage.ImageUrl = "~/Images/Weather/Status-weather-clear-icon.png";
                        Label1.Text = "Сончево и ведро";
                    }
                    else if (cond.Contains("cloud"))
                    {
                        weatherImage.ImageUrl = "~/Images/Weather/Status-weather-clouds-icon.png";
                        Label1.Text = "Сончево со облачни периоди";
                    }
                }
            }
            catch
            {
                Label1.Text = "Не се пронајдени податоци за овој град!";
                Label2.Text = "";
                Label3.Text = "";
                Label4.Text = "";
                Label5.Text = "";
                Label6.Text = "";

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