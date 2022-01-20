using System;
using System.Net;
using System.Text.Json;
using onesecMailapi.Responses;

namespace onesecMailapi
{
    public class MailApi
    {
        public static string[]? GenerateRandomMails(int count)
        {
            string url = $"https://www.1secmail.com/api/v1/?action=genRandomMailbox&count={count}";
            string requestResponse = "";
            using (WebClient wc = new WebClient())
            {
                requestResponse = wc.DownloadString(url);
            }
            return JsonSerializer.Deserialize<string[]>(requestResponse);
        }

        public static string[]? GetActiveDomains()
        {
            string url = "https://www.1secmail.com/api/v1/?action=getDomainList";
            string requestResponse = "";
            using (WebClient wc = new WebClient())
            {
                requestResponse = wc.DownloadString(url);
            }
            return JsonSerializer.Deserialize<string[]>(requestResponse);
        }

        public static Email[]? CheckMail(string login, string domain)
        {
            string url = $"https://www.1secmail.com/api/v1/?action=getMessages&login={login}&domain={domain}";
            string requestResponse = "";
            using (WebClient wc = new WebClient())
            {
                requestResponse = wc.DownloadString(url);
            }
            return JsonSerializer.Deserialize<Email[]>(requestResponse);
        }
        
        public static Message? GetMessageDetails(string login, string domain, int id)
        {
            string url = $"https://www.1secmail.com/api/v1/?action=readMessage&login={login}&domain={domain}&id={id}";
            string requestResponse = "";
            using (WebClient wc = new WebClient())
            {
                requestResponse = wc.DownloadString(url);
            }
            return JsonSerializer.Deserialize<Message>(requestResponse);
        }

        public static (string, string) SplitMail(string email)
        {
            if (!email.Contains('@')) throw new Exception("Not a valid mail address");
            string[] splitMail = email.Split('@');
            return (splitMail[0], splitMail[1]);
        }
    }
}