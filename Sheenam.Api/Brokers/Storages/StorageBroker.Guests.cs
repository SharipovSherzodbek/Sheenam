//===================================================
// Copyright(c) Coalition of Good-Hearted Engineers
// Free To Use
//===================================================

using Microsoft.EntityFrameworkCore;
using Sheenam.Api.Models.Foundations.Guests;

namespace Sheenam.Api.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet <Guests> Guests { get; set; }
    }
}
