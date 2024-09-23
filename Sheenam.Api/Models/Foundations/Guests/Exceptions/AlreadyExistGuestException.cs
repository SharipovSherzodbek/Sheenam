﻿//===================================================
// Copyright(c) Coalition of Good-Hearted Engineers
// Free To Use
//===================================================


using System;
using Xeptions;

namespace Sheenam.Api.Models.Foundations.Guests.Exceptions
{
    public class AlreadyExistGuestException : Xeption
    {
        public AlreadyExistGuestException(Exception innerException)
            : base(message: "Guest already exists", innerException)
        { }
    }
}
