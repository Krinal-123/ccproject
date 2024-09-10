using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CottageCare.BAL.ServiceClass;
using CottageCareOnlinePricing.BAL;
using CottageCareOnlinePricing.BAL.ServiceClass;
using CottageCareOnlinePricing.DAL;
using CottageCareOnlinePricing.Utility;
using log4net;

namespace CottageCareOnlinePricingWebAPI.Controllers
{
    public class PostalCodeController : ApiController
    {
        
        private static readonly ILog Logger = LogManager.GetLogger(typeof(PostalCodeController));


        [HttpPost]
        [Route("api/check-postal-code")]
        public Result CheckPostalCode(PostalCodeCheckMapper postalCodeMapper)
        {
            Result result = new Result();
            PostalCodeEntity postalCodeEntity = new PostalCodeEntity();
            try
            {
                
                if (!ModelState.IsValid)
                {
                    result = new Result(APIResponseMessage.EnteredDataIsNotValid, StatusType.BadRequest,false);
                    result.ResultObject = ModelState;
                    return result;
                }
                if (postalCodeEntity.CheckPostalCode(postalCodeMapper.PostalCode))
                {
                    Logger.Info(APIResponseMessage.PostalCodeServiceable + "CheckPostalCode");
                    return result = new Result(APIResponseMessage.PostalCodeServiceable, StatusType.Success,true);
                }
                
                Logger.Warn(APIResponseMessage.PostalCodeNotServiceable + "CheckPostalCode");
                return result = new Result(APIResponseMessage.PostalCodeNotServiceable, StatusType.Success,false);
                   
                
            }
            catch (Exception e)
            {
                Logger.Error(APIResponseMessage.SomethingWrong + "CheckPostalCode", e);
                result = new Result(APIResponseMessage.SomethingWrong + "CheckPostalCode", StatusType.Error,false);
                result.ExceptionMessage = e.Message;
                result.ExceptionStackTrace = e.StackTrace;
                result.ResultException = e.InnerException;
            }
          
            return result;
           

        }
    }
}
