﻿namespace TestingContextCore.Implementation.Registrations.HighLevel
{
    using System;
    using System.Linq;
    using TestingContext.Interface;
    using TestingContext.LimitedInterface;
    using TestingContext.LimitedInterface.Diag;
    using TestingContext.LimitedInterface.Tokens;

    internal class HighLevelRegistrations
    {
        private readonly InnerHighLevelRegistration inner;

        public HighLevelRegistrations(InnerHighLevelRegistration inner)
        {
            this.inner = inner;
        }

        public IFilterToken Not(Action<ITokenRegister> action, string file, int line, string member)
            => inner.Not(DiagInfo.Create(file, line, member), action);

        public IFilterToken Either(Action<ITokenRegister> action, Action<ITokenRegister> action2,
            Action<ITokenRegister> action3, Action<ITokenRegister> action4,
            Action<ITokenRegister> action5, string file, int line, string member)
            => inner.Either(DiagInfo.Create(file, line, member), Actions(action, action2, action3, action4, action5));

        public IFilterToken Xor(Action<ITokenRegister> action, Action<ITokenRegister> action2, string file, int line, string member)
            => inner.Xor(DiagInfo.Create(file, line, member), action, action2);

        public IFilterToken Not(Action<IRegister> action, string file, int line, string member)
            => inner.Not(DiagInfo.Create(file, line, member), action);

        public IFilterToken Either(Action<IRegister> action, Action<IRegister> action2,
            Action<IRegister> action3, Action<IRegister> action4,
            Action<IRegister> action5, string file, int line, string member)
            => inner.Either(DiagInfo.Create(file, line, member), Actions(action, action2, action3, action4, action5));

        public IFilterToken Xor(Action<IRegister> action, Action<IRegister> action2, string file, int line, string member)
            => inner.Xor(DiagInfo.Create(file, line, member), action, action2);

        private Action<IRegister>[] Actions(Action<IRegister> action,
            Action<IRegister> action2,
            Action<IRegister> action3,
            Action<IRegister> action4,
            Action<IRegister> action5)
        {
            return new [] { action, action2, action3, action4, action5 }.Where(x => x != null).ToArray();
        }
    }
}
