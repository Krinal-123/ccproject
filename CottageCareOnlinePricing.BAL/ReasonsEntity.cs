using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CottageCareOnlinePricing.BAL.ServiceClass;
using CottageCareOnlinePricing.DAL;
using CottageCareOnlinePricing.Utility;
using log4net;

namespace CottageCareOnlinePricing.BAL
{
    public class ReasonsEntity: BaseEntity
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(ReasonsEntity));
        public List<GetReasonMappers> GetReasonsMaster()
        {

            var reasons = _cottageCareContext.ReasonsMasters
                 .Select(r => new GetReasonMappers
                 {
                     Id = r.Id,
                     ReasonName = r.ReasonName,
                     ReasonType = (ReasonType)r.ReasonType,

                 }).ToList();

                return reasons;
 
        }


    }
}
