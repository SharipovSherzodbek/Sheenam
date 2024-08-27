using Sheenam.Api.Models.Foundations.Guest;
using System.Threading.Tasks;

namespace Sheenam.Api.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        //Create //Read //Update //Delete
        ValueTask <Guest> InsertGuestsAsync (Guest guests);
    }
}
