//===================================================
// Copyright(c) Coalition of Good-Hearted Engineers
// Free To Use ! For Peace
//===================================================


using FluentAssertions;
using Moq;
using Sheenam.Api.Brokers.Storages;
using Sheenam.Api.Models.Foundations.Guest;
using Sheenam.Api.Service.Foundations.Guests;
using System.ComponentModel.DataAnnotations;


namespace Sheenam.APi.Tests.Unit.Services.Foundations.Guests
{
    public partial class GuestServiceTests
    {
        private readonly Mock<IStorageBroker> storageBrokerMock;
        private readonly IGuestService guestServiceMock;

        public GuestServiceTests()
        {
            this.storageBrokerMock = new Mock<IStorageBroker>();

            this.guestServiceMock =
                new GuestService(storageBroker: this.storageBrokerMock.Object); 
        }

        [Fact]
        public async Task ShouldAddGuestAsync()
        {

            //Arrange
            Guest randomGuest = new Guest
            {
                FirstName = "Nursultan",
                LastName = "Hongyon",
                Address = "Chust Str 45",
                DateOfBirth = new DateTimeOffset(),
                Email = "helic@gmail.com",
                Gender = GenderType.Male,
                Id = Guid.NewGuid(),
                PhoneNumber = "54545431656"
            };

            this.storageBrokerMock.Setup(broker =>
                broker.InsertGuestsAsync(randomGuest)).ReturnsAsync(randomGuest);
            //Act
            Guest actual = await this.guestServiceMock.AddGuestAsync(randomGuest);
            
            //Assert
            actual.Should().BeEquivalentTo(randomGuest);
        }
    }
}
