namespace Quota.Domain.Services.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Net;
    using System.Net.Mail;

    public class EmailManagement
    {
        MailMessage messages = new MailMessage();
        SmtpClient sent = new SmtpClient();

        public string sendEmail(string emitter, string password, string message, string subject, string destinataries, string url, string server)
        {
            string isSuccess = "";
            try
            {
                messages.To.Clear();
                messages.Body = "";
                messages.Subject = "";
                messages.Body = message;
                messages.Subject = subject;
                messages.IsBodyHtml = false;
                string[] vector0 = destinataries.Split(';');

                for (int i = 0; i < vector0.Count(); i++)
                {
                    messages.To.Add(vector0[i]);
                }
                if (!url.Equals(""))
                {
                    string[] vector = url.Split(',');
                    for (int i = 0; i < vector.Count(); i++)
                    {
                        System.Net.Mail.Attachment archivo = new System.Net.Mail.Attachment(vector[i]);
                        messages.Attachments.Add(archivo);
                    }
                }

                messages.From = new MailAddress(emitter);
                sent.EnableSsl = true;
                sent.UseDefaultCredentials = false;
                sent.Credentials = new NetworkCredential(emitter, password);
                sent.Host = server.Split(':')[0];
                sent.Port = Convert.ToInt32(server.Split(':')[1]);             
                sent.DeliveryMethod = SmtpDeliveryMethod.Network;
                sent.Send(messages);
                isSuccess = "SI";
            }
            catch (Exception ex)
            {
                isSuccess = "NO";
            }
            return isSuccess;
        }
    }
}
