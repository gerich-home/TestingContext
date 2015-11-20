﻿namespace TestingContextCore.Implementation.Filters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TestingContextCore.Implementation.Dependencies;
    using TestingContextCore.Implementation.Nodes;
    using TestingContextCore.Implementation.ResolutionContext;
    using TestingContextCore.Interfaces;

    internal class NotGroup : IFilterGroup
    {
        private readonly AndGroup andGroup = new AndGroup();

        public void AddFilter(IFilter filter) => andGroup.AddFilter(filter);

        #region IFilter
        public IDependency[] Dependencies => andGroup.Dependencies;

        public IFilterGroup Group => null;

        public bool MeetsCondition(IResolutionContext context, NodeResolver resolver, out int[] failureWeight, out IFailure failure)
        {
            failureWeight = FilterConstant.EmptyArray;
            failure = andGroup;
            IFailure innerFailure;
            int[] innerWeight;
            return !andGroup.MeetsCondition(context, resolver, out innerWeight, out innerFailure);
        }
        #endregion

        #region IFailure members
        public IEnumerable<string> Definitions => Dependencies.Select(x => x.Definition.ToString());

        public string FilterString => "NOT-AND group" + Environment.NewLine + andGroup.FilterString;

        public string Key => null;
        #endregion
    }
}
