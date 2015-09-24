﻿namespace TestingContextCore.Implementation.Filters
{
    using System;
    using System.Linq.Expressions;
    using TestingContextCore.Implementation.Dependencies;
    using TestingContextCore.Implementation.ResolutionContext;

    internal class Filter2<T1, T2> : IFilter
    {
        private readonly IDependency<T1> dependency1;
        private readonly IDependency<T2> dependency2;
        private readonly Expression<Func<T1, T2, bool>> filterExpression;
        private readonly Func<T1, T2, bool> filterFunc;

        public Filter2(IDependency<T1> dependency1, IDependency<T2> dependency2, Expression<Func<T1, T2, bool>> filterExpression)
        {
            Definitions = new[] { dependency1.DependsOn, dependency2.DependsOn };
            this.dependency1 = dependency1;
            this.dependency2 = dependency2;
            this.filterExpression = filterExpression;
            this.filterFunc = filterExpression.Compile();
        }

        public Definition[] Definitions { get; }

        public bool IsCollectionFilter => dependency1.IsCollectionDependency;

        public bool MeetsCondition(IResolutionContext context)
        {
            var argument1 = dependency1.GetValue(context);
            T2 argument2;
            return dependency2.TryGetValue(context, out argument2) && filterFunc(argument1, argument2);
        }

        public string FailureString => filterExpression.ToString();
    }
}
