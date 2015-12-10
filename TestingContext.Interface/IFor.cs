﻿namespace TestingContext.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Runtime.CompilerServices;
    using TestingContext.LimitedInterface;

    public interface IFor<T1> : IForToken<T1>, IHighLevelOperations<IRegister>
    {
        new IFor<T1, T2> For<T2>(IHaveToken<T2> haveToken);

        new IFor<T1, IEnumerable<T2>> ForCollection<T2>(IHaveToken<T2> haveToken);

        IFor<T1, T2> For<T2>(string name,
                             [CallerFilePath] string file = "",
                             [CallerLineNumber] int line = 0,
                             [CallerMemberName] string member = "");

        IFor<T1, IEnumerable<T2>> ForCollection<T2>(string name,
                                                    [CallerFilePath] string file = "",
                                                    [CallerLineNumber] int line = 0,
                                                    [CallerMemberName] string member = "");

        void Exists<T2>(string name,
                        Expression<Func<T1, IEnumerable<T2>>> srcFunc,
                        [CallerFilePath] string file = "",
                        [CallerLineNumber] int line = 0,
                        [CallerMemberName] string member = "");

        void DoesNotExist<T2>(string name,
                              Expression<Func<T1, IEnumerable<T2>>> srcFunc,
                              [CallerFilePath] string file = "",
                              [CallerLineNumber] int line = 0,
                              [CallerMemberName] string member = "");

        void Each<T2>(string name,
                      Expression<Func<T1, IEnumerable<T2>>> srcFunc,
                      [CallerFilePath] string file = "",
                      [CallerLineNumber] int line = 0,
                      [CallerMemberName] string member = "");

        void Is<T2>(string name,
                              Expression<Func<T1, T2>> srcFunc,
                              [CallerFilePath] string file = "",
                              [CallerLineNumber] int line = 0,
                              [CallerMemberName] string member = "");

        void IsNot<T2>(string name,
                                    Expression<Func<T1, T2>> srcFunc,
                                    [CallerFilePath] string file = "",
                                    [CallerLineNumber] int line = 0,
                                    [CallerMemberName] string member = "");
    }
}
