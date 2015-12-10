﻿namespace TestingContextCore.Implementation.Registrations.HighLevel
{
    using System;
    using TestingContext.Interface;
    using TestingContext.LimitedInterface;
    using TestingContextCore.Implementation.Filters;

    internal class InnerHighLevelRegistration
    {
        private readonly TokenStore store;
        private readonly IFilterGroup group;
        private readonly int priority;

        public InnerHighLevelRegistration(TokenStore store, IFilterGroup group, int priority)
        {
            this.store = store;
            this.group = group;
            this.priority = priority;
        }

        public IFilterToken Not(Action<IRegister> action, IDiagInfo diagInfo)
        {
            var notGroup = new NotGroup(diagInfo);
            store.RegisterFilter(notGroup, group);
            RegisterSubgroup(action, notGroup);
            return notGroup.Token;
        }

        public IFilterToken Or(Action<IRegister> action,
            Action<IRegister> action2,
            Action<IRegister> action3,
            Action<IRegister> action4,
            Action<IRegister> action5,
            IDiagInfo diagInfo)
        {
            var orGroup = new OrGroup(diagInfo);
            store.RegisterFilter(orGroup, group);
            RegisterSubgroup(action, orGroup);
            RegisterSubgroup(action2, orGroup);
            RegisterSubgroup(action3, orGroup);
            RegisterSubgroup(action4, orGroup);
            RegisterSubgroup(action5, orGroup);
            return orGroup.Token;
        }

        public IFilterToken Xor(Action<IRegister> action, Action<IRegister> action2, IDiagInfo diagInfo)
        {
            var xorGroup = new XorGroup(diagInfo);
            store.RegisterFilter(xorGroup, group);
            RegisterSubgroup(action, xorGroup);
            RegisterSubgroup(action2, xorGroup);
            return xorGroup.Token;
        }

        private void RegisterSubgroup(Action<IRegister> action, IFilterGroup parentGroup)
        {
            if (action == null)
            {
                return;
            }

            var andGroup = new AndGroup { Id = store.NextId };
            parentGroup.Filters.Add(andGroup);
            action(RegistrationFactory.GetRegistration(store, andGroup, priority));
        }
    }
}