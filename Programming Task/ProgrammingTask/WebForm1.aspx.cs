using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;

namespace ProgrammingTask
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            string movieRequest = "http://www.omdbapi.com/?t=" + HttpContext.Current.Server.UrlEncode(TextBoxMovieName.Text); //Create the URL String and code it as a URL

            HttpWebRequest webRequest = (HttpWebRequest) WebRequest.Create(movieRequest); //Make the HTTP Request with the generated string

            webRequest.Timeout = 10000;
            webRequest.UserAgent = "Code Sample Web Client";

            HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();

            Encoding enc = Encoding.GetEncoding(1252);

            StreamReader responseStream = new StreamReader(webResponse.GetResponseStream(), enc);

            string movieData = responseStream.ReadToEnd(); //Create the string that holds the response.

            webResponse.Close();
            responseStream.Close();

            if (movieData == "{\"Response\":\"False\",\"Error\":\"Movie not found!\"}")
            {
                LabelResponse.Text = "Sorry! The movie you were looking for was not found! Please Try Again!"; //If the API data comes back with movie not found, display a sorry message
                TextBoxMovieName.Text = "";
            }
            else
            {
                movieData = movieData.Replace("\",\"", "<br />");
                movieData = movieData.Replace("\"", "");
                movieData = movieData.Replace("{", "");             //Remove unwanted characters from the data retrieved from the API. Add spacing to make it clearer
                movieData = movieData.Replace("}", "");
                movieData = movieData.Replace(":", ": ");
                movieData = movieData.Replace("[],", "<br />");
                movieData = movieData.Replace("Response: True", "");
                movieData = movieData.Replace(",", ", ");
                movieData = movieData.Replace("[", " ");
                movieData = movieData.Replace("]", " ");

                TextBoxMovieName.Text = "";

                LabelResponse.Text = movieData;
            }

        }
    }
}