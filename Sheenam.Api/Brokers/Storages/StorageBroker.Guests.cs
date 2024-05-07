//===================================================
// Copyright(c) Coalition of Good-Hearted Engineers
// Free To Use ! For Peace
//===================================================

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Sheenam.Api.Models.Foundations.Guests;
using System.Threading.Tasks;

namespace Sheenam.Api.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet <Guests> Guests { get; set; }

        public async ValueTask<Guests> InsertGuestsAsync(Guests guests) 
        {
            using var broker = new StorageBroker(this.configuration);

            EntityEntry<Guests> guestEntityEntry =
                await broker.Guests.AddAsync(guests);

            await broker.SaveChangesAsync();

            return guestEntityEntry.Entity;
        }
    }
}
