﻿namespace TestingContextCore.PublicMembers.Exceptions
{
    using System;
    using global::TestingContext.Interface;

    public class RegistrationException : Exception
    {
        public IDiagInfo Diag { get; set; }

        public RegistrationException(string message, IDiagInfo diag, Exception inner = null) : base(message + Environment.NewLine + "Diagnostics: " + diag, inner)
        {
            Diag = diag;
        }
    }
}