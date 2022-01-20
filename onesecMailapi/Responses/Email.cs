using System;
using System.Net;
using System.Text.Json;

namespace onesecMailapi.Responses
{
    [Serializable]
    public class Email
    {
        public int id { get; set; }
        public string from { get; set; }
        public string subject { get; set; }
        public string date { get; set; }

        public Message? GetDetails(string login, string domain)
        {
            string url = $"https://www.1secmail.com/api/v1/?action=readMessage&login={login}&domain={domain}&id={id}";
            string requestResponse = "";
            using (WebClient wc = new WebClient())
            {
                requestResponse = wc.DownloadString(url);
            }
            return JsonSerializer.Deserialize<Message>(requestResponse);
        }
    }
}