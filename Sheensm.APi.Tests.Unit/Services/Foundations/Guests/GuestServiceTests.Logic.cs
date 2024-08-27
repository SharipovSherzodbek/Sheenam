//===================================================
// Copyright(c) Coalition of Good-Hearted Engineers
// Free To Use ! For Peace
//===================================================

using FluentAssertions;
using Force.DeepCloner;
using Moq;
using Sheenam.Api.Models.Foundations.Guests;

namespace Sheenam.APi.Tests.Unit.Services.Foundations.Guests
{
    public partial class GuestServiceTests
    {

        [Fact]

        public async Task ShouldAddGuestAsync()
        {

            //given
            Guest randomGuest = CreateRandomGuest();
            Guest inputGuest = randomGuest;
            Guest storageGuest = inputGuest;
            Guest expectedGuest = storageGuest.DeepClone();

            this.storageBrokerMock.Setup(broker =>
            broker.InsertGuestsAsync(inputGuest)).ReturnsAsync(storageGuest);

            //when
            Guest actualGuest =
            await this.guestServiceMock.AddGuestAsync(inputGuest);

            //then
            actualGuest.Should().BeEquivalentTo(expectedGuest);

            this.storageBrokerMock.Verify(broker =>
                broker.InsertGuestsAsync(inputGuest), Times.Once());

            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}
