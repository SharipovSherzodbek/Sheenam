//===================================================
// Copyright(c) Coalition of Good-Hearted Engineers
// Free To Use ! For Peace
//===================================================

using Sheenam.Api.Models.Foundations.Guest;
using System.Threading.Tasks;

namespace Sheenam.Api.Service.Foundations.Guests
{
    public interface IGuestService
    {
        ValueTask<Guest> AddGuestAsync(Guest guest);

    }
}
