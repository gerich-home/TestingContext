﻿namespace TestingContextCore.Implementation.TreeOperation.Subsystems
{
    using System.Collections.Generic;
    using System.Linq;
    using TestingContextCore.Implementation.Dependencies;
    using TestingContextCore.Implementation.Filters;
    using TestingContextCore.Implementation.Nodes;
    using TestingContextCore.Implementation.Registration;
    using static FilterProcessingService;
    using static NodeReorderingService;

    internal static class FilterAssignmentService
    {
        public static INode GetAssignmentNode(Tree tree, IHaveDependencies have)
        {
            return have.Dependencies
                       .Select(x => x.GetDependencyNode(tree))
                       .OrderByDescending(x => x.GetParentalChain().Count)
                       .First();
        }

        public static void AssignFilter(TokenStore store, IFilter filter)
        {
            if (!filter.Dependencies.Any() || store.DisabledFilter == filter.Token)
            {
                return;
            }

            var node = GetAssignmentNode(store.Tree, filter);
            node.FilterInfo.Group.Filters.Add(filter);
        }

        public static void AssignFilters(TokenStore store)
        {
            var freeFilters = new List<IFilter>();
            foreach (var filter in store.Filters)
            {
                ProcessFilterGroup(filter as IFilterGroup, freeFilters, store);
                AddFilter(filter, freeFilters, store);
            }

            freeFilters.ForEach(x => ReorderNodes(store, x));
            freeFilters.ForEach(x => AssignFilter(store, x));
        }
    }
}
