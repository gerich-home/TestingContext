﻿namespace TestingContextCore.Implementation.Filters
{
    using System;
    using TestingContextCore.Implementation.Dependencies;
    using TestingContextCore.Implementation.ResolutionContext;

    internal class Filter1<T1> : IFilter
    {
        private readonly IDependency<T1> dependency;
        private readonly Func<T1, bool> filterFunc;

        public Filter1(IDependency<T1> dependency, Func<T1, bool> filterFunc)
        {
            this.dependency = dependency;
            this.filterFunc = filterFunc;
            Definitions = new []{ dependency.DependsOn };
        }

        public bool IsPostFilter => false;
        public bool IsCollectionFilter => dependency.IsCollectionDependency;
        public Definition[] Definitions { get; }

        public bool MeetsCondition(IResolutionContext context)
        {
            return filterFunc(dependency.GetValue(context));
        }
    }
}
