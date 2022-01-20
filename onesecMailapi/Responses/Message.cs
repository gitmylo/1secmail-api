using System;
using System.Collections.Generic;

namespace onesecMailapi.Responses
{
    [Serializable]
    public class Message
    {
        public int id { get; set; }
        public string from { get; set; }
        public string subject { get; set; }
        public string date { get; set; }
        public Attachment[] attachments { get; set; }
        public string body { get; set; }
        public string textBody { get; set; }
        public string htmlBody { get; set; }
    }

    [Serializable]
    public class Attachment
    {
        public string filename { get; set; }
        public string contentType { get; set; }
        public int size { get; set; }

        public string getDownloadLink(string login, string domain, int mailId)
        {
            return $"https://www.1secmail.com/api/v1/?action=download&login={login}&domain={domain}&id={mailId}&file={filename}";
        }
    }
}