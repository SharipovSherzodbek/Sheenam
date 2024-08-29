//===================================================
// Copyright(c) Coalition of Good-Hearted Engineers
// Free To Use ! For Peace
//===================================================

using System.Threading.Tasks;
using Sheenam.Api.Models.Foundations.Guests;

namespace Sheenam.Api.Service.Foundations.Guests
{
    public interface IGuestService
    {
        ValueTask<Guest>  AddGuestAsync(Guest guest);

    }
}
