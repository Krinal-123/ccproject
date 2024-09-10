using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.SessionState;
using CottageCareOnlinePricing.DAL;
using log4net;
using log4net.Repository.Hierarchy;

namespace CottageCareOnlinePricing.Utility
{

    public class CommonLogic
    {
        public static readonly ILog Logger = LogManager.GetLogger(System.Environment.MachineName);
   
        #region Ip supported Function
        public static string GetIpAddress()
        {
            string ip = HttpContext.Current != null ? HttpContext.Current.Request.UserHostAddress : "";
            return ip;
        }

        #endregion

        #region Get deviceType Function
        public static string GetDeviceType()
        {

            string deviceType = HttpContext.Current.Request.Headers["User-Agent"] ?? "Unknown";
            return deviceType;
        }
        #endregion
        public static string CreateSession()
        {
            SessionIDManager manager = new SessionIDManager();
            string SessionId = manager.CreateSessionID(HttpContext.Current);
            return SessionId;
        }
        public static string GetCurrentSessionId()
        {
            string SessionId = Convert.ToString(HttpContext.Current?.Request?.Headers?.Get("SessionId"));
            return SessionId;
        }

        public static string GetConfigValue(string paramName)
        {
            string tmpS;
            try
            {
                tmpS = Convert.ToString(ConfigurationManager.AppSettings[paramName]);
            }
            catch
            {
                tmpS = String.Empty;
            }
            return tmpS;

        }
        public static void SendMail(MailAddress toMailAddress, TemplateName templateName, Dictionary<string, string> placeholdersWithValues)
        {
            var templateNameString = templateName.ToString();
             var template = cottageCarecontext.EmailTemplates
             .Where(t => t.TemplateTitle.Equals(templateNameString, StringComparison.OrdinalIgnoreCase))
             .Select(t => new
             {
                 t.EmailSubject,
                 t.EmailBody
             })
             .FirstOrDefault();
            if (template == null)
            {
                throw new InvalidOperationException($"No template found with title '{templateNameString}'.");
            }

            // Prepare the SMTP client
            var smtp = new SmtpClient
            {
                Host = GetConfigValue("SMTP_Host"),
                Port = Convert.ToInt32(GetConfigValue("SMTP_Port")),
                EnableSsl = true, // Set based on your server's requirements
                DeliveryMethod = SmtpDeliveryMethod.Network
            };

            // Authentication
            string fromNoReplyEmail = GetConfigValue("FromNoReplyEmail");
            string smtpPassword = GetConfigValue("SMTP_Password");
            if (!string.IsNullOrEmpty(fromNoReplyEmail) && !string.IsNullOrEmpty(smtpPassword))
            {
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(fromNoReplyEmail, smtpPassword);
            }
            else
            {
                smtp.UseDefaultCredentials = true;
            }

            string emailBody = template.EmailBody;

            foreach (var placeholder in placeholdersWithValues)
            {
                emailBody = emailBody.Replace(placeholder.Key, placeholder.Value);
            }
            // Prepare the email message
            var mailmsg = new MailMessage
            {
                From = new MailAddress(fromNoReplyEmail),
                Subject = template.EmailSubject,
                Body = emailBody,
                IsBodyHtml = true
            };

            // Add the recipient
            mailmsg.To.Add(toMailAddress);

            try
            {
                smtp.Send(mailmsg);
                Logger.Info($"Email sent successfully to {toMailAddress.Address}.");
            }
            catch (Exception ex)
            {
                Logger.Error("Failed to send email.", ex);
                throw;
            }
            finally
            {
                mailmsg.Dispose();
            }

        }
        public static string FormatName(string FirstName, string MiddleName, string LastName)
        {
            StringBuilder stringBuilder = new StringBuilder();
           
            if (!string.IsNullOrEmpty(FirstName))
            {
                stringBuilder.Append(FirstName);
            }
            if (!string.IsNullOrEmpty(FirstName))
            {
                stringBuilder.Append(" " + MiddleName);
            }
            if (!string.IsNullOrEmpty(FirstName))
            {
                stringBuilder.Append(" " + LastName);
            }
            return Convert.ToString(stringBuilder);
        }
    }
}
