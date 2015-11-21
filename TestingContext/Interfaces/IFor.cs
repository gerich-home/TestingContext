﻿namespace TestingContextCore.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Runtime.CompilerServices;
    using TestingContextCore.Interfaces.Tokens;

    public interface IFor<T1>
    {
        IHaveToken IsTrue(Expression<Func<T1, bool>> filter,
            [CallerFilePath] string file = "",
            [CallerLineNumber] int line = 0,
            [CallerMemberName] string member = "");

        IFor<T1, T2> For<T2>(Func<ITestingContext, IToken<T2>> getToken);

        IFor<T1, T2> For<T2>(string name);

        IFor<T1, IEnumerable<T2>> ForCollection<T2>(Func<ITestingContext, IToken<T2>> getToken);

        IFor<T1, IEnumerable<T2>> ForCollection<T2>(string name);

        IHaveToken<T2> Exists<T2>(Func<T1, IEnumerable<T2>> srcFunc);

        IHaveToken<T2> Is<T2>(Func<T1, T2> srcFunc);

        IHaveToken<T2> DoesNotExist<T2>(Func<T1, IEnumerable<T2>> srcFunc);

        IHaveToken<T2> IsNot<T2>(Func<T1, T2> srcFunc);

        IHaveToken<T2> Each<T2>(Func<T1, IEnumerable<T2>> srcFunc);
    }
}
