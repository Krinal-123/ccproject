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

namespace CottageCareOnlinePricingWebAPI.Controllers
{
    public class ExistingCustomerController : ApiController
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(ExistingCustomerController));
        [HttpPost]
        [Route("api/add-existing-customer")]
        public Result AddExistingCustomerForm(ExistingCustomerMappers existingCustomerMappers)
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
                if (existingCustomerMappers != null && existingCustomerMappers.IsExistingCustomer == true)
                {
                    CustomerEntity customerEntity = new CustomerEntity();
                    existingCustomerMappers = customerEntity.AddExistingCustomerInfotmation(existingCustomerMappers);
                    Logger.Info(APIResponseMessage.DataSaved + "AddExistingCustomerForm");
                    result = new Result(APIResponseMessage.DataSaved, StatusType.Success,true);
                    result.ResultObject = existingCustomerMappers;
                }
                else
                {
                    Logger.Info(APIResponseMessage.NonExistingCustomer+ "AddExistingCustomerForm");
                    result = new Result(APIResponseMessage.NonExistingCustomer, StatusType.Success);
                }


            }
            catch (Exception e)
            {
                Logger.Error(APIResponseMessage.SomethingWrong + "AddExistingCustomerForm", e);
                result = new Result(APIResponseMessage.SomethingWrong + "AddExistingCustomerForm", StatusType.Error, false);
                result.ExceptionMessage = e.Message;
                result.ExceptionStackTrace = e.StackTrace;
                result.ResultException = e.InnerException;
            }
            return result;


        }
    }
}
