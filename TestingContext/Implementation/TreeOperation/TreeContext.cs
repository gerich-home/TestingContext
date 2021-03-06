﻿namespace TestingContextCore.Implementation.TreeOperation
{
    using System;
    using System.Collections.Generic;
    using TestingContextCore.Implementation.Dependencies;
    using TestingContextCore.Implementation.Filters;
    using TestingContextCore.Implementation.Filters.Groups;
    using TestingContextCore.Implementation.Registrations;
    using TestingContextLimitedInterface.Tokens;

    internal class TreeContext
    {
        private int currentId = 1;

        public int NextId => currentId++;

        public Tree Tree { get; set; }

        public TokenStore Store { get; set; }

        public Dictionary<IToken, HashSet<IToken>> Parents { get; } = new Dictionary<IToken, HashSet<IToken>>();

        public List<IFilter> Filters { get; set; }

        public Dictionary<IFilterToken, IFilterGroup> Groups { get; set; }

        public Dictionary<IFilterToken, List<IFilter>> FiltersInGroup { get; set; }

        public Dictionary<IFilterToken, List<IFilter>> AllFiltersInGroup { get; } 
            = new Dictionary<IFilterToken, List<IFilter>>();

        public Dictionary<IFilterToken, List<IToken>> ProviderTokensInGroup { get; set; }

        public Dictionary<IFilterToken, List<IToken>> AllProviderTokensInGroup { get; } 
            = new Dictionary<IFilterToken, List<IToken>>();


        // used to avoid assigning two or more equal filters to the same pair of nodes
        public HashSet<Tuple<IToken, IToken>> NonEqualFilters { get; } = new HashSet<Tuple<IToken, IToken>>();

        // used to avoid same dependency increase weight several times
        public HashSet<IDependency> WeightedDependencies { get; } = new HashSet<IDependency>();
    }
}
