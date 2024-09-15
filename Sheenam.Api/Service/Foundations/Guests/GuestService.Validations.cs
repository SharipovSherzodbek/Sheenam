//===================================================
// Copyright(c) Coalition of Good-Hearted Engineers
// Free To Use
//===================================================

using System;
using System.Text.RegularExpressions;
using Sheenam.Api.Models.Foundations.Guests;
using Sheenam.Api.Models.Foundations.Guests.Exceptions;

namespace Sheenam.Api.Service.Foundations.Guests
{
    public partial class GuestService
    {
        private void ValidateGuestOnAdd(Guest guest)
        {
            ValidateGuestNotNull(guest);

            Validate(
                (Rule: IsInvalid(guest.Id), Paremeter: nameof(Guest.Id)),
                (Rule: IsInvalid(guest.FirstName), Paremeter: nameof(Guest.FirstName)),
                (Rule: IsInvalid(guest.LastName), Paremeter: nameof(Guest.LastName)),
                (Rule: IsInvalid(guest.DateOfBirth), Paremeter: nameof(Guest.DateOfBirth)),
                (Rule: IsEmailInvalid(guest.Email), Paremeter: nameof(Guest.Email)),
                (Rule: IsInvalid(guest.Address), Paremeter: nameof(Guest.Address))
                );
        }

        private void ValidateGuestNotNull(Guest guest)
        {
            if (guest is null)
            {
                throw new NullGuestException();
            }

        }

        private static dynamic IsInvalid(Guid id) => new
        {
            Condition = id == Guid.Empty,
            Message = "Id is required"
        };

        private static dynamic IsInvalid(string text) => new
        {
            Condition = string.IsNullOrWhiteSpace(text),
            Message = "Text is required"
        };

        private static dynamic IsInvalid(DateTimeOffset date) => new
        {
            Condition = date == default,
            Message = "Date is required"
        };

        private static dynamic IsEmailInvalid(string email) => new
        {
            Condition = !IsValidEmail(email),
            Message = "Email is not valid"
        };

        private static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }

            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern);
        }

        private static void Validate(params (dynamic Rule, string Parameter)[] validations)
        {
            var invalidGuestException = new InvalidGuestException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidGuestException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }

            invalidGuestException.ThrowIfContainsErrors();
        }
    }
}
