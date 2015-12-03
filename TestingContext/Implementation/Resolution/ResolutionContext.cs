﻿namespace TestingContextCore.Implementation.Resolution
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using TestingContext.Interface;
    using TestingContext.LimitedInterface;
    using TestingContextCore.Implementation.Filters;
    using TestingContextCore.Implementation.Logging;
    using TestingContextCore.Implementation.Nodes;
    using TestingContextCore.Implementation.Registrations;
    using TestingContextCore.UsefulExtensions;

    internal class ResolutionContext<T> : IResolutionContext<T>, IResolutionContext
    {
        private readonly IResolutionContext parent;
        private readonly TokenStore store;
        private Dictionary<IToken, IEnumerable<IResolutionContext>> childResolutions 
            = new Dictionary<IToken, IEnumerable<IResolutionContext>>();
        private int[] failureWeight;
        private IFilter failure;

        public ResolutionContext(T value,
            INode node,
            IResolutionContext parent,
            TokenStore store)
        {
            Value = value;
            Node = node;
            this.parent = parent;
            this.store = store;
            Evaluate();
        }

        public void Evaluate()
        {
            childResolutions = new Dictionary<IToken, IEnumerable<IResolutionContext>>();
            MeetsConditions = Node.FilterInfo.ItemFilter.MeetsCondition(this, out failureWeight, out failure);
        }

        public bool MeetsConditions { get; private set; }

        public INode Node { get; }

        public T Value { get; }

        public IEnumerable<IResolutionContext<TOther>> Get<TOther>(IToken<TOther> token)
        {
            return GetFromTree(token)
                .Distinct()
                .Cast<IResolutionContext<TOther>>();
        }

        public IEnumerable<IResolutionContext<TOther>> Get<TOther>(string name)
        {
            return Get(store.GetToken<TOther>(name));
        }

        #region after cache methods
        public IEnumerable<IResolutionContext> ResolveDown(IToken token, List<INode> chain, int index)
        {
            var nextNode = chain[index];
            var resolution = GetChildResolution(nextNode);
            if (token == nextNode.Token)
            {
                return resolution;
            }

            return resolution
                .Where(x => x.MeetsConditions)
                .SelectMany(x => x.ResolveDown(token, chain, index + 1));
        }

        public IResolutionContext ResolveSingle(IToken token) => token == Node.Token ? this : parent.ResolveSingle(token);

        public IEnumerable<IResolutionContext> ResolveFromClosestParent(IToken token, IToken parentToken)
        {
            return parentToken == Node.Token 
                ? GetFromTree(token) 
                : parent.ResolveFromClosestParent(token, parentToken);
        }
        #endregion

        public IEnumerable<IResolutionContext> GetFromTree(IToken token)
        {
            return Node.Resolver.GetFitItems(token, this);
        }

        private IEnumerable<IResolutionContext> GetChildResolution(INode nextNode)
        {
            return childResolutions.GetOrAdd(nextNode.Token, () => nextNode.Provider.Resolve(this, nextNode));
        }

        public void ReportFailure(FailureCollect collect, int[] startingWeight)
        {
            collect.ReportFailure(startingWeight.Add(0).Add(failureWeight), failure);
            var children = childResolutions.Values.ToArray();
            for (int i = 0; i < children.Length; i++)
            {
                if (children[i].Any(x => x.MeetsConditions))
                {
                    continue;
                }

                var cascadeWeight = startingWeight.Add(1, i);
                if (collect.CanCascade(cascadeWeight))
                {
                    foreach (var item in children[i])
                    {
                       item.ReportFailure(collect, cascadeWeight);   
                    }
                }
            }
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as ResolutionContext<T>);
        }

        protected bool Equals(ResolutionContext<T> other)
        {
            return other != null && ReferenceEquals(Value, other.Value);
        }

        public override int GetHashCode()
        {
            return RuntimeHelpers.GetHashCode(Value);
        }
    }
}