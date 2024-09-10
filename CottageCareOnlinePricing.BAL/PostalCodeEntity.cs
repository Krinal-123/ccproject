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
    public class PostalCodeEntity : BaseEntity
    {
        public bool CheckPostalCode(string postalCode)
        {
            bool IsServiceable =  false;
            if (string.IsNullOrWhiteSpace(postalCode))
            {
               return IsServiceable;
            }

            IsServiceable = _cottageCareContext.PostalCodes.Any(x => x.Code == postalCode);

            if (!IsServiceable)
            {
                var nonServiceablePostalCode = new NonServiceablePostalCode
                {
                    PostalCode = postalCode,

                };
                _cottageCareContext.NonServiceablePostalCodes.Add(nonServiceablePostalCode);
                _cottageCareContext.SaveChanges();
            }
            return IsServiceable;

        }
        
    }
}
    

