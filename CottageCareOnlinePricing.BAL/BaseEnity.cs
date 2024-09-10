using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using CottageCareOnlinePricing.DAL;
using CottageCareOnlinePricing.Utility;
using log4net;


public class BaseEntity
{
    
    public CottageCareOnlinePricingEntities _cottageCareContext = new CottageCareOnlinePricingEntities();
    public  CottageCareMasterEntities _masterContext = new CottageCareMasterEntities();
    public DbContext GetDynamicDbContext(string companyDbName)
    {
        string dynamicConnectionString = CommonLogic.GetConfigValue(ConfigConstants.dynamicConnectionString);
        dynamicConnectionString = dynamicConnectionString.Replace("##DatabaseName##", companyDbName);
        return new DynamicDbContext(dynamicConnectionString);
    }
}




