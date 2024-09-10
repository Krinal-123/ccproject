using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using System.Web;using System.Net.Http;using CottageCareOnlinePricing.BAL.ServiceClass;using CottageCareOnlinePricing.DAL;using CottageCareOnlinePricing.Utility;using System.Net.Mail;using System.Data.Entity;using log4net;namespace CottageCareOnlinePricing.BAL{    public class CustomerEntity : BaseEntity    {
     
        private static readonly ILog Logger = LogManager.GetLogger(typeof(CustomerEntity));
               public ExistingCustomerMappers AddExistingCustomerInfotmation(ExistingCustomerMappers existingCustomerMappers)        {            Logger.Info("AddExistingCustomerInfotmation Method Started");
            string deviceType = CommonLogic.GetDeviceType();
            string ipAddress = CommonLogic.GetIpAddress();


            if (existingCustomerMappers != null)            {                string postalCode = existingCustomerMappers.PostalCode;                var companyId = _cottageCareContext.PostalCodes.Where(c => c.Code == postalCode).Select(c => c.CompanyID).FirstOrDefault();                var existingCustomer = new GuestUser                {                    FirstName = existingCustomerMappers.FirstName,                    LastName = existingCustomerMappers.LastName,                    PrimaryContact = existingCustomerMappers.PrimaryContact,                    Email = existingCustomerMappers.Email,                    IsExistingCustomer = existingCustomerMappers.IsExistingCustomer,                    CompanyId = companyId,                    IPAddress = ipAddress,                    DeviceType = deviceType,                };                _cottageCareContext.GuestUsers.Add(existingCustomer);                _cottageCareContext.SaveChanges();                Logger.Info("ExistingCustomer infotmation added");
                //need to add email template

                Logger.Info("Existing customer data sent to Service Manager by email ");

            }
            return existingCustomerMappers;        }        public string AddtNewCustomerInformation(NewCustomerMappers newCustomerMappers)        {
           Logger.Info("AddNewCustomerInformation method started");            string deviceType = CommonLogic.GetDeviceType();            string ipAddress = CommonLogic.GetIpAddress();            string sessonId = CommonLogic.CreateSession();            string postalCode = newCustomerMappers.PostalCode;            var companyId = _cottageCareContext.PostalCodes.Where(c => c.Code == postalCode).Select(c => c.CompanyID).FirstOrDefault();            if (newCustomerMappers != null)            {                var newCustomer = new GuestUser                {                    Salutation = newCustomerMappers.Salutation,                    FirstName = newCustomerMappers.FirstName,                    LastName = newCustomerMappers.LastName,                    Email = newCustomerMappers.Email,                    PrimaryContact = newCustomerMappers.PrimaryContact,                    AlternateContact = newCustomerMappers.AlternateContact,                    Country = newCustomerMappers.Country,                    Address = newCustomerMappers.Address,                    City = newCustomerMappers.City,                    StateProvince = newCustomerMappers.StateProvince,                    PostalCode = newCustomerMappers.PostalCode,                    PreferredContactMethod = newCustomerMappers.PreferredContactMethod,                    ViewedVideo = newCustomerMappers.ViewedVideo,                    ViewedDocument = newCustomerMappers.ViewedDocument,                    ReceivePromotions = newCustomerMappers.ReceivePromotions,                    CleanType = newCustomerMappers.CleanType,                    SessionId = sessonId,                    CompanyId = companyId,                    IPAddress = ipAddress,                    DeviceType = deviceType,                };

                _cottageCareContext.GuestUsers.Add(newCustomer);
                _cottageCareContext.SaveChanges();
                Logger.Info("New Customer Information Added");                if (newCustomerMappers.ReceivePromotions == true)                {
                    //need to add email template

                    Logger.Info("Promotions email consent sent to Customer");                }                Logger.Info("AddNewCustomerInformation method End");            }
            return sessonId;        }        public HomeInformationMappers AddHomeInformation(HomeInformationMappers homeInformationMappers)        {            Logger.Info("AddHomeInformation method Started");
            string SessionId = CommonLogic.GetCurrentSessionId();

            var sessionToUpdate = _cottageCareContext.GuestUsers.FirstOrDefault(s => s.SessionId == SessionId);            if (homeInformationMappers != null && sessionToUpdate != null)            {                sessionToUpdate.HeardAboutUs = homeInformationMappers.HeardAboutUs;                sessionToUpdate.TotalSquareFootage = homeInformationMappers.TotalSquareFootage;                sessionToUpdate.OtherCleaningServicesUsed = homeInformationMappers.OtherCleaningServicesUsed;                sessionToUpdate.NumberOfAdults = homeInformationMappers.NumberOfAdults;                sessionToUpdate.NumberOfChildren = homeInformationMappers.NumberOfChildren;                sessionToUpdate.NumberOfCats = homeInformationMappers.NumberOfCats;                sessionToUpdate.NumberOfDogs = homeInformationMappers.NumberOfDogs;                sessionToUpdate.CleaningFrequency = homeInformationMappers.CleaningFrequency;                _cottageCareContext.SaveChanges();            }            Logger.Info("HomeInformation data added");            Logger.Info("AddHomeInformation method End");            return homeInformationMappers;

        }
        public List<RoomTypeMappers> GetRoomTypes()
        {
            Logger.Info("GetRoomTypes method Started");
            var roomTypes = _cottageCareContext.RoomTypes.ToList();

                var roomTypeMappers = roomTypes.Select(rt => new RoomTypeMappers
                {

                    Id = rt.Id,
                    RoomTypeName = rt.RoomTypeName,
                    Type = rt.Type

                }).ToList();
                Logger.Info("GetRoomTypes method End");
                return roomTypeMappers;
        }
        public List<FlourTypeMappers> GetFloorTypes()
        {
               Logger.Info("GetFloorTypes method Started");
         
                var roomTypes = _cottageCareContext.FloorTypes.ToList();

                var roomTypeMappers = roomTypes.Select(rt => new FlourTypeMappers
                {
                    Id = rt.Id,
                    FloorTypeName = rt.FloorTypeName

                }).ToList();
                Logger.Info("GetFloorTypes method End");
                return roomTypeMappers;
            
        }
        public List<OtherRoomsMappers> GetAdditionalRoom()        {
      
            Logger.Info("GetAdditionalRoom method Started");            string SessionId = CommonLogic.GetCurrentSessionId();            List<OtherRoomsMappers> otherRoomsMappers = new List<OtherRoomsMappers>();
            if (SessionId != null)            {                var sessionData = _cottageCareContext.GuestUsers.FirstOrDefault(s => s.SessionId == SessionId);                var companyDbName = _masterContext.Companies.Where(c => c.CompanyID == sessionData.CompanyId).Select(c => c.DatabaseName).FirstOrDefault();
                var dynamicContext = (DynamicDbContext)GetDynamicDbContext(companyDbName);
                var additionalRoom = dynamicContext.OtherRooms.ToList();
                var otherRoom = additionalRoom.Select(rt => new OtherRoomsMappers
                {
                    ID = rt.ID,
                    OtherRoomsMasterID = rt.OtherRoomsMasterID,
                    CompanyID = rt.CompanyID,
                    RoomName = rt.RoomName,
                    RoomPrice = rt.RoomPrice

                }).ToList();
                return otherRoom;
            }            Logger.Info("GetAdditionalRoom method End");            return otherRoomsMappers;        }        public List<EmailRequestMapper> GetEmailTemplate()
        {
            List<EmailRequestMapper> emailRequests = new List<EmailRequestMapper>();
            var templateNameString = TemplateName.WelcomeEmail.ToString();
            var template = _cottageCareContext.EmailTemplates
            .Where(t => t.TemplateTitle.Equals(templateNameString, StringComparison.OrdinalIgnoreCase))
            .Select(t => new
            {
                t.EmailSubject,
                t.EmailBody
            }).ToList();
            return emailRequests;        }    }
}
