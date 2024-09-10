using CottageCareOnlinePricing.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CottageCareOnlinePricing.BAL.ServiceClass
{
   
    public class EmailRequestMapper
    {
        public string ToEmail { get; set; }
     
        public string FirstName { get; set; }
        //public TemplateName TemplateType { get; set; }
        public string LastName { get; set; }
    }


}
