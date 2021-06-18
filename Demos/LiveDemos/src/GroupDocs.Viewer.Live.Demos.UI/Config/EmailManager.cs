using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Timers;
using System.Collections.Generic;
using System.Net.Mail;
using System.Net;
using System.IO;

namespace GroupDocs.Viewer.Live.Demos.UI.Config
{
    /// <summary>
    /// ///////////////This class is for managing sending emails process to users in case they forget thier Username or Password
    /// </summary>
    public class EmailManager
    {
        public EmailManager()
        {
            //
            // TODO: Add constructor logic here
            //
        }                     
        public  static bool SendEmail(string toEmailAddress, string fromEmailAddress,  string subject, string body, string CC)
        {            
            SmtpClient smtp = new SmtpClient();
            MailMessage message = new MailMessage();
            try
            {                
                message.To.Add(toEmailAddress);
                message.From = new MailAddress(fromEmailAddress);    
                if(CC != "")
                {
                    message.CC.Add(CC);    
                }
                message.Subject = subject;
                message.Body = body;
                message.IsBodyHtml = true;
                smtp.UseDefaultCredentials = false;
                smtp.Host = Configuration.MailServer;
                smtp.Port = Configuration.MailServerPort;
                smtp.Timeout = Configuration.MailServerTimeOut;
                
                smtp.EnableSsl = true;
               
                smtp.Credentials = new NetworkCredential(Configuration.MailServerUserId, Configuration.MailServerUserPassword);                
                if (message.To.Count > 0)
                {
                    smtp.Send(message);
                }

            }
            finally
            {
                message.Dispose();
            }
            
            return true;
        }
        public static bool SendEmailWithAttachment(string toEmailAddress, string fromEmailAddress, string subject, string body, string CC, string Certificates)
        {
            SmtpClient smtp = new SmtpClient();
            MailMessage message = new MailMessage();
            try
            {
                message.To.Add(toEmailAddress);
                message.From = new MailAddress(fromEmailAddress);
                if (CC != "")
                {
                    message.CC.Add(CC);
                }
                message.Subject = subject;
                message.Body = body;
                message.IsBodyHtml = true;
                smtp.UseDefaultCredentials = false;
                smtp.Host = Configuration.MailServer;
                smtp.Port = Configuration.MailServerPort;
                smtp.Timeout = Configuration.MailServerTimeOut;
                smtp.EnableSsl = true;

                if (Certificates != "")
                {
                    message.Attachments.Add(new Attachment(Certificates));
                }

                smtp.Credentials = new NetworkCredential(Configuration.MailServerUserId, Configuration.MailServerUserPassword);
                if (message.To.Count > 0)
                {
                    smtp.Send(message);
                }

            }
            finally
            {
                message.Dispose();
            }
            return true;
        }

        public static string PopulateBody(string userName, string title, string url, string description, string featureDescription, string successMessage)
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("~/App_Data/EmailTemplate.html")))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("{UserName}", userName);
            body = body.Replace("{Title}", title);
            body = body.Replace("{Url}", url);
            body = body.Replace("{Description}", description);
			body = body.Replace("{FeatureDescription}", featureDescription);
			body = body.Replace("{SuccessMessage}", successMessage);
			return body;
        }       

        public static string PopulateEmailBody(string heading, string url, string successMessage)
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("~/App_Data/TemplateEmail.html")))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("{Heading}", heading);
            body = body.Replace("{Url}", url);
            body = body.Replace("{SuccessMessage}", successMessage);
            body = body.Replace("{Year}", DateTime.Now.Year.ToString());

            return body;
        }

    }

}
