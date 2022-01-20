using System;
using System.Text.Json;
using onesecMailapi;

Console.WriteLine("Testing api...");

string[]? mails = MailApi.GenerateRandomMails(1);

if (mails != null)
{
    Console.WriteLine($"Generated mail: {mails[0]}");
    (string login, string domain) = MailApi.SplitMail(mails[0]);
    Console.WriteLine($"Send a mail to this address, then press a key to check");
    while (true)
    {
        Console.ReadKey();
        Console.WriteLine("All mail:");
        foreach (var mail in MailApi.CheckMail(login, domain))
        {
            Console.WriteLine(JsonSerializer.Serialize(mail.GetDetails(login, domain)));
        }
        Console.WriteLine("-----End of mail-----");
    }
}
else
{
    Console.WriteLine("Something went wrong generating mails!");
}