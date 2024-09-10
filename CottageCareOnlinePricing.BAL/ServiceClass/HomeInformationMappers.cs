using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CottageCareOnlinePricing.BAL.ServiceClass
{
    public class HomeInformationMappers
    {
        public string HeardAboutUs { get; set; }
        public string TotalSquareFootage { get; set; }
        public string OtherCleaningServicesUsed { get; set; }
        public int NumberOfAdults { get; set; }
        public int NumberOfChildren { get; set; }
        public int NumberOfCats { get; set; }
        public int NumberOfDogs { get; set; }
        public string CleaningFrequency { get; set; }
    }
}
