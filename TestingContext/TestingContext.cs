﻿namespace TestingContextCore
{
    using System;
    using System.Collections.Generic;
    using TestingContextCore.Implementation;
    using TestingContextCore.Implementation.ContextStorage;
    using TestingContextCore.Implementation.Filters;
    using TestingContextCore.Implementation.Registrations;
    using TestingContextCore.Implementation.Resolution.ResolutionStrategy;
    using TestingContextCore.Implementation.ResolutionContext;
    using TestingContextCore.Interfaces;
    using static Implementation.Definition;

    public class TestingContext
    {
        private readonly ContextStore store;
        private IResolutionContext rootContext;

        public TestingContext()
        {
            store = new ContextStore();
        }

       public bool Logging { set { store.Logging = value; } }

        public IFor<T> For<T>(string key) where T : class
        {
            return new FilterRegistrator1<T>(key, store);
        }

        public IRegistration<TestingContext> Root()
        {
            return new RootRegistration<TestingContext>(store, store.RootDefinition);
        }

        public IRegistration<TSource> RootResolve<TSource>(string key) where TSource : class
        {
            return new RootRegistration<TSource>(store, Define<TSource>(key));
        }

        public IChildRegistration<T> ExistsFor<T>(string key) where T : class
        {
            var def = Define<T>(key);
            return new DependentRegistration<T>(def, def, store, ResolutionStrategyFactory.Exists());
        }

        public IChildRegistration<T> DoesNotExistFor<T>(string key) where T : class
        {
            var def = Define<T>(key);
            return new DependentRegistration<T>(def, def, store, ResolutionStrategyFactory.DoesNotExist());
        }

        public IChildRegistration<T> EachFor<T>(string key) where T : class
        {
            var def = Define<T>(key);
            return new DependentRegistration<T>(def, def, store, ResolutionStrategyFactory.Each());
        }

        public IEnumerable<IResolutionContext<T>> All<T>(string key)
        {
            rootContext = rootContext ?? new RootResolutionContext(store.RootDefinition, this, store);
            store.ValidateDependencies();
            store.ResolutionStarted = true;
            return rootContext.Resolve(Define<T>(key)) as IEnumerable<IResolutionContext<T>>;
        }

        public T Value<T>(string key)
            where T : class
        {
            return store.LoggedFirstOrDefault(All<T>(key))?.Value;
        }
    }
}