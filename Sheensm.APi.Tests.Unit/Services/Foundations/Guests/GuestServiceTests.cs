//===================================================
// Copyright(c) Coalition of Good-Hearted Engineers
// Free To Use ! For Peace
//===================================================

using System.Linq.Expressions;
using System.Runtime.Serialization;
using Microsoft.Data.SqlClient;
using Moq;
using Sheenam.Api.Brokers.Loggings;
using Sheenam.Api.Brokers.Storages;
using Sheenam.Api.Models.Foundations.Guests;
using Sheenam.Api.Service.Foundations.Guests;
using Tynamix.ObjectFiller;
using Xeptions;


namespace Sheenam.APi.Tests.Unit.Services.Foundations.Guests
{
    public partial class GuestServiceTests
    {
        private readonly Mock<IStorageBroker> storageBrokerMock;
        private readonly Mock<ILoggingBroker> loggingBrokerMock;
        private readonly IGuestService guestService;    

        public GuestServiceTests()
        {
            this.storageBrokerMock = new Mock<IStorageBroker>();
            this.loggingBrokerMock = new Mock<ILoggingBroker>();

            this.guestService = new GuestService(
                storageBroker: this.storageBrokerMock.Object, 
                loggingBroker: this.loggingBrokerMock.Object);
        }

        private static Guest CreateRandomGuest() =>
               CreateGuestFiller(date: GetRandomDateTimeOffset()).Create();

        private static string GetRandomEmail() =>
            new EmailAddresses().GetValue();

        private static DateTimeOffset GetRandomDateTimeOffset() =>
            new DateTimeRange(earliestDate: new DateTime()).GetValue();

        private static int GetRandomNumber() =>
            new IntRange(min: 3, max: 9).GetValue();

        private static SqlException GetSqlError() =>
            (SqlException)FormatterServices.GetUninitializedObject(typeof(SqlException));

        private static T GetInvalidEnum<T>()
        {
            int randomNumber = GetRandomNumber();

            while(Enum.IsDefined(typeof(T), randomNumber) is true)
            {
                randomNumber = GetRandomNumber();
            }

            return (T)(object)randomNumber;
        }

        private Expression<Func<Xeption, bool>> SameExceptionAs(Xeption expectedException) =>
            actualException => actualException.SameExceptionAs(expectedException);

        private static Filler<Guest> CreateGuestFiller(DateTimeOffset date)
        {
            var filler = new Filler<Guest>();

            filler.Setup()
                .OnProperty(guest => guest.Email).Use(GetRandomEmail())
                .OnType<DateTimeOffset>().Use(date);

            return filler;
        }
    }
}
