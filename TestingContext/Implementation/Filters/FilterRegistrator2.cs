﻿namespace TestingContextCore.Implementation.Filters
{
    using System;
    using TestingContextCore.Implementation.ContextStorage;
    using TestingContextCore.Implementation.Dependencies;
    using TestingContextCore.Interfaces;
    using static Definition;

    internal class FilterRegistrator2<T1, T2> : IWith<T1, T2>
        where T1 : class
        where T2 : class
    {
        private readonly IDependency<T1> dependency1;
        private readonly ContextStore store;
        private readonly IDependency<T2> dependency2;

        public FilterRegistrator2(IDependency<T1> dependency1, string key2, ContextStore store)
        {
            this.dependency1 = dependency1;
            dependency2 = store.Depend<T2>(dependency1.DependsOn, Define<T2>(key2));
            this.store = store;
        }

        public void Filter(Func<T1, T2, bool> filterFunc)
        {
            store.RegisterFilter(dependency1.DependsOn, new Filter2<T1, T2>(dependency1, dependency2, filterFunc));
        }
    }
}
