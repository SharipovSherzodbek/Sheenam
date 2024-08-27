//===================================================
// Copyright(c) Coalition of Good-Hearted Engineers
// Free To Use ! For Peace
//===================================================

using Sheenam.Api.Brokers.Storages;
using Sheenam.Api.Models.Foundations.Guest;
using System;
using System.Threading.Tasks;

namespace Sheenam.Api.Service.Foundations.Guests
{
    public class GuestService : IGuestService
    {
        private readonly IStorageBroker storageBroker;

        public GuestService(IStorageBroker storageBroker) =>
            this.storageBroker = storageBroker;
        public async ValueTask<Guest> AddGuestAsync(Guest guest) =>
            await this.storageBroker.InsertGuestsAsync(guest);
            
    }
}
