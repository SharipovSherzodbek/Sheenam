//===================================================
// Copyright(c) Coalition of Good-Hearted Engineers
// Free To Use
//===================================================


using System;
using Xeptions;

namespace Sheenam.Api.Models.Foundations.Guests.Exceptions
{
    public class FailedGuestServiceException : Xeption
    {
        public FailedGuestServiceException(Exception innnerException)
            : base(message: "Failed guest service error occured, contact support", 
                  innnerException)
        {}
    }
}
