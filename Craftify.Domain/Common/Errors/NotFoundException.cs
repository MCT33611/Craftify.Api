﻿

namespace Craftify.Domain.Common.Errors
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message) { }
    }
}
