﻿//===================================================
// Copyright(c) Coalition of Good-Hearted Engineers
// Free To Use ! For Peace
//===================================================


using System.Data;
using Moq;
using Sheenam.Api.Models.Foundations.Guests;
using Sheenam.Api.Models.Foundations.Guests.Exceptions;


namespace Sheenam.APi.Tests.Unit.Services.Foundations.Guests
{
    public partial class GuestServiceTests
    {

        [Fact]
        public async Task ShouldThrowValidationExceptionOnAddIfGuestIsNullAndLogItAsync()
        {
            // given
            Guest nullGuest = null;
            var nullGuestException = new NullGuestException();

            var expectedGuestValidationException =
                new GuestValidationException(nullGuestException);

            // when
            ValueTask<Guest> addGuestTask = 
                this.guestService.AddGuestAsync(nullGuest);

            // then
            await Assert.ThrowsAsync<GuestValidationException>(() => 
                addGuestTask.AsTask());

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(expectedGuestValidationException))), 
                    Times.Once);

            this.storageBrokerMock.Verify(broker =>
                broker.InsertGuestsAsync(It.IsAny<Guest>()),
                    Times.Never);

            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();

        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async Task ShouldThrowValidationExceptionOnAddIfGuestIsInvalidAndLogItAsync(
            string invalidText)
        {
            //given
            var invalidGuest = new Guest{ FirstName = invalidText };

            var invalidGuestException = new InvalidGuestException();

            invalidGuestException.AddData(key: nameof(Guest.Id), values: "Id is required");
            invalidGuestException.AddData(key: nameof(Guest.FirstName), values: "Text is required");
            invalidGuestException.AddData(key: nameof(Guest.LastName), values: "Text is required");
            invalidGuestException.AddData(key: nameof(Guest.DateOfBirth), values: "Date is required");
            invalidGuestException.AddData(key: nameof(Guest.Email), values: "Email is required");
            invalidGuestException.AddData(key: nameof(Guest.Address), values: "Text is required");

            var expectedGuestValidationException = 
                new GuestValidationException(invalidGuestException);

            //when
            ValueTask<Guest> addGuestTask = this.guestService.AddGuestAsync(invalidGuest);

            //then
            await Assert.ThrowsAsync<GuestValidationException>(() => addGuestTask.AsTask());

            this.loggingBrokerMock.Verify(broker => 
                broker.LogError(It.Is(SameExceptionAs(expectedGuestValidationException))), 
                    Times.Once);

            this.storageBrokerMock.Verify(broker => 
                broker.InsertGuestsAsync(It.IsAny<Guest>()), 
                    Times.Never);
            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
        }




    }
}
