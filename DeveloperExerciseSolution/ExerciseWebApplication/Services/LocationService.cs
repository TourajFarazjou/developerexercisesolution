using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml;

namespace ExerciseWebApplication.Services
{
    public class LocationService : ILocationService
    {
        private string _RequestBaseUri;

        public LocationService()
        {
            _RequestBaseUri = ConfigurationManager.AppSettings["GoogleApiRequestUri"];
        }

        public double? ComputeDistance(string origin, string destination)
        {
            //////string url = @"http://maps.googleapis.com/maps/api/distancematrix/xml?origins=" +
            //////      origin + "&destinations=" + destination +
            //////      "&mode=driving&sensor=false&language=en-EN"; // &units=imperial

            string RequestUri = 
                $"{_RequestBaseUri}?origins={origin}&destinations={destination}&mode=driving&sensor=false&language=en-EN";

            var request = (HttpWebRequest)WebRequest.Create(RequestUri);
            var response = request.GetResponse();
            var dataStream = response.GetResponseStream();
            var sreader = new StreamReader(dataStream);
            string responsereader = sreader.ReadToEnd();
            response.Close();

            var xmldoc = new XmlDocument();
            xmldoc.LoadXml(responsereader);

            if (xmldoc.GetElementsByTagName("status")[0].ChildNodes[0].InnerText == "OK")
            {
                var distance = xmldoc.GetElementsByTagName("distance");
                return Convert.ToDouble(distance[0].ChildNodes[1].InnerText.Replace(" km", ""));
            }

            return null;
        }
    }
}
