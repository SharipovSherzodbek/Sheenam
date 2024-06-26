﻿using Sheenam.Api.Models.Foundations.Guests;
using System.Threading.Tasks;

namespace Sheenam.Api.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        //Create //Read //Update //Delete
        ValueTask <Guests> InsertGuestsAsync (Guests guests);
    }
}
