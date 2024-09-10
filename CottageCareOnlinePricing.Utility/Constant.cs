using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CottageCareOnlinePricing.Utility
{
    class Constant
    {
    }
    public class APIResponseMessage
    {
        public static string PostalCodeNotServiceable = "Unfortunately, we do not service this postal code currently. We are always looking to expand, so feel free to check back in the future. We appreciate your interest!";
        public static string PostalCodeServiceable = "This postal code is within our service area.";
        public static string PostalCodeRequired = "Postal code is required.";
        public bool IsServiceable = false;
       
        #region Basic API Req Res Message
        public static string DataFound = "Data Found";
        public static string DataNotFound = "Data was not Found";
        public static string DataRemoved = "Data Removed";
        public static string TokenExpired = "Token Expired";
        public static string DataSaved = "Data Saved";
        public static string TimeOut = "SQL Time-Out Exception";
        public static string EnteredDataIsNotValid = "Entered Data Is Not Valid";
        public static string SomethingWrong = "Something went wrong with API = ";
        #endregion


        public static string HomeCleanedBefore = "Your home has been cleaned by CottageCare! Call the service center at 1-800-123-4567";
        public static string HomeNotCleanedBefore = "Your home has not been cleaned by CottageCare. Please fill out the form for new customers";
        public static string NonExistingCustomer = "Sorry! You are not an existing customer ";

       
    }
    public class ConfigConstants
    {
        public static string LogInURL = "LogInURL";
        public static string UserTempPassword = "UserTempPassword";
        public static string PasswordSecretKey = "PasswordSecretKey";
        public static string ForgotPswURL = "ForgotPswURL";
        public static string CurrentEnvironment = "CurrentEnvironment";
        public static string SessionTimeOut = "SessionTimeOut";
        public static string SMTP_Host = "SMTP_Host";
        public static string SMTP_UserName = "SMTP_UserName";
        public static string SMTP_Password = "SMTP_Password";
        public static string SMTP_Port = "SMTP_Port";
        public static string SMTP_EnableSSL = "SMTP_EnableSSL";
        public static string FromNoReplyEmail = "FromNoReplyEmail";
        public static string FromNoReplyName = "FromNoReplyName";
        public static string CCLogoPath = "CCLogoPath";
        public static string LetterheadLogoPath = "LetterheadLogoPath";
        public static string apiFileUrl = "apiFileUrl";
        public static string dynamicConnectionString = "dynamicConnectionString";
        public static string OtpMode = nameof(OtpMode);
    }



}