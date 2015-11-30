﻿namespace TestingContextCore.Implementation.Resolution
{
    using System.Collections.Generic;
    using TestingContext.LimitedInterface;
    using TestingContextCore.Implementation.Logging;
    using TestingContextCore.Implementation.Nodes;
    internal interface IResolutionContext : IFailureReporter
    {
        bool MeetsConditions { get; }

        INode Node { get; }

        #region after cache methods
        IEnumerable<IResolutionContext> ResolveDown(IToken token, List<INode> chain, int index);

        IResolutionContext ResolveSingle(IToken token);

        IEnumerable<IResolutionContext> ResolveFromClosestParent(IToken token, IToken parent);
        #endregion

        #region cached method
        IEnumerable<IResolutionContext> GetFromTree(IToken token);
        #endregion
    }
}
