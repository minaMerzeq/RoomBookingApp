using Moq;
using RoomBookingApp.Core.Domain;
using RoomBookingApp.Core.Models;
using RoomBookingApp.Core.Processors;
using RoomBookingApp.Core.Services;
using Shouldly;

namespace RoomBookingApp.Core
{
    public class RoomBookingRequestProcessorTest
    {
        private readonly RoomBookingRequestProcessor _processor;
        private readonly RoomBookingRequest _request;
        private readonly Mock<IBookingService> _bookingServiceMock;

        public RoomBookingRequestProcessorTest()
        {
            // Arrange
            _request = new RoomBookingRequest
            {
                FullName = "Test Name",
                Email = "test@gmail.com",
                Date = DateTime.Now,
            };
            _bookingServiceMock = new Mock<IBookingService>();
            _processor = new RoomBookingRequestProcessor(_bookingServiceMock.Object);
        }

        [Fact]
        public void Should_Return_Room_Booking_Response_With_Request_Values()
        {
            // Act
            RoomBookingResponse response = _processor.BookRoom(_request);

            // Assert
            response.ShouldNotBeNull();
            response.FullName.ShouldBe(_request.FullName);
            response.Email.ShouldBe(_request.Email);
            response.Date.ShouldBe(_request.Date);
        }

        [Fact]
        public void Should_Throw_Null_Exception_For_Null_Request()
        {
            var exception = Should.Throw<ArgumentNullException>(() => _processor.BookRoom(null));
            exception.ParamName.ShouldBe("request");
        }

        [Fact]
        public void Should_Save_Booking_Request()
        {
            RoomBooking savedBooking = null;
            _bookingServiceMock.Setup(q => q.Save(It.IsAny<RoomBooking>()))
                .Callback<RoomBooking>(booking => {
                    savedBooking = booking;
                });

            _processor.BookRoom(_request);

            _bookingServiceMock.Verify(q => q.Save(It.IsAny<RoomBooking>()), Times.Once);
            savedBooking.ShouldNotBeNull();
            savedBooking.FullName.ShouldBe(_request.FullName);
            savedBooking.Email.ShouldBe(_request.Email);
            savedBooking.Date.ShouldBe(_request.Date);
        }
    }
}
