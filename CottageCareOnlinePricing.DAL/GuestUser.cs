//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CottageCareOnlinePricing.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class GuestUser
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GuestUser()
        {
            this.AdditionalRoomsDetails = new HashSet<AdditionalRoomsDetail>();
            this.CleaningAppointments = new HashSet<CleaningAppointment>();
            this.QuoteDetails = new HashSet<QuoteDetail>();
            this.Quotes = new HashSet<Quote>();
            this.Rooms = new HashSet<Room>();
        }
    
        public long Id { get; set; }
        public string SessionId { get; set; }
        public Nullable<long> CompanyId { get; set; }
        public string PostalCode { get; set; }
        public string CleanType { get; set; }
        public Nullable<bool> ViewedVideo { get; set; }
        public Nullable<bool> ViewedDocument { get; set; }
        public Nullable<bool> ReceivePromotions { get; set; }
        public string Salutation { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PrimaryContact { get; set; }
        public string AlternateContact { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public string PreferredContactMethod { get; set; }
        public bool IsExistingCustomer { get; set; }
        public Nullable<bool> CallServiceCenter { get; set; }
        public string HeardAboutUs { get; set; }
        public string TotalSquareFootage { get; set; }
        public string OtherCleaningServicesUsed { get; set; }
        public Nullable<int> NumberOfAdults { get; set; }
        public Nullable<int> NumberOfChildren { get; set; }
        public Nullable<int> NumberOfCats { get; set; }
        public Nullable<int> NumberOfDogs { get; set; }
        public string CleaningFrequency { get; set; }
        public Nullable<int> MasterBathCount { get; set; }
        public Nullable<int> FullBathCount { get; set; }
        public Nullable<int> HalfBathCount { get; set; }
        public Nullable<bool> HasKitchen { get; set; }
        public Nullable<bool> HasKitchenNook { get; set; }
        public Nullable<bool> HasLaundryRoom { get; set; }
        public string IPAddress { get; set; }
        public string DeviceType { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public System.DateTime UpdatedAt { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AdditionalRoomsDetail> AdditionalRoomsDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CleaningAppointment> CleaningAppointments { get; set; }
        public virtual GuestUser GuestUsers1 { get; set; }
        public virtual GuestUser GuestUser1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QuoteDetail> QuoteDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Quote> Quotes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Room> Rooms { get; set; }
    }
}
