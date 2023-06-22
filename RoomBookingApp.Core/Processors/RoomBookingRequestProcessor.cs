using RoomBookingApp.Core.Domain;
using RoomBookingApp.Core.Models;
using RoomBookingApp.Core.Services;

namespace RoomBookingApp.Core.Processors
{
    public class RoomBookingRequestProcessor
    {
        private IBookingService _bookingService;

        public RoomBookingRequestProcessor()
        {
        }

        public RoomBookingRequestProcessor(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        public RoomBookingResponse BookRoom(RoomBookingRequest request)
        {
            if(request is null)
                throw new ArgumentNullException(nameof(request));

            _bookingService.Save(CreateRoomBookingObject<RoomBooking>(request));

            return CreateRoomBookingObject<RoomBookingResponse>(request);
        }

        private static TRoomBookingBase CreateRoomBookingObject<TRoomBookingBase>(RoomBookingRequest bookingRequest)
            where TRoomBookingBase : RoomBookingBase, new() 
        {
            return new()
            {
                FullName = bookingRequest.FullName,
                Email = bookingRequest.Email,
                Date = bookingRequest.Date,
            };
        }
    }
}