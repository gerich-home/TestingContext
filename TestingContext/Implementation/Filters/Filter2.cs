﻿namespace TestingContextCore.Implementation.Filters
{
    using System;
    using TestingContextCore.Implementation.ContextStorage;
    using TestingContextCore.Interfaces;

    internal class Filter2<T1, T2> : IFor<T1, T2>, IFilter
    {
        private readonly string key1;
        private readonly string key2;
        private readonly ContextStore store;
        private Func<T1, T2, bool> filter;

        public Filter2(string key1, string key2, ContextStore store)
        {
            this.key1 = key1;
            this.key2 = key2;
            this.store = store;
        }

        public void Filter(Func<T1, T2, bool> filterFunc)
        {
            filter = filterFunc;
            store.RegisterFilter(this);
        }

        public EntityDefinition[] EntityDefinitions
        {
            get
            {
                return new[] { new EntityDefinition(typeof(T1), key1), new EntityDefinition(typeof(T2), key2) };
            }
        }
    }
}
