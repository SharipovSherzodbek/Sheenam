//===================================================
// Copyright(c) Coalition of Good-Hearted Engineers
// Free To Use
//===================================================


using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;
using RESTFulSense.Models.Attributes;
using Sheenam.Api.Models.Foundations.Guests;
using Sheenam.Api.Models.Foundations.Guests.Exceptions;
using Sheenam.Api.Service.Foundations.Guests;

namespace Sheenam.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GuestsController : RESTFulController
    {
        private readonly IGuestService guestService;

        public GuestsController(IGuestService guestService)
        {
            this.guestService = guestService;
        }

        [HttpPost]
        public async ValueTask<ActionResult<Guest>> PostGuestAsync(Guest guest)
        {
            try
            {
                Guest postdGuest = await this.guestService.AddGuestAsync(guest);

                return Created(postdGuest);
            }
            catch(GuestValidationException guestValidationException)
            {
                return BadRequest(guestValidationException.InnerException);
            }

           catch(GuestDependencyValidationException guestDependencyValidationException)
                when(guestDependencyValidationException.InnerException is AlreadyExistGuestException)
            {
                return Conflict(guestDependencyValidationException.InnerException);
            }

            catch(GuestDependencyValidationException guestDependencyValidationException)
            {
                return BadRequest(guestDependencyValidationException.InnerException);
            }

            catch(GuestDependencyException guestDependencyException)
            {
                return InternalServerError(guestDependencyException.InnerException);
            }

            catch(GuestServiceException guestServiceException)
            {
                return InternalServerError(guestServiceException.InnerException);
            }
        }

    }
}
