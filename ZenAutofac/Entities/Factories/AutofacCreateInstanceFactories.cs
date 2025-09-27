using System;
using Autofac;
using ZenAutofac.Interfaces;

namespace ZenAutofac.Entities.Factories
{
    public static partial class DIExtensions
    {
        //generated amount 10

        internal class AutofacCreateInstanceFactory<TInstance>
            : IFactory<TInstance>
            where TInstance : class
        {
            private readonly ILifetimeScope _scope;

            public AutofacCreateInstanceFactory(ILifetimeScope scope)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
            }

            public TInstance Create()
            {
                return _scope.CreateInstance<TInstance>();
            }
        }

        internal class AutofacCreateInstanceFactory<TP0, TInstance>
            : IFactory<TP0, TInstance>
            where TInstance : class
        {
            private readonly ILifetimeScope _scope;

            public AutofacCreateInstanceFactory(ILifetimeScope scope)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
            }

            public TInstance Create(TP0 param0)
            {
                return _scope.CreateInstance<TInstance>(param0);
            }
        }

        internal class AutofacCreateInstanceFactory<TP0, TP1, TInstance>
            : IFactory<TP0, TP1, TInstance>
            where TInstance : class
        {
            private readonly ILifetimeScope _scope;

            public AutofacCreateInstanceFactory(ILifetimeScope scope)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
            }

            public TInstance Create(TP0 param0, TP1 param1)
            {
                return _scope.CreateInstance<TInstance>(param0, param1);
            }
        }

        internal class AutofacCreateInstanceFactory<TP0, TP1, TP2, TInstance>
            : IFactory<TP0, TP1, TP2, TInstance>
            where TInstance : class
        {
            private readonly ILifetimeScope _scope;

            public AutofacCreateInstanceFactory(ILifetimeScope scope)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
            }

            public TInstance Create(TP0 param0, TP1 param1, TP2 param2)
            {
                return _scope.CreateInstance<TInstance>(param0, param1, param2);
            }
        }

        internal class AutofacCreateInstanceFactory<TP0, TP1, TP2, TP3, TInstance>
            : IFactory<TP0, TP1, TP2, TP3, TInstance>
            where TInstance : class
        {
            private readonly ILifetimeScope _scope;

            public AutofacCreateInstanceFactory(ILifetimeScope scope)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
            }

            public TInstance Create(TP0 param0, TP1 param1, TP2 param2, TP3 param3)
            {
                return _scope.CreateInstance<TInstance>(param0, param1, param2, param3);
            }
        }

        internal class AutofacCreateInstanceFactory<TP0, TP1, TP2, TP3, TP4, TInstance>
            : IFactory<TP0, TP1, TP2, TP3, TP4, TInstance>
            where TInstance : class
        {
            private readonly ILifetimeScope _scope;

            public AutofacCreateInstanceFactory(ILifetimeScope scope)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
            }

            public TInstance Create(TP0 param0, TP1 param1, TP2 param2, TP3 param3, TP4 param4)
            {
                return _scope.CreateInstance<TInstance>(param0, param1, param2, param3, param4);
            }
        }

        internal class AutofacCreateInstanceFactory<TP0, TP1, TP2, TP3, TP4, TP5, TInstance>
            : IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TInstance>
            where TInstance : class
        {
            private readonly ILifetimeScope _scope;

            public AutofacCreateInstanceFactory(ILifetimeScope scope)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
            }

            public TInstance Create(TP0 param0, TP1 param1, TP2 param2, TP3 param3, TP4 param4, TP5 param5)
            {
                return _scope.CreateInstance<TInstance>(param0, param1, param2, param3, param4, param5);
            }
        }

        internal class AutofacCreateInstanceFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance>
            : IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance>
            where TInstance : class
        {
            private readonly ILifetimeScope _scope;

            public AutofacCreateInstanceFactory(ILifetimeScope scope)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
            }

            public TInstance Create(TP0 param0, TP1 param1, TP2 param2, TP3 param3, TP4 param4, TP5 param5, TP6 param6)
            {
                return _scope.CreateInstance<TInstance>(param0, param1, param2, param3, param4, param5, param6);
            }
        }

        internal class AutofacCreateInstanceFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance>
            : IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance>
            where TInstance : class
        {
            private readonly ILifetimeScope _scope;

            public AutofacCreateInstanceFactory(ILifetimeScope scope)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
            }

            public TInstance Create(TP0 param0, TP1 param1, TP2 param2, TP3 param3, TP4 param4, TP5 param5, TP6 param6, TP7 param7)
            {
                return _scope.CreateInstance<TInstance>(param0, param1, param2, param3, param4, param5, param6, param7);
            }
        }

        internal class AutofacCreateInstanceFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance>
            : IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance>
            where TInstance : class
        {
            private readonly ILifetimeScope _scope;

            public AutofacCreateInstanceFactory(ILifetimeScope scope)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
            }

            public TInstance Create(TP0 param0, TP1 param1, TP2 param2, TP3 param3, TP4 param4, TP5 param5, TP6 param6, TP7 param7, TP8 param8)
            {
                return _scope.CreateInstance<TInstance>(param0, param1, param2, param3, param4, param5, param6, param7, param8);
            }
        }

        internal class AutofacCreateInstanceFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance>
            : IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance>
            where TInstance : class
        {
            private readonly ILifetimeScope _scope;

            public AutofacCreateInstanceFactory(ILifetimeScope scope)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
            }

            public TInstance Create(TP0 param0, TP1 param1, TP2 param2, TP3 param3, TP4 param4, TP5 param5, TP6 param6, TP7 param7, TP8 param8, TP9 param9)
            {
                return _scope.CreateInstance<TInstance>(param0, param1, param2, param3, param4, param5, param6, param7, param8, param9);
            }
        }

    }
}