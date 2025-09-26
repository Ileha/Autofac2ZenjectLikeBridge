using System;
using Autofac;
using ZenAutofac.Interfaces;

namespace ZenAutofac.Entities.Factories
{
    public static partial class DIExtensions
    {
        //generated amount 10

        internal class AutofacFunctionFactory<TInstance>
            : IFactory<TInstance>
            where TInstance : class
        {
            private readonly ILifetimeScope _scope;
            private readonly Func<ILifetimeScope, TInstance> _subScopeLoader;

            public AutofacFunctionFactory(
                ILifetimeScope scope,
                Func<ILifetimeScope, TInstance> subScopeLoader)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _subScopeLoader = subScopeLoader ?? throw new ArgumentNullException(nameof(subScopeLoader));
            }

            public TInstance Create()
            {
                return _subScopeLoader(_scope);
            }
        }

        internal class AutofacFunctionFactory<TP0, TInstance>
            : IFactory<TP0, TInstance>
            where TInstance : class
        {
            private readonly ILifetimeScope _scope;
            private readonly Func<ILifetimeScope, TP0, TInstance> _subScopeLoader;

            public AutofacFunctionFactory(
                ILifetimeScope scope,
                Func<ILifetimeScope, TP0, TInstance> subScopeLoader)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _subScopeLoader = subScopeLoader ?? throw new ArgumentNullException(nameof(subScopeLoader));
            }

