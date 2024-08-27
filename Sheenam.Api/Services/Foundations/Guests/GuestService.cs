//===================================================
// Copyright(c) Coalition of Good-Hearted Engineers
// Free To Use
//===================================================


using Sheenam.Api.Brokers.Storages;
using Sheenam.Api.Models.Foundations.Guests;
using System;
using System.Threading.Tasks;

namespace Sheenam.Api.Services.Foundations.Guests
{
    public class GuestService : IGuestService
    {
        private readonly IStorageBroker _storageBroker;

        public GuestService(IStorageBroker storageBroker)
        {
            _storageBroker = storageBroker;
        }

        public ValueTask<Guest> AddGuestAsync(Guest guest) =>
             throw new NotImplementedException();
        
    }
}
