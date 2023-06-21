using RoomBookingApp.Core.Models;
using RoomBookingApp.Core.Processors;
using Shouldly;

namespace RoomBookingApp.Core
{
    public class RoomBookingRequestProcessorTest
    {
        private readonly RoomBookingRequestProcessor _processor;

        public RoomBookingRequestProcessorTest()
        {
            _processor = new RoomBookingRequestProcessor();
        }

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

            // Act
            RoomBookingResponse response = _processor.BookRoom(request);

            // Assert
            response.ShouldNotBeNull();
            response.FullName.ShouldBe(request.FullName);
            response.Email.ShouldBe(request.Email);
            response.Date.ShouldBe(request.Date);
        }

        [Fact]
        public void Should_Throw_Null_Exception_For_Null_Request()
        {
            var exception = Should.Throw<ArgumentNullException>(() => _processor.BookRoom(null));
            exception.ParamName.ShouldBe("request");
        }
    }
}
