using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CottageCare.BAL.ServiceClass;
using CottageCareOnlinePricing.BAL;
using CottageCareOnlinePricing.BAL.ServiceClass;
using CottageCareOnlinePricing.Utility;
using log4net;
using log4net.Repository.Hierarchy;

namespace CottageCareOnlinePricingWebAPI.Controllers
{
    public class RoomInformationController : ApiController
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(RoomInformationController));
        [HttpGet]
        [Route("api/get-room-information")]
        public Result GetRoomInformation()
        {
            Result result = new Result();
            try
            {
                RoomInfoEnitity roomInfoEnitity = new RoomInfoEnitity();
                RoomInfoMappers roomInfoMappers = new RoomInfoMappers();
                roomInfoMappers = roomInfoEnitity.GetRoomInformation();
                Logger.Info(APIResponseMessage.DataFound + "GetRoomInformation");
                result = new Result(APIResponseMessage.DataFound, StatusType.Success);
                result.ResultObject = roomInfoMappers;
            }
            catch (Exception e)
            {
                CommonLogic.Logger.Error(APIResponseMessage.DataNotFound + "GetRoomInformation", e);
                result = new Result(APIResponseMessage.DataNotFound + "GetRoomInformation", StatusType.Error);
                result.ExceptionMessage = e.Message;
                result.ExceptionStackTrace = e.StackTrace;
                result.ResultException = e.InnerException;

            }
            return result;
        }

        [HttpPost]
        [Route("api/manage-room-information")]
        public Result ManageRoomInformation(RoomInfoMappers roomInfoMappers)
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
                if (roomInfoMappers != null)
                {
                    RoomInfoEnitity roomInfoEnitity = new RoomInfoEnitity();
                    roomInfoMappers = roomInfoEnitity.ManageRoomInformation(roomInfoMappers);
                    Logger.Info(APIResponseMessage.DataSaved + "ManageRoomInformation");
                    result = new Result(APIResponseMessage.DataSaved, StatusType.Success);
                    result.ResultObject = roomInfoMappers;
                }
            }
            catch (Exception e)
            {
                CommonLogic.Logger.Error(APIResponseMessage.SomethingWrong + "ManageRoomInformation", e);
                result = new Result(APIResponseMessage.SomethingWrong + "ManageRoomInformation", StatusType.Error, false);
                result.ExceptionMessage = e.Message;
                result.ExceptionStackTrace = e.StackTrace;
                result.ResultException = e.InnerException;
            }

            return result;
        }



    }
}
