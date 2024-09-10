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
    public class RoomInfoEnitity: BaseEntity
    {
        public RoomInfoMappers GetRoomInformation()
        {
            RoomInfoMappers roomInfoMappers = new RoomInfoMappers();
            string sessonId = CommonLogic.GetCurrentSessionId();
            var roomData = _cottageCareContext.GuestUsers.FirstOrDefault(s => s.SessionId == sessonId);
            var rooms = _cottageCareContext.Rooms.Where(s => s.GuestUserId == roomData.Id).ToList();
            var additionalRooms = _cottageCareContext.AdditionalRoomsDetails.Where(s => s.GuestUserId == roomData.Id).ToList();
            var roomMappers = rooms.Select(room => new RoomMappers
            {
                Id = room.Id,
                RoomTypeId = room.RoomTypeId,
                FloorTypeId = room.FloorTypeId,
                Quantity = room.Quantity,
                DampMoppedQuantity = room.DampMoppedQuantity
            }).ToList();
            var addditionalRoomMappers = additionalRooms.Select(additionalroom => new AdditionalRoomMappers
            {
                Id = additionalroom.Id,
                FloorTypeName = additionalroom.FloorTypeName,
                FloorTypeId = additionalroom.FloorTypeId,
                Quantity = additionalroom.Quantity,
                DampMoppedQuantity = additionalroom.DampMoppedQuantity,
                AdditionalRoomName = additionalroom.AdditionalRoomName,
                AdditionalRoomMasterID = additionalroom.AdditionalRoomMasterID,
            }).ToList();
            var homeDetails = new RoomInfoMappers
            {
                MasterBathCount = (int)roomData.MasterBathCount,
                FullBathCount = (int)roomData.FullBathCount,
                HalfBathCount = (int)roomData.HalfBathCount,
                HasKitchen = (bool)roomData.HasKitchen,
                HasKitchenNook = (bool)roomData.HasKitchenNook,
                HasLaundryRoom = (bool)roomData.HasLaundryRoom,
                Rooms = roomMappers,
                AdditionalRooms = addditionalRoomMappers
            };
            return homeDetails;
        }
        public RoomInfoMappers ManageRoomInformation(RoomInfoMappers roomInfoMappers)
        {
            string sessonId = CommonLogic.GetCurrentSessionId();
            var sessionData = _cottageCareContext.GuestUsers.FirstOrDefault(s => s.SessionId == sessonId);
            var roomsIds = roomInfoMappers.Rooms.Select(r => r.Id).ToList();
            var newRooms = roomInfoMappers.Rooms.Where(r => r.Id == 0).ToList();
            var updateRoomIds = roomInfoMappers.Rooms.Where(r => r.Id != 0).Select(r => r.Id).ToList();
            if (roomInfoMappers != null)
            {
                sessionData.MasterBathCount = roomInfoMappers.MasterBathCount;
                sessionData.FullBathCount = roomInfoMappers.FullBathCount;
                sessionData.HalfBathCount = roomInfoMappers.HalfBathCount;
                sessionData.HasKitchen = roomInfoMappers.HasKitchen;
                sessionData.HasKitchenNook = roomInfoMappers.HasKitchenNook;
                sessionData.HasLaundryRoom = roomInfoMappers.HasLaundryRoom;
                _cottageCareContext.SaveChanges();
            }
            //Deleting rooms
            var recordsToRemove = _cottageCareContext.Rooms.Where(r => r.GuestUserId == sessionData.Id && !roomsIds.Contains(r.Id)).ToList();
            if (recordsToRemove != null && recordsToRemove.Count != 0)
            {
                _cottageCareContext.Rooms.RemoveRange(recordsToRemove);
                _cottageCareContext.SaveChanges();
            }
            //Adding rooms
            if (newRooms != null && newRooms.Count != 0)
            {
                foreach (var roomsData in newRooms)
                {
                    var room = new Room
                    {
                        Id = roomsData.Id,
                        RoomTypeId = roomsData.RoomTypeId,
                        FloorTypeId = roomsData.FloorTypeId,
                        Quantity = roomsData.Quantity,
                        DampMoppedQuantity = roomsData.DampMoppedQuantity,
                        GuestUserId = sessionData.Id,
                    };
                    _cottageCareContext.Rooms.Add(room);
                    _cottageCareContext.SaveChanges();
                }
            }
            //updating rooms
            var roomsToUpdate = _cottageCareContext.Rooms.Where(r => updateRoomIds.Contains(r.Id)).ToList();
            if (roomsToUpdate != null && roomsToUpdate.Count != 0)
            {
                foreach (var room in roomsToUpdate)
                {
                    var updatedRoom = roomInfoMappers.Rooms.FirstOrDefault(r => r.Id == room.Id);

                    if (updatedRoom != null)
                    {
                        room.RoomTypeId = updatedRoom.RoomTypeId;
                        room.FloorTypeId = updatedRoom.FloorTypeId;
                        room.Quantity = updatedRoom.Quantity;
                        room.DampMoppedQuantity = updatedRoom.DampMoppedQuantity;
                    }
                    _cottageCareContext.SaveChanges();
                }
            }
            //Adding, updating and deleting additional room
            var additionalRoomsIds = roomInfoMappers.AdditionalRooms.Select(r => r.Id).ToList();
            var additionalNewRooms = roomInfoMappers.AdditionalRooms.Where(r => r.Id == 0).ToList();
            var additionalupdateRoomIds = roomInfoMappers.AdditionalRooms.Where(r => r.Id != 0).Select(r => r.Id).ToList();
            var additionalToRemove = _cottageCareContext.AdditionalRoomsDetails.Where(r => r.GuestUserId == sessionData.Id && !additionalRoomsIds.Contains(r.Id)).ToList();
            if (additionalToRemove != null && additionalToRemove.Count != 0)
            {
                _cottageCareContext.AdditionalRoomsDetails.RemoveRange(additionalToRemove);
                _cottageCareContext.SaveChanges();
            }
            if (newRooms != null && additionalNewRooms.Count != 0)
            {
                foreach (var additionalRoomsData in additionalNewRooms)
                {
                    var additionalRoom = new AdditionalRoomsDetail
                    {
                        Id = additionalRoomsData.Id,
                        FloorTypeId = additionalRoomsData.FloorTypeId,
                        FloorTypeName = additionalRoomsData.FloorTypeName,
                        AdditionalRoomMasterID = additionalRoomsData.AdditionalRoomMasterID,
                        AdditionalRoomName = additionalRoomsData.AdditionalRoomName,
                        Quantity = additionalRoomsData.Quantity,
                        DampMoppedQuantity = additionalRoomsData.DampMoppedQuantity,
                        GuestUserId = sessionData.Id,
                    };
                    _cottageCareContext.AdditionalRoomsDetails.Add(additionalRoom);
                    _cottageCareContext.SaveChanges();
                }
            }
            var additionalRoomsToUpdate = _cottageCareContext.AdditionalRoomsDetails.Where(r => additionalupdateRoomIds.Contains(r.Id)).ToList();
            if (additionalRoomsToUpdate != null && additionalRoomsToUpdate.Count != 0)
            {
                foreach (var additionalroom in additionalRoomsToUpdate)
                {
                    var updatedAdditionalRoom = roomInfoMappers.AdditionalRooms.FirstOrDefault(r => r.Id == additionalroom.Id);

                    if (updatedAdditionalRoom != null)
                    {
                        additionalroom.FloorTypeId = updatedAdditionalRoom.FloorTypeId;
                        additionalroom.FloorTypeName = updatedAdditionalRoom.FloorTypeName;
                        additionalroom.AdditionalRoomMasterID = updatedAdditionalRoom.AdditionalRoomMasterID;
                        additionalroom.AdditionalRoomName = updatedAdditionalRoom.AdditionalRoomName;
                        additionalroom.Quantity = updatedAdditionalRoom.Quantity;
                        additionalroom.DampMoppedQuantity = updatedAdditionalRoom.DampMoppedQuantity;
                    }
                    _cottageCareContext.SaveChanges();
                }

            }
            return roomInfoMappers;

        }
    }
}
