using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sheenam.Api.Models.Foundations.Guests;
using Sheenam.Api.Models.Foundations.Guests.Exceptions;

namespace Sheensm.APi.Tests.Unit.Services.Foundations.Guests
{
    public partial class GuestServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidationExceptionOnAddIfGuestIsNullAndLogItAsync()
        {
            //given
            Guest nullGuest = null;
            var nullGuestException = new NullGuestException();

            var expectedGuestValidationException = new GuestValidationException(nullGuestException);

            //when
            ValueTask<Guest> addGuestTask = this.guestService.AddGuestAsync(nullGuest);


            //then
            await Assert.ThrowsAsync<GuestValidationException>(() => addGuestTask.AsTask());

        }
    }
}
