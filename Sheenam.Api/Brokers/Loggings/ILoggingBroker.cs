//===================================================
// Copyright(c) Coalition of Good-Hearted Engineers
// Free To Use
//==============================================

using System;

namespace Sheenam.Api.Brokers.Loggings
{
    public interface ILoggingBroker
    {
        void LogError(Exception exception);

        void LogCritical(Exception exception);




    }
}
