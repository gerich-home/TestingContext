﻿namespace TestingContextCore.Implementation.Registrations.FilterRegistrations
{
    using System;
    using TestingContextCore.Implementation.Filters;

    internal class FilterRegistration
    {
        private readonly Func<IFilter> filterConstructor;

        public FilterRegistration(Func<IFilter> filterConstructor)
        {
            this.filterConstructor = filterConstructor;
        }

        public IFilter GetFilter() => filterConstructor();
    }
}
