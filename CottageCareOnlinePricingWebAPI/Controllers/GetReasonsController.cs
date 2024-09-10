using CottageCare.BAL.ServiceClass;
using CottageCareOnlinePricing.BAL;
using CottageCareOnlinePricing.BAL.ServiceClass;
using CottageCareOnlinePricing.DAL;
using CottageCareOnlinePricing.Utility;
using log4net;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CottageCareOnlinePricingWebAPI.Controllers
{
    public class GetReasonsController : ApiController
    {
        public static readonly ILog Logger = LogManager.GetLogger(System.Environment.MachineName);

        [HttpGet]
        [Route("api/get-reasons")]
        public Result GetReasonsMaster()
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

                ReasonsEntity reasonsEntity = new ReasonsEntity();
                List<GetReasonMappers> getReasons = reasonsEntity.GetReasonsMaster();
                Logger.Info(APIResponseMessage.DataFound + "GetReasonsMaster");
                result = new Result(APIResponseMessage.DataFound, StatusType.Success);
                {
                    result.ResultObject = getReasons;
                }

            }
            catch (Exception e)
            {
                Logger.Error(APIResponseMessage.SomethingWrong + "GetReasonsMaster", e);
                result = new Result(APIResponseMessage.SomethingWrong + "GetReasonsMaster", StatusType.Error, false);
                result.ExceptionMessage = e.Message;
                result.ExceptionStackTrace = e.StackTrace;
                result.ResultException = e.InnerException;
            }
            return result;
        }
    }
}