            public TInstance Create(TP0 param0)
            {
                return _subScopeLoader(_scope, param0);
            }
        }

        internal class AutofacFunctionFactory<TP0, TP1, TInstance>
            : IFactory<TP0, TP1, TInstance>
            where TInstance : class
        {
            private readonly ILifetimeScope _scope;
            private readonly Func<ILifetimeScope, TP0, TP1, TInstance> _subScopeLoader;

            public AutofacFunctionFactory(
                ILifetimeScope scope,
                Func<ILifetimeScope, TP0, TP1, TInstance> subScopeLoader)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _subScopeLoader = subScopeLoader ?? throw new ArgumentNullException(nameof(subScopeLoader));
            }

            public TInstance Create(TP0 param0, TP1 param1)
            {
                return _subScopeLoader(_scope, param0, param1);
            }
        }

        internal class AutofacFunctionFactory<TP0, TP1, TP2, TInstance>
            : IFactory<TP0, TP1, TP2, TInstance>
            where TInstance : class
        {
            private readonly ILifetimeScope _scope;
            private readonly Func<ILifetimeScope, TP0, TP1, TP2, TInstance> _subScopeLoader;

            public AutofacFunctionFactory(
                ILifetimeScope scope,
                Func<ILifetimeScope, TP0, TP1, TP2, TInstance> subScopeLoader)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _subScopeLoader = subScopeLoader ?? throw new ArgumentNullException(nameof(subScopeLoader));
            }

            public TInstance Create(TP0 param0, TP1 param1, TP2 param2)
            {
                return _subScopeLoader(_scope, param0, param1, param2);
            }
        }

        internal class AutofacFunctionFactory<TP0, TP1, TP2, TP3, TInstance>
            : IFactory<TP0, TP1, TP2, TP3, TInstance>
            where TInstance : class
        {
            private readonly ILifetimeScope _scope;
            private readonly Func<ILifetimeScope, TP0, TP1, TP2, TP3, TInstance> _subScopeLoader;

            public AutofacFunctionFactory(
                ILifetimeScope scope,
                Func<ILifetimeScope, TP0, TP1, TP2, TP3, TInstance> subScopeLoader)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _subScopeLoader = subScopeLoader ?? throw new ArgumentNullException(nameof(subScopeLoader));
            }

            public TInstance Create(TP0 param0, TP1 param1, TP2 param2, TP3 param3)
            {
                return _subScopeLoader(_scope, param0, param1, param2, param3);
            }
        }

        internal class AutofacFunctionFactory<TP0, TP1, TP2, TP3, TP4, TInstance>
            : IFactory<TP0, TP1, TP2, TP3, TP4, TInstance>
            where TInstance : class
        {
            private readonly ILifetimeScope _scope;
            private readonly Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TInstance> _subScopeLoader;

            public AutofacFunctionFactory(
                ILifetimeScope scope,
                Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TInstance> subScopeLoader)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _subScopeLoader = subScopeLoader ?? throw new ArgumentNullException(nameof(subScopeLoader));
            }

            public TInstance Create(TP0 param0, TP1 param1, TP2 param2, TP3 param3, TP4 param4)
            {
                return _subScopeLoader(_scope, param0, param1, param2, param3, param4);
            }
        }

        internal class AutofacFunctionFactory<TP0, TP1, TP2, TP3, TP4, TP5, TInstance>
            : IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TInstance>
            where TInstance : class
        {
            private readonly ILifetimeScope _scope;
            private readonly Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TP5, TInstance> _subScopeLoader;

            public AutofacFunctionFactory(
                ILifetimeScope scope,
                Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TP5, TInstance> subScopeLoader)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _subScopeLoader = subScopeLoader ?? throw new ArgumentNullException(nameof(subScopeLoader));
            }

            public TInstance Create(TP0 param0, TP1 param1, TP2 param2, TP3 param3, TP4 param4, TP5 param5)
            {
                return _subScopeLoader(_scope, param0, param1, param2, param3, param4, param5);
            }
        }

        internal class AutofacFunctionFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance>
            : IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance>
            where TInstance : class
        {
            private readonly ILifetimeScope _scope;
            private readonly Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance> _subScopeLoader;

            public AutofacFunctionFactory(
                ILifetimeScope scope,
                Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance> subScopeLoader)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _subScopeLoader = subScopeLoader ?? throw new ArgumentNullException(nameof(subScopeLoader));
            }

            public TInstance Create(TP0 param0, TP1 param1, TP2 param2, TP3 param3, TP4 param4, TP5 param5, TP6 param6)
            {
                return _subScopeLoader(_scope, param0, param1, param2, param3, param4, param5, param6);
            }
        }

        internal class AutofacFunctionFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance>
            : IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance>
            where TInstance : class
        {
            private readonly ILifetimeScope _scope;
            private readonly Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance> _subScopeLoader;

            public AutofacFunctionFactory(
                ILifetimeScope scope,
                Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance> subScopeLoader)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _subScopeLoader = subScopeLoader ?? throw new ArgumentNullException(nameof(subScopeLoader));
            }

            public TInstance Create(TP0 param0, TP1 param1, TP2 param2, TP3 param3, TP4 param4, TP5 param5, TP6 param6, TP7 param7)
            {
                return _subScopeLoader(_scope, param0, param1, param2, param3, param4, param5, param6, param7);
            }
        }

        internal class AutofacFunctionFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance>
            : IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance>
            where TInstance : class
        {
            private readonly ILifetimeScope _scope;
            private readonly Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance> _subScopeLoader;

            public AutofacFunctionFactory(
                ILifetimeScope scope,
                Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance> subScopeLoader)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _subScopeLoader = subScopeLoader ?? throw new ArgumentNullException(nameof(subScopeLoader));
            }

            public TInstance Create(TP0 param0, TP1 param1, TP2 param2, TP3 param3, TP4 param4, TP5 param5, TP6 param6, TP7 param7, TP8 param8)
            {
                return _subScopeLoader(_scope, param0, param1, param2, param3, param4, param5, param6, param7, param8);
            }
        }

        internal class AutofacFunctionFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance>
            : IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance>
            where TInstance : class
        {
            private readonly ILifetimeScope _scope;
            private readonly Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance> _subScopeLoader;

            public AutofacFunctionFactory(
                ILifetimeScope scope,
                Func<ILifetimeScope, TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance> subScopeLoader)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
                _subScopeLoader = subScopeLoader ?? throw new ArgumentNullException(nameof(subScopeLoader));
            }

            public TInstance Create(TP0 param0, TP1 param1, TP2 param2, TP3 param3, TP4 param4, TP5 param5, TP6 param6, TP7 param7, TP8 param8, TP9 param9)
            {
                return _subScopeLoader(_scope, param0, param1, param2, param3, param4, param5, param6, param7, param8, param9);
            }
        }

    }
}