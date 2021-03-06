﻿namespace TestingContextCore.Implementation.Nodes
{
    using System.Collections.Generic;
    using TestingContextCore.Implementation.Filters.Groups;
    using TestingContextCore.Implementation.Providers;
    using TestingContextCore.Implementation.TreeOperation;
    using TestingContextLimitedInterface.Tokens;

    internal class RootNode : INode
    {
        public RootNode(Tree tree, IToken token )
        {
            Tree = tree;
            Token = token;
            Resolver = new NodeResolver(this);
        }

        public int Weight { get; set; } = 0;

        public Tree Tree { get; }

        public IToken Token { get; }

        public INode SourceParent { get; set; }

        public INode Parent { get; set; }

        public AndGroup Filters { get; } = new AndGroup();

        public NodeResolver Resolver { get; }

        public List<INode> Children => null;

        public NodeFilterInfo FilterInfo { get; } = new NodeFilterInfo(null, null);

        public IProvider Provider => null;

        public bool IsNegative => false;

        public bool IsChildOf(INode node) => false;

        public List<INode> GetParentalChain() => new List<INode> { this };

        public List<INode> GetSourceChain() => new List<INode> { this };

        public override string ToString() => "root node";
    }
}
