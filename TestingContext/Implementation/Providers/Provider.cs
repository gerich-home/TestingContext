﻿namespace TestingContextCore.Implementation.Providers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TestingContextCore.Implementation.Dependencies;
    using TestingContextCore.Implementation.Registrations;
    using TestingContextCore.Implementation.ResolutionContext;
    using TestingContextCore.Implementation.TreeOperation.Nodes;

    internal class Provider<TSource, T> : IProvider
    {
        private readonly IDependency<TSource> dependency;
        private readonly Func<TSource, IEnumerable<T>> sourceFunc;

        public Provider(IDependency<TSource> dependency,
            Func<TSource, IEnumerable<T>> sourceFunc)
        {
            this.dependency = dependency;
            this.sourceFunc = sourceFunc;
        }

        public IDependency Dependency => dependency;

        public IEnumerable<IResolutionContext> Resolve(IResolutionContext parentContext, INode node)
        {
            TSource sourceValue;
            if (!dependency.TryGetValue(parentContext, node.Resolver, out sourceValue))
            {
                return Enumerable.Empty<IResolutionContext>();
            }

            var source = sourceFunc(sourceValue) ?? Enumerable.Empty<T>();
            return source
                .Select(x => new ResolutionContext<T>(x, node, parentContext))
                .Cache();
        }
    }
}
