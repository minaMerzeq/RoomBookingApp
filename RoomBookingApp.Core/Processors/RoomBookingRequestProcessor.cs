using RoomBookingApp.Core.Models;

namespace RoomBookingApp.Core.Processors
{
    public class RoomBookingRequestProcessor
    {
        public RoomBookingRequestProcessor()
        {
        }

        public RoomBookingResponse BookRoom(RoomBookingRequest request) =>
            new RoomBookingResponse
            {
                FullName = request.FullName,
                Email = request.Email,
                Date = request.Date,
            };

    }
}