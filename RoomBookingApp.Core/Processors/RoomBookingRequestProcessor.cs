using RoomBookingApp.Core.Models;

namespace RoomBookingApp.Core.Processors
{
    public class RoomBookingRequestProcessor
    {
        public RoomBookingRequestProcessor()
        {
        }

        public RoomBookingResponse BookRoom(RoomBookingRequest request)
        {
            if(request is null)
                throw new ArgumentNullException(nameof(request));

            return new()
            {
                FullName = request.FullName,
                Email = request.Email,
                Date = request.Date,
            };
        }
    }
}