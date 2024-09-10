using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CottageCareOnlinePricing.BAL.ServiceClass
{
    public class NewCustomerMappers
    {
        public string Salutation { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "PhoneNumber must be numeric")]
        public string PrimaryContact { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = "AlternateContact must be numeric")]
        public string AlternateContact { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        public string StateProvince { get; set; }
        [Required]
        [DataType(DataType.PostalCode)]
        public string PostalCode { get; set; }
        public string PreferredContactMethod { get; set; }
        public bool IsExistingCustomer { get; set; }
        public bool ViewedVideo { get; set; }
        public bool ViewedDocument { get; set; }
        public bool ReceivePromotions { get; set; }
        [Required]
        public string CleanType { get; set; }

    }
    public class PostalCodeCheckMapper
    {
        [Required]
        [DataType(DataType.PostalCode)]
        public string PostalCode { get; set; }

    }
}
