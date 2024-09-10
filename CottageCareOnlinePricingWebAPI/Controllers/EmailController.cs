using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Web.Http;
using CottageCareOnlinePricing.BAL;
using CottageCareOnlinePricing.BAL.ServiceClass;
using CottageCareOnlinePricing.DAL;
using CottageCareOnlinePricing.Utility;
using log4net;
using log4net.Repository.Hierarchy;

namespace CottageCareOnlinePricingWebAPI.Controllers
{
    public class EmailController : ApiController
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(EmailController));
        CustomerEntity customerEntity = new CustomerEntity();
        [HttpPost]
        [Route("api/send-template-email")]
        public IHttpActionResult SendTemplatedEmail(EmailRequestMapper request)
        {
            if (request == null)
            {
                Logger.Warn("SendTemplatedEmail called with a null request.");
                return BadRequest("Request cannot be null.");
            }

            try
            {
                Logger.Info("SendTemplatedEmail called with valid request.");

                var placeholdersWithValues = new Dictionary<string, string>
                {
                    { "##username##", "John" },
                    { "##useremail##", "himanshu@vervesys.com" },
                    { "##name##", "John Doe" }
                };

                MailAddress ToEmail = new MailAddress(request.ToEmail,
                    CommonLogic.FormatName(request.FirstName, "", request.LastName));
                Logger.Info($"Sending email to {ToEmail.Address}");

               var template= customerEntity.GetEmailTemplate();
                CommonLogic.SendMail(ToEmail, TemplateName.WelcomeEmail, placeholdersWithValues);

                Logger.Info("Templated email sent successfully.");
                return Ok("Templated email sent successfully.");
            }
            catch (FormatException ex)
            {
                Logger.Error("Invalid email address format.", ex);
                return BadRequest("Invalid email address format.");
            }
            catch (Exception ex)
            {
                Logger.Error("An error occurred while sending templated email.", ex);
                return InternalServerError(ex);
            }
            
        }
    }
}
   

