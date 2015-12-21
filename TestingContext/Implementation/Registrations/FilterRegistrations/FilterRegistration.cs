﻿namespace TestingContextCore.Implementation.Registrations.FilterRegistrations
{
    using System;
    using TestingContextCore.Implementation.Filters;
    using TestingContextCore.Implementation.Filters.Groups;

    internal class FilterRegistration : IFilterRegistration
    {
        private readonly Func<IFilter> filterConstructor;

        public FilterRegistration(Func<IFilter> filterConstructor)
        {
            this.filterConstructor = filterConstructor;
        }

        public IFilter GetFilter(IFilterGroup group) => filterConstructor();
    }
}