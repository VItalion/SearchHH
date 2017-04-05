using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace SearchHH
{
    public class API
    {
        private static API instance;
        public static API Instance
        {
            get
            {
                if (instance == null)
                    instance = new API();

                return instance;
            }
        }

        private string uri;

        private API()
        {
            uri = "https://api.hh.ru/";
        }

        public async Task<Responce> Get(string request)
        {
            HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create(uri + request);
            httpRequest.UserAgent = "hh-recommender";
            //httpRequest.Headers.Add(HttpRequestHeader.UserAgent, "MyApp/1.0");
            var respone = await httpRequest.GetResponseAsync();

            string strRespone = string.Empty;
            using (StreamReader resStream = new StreamReader(respone.GetResponseStream()))
            {
                strRespone = await resStream.ReadToEndAsync();
            }

            File.WriteAllText("respone.json", strRespone);

            Responce result = JsonConvert.DeserializeObject<Responce>(strRespone);
            //System.Windows.MessageBox.Show(s.Items[0].Name);

            return result;
        }
    }

    public class Vacancie
    {
        public string Expirience { get; set; }
        public string Employment { get; set; }
        public string VacanciType { get; set; }
        public string Vacancilabel { get; set; }
    }
}
