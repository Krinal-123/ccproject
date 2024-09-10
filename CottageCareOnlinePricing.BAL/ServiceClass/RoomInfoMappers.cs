using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CottageCareOnlinePricing.DAL;

namespace CottageCareOnlinePricing.BAL.ServiceClass
{
    public class RoomInfoMappers
    {

        public int MasterBathCount { get; set; }
        public int FullBathCount { get; set; }
        public int HalfBathCount { get; set; }
        public bool HasKitchen { get; set; }
        public bool HasKitchenNook { get; set; }
        public bool HasLaundryRoom { get; set; }
        public List<RoomMappers> Rooms { get; set; }
        public List<AdditionalRoomMappers> AdditionalRooms { get; set; }

      
    }
    public class RoomMappers
    {
        public long Id { get; set; }
        public long RoomTypeId { get; set; }
        public long FloorTypeId { get; set; }
        public int Quantity { get; set; }
        public int DampMoppedQuantity { get; set; }


    }
    public class RoomTypeMappers
    {
        public long Id { get; set; }
        public string RoomTypeName { get; set; }
        public int Type { get; set; }


    }
    public class OtherRoomsMappers
    {
        public long ID { get; set; }
        public Nullable<long> OtherRoomsMasterID { get; set; }
        public string RoomName { get; set; }
        public decimal RoomPrice { get; set; }
        public long CompanyID { get; set; }
    }
    public class AdditionalRoomMappers
    {
        public long Id { get; set; }
        public long FloorTypeId { get; set; }
        public string FloorTypeName { get; set; }
        public long AdditionalRoomMasterID { get; set; }
        public string AdditionalRoomName { get; set; }
        public int Quantity { get; set; }
        public int DampMoppedQuantity { get; set; }

    }
}
