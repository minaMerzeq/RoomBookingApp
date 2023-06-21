using RoomBookingApp.Core.Models;
using RoomBookingApp.Core.Processors;
using Shouldly;

namespace RoomBookingApp.Core
{
    public class RoomBookingRequestProcessorTest
    {
        [Fact]
        public void Should_Return_Room_Booking_Response_With_Request_Values()
        {
            // Arrange
            var request = new RoomBookingRequest
            {
                FullName = "Test Name",
                Email = "test@gmail.com",
                Date = DateTime.Now,
            };

            var processor = new RoomBookingRequestProcessor();

            // Act
            RoomBookingResponse response = processor.BookRoom(request);

            // Assert
            response.ShouldNotBeNull();
            response.FullName.ShouldBe(request.FullName);
            response.Email.ShouldBe(request.Email);
            response.Date.ShouldBe(request.Date);
        }
    }
}
