using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.SessionState;
using CottageCare.BAL.ServiceClass;
using CottageCareOnlinePricing.BAL;
using CottageCareOnlinePricing.BAL.ServiceClass;
using CottageCareOnlinePricing.DAL;
using CottageCareOnlinePricing.Utility;
using log4net;

namespace CottageCareOnlinePricingWebAPI.Controllers
{
    public class NewCustomerController : ApiController
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(NewCustomerController));

        [HttpPost]
        [Route("api/add-new-customer")]
        public Result AddNewCustomerInformation(NewCustomerMappers newCustomerMappers)
        {
            Result result = new Result();
            try
            {
                if (!ModelState.IsValid)
                {
                    result = new Result(APIResponseMessage.EnteredDataIsNotValid, StatusType.BadRequest);
                    result.ResultObject = ModelState;
                    return result;
                }
                if (newCustomerMappers != null && newCustomerMappers.IsExistingCustomer == false)
                {
                    CustomerEntity customerEntity = new CustomerEntity();
                    string newCustomerSessionId = customerEntity.AddtNewCustomerInformation(newCustomerMappers);
                    Logger.Info(APIResponseMessage.DataSaved + "AddNewCustomerInformation");
                    result = new Result(APIResponseMessage.DataSaved, StatusType.Success);
                    result.ResultObject = newCustomerSessionId;

                }
            }
            catch (Exception e)
            {
                Logger.Error(APIResponseMessage.SomethingWrong + "AddNewCustomerInformation", e);
                result = new Result(APIResponseMessage.SomethingWrong + "AddNewCustomerInformation", StatusType.Error, false);
                result.ExceptionMessage = e.Message;
                result.ExceptionStackTrace = e.StackTrace;
                result.ResultException = e.InnerException;
            }

            return result;
        }
        [HttpPost]
        [Route("api/add-home-information")]
        public Result AddHomeInformation(HomeInformationMappers homeInformationMappers)
        {
            Result result = new Result();
            string SessionId = CommonLogic.GetCurrentSessionId();
            try
            {
                if (!ModelState.IsValid)
                {
                    result = new Result(APIResponseMessage.EnteredDataIsNotValid, StatusType.BadRequest);
                    result.ResultObject = ModelState;
                    return result;
                }
                if (homeInformationMappers != null)
                {
                    CustomerEntity customerEntity = new CustomerEntity();
                    homeInformationMappers = customerEntity.AddHomeInformation(homeInformationMappers);
                    Logger.Info(APIResponseMessage.DataSaved + "AddHomeInformation");
                    result = new Result(APIResponseMessage.DataSaved, StatusType.Success);
                    result.ResultObject = homeInformationMappers;

                }
            }
            catch (Exception e)
            {
                Logger.Error(APIResponseMessage.SomethingWrong + "AddHomeInformation", e);
                result = new Result(APIResponseMessage.SomethingWrong + "AddHomeInformation", StatusType.Error, false);
                result.ExceptionMessage = e.Message;
                result.ExceptionStackTrace = e.StackTrace;
                result.ResultException = e.InnerException;
            }
            return result;
        }
        [HttpGet]
        [Route("api/get-roomtypes")]
        public Result GetRoomTypes()
        {
            Result result = new Result();
            try
            {
                CustomerEntity customerEntity = new CustomerEntity();
                List<RoomTypeMappers> roomType = new List<RoomTypeMappers>();
                roomType = customerEntity.GetRoomTypes();
                Logger.Info(APIResponseMessage.DataFound + "GetRoomTypes");
                result = new Result(APIResponseMessage.DataFound, StatusType.Success);
                result.ResultObject = roomType;
            }
            catch (Exception e)
            {
                Logger.Error(APIResponseMessage.DataNotFound + "GetRoomTypes", e);
                result = new Result(APIResponseMessage.DataNotFound + "GetRoomTypes", StatusType.Error);
                result.ExceptionMessage = e.Message;

                result.ExceptionStackTrace = e.StackTrace;
                result.ResultException = e.InnerException;
            }
            return result;
        }
        [HttpGet]
        [Route("api/get-floortypes")]
        public Result GetFloorTypes()
        {
            Result result = new Result();
            try
            {
                CustomerEntity customerEntity = new CustomerEntity();
                List<FlourTypeMappers> floorType = new List<FlourTypeMappers>();
                floorType = customerEntity.GetFloorTypes();
                CommonLogic.Logger.Info(APIResponseMessage.DataFound + "GetFloorTypes");
                result = new Result(APIResponseMessage.DataFound, StatusType.Success);
                result.ResultObject = floorType;
            }
            catch (Exception e)
            {
                CommonLogic.Logger.Error(APIResponseMessage.DataNotFound + "GetFloorTypes", e);
                result = new Result(APIResponseMessage.DataNotFound + "GetFloorTypes", StatusType.Error);
                result.ExceptionMessage = e.Message;
                result.ExceptionStackTrace = e.StackTrace;
                result.ResultException = e.InnerException;
            }
            return result;
        }
        [HttpGet]
        [Route("api/get-additionalrooms")]
        public Result GetAdditionalRoom()
        {
            Result result = new Result();
            try
            {
                CustomerEntity customerEntity = new CustomerEntity();
                List<OtherRoomsMappers> additionalRooms = new List<OtherRoomsMappers>();
                additionalRooms = customerEntity.GetAdditionalRoom();
                Logger.Info(APIResponseMessage.DataFound + "GetAdditionalRoom");
                result = new Result(APIResponseMessage.DataFound, StatusType.Success);
                result.ResultObject = additionalRooms;
            }
            catch (Exception e)
            {
                CommonLogic.Logger.Error(APIResponseMessage.DataNotFound + "GetAdditionalRoom", e);
                result = new Result(APIResponseMessage.DataNotFound + "GetAdditionalRoom", StatusType.Error);
                result.ExceptionMessage = e.Message;
                result.ExceptionStackTrace = e.StackTrace;
                result.ResultException = e.InnerException;
            }
            return result;
        }



    }
}
