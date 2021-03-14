using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TechExam_Winforms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            //using (MyApiClient client = new MyApiClient("https://api.github.com/"))
            //{
            //    string response = client.GetAsync("users/intevaluetesting").Result;
            //    rtxtDetails.Text = response.ToString();
            //}

            HttpWebRequest webRequest = System.Net.WebRequest.Create("https://api.github.com/users/intevaluetesting") as HttpWebRequest;
            if (webRequest != null)
            {
                webRequest.Method = "GET";
                webRequest.UserAgent = "Anything";
                webRequest.ServicePoint.Expect100Continue = false;

                try
                {
                    using (StreamReader responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream()))
                    {
                        string reader = responseReader.ReadToEnd();
                        var jsonobj = JsonConvert.DeserializeObject(reader);
                        rtxtDetails.Text = jsonobj.ToString();
                    }
                }
                catch
                {
                    return;
                }
            }

        }
    }
}
