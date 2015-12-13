﻿namespace TestingContextCore.Implementation.Registrations.HighLevel
{
    using System;
    using TestingContext.Interface;
    using TestingContext.LimitedInterface;
    using TestingContextCore.Implementation.Dependencies;
    using TestingContextCore.Implementation.Filters;
    using TestingContextCore.Implementation.Filters.Groups;

    internal class InnerHighLevelRegistration
    {
        private readonly TokenStore store;
        private readonly IFilterGroup group;
        private readonly int priority;
        private readonly IDependency[] dependencies;

        public InnerHighLevelRegistration(TokenStore store, IFilterGroup group, int priority, params IDependency[] dependencies)
        {
            this.store = store;
            this.group = group;
            this.priority = priority;
            this.dependencies = dependencies;
        }

        public IFilterToken Not(Action<IRegister> action, IDiagInfo diagInfo)
        {
            var notGroup = new NotGroup(dependencies, group, diagInfo);
            store.RegisterFilter(notGroup, group);
            action(RegistrationFactory.GetRegistration(store, notGroup, priority));
            return notGroup.Token;
        }

        public IFilterToken Either(Action<IRegister> action,
            Action<IRegister> action2,
            Action<IRegister> action3,
            Action<IRegister> action4,
            Action<IRegister> action5,
            IDiagInfo diagInfo)
        {
            var orGroup = new OrGroup(dependencies, group, diagInfo);
            store.RegisterFilter(orGroup, group);
            RegisterSubgroup(action, orGroup);
            RegisterSubgroup(action2, orGroup);
            CheckAndRegisterSubgroup(action3, orGroup);
            CheckAndRegisterSubgroup(action4, orGroup);
            CheckAndRegisterSubgroup(action5, orGroup);
            return orGroup.Token;
        }

        public IFilterToken Xor(Action<IRegister> action, Action<IRegister> action2, IDiagInfo diagInfo)
        {
            var xorGroup = new XorGroup(dependencies, group, diagInfo);
            store.RegisterFilter(xorGroup, group);
            RegisterSubgroup(action, xorGroup);
            RegisterSubgroup(action2, xorGroup);
            return xorGroup.Token;
        }

        private void CheckAndRegisterSubgroup(Action<IRegister> action, IFilterGroup parentGroup)
        {
            if (action != null)
            {
                RegisterSubgroup(action, parentGroup);
            }
        }

        private void RegisterSubgroup(Action<IRegister> action, IFilterGroup parentGroup)
        {
            var andGroup = new AndGroup(parentGroup.GroupToken) { Id = store.NextId };
            parentGroup.Filters.Add(andGroup);
            action(RegistrationFactory.GetRegistration(store, andGroup, priority));
        }
    }
}
