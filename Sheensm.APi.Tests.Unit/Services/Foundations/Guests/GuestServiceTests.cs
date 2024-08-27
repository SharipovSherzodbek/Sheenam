﻿//===================================================
// Copyright(c) Coalition of Good-Hearted Engineers
// Free To Use ! For Peace
//===================================================


using FluentAssertions;
using Moq;
using Sheenam.Api.Brokers.Storages;
using Sheenam.Api.Models.Foundations.Guests;
using Sheenam.Api.Service.Foundations.Guests;
using System.ComponentModel.DataAnnotations;
using Tynamix.ObjectFiller;


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

        private static Guest CreateRandomGuest() =>
               CreateGuestFiller(date: GetRandomDateTimeOffset()).Create();

        private static DateTimeOffset GetRandomDateTimeOffset() =>
            new DateTimeRange(earliestDate: new DateTime()).GetValue();

        private static Filler<Guest> CreateGuestFiller(DateTimeOffset date)
        {
            var filler = new Filler<Guest>();

            filler.Setup()
                .OnType<DateTimeOffset>().Use(date);

            return filler;
        }
    }
}
