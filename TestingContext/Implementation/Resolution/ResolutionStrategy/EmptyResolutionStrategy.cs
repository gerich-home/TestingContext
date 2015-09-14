﻿namespace TestingContextCore.Implementation.Resolution.ResolutionStrategy
{
    using System.Collections.Generic;
    using TestingContextCore.Implementation.ResolutionContext;
    using TestingContextCore.Interfaces;

    internal class EmptyResolutionStrategy : IResolutionStrategy
    {
        public bool MeetsCondition<T>(IEnumerable<IInternalResolutionContext<T>> source)
        {
            return true;
        }
    }
}
