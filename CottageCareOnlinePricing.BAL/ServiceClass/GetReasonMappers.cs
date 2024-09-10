using CottageCareOnlinePricing.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CottageCareOnlinePricing.BAL.ServiceClass
{
    public class GetReasonMappers
    {
        public long Id { get; set; }
        public string ReasonName { get; set; }
        public ReasonType ReasonType { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public Nullable<System.DateTime> UpdatedAt { get; set; }
    }
}
