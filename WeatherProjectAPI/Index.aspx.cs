using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.WebRequestMethods;

namespace WeatherProjectAPI
{
    public partial class Index : System.Web.UI.Page
    {
        
        public double UkjentLigning(double a, double b)
        {
            double x = (a - b);
            return x;
        }
        public void ReverseFileContents(string filePath)
        {
            // Leser all tekst fra filen
            string text = System.IO.File.ReadAllText(filePath);

            // konverterer tekst til array og reverserer den
            char[] charArray = text.ToCharArray();
            Array.Reverse(charArray);

            // konverterer den reverserte stringen til array
            string reversedText = new string(charArray);

            // skriv den reverserte teksten tilbake i filen
            System.IO.File.WriteAllText(filePath, reversedText);
        }
        public class WeatherData
        {
            public double Temperature { get; set; }
            public double Wind { get; set; }
            public double WindDirection { get; set; }
        }
        public WeatherData GetWeatherData()
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://api.met.no/weatherapi/nowcast/2.0/complete?lat=59.9333&lon=10.7166");

            try
            {
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "GET";
                httpWebRequest.UserAgent = "bolle";
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    JObject jObj = JObject.Parse(result);
                    JToken data = jObj.SelectToken("properties.timeseries[0].data.instant.details");

                    var weatherData = new WeatherData
                    {
                        Temperature = data.Value<double>("air_temperature"),
                        Wind = data.Value<double>("wind_speed"),
                        WindDirection = data.Value<double>("wind_from_direction")
                    };

                    return weatherData;
                }
            }
            catch (Exception ex)
            {
                // Handle exception here
            }

            return null;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            var weatherData = GetWeatherData();

            Labelukjentligning.Text = UkjentLigning(12, 2).ToString();

            if (weatherData != null)
            {
                LabelTemp.Text = weatherData.Temperature.ToString();
                LabelWind.Text = weatherData.Wind.ToString();
                LabelWindDirection.Text = weatherData.WindDirection.ToString();
            }

        }
        public double GetTemp()//denne har int, så vil da kunne returnere et heltall. 
        {
            //http://jsonviewer.stack.hu/
            //https://peterdaugaardrasmussen.com/2022/01/18/how-to-get-a-property-from-json-using-selecttoken/
            //create the httpwebrequest
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://api.met.no/weatherapi/nowcast/2.0/complete?lat=59.9333&lon=10.7166");

            //the usual stuff. run the request, parse your json. with error handling
            try
            {
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "GET";
                httpWebRequest.UserAgent = "bolle";
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    JObject jObj = JObject.Parse(result);
                    JToken data = jObj.SelectToken("properties.timeseries[0].data.instant.details");

                    double temp = data.Value<double>("air_temperature");//key name står i " " - getting key.value
                    return temp;
                }
                return 0;//returner ønsket verdi
            }
            catch { Exception ex; }
            return 0;//returner ønsket verdi
        }
        public double GetWind()//denne har int, så vil da kunne returnere et heltall. 
        {
            //http://jsonviewer.stack.hu/
            //https://peterdaugaardrasmussen.com/2022/01/18/how-to-get-a-property-from-json-using-selecttoken/
            //create the httpwebrequest
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://api.met.no/weatherapi/nowcast/2.0/complete?lat=59.9333&lon=10.7166");

            //the usual stuff. run the request, parse your json. with error handling
            try
            {
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "GET";
                httpWebRequest.UserAgent = "bolle";
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    JObject jObj = JObject.Parse(result);
                    JToken data = jObj.SelectToken("properties.timeseries[0].data.instant.details");

                    double wind = data.Value<double>("wind_speed");//key name står i " " - getting key.value
                    return wind;
                }
                return 0;//returner ønsket verdi
            }
            catch { Exception ex; }
            return 0;//returner ønsket verdi
        }
        public double GetWindDirection()//denne har int, så vil da kunne returnere et heltall. 
        {
            //http://jsonviewer.stack.hu/
            //https://peterdaugaardrasmussen.com/2022/01/18/how-to-get-a-property-from-json-using-selecttoken/
            //create the httpwebrequest
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://api.met.no/weatherapi/nowcast/2.0/complete?lat=59.9333&lon=10.7166");

            //the usual stuff. run the request, parse your json. with error handling
            try
            {
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "GET";
                httpWebRequest.UserAgent = "bolle";
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    JObject jObj = JObject.Parse(result);
                    JToken data = jObj.SelectToken("properties.timeseries[0].data.instant.details");

                    double winddirection = data.Value<double>("wind_from_direction");//key name står i " " - getting key.value
                    return winddirection;
                }
                return 0;//returner ønsket verdi
            }
            catch { Exception ex; }
            return 0;//returner ønsket verdi
        }

        protected void Buttonreversetext_Click(object sender, EventArgs e)
        {
            string filePath = @"C:\Users\CRINGELORD\Desktop\FTP-Folder\reverse.txt";
            ReverseFileContents(filePath);
        }
    }
}