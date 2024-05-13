//===================================================
// Copyright(c) Coalition of Good-Hearted Engineers
// Free To Use ! For Peace
//===================================================

using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Sheenam.Api.Models.Foundations.Guest;
using Xunit;

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
            Guest returningGuest = inputGuest;
            Guest expectedGuest = returningGuest;

            this.storageBrokerMock.Setup(broker =>
            broker.InsertGuestsAsync(inputGuest)).ReturnsAsync(inputGuest);

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
