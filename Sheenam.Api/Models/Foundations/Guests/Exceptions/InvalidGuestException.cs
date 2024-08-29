//===================================================
// Copyright(c) Coalition of Good-Hearted Engineers
// Free To Use
//===================================================


using Xeptions;

namespace Sheenam.Api.Models.Foundations.Guests.Exceptions
{
    public class InvalidGuestException: Xeption
    {
        public InvalidGuestException() :base(message: "Guest is invalid") 
        {
            
        }

    }
}
