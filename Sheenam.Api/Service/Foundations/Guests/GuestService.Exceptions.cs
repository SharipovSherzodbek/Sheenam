﻿//===================================================
// Copyright(c) Coalition of Good-Hearted Engineers
// Free To Use
//===================================================

using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Sheenam.Api.Models.Foundations.Guests;
using Sheenam.Api.Models.Foundations.Guests.Exceptions;
using Xeptions;

namespace Sheenam.Api.Service.Foundations.Guests
{
    public partial class GuestService
    {
        private delegate ValueTask<Guest> ReturningGuestFunction();

        private async ValueTask<Guest> TryCatch(ReturningGuestFunction returningGuestFunction)
        {
            try
            {
                return await returningGuestFunction();
            }

            catch(NullGuestException nullGuestException)
            {
               throw CreateAndLogValidationException(nullGuestException);
            }

            catch(InvalidGuestException invalidGuestException)
            {
                throw CreateAndLogValidationException(invalidGuestException);
            }
            catch(SqlException sqlException) 
            {
                var failedGuestStorageException = new FailedGuestStorageException(sqlException);

                throw CreateAndLogCriticalDependencyException(failedGuestStorageException);
            }
        }

        private GuestValidationException CreateAndLogValidationException(Xeption exception)
        {
            var guestValidationException = new GuestValidationException(exception);

             this.loggingBroker.LogError(guestValidationException);

            return guestValidationException;
        }

        private GuestDependencyException CreateAndLogCriticalDependencyException(Xeption exception)
        {
            var guestDependencyException = new GuestDependencyException(exception);

            this.loggingBroker.LogCritical(guestDependencyException);

            return guestDependencyException;
        }
    }
}
