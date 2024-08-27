using System.Threading.Tasks;
using Sheenam.Api.Models.Foundations.Guests;

namespace Sheenam.Api.Brokers.Storages;

public partial interface IStorageBroker
{
    // Create // Read // Update // Delete
    ValueTask<Guest> InsertGuestsAsync(Guest guest);
}

