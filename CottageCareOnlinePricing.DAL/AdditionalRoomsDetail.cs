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
    
    public partial class AdditionalRoomsDetail
    {
        public long Id { get; set; }
        public long GuestUserId { get; set; }
        public long FloorTypeId { get; set; }
        public string FloorTypeName { get; set; }
        public long AdditionalRoomMasterID { get; set; }
        public string AdditionalRoomName { get; set; }
        public int Quantity { get; set; }
        public int DampMoppedQuantity { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public Nullable<System.DateTime> UpdatedAt { get; set; }
    
        public virtual GuestUser GuestUser { get; set; }
    }
}
