using System;
using Autofac;
using Autofac.Builder;
using ZenAutofac.Builders.Factory;
using ZenAutofac.Entities.Factories;
using ZenAutofac.Interfaces;
using ZenAutofac.Interfaces.Builders.Factory;

namespace ZenAutofac
{
    public static partial class DIExtensions
    {
        //generated amount 10

#region RegisterIFactoryExtended

        public static IExtendedFactoryBuilder<
            TInstance,
            IFactory<TInstance>,
            ConcreteReflectionActivatorData> RegisterIFactoryExtended<TInstance>(this ContainerBuilder builder)
            where TInstance : class
        {
            if (builder is null)
                throw new ArgumentNullException(nameof(builder));

            return new ExtendedFactoryBuilder<TInstance>(builder);
        }

        public static IExtendedFactoryBuilder<
            TP0,
			TInstance,
            IFactory<TP0, TInstance>,
            ConcreteReflectionActivatorData> RegisterIFactoryExtended<TP0, TInstance>(this ContainerBuilder builder)
            where TInstance : class
        {
            if (builder is null)
                throw new ArgumentNullException(nameof(builder));

            return new ExtendedFactoryBuilder<TP0, TInstance>(builder);
        }

        public static IExtendedFactoryBuilder<
            TP0,
			TP1,
			TInstance,
            IFactory<TP0, TP1, TInstance>,
            ConcreteReflectionActivatorData> RegisterIFactoryExtended<TP0, TP1, TInstance>(this ContainerBuilder builder)
            where TInstance : class
        {
            if (builder is null)
                throw new ArgumentNullException(nameof(builder));

            return new ExtendedFactoryBuilder<TP0, TP1, TInstance>(builder);
        }

        public static IExtendedFactoryBuilder<
            TP0,
			TP1,
			TP2,
			TInstance,
            IFactory<TP0, TP1, TP2, TInstance>,
            ConcreteReflectionActivatorData> RegisterIFactoryExtended<TP0, TP1, TP2, TInstance>(this ContainerBuilder builder)
            where TInstance : class
        {
            if (builder is null)
                throw new ArgumentNullException(nameof(builder));

            return new ExtendedFactoryBuilder<TP0, TP1, TP2, TInstance>(builder);
        }

        public static IExtendedFactoryBuilder<
            TP0,
			TP1,
			TP2,
			TP3,
			TInstance,
            IFactory<TP0, TP1, TP2, TP3, TInstance>,
            ConcreteReflectionActivatorData> RegisterIFactoryExtended<TP0, TP1, TP2, TP3, TInstance>(this ContainerBuilder builder)
            where TInstance : class
        {
            if (builder is null)
                throw new ArgumentNullException(nameof(builder));

            return new ExtendedFactoryBuilder<TP0, TP1, TP2, TP3, TInstance>(builder);
        }

        public static IExtendedFactoryBuilder<
            TP0,
			TP1,
			TP2,
			TP3,
			TP4,
			TInstance,
            IFactory<TP0, TP1, TP2, TP3, TP4, TInstance>,
            ConcreteReflectionActivatorData> RegisterIFactoryExtended<TP0, TP1, TP2, TP3, TP4, TInstance>(this ContainerBuilder builder)
            where TInstance : class
        {
            if (builder is null)
                throw new ArgumentNullException(nameof(builder));

            return new ExtendedFactoryBuilder<TP0, TP1, TP2, TP3, TP4, TInstance>(builder);
        }

        public static IExtendedFactoryBuilder<
            TP0,
			TP1,
			TP2,
			TP3,
			TP4,
			TP5,
			TInstance,
            IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TInstance>,
            ConcreteReflectionActivatorData> RegisterIFactoryExtended<TP0, TP1, TP2, TP3, TP4, TP5, TInstance>(this ContainerBuilder builder)
            where TInstance : class
        {
            if (builder is null)
                throw new ArgumentNullException(nameof(builder));

            return new ExtendedFactoryBuilder<TP0, TP1, TP2, TP3, TP4, TP5, TInstance>(builder);
        }

        public static IExtendedFactoryBuilder<
            TP0,
			TP1,
			TP2,
			TP3,
			TP4,
			TP5,
			TP6,
			TInstance,
            IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance>,
            ConcreteReflectionActivatorData> RegisterIFactoryExtended<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance>(this ContainerBuilder builder)
            where TInstance : class
        {
            if (builder is null)
                throw new ArgumentNullException(nameof(builder));

            return new ExtendedFactoryBuilder<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance>(builder);
        }

        public static IExtendedFactoryBuilder<
            TP0,
			TP1,
			TP2,
			TP3,
			TP4,
			TP5,
			TP6,
			TP7,
			TInstance,
            IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance>,
            ConcreteReflectionActivatorData> RegisterIFactoryExtended<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance>(this ContainerBuilder builder)
            where TInstance : class
        {
            if (builder is null)
                throw new ArgumentNullException(nameof(builder));

            return new ExtendedFactoryBuilder<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance>(builder);
        }

        public static IExtendedFactoryBuilder<
            TP0,
			TP1,
			TP2,
			TP3,
			TP4,
			TP5,
			TP6,
			TP7,
			TP8,
			TInstance,
            IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance>,
            ConcreteReflectionActivatorData> RegisterIFactoryExtended<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance>(this ContainerBuilder builder)
            where TInstance : class
        {
            if (builder is null)
                throw new ArgumentNullException(nameof(builder));

            return new ExtendedFactoryBuilder<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance>(builder);
        }

        public static IExtendedFactoryBuilder<
            TP0,
			TP1,
			TP2,
			TP3,
			TP4,
			TP5,
			TP6,
			TP7,
			TP8,
			TP9,
			TInstance,
            IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance>,
            ConcreteReflectionActivatorData> RegisterIFactoryExtended<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance>(this ContainerBuilder builder)
            where TInstance : class
        {
            if (builder is null)
                throw new ArgumentNullException(nameof(builder));

            return new ExtendedFactoryBuilder<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance>(builder);
        }

#endregion

#region IFactoryFromSubScope

        public static ISubScopeFactoryBuilder<
            TInstance,
            IFactory<TInstance>,
            ConcreteReflectionActivatorData> FromSubScope<TInstance, TActivatorData>(
                this IExtendedFactoryBuilder<TInstance, IFactory<TInstance>, TActivatorData> builder)
            where TInstance : class, IDisposable
        {
            if (builder is null)
                throw new ArgumentNullException(nameof(builder));

            return new SubScopeFactoryBuilder<TInstance>(builder.Builder);
        }

        public static ISubScopeFactoryBuilder<
            TP0,
			TInstance,
            IFactory<TP0, TInstance>,
            ConcreteReflectionActivatorData> FromSubScope<TP0, TInstance, TActivatorData>(
                this IExtendedFactoryBuilder<TP0, TInstance, IFactory<TP0, TInstance>, TActivatorData> builder)
            where TInstance : class, IDisposable
        {
            if (builder is null)
                throw new ArgumentNullException(nameof(builder));

            return new SubScopeFactoryBuilder<TP0, TInstance>(builder.Builder);
        }

        public static ISubScopeFactoryBuilder<
            TP0,
			TP1,
			TInstance,
            IFactory<TP0, TP1, TInstance>,
            ConcreteReflectionActivatorData> FromSubScope<TP0, TP1, TInstance, TActivatorData>(
                this IExtendedFactoryBuilder<TP0, TP1, TInstance, IFactory<TP0, TP1, TInstance>, TActivatorData> builder)
            where TInstance : class, IDisposable
        {
            if (builder is null)
                throw new ArgumentNullException(nameof(builder));

            return new SubScopeFactoryBuilder<TP0, TP1, TInstance>(builder.Builder);
        }

        public static ISubScopeFactoryBuilder<
            TP0,
			TP1,
			TP2,
			TInstance,
            IFactory<TP0, TP1, TP2, TInstance>,
            ConcreteReflectionActivatorData> FromSubScope<TP0, TP1, TP2, TInstance, TActivatorData>(
                this IExtendedFactoryBuilder<TP0, TP1, TP2, TInstance, IFactory<TP0, TP1, TP2, TInstance>, TActivatorData> builder)
            where TInstance : class, IDisposable
        {
            if (builder is null)
                throw new ArgumentNullException(nameof(builder));

            return new SubScopeFactoryBuilder<TP0, TP1, TP2, TInstance>(builder.Builder);
        }

        public static ISubScopeFactoryBuilder<
            TP0,
			TP1,
			TP2,
			TP3,
			TInstance,
            IFactory<TP0, TP1, TP2, TP3, TInstance>,
            ConcreteReflectionActivatorData> FromSubScope<TP0, TP1, TP2, TP3, TInstance, TActivatorData>(
                this IExtendedFactoryBuilder<TP0, TP1, TP2, TP3, TInstance, IFactory<TP0, TP1, TP2, TP3, TInstance>, TActivatorData> builder)
            where TInstance : class, IDisposable
        {
            if (builder is null)
                throw new ArgumentNullException(nameof(builder));

            return new SubScopeFactoryBuilder<TP0, TP1, TP2, TP3, TInstance>(builder.Builder);
        }

        public static ISubScopeFactoryBuilder<
            TP0,
			TP1,
			TP2,
			TP3,
			TP4,
			TInstance,
            IFactory<TP0, TP1, TP2, TP3, TP4, TInstance>,
            ConcreteReflectionActivatorData> FromSubScope<TP0, TP1, TP2, TP3, TP4, TInstance, TActivatorData>(
                this IExtendedFactoryBuilder<TP0, TP1, TP2, TP3, TP4, TInstance, IFactory<TP0, TP1, TP2, TP3, TP4, TInstance>, TActivatorData> builder)
            where TInstance : class, IDisposable
        {
            if (builder is null)
                throw new ArgumentNullException(nameof(builder));

            return new SubScopeFactoryBuilder<TP0, TP1, TP2, TP3, TP4, TInstance>(builder.Builder);
        }

        public static ISubScopeFactoryBuilder<
            TP0,
			TP1,
			TP2,
			TP3,
			TP4,
			TP5,
			TInstance,
            IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TInstance>,
            ConcreteReflectionActivatorData> FromSubScope<TP0, TP1, TP2, TP3, TP4, TP5, TInstance, TActivatorData>(
                this IExtendedFactoryBuilder<TP0, TP1, TP2, TP3, TP4, TP5, TInstance, IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TInstance>, TActivatorData> builder)
            where TInstance : class, IDisposable
        {
            if (builder is null)
                throw new ArgumentNullException(nameof(builder));

            return new SubScopeFactoryBuilder<TP0, TP1, TP2, TP3, TP4, TP5, TInstance>(builder.Builder);
        }

        public static ISubScopeFactoryBuilder<
            TP0,
			TP1,
			TP2,
			TP3,
			TP4,
			TP5,
			TP6,
			TInstance,
            IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance>,
            ConcreteReflectionActivatorData> FromSubScope<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance, TActivatorData>(
                this IExtendedFactoryBuilder<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance, IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance>, TActivatorData> builder)
            where TInstance : class, IDisposable
        {
            if (builder is null)
                throw new ArgumentNullException(nameof(builder));

            return new SubScopeFactoryBuilder<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance>(builder.Builder);
        }

        public static ISubScopeFactoryBuilder<
            TP0,
			TP1,
			TP2,
			TP3,
			TP4,
			TP5,
			TP6,
			TP7,
			TInstance,
            IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance>,
            ConcreteReflectionActivatorData> FromSubScope<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance, TActivatorData>(
                this IExtendedFactoryBuilder<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance, IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance>, TActivatorData> builder)
            where TInstance : class, IDisposable
        {
            if (builder is null)
                throw new ArgumentNullException(nameof(builder));

            return new SubScopeFactoryBuilder<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance>(builder.Builder);
        }

        public static ISubScopeFactoryBuilder<
            TP0,
			TP1,
			TP2,
			TP3,
			TP4,
			TP5,
			TP6,
			TP7,
			TP8,
			TInstance,
            IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance>,
            ConcreteReflectionActivatorData> FromSubScope<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance, TActivatorData>(
                this IExtendedFactoryBuilder<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance, IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance>, TActivatorData> builder)
            where TInstance : class, IDisposable
        {
            if (builder is null)
                throw new ArgumentNullException(nameof(builder));

            return new SubScopeFactoryBuilder<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance>(builder.Builder);
        }

        public static ISubScopeFactoryBuilder<
            TP0,
			TP1,
			TP2,
			TP3,
			TP4,
			TP5,
			TP6,
			TP7,
			TP8,
			TP9,
			TInstance,
            IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance>,
            ConcreteReflectionActivatorData> FromSubScope<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance, TActivatorData>(
                this IExtendedFactoryBuilder<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance, IFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance>, TActivatorData> builder)
            where TInstance : class, IDisposable
        {
            if (builder is null)
                throw new ArgumentNullException(nameof(builder));

            return new SubScopeFactoryBuilder<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance>(builder.Builder);
        }

#endregion

#region RegisterPlaceholderFactoryExtended

        public static IExtendedFactoryBuilder<
            TInstance,
            TPlaceholderFactory,
            SimpleActivatorData> RegisterPlaceholderFactoryExtended<TInstance, TPlaceholderFactory>(this ContainerBuilder builder)
            where TInstance : class
            where TPlaceholderFactory : PlaceholderFactory<TInstance>
        {
            if (builder is null)
                throw new ArgumentNullException(nameof(builder));

            return new ExtendedPlaceholderFactoryBuilder<TInstance, TPlaceholderFactory>(builder);
        }

        public static IExtendedFactoryBuilder<
            TP0,
			TInstance,
            TPlaceholderFactory,
            SimpleActivatorData> RegisterPlaceholderFactoryExtended<TP0, TInstance, TPlaceholderFactory>(this ContainerBuilder builder)
            where TInstance : class
            where TPlaceholderFactory : PlaceholderFactory<TP0, TInstance>
        {
            if (builder is null)
                throw new ArgumentNullException(nameof(builder));

            return new ExtendedPlaceholderFactoryBuilder<TP0, TInstance, TPlaceholderFactory>(builder);
        }

        public static IExtendedFactoryBuilder<
            TP0,
			TP1,
			TInstance,
            TPlaceholderFactory,
            SimpleActivatorData> RegisterPlaceholderFactoryExtended<TP0, TP1, TInstance, TPlaceholderFactory>(this ContainerBuilder builder)
            where TInstance : class
            where TPlaceholderFactory : PlaceholderFactory<TP0, TP1, TInstance>
        {
            if (builder is null)
                throw new ArgumentNullException(nameof(builder));

            return new ExtendedPlaceholderFactoryBuilder<TP0, TP1, TInstance, TPlaceholderFactory>(builder);
        }

        public static IExtendedFactoryBuilder<
            TP0,
			TP1,
			TP2,
			TInstance,
            TPlaceholderFactory,
            SimpleActivatorData> RegisterPlaceholderFactoryExtended<TP0, TP1, TP2, TInstance, TPlaceholderFactory>(this ContainerBuilder builder)
            where TInstance : class
            where TPlaceholderFactory : PlaceholderFactory<TP0, TP1, TP2, TInstance>
        {
            if (builder is null)
                throw new ArgumentNullException(nameof(builder));

            return new ExtendedPlaceholderFactoryBuilder<TP0, TP1, TP2, TInstance, TPlaceholderFactory>(builder);
        }

        public static IExtendedFactoryBuilder<
            TP0,
			TP1,
			TP2,
			TP3,
			TInstance,
            TPlaceholderFactory,
            SimpleActivatorData> RegisterPlaceholderFactoryExtended<TP0, TP1, TP2, TP3, TInstance, TPlaceholderFactory>(this ContainerBuilder builder)
            where TInstance : class
            where TPlaceholderFactory : PlaceholderFactory<TP0, TP1, TP2, TP3, TInstance>
        {
            if (builder is null)
                throw new ArgumentNullException(nameof(builder));

            return new ExtendedPlaceholderFactoryBuilder<TP0, TP1, TP2, TP3, TInstance, TPlaceholderFactory>(builder);
        }

        public static IExtendedFactoryBuilder<
            TP0,
			TP1,
			TP2,
			TP3,
			TP4,
			TInstance,
            TPlaceholderFactory,
            SimpleActivatorData> RegisterPlaceholderFactoryExtended<TP0, TP1, TP2, TP3, TP4, TInstance, TPlaceholderFactory>(this ContainerBuilder builder)
            where TInstance : class
            where TPlaceholderFactory : PlaceholderFactory<TP0, TP1, TP2, TP3, TP4, TInstance>
        {
            if (builder is null)
                throw new ArgumentNullException(nameof(builder));

            return new ExtendedPlaceholderFactoryBuilder<TP0, TP1, TP2, TP3, TP4, TInstance, TPlaceholderFactory>(builder);
        }

        public static IExtendedFactoryBuilder<
            TP0,
			TP1,
			TP2,
			TP3,
			TP4,
			TP5,
			TInstance,
            TPlaceholderFactory,
            SimpleActivatorData> RegisterPlaceholderFactoryExtended<TP0, TP1, TP2, TP3, TP4, TP5, TInstance, TPlaceholderFactory>(this ContainerBuilder builder)
            where TInstance : class
            where TPlaceholderFactory : PlaceholderFactory<TP0, TP1, TP2, TP3, TP4, TP5, TInstance>
        {
            if (builder is null)
                throw new ArgumentNullException(nameof(builder));

            return new ExtendedPlaceholderFactoryBuilder<TP0, TP1, TP2, TP3, TP4, TP5, TInstance, TPlaceholderFactory>(builder);
        }

        public static IExtendedFactoryBuilder<
            TP0,
			TP1,
			TP2,
			TP3,
			TP4,
			TP5,
			TP6,
			TInstance,
            TPlaceholderFactory,
            SimpleActivatorData> RegisterPlaceholderFactoryExtended<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance, TPlaceholderFactory>(this ContainerBuilder builder)
            where TInstance : class
            where TPlaceholderFactory : PlaceholderFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance>
        {
            if (builder is null)
                throw new ArgumentNullException(nameof(builder));

            return new ExtendedPlaceholderFactoryBuilder<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance, TPlaceholderFactory>(builder);
        }

        public static IExtendedFactoryBuilder<
            TP0,
			TP1,
			TP2,
			TP3,
			TP4,
			TP5,
			TP6,
			TP7,
			TInstance,
            TPlaceholderFactory,
            SimpleActivatorData> RegisterPlaceholderFactoryExtended<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance, TPlaceholderFactory>(this ContainerBuilder builder)
            where TInstance : class
            where TPlaceholderFactory : PlaceholderFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance>
        {
            if (builder is null)
                throw new ArgumentNullException(nameof(builder));

            return new ExtendedPlaceholderFactoryBuilder<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance, TPlaceholderFactory>(builder);
        }

        public static IExtendedFactoryBuilder<
            TP0,
			TP1,
			TP2,
			TP3,
			TP4,
			TP5,
			TP6,
			TP7,
			TP8,
			TInstance,
            TPlaceholderFactory,
            SimpleActivatorData> RegisterPlaceholderFactoryExtended<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance, TPlaceholderFactory>(this ContainerBuilder builder)
            where TInstance : class
            where TPlaceholderFactory : PlaceholderFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance>
        {
            if (builder is null)
                throw new ArgumentNullException(nameof(builder));

            return new ExtendedPlaceholderFactoryBuilder<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance, TPlaceholderFactory>(builder);
        }

        public static IExtendedFactoryBuilder<
            TP0,
			TP1,
			TP2,
			TP3,
			TP4,
			TP5,
			TP6,
			TP7,
			TP8,
			TP9,
			TInstance,
            TPlaceholderFactory,
            SimpleActivatorData> RegisterPlaceholderFactoryExtended<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance, TPlaceholderFactory>(this ContainerBuilder builder)
            where TInstance : class
            where TPlaceholderFactory : PlaceholderFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance>
        {
            if (builder is null)
                throw new ArgumentNullException(nameof(builder));

            return new ExtendedPlaceholderFactoryBuilder<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance, TPlaceholderFactory>(builder);
        }

#endregion

#region PlaceholderFactoryFromSubScope

        public static ISubScopeFactoryBuilder<
            TInstance,
            TPlaceholderFactory,
            SimpleActivatorData> FromSubScope<TInstance, TPlaceholderFactory, TActivatorData>(
                this IExtendedFactoryBuilder<TInstance, TPlaceholderFactory, TActivatorData> builder)
            where TInstance : class, IDisposable
            where TPlaceholderFactory : PlaceholderFactory<TInstance>
        {
            if (builder is null)
                throw new ArgumentNullException(nameof(builder));

            return new SubScopePlaceholderFactoryBuilder<TInstance, TPlaceholderFactory>(builder.Builder);
        }

        public static ISubScopeFactoryBuilder<
            TP0,
			TInstance,
            TPlaceholderFactory,
            SimpleActivatorData> FromSubScope<TP0, TInstance, TPlaceholderFactory, TActivatorData>(
                this IExtendedFactoryBuilder<TP0, TInstance, TPlaceholderFactory, TActivatorData> builder)
            where TInstance : class, IDisposable
            where TPlaceholderFactory : PlaceholderFactory<TP0, TInstance>
        {
            if (builder is null)
                throw new ArgumentNullException(nameof(builder));

            return new SubScopePlaceholderFactoryBuilder<TP0, TInstance, TPlaceholderFactory>(builder.Builder);
        }

        public static ISubScopeFactoryBuilder<
            TP0,
			TP1,
			TInstance,
            TPlaceholderFactory,
            SimpleActivatorData> FromSubScope<TP0, TP1, TInstance, TPlaceholderFactory, TActivatorData>(
                this IExtendedFactoryBuilder<TP0, TP1, TInstance, TPlaceholderFactory, TActivatorData> builder)
            where TInstance : class, IDisposable
            where TPlaceholderFactory : PlaceholderFactory<TP0, TP1, TInstance>
        {
            if (builder is null)
                throw new ArgumentNullException(nameof(builder));

            return new SubScopePlaceholderFactoryBuilder<TP0, TP1, TInstance, TPlaceholderFactory>(builder.Builder);
        }

        public static ISubScopeFactoryBuilder<
            TP0,
			TP1,
			TP2,
			TInstance,
            TPlaceholderFactory,
            SimpleActivatorData> FromSubScope<TP0, TP1, TP2, TInstance, TPlaceholderFactory, TActivatorData>(
                this IExtendedFactoryBuilder<TP0, TP1, TP2, TInstance, TPlaceholderFactory, TActivatorData> builder)
            where TInstance : class, IDisposable
            where TPlaceholderFactory : PlaceholderFactory<TP0, TP1, TP2, TInstance>
        {
            if (builder is null)
                throw new ArgumentNullException(nameof(builder));

            return new SubScopePlaceholderFactoryBuilder<TP0, TP1, TP2, TInstance, TPlaceholderFactory>(builder.Builder);
        }

        public static ISubScopeFactoryBuilder<
            TP0,
			TP1,
			TP2,
			TP3,
			TInstance,
            TPlaceholderFactory,
            SimpleActivatorData> FromSubScope<TP0, TP1, TP2, TP3, TInstance, TPlaceholderFactory, TActivatorData>(
                this IExtendedFactoryBuilder<TP0, TP1, TP2, TP3, TInstance, TPlaceholderFactory, TActivatorData> builder)
            where TInstance : class, IDisposable
            where TPlaceholderFactory : PlaceholderFactory<TP0, TP1, TP2, TP3, TInstance>
        {
            if (builder is null)
                throw new ArgumentNullException(nameof(builder));

            return new SubScopePlaceholderFactoryBuilder<TP0, TP1, TP2, TP3, TInstance, TPlaceholderFactory>(builder.Builder);
        }

        public static ISubScopeFactoryBuilder<
            TP0,
			TP1,
			TP2,
			TP3,
			TP4,
			TInstance,
            TPlaceholderFactory,
            SimpleActivatorData> FromSubScope<TP0, TP1, TP2, TP3, TP4, TInstance, TPlaceholderFactory, TActivatorData>(
                this IExtendedFactoryBuilder<TP0, TP1, TP2, TP3, TP4, TInstance, TPlaceholderFactory, TActivatorData> builder)
            where TInstance : class, IDisposable
            where TPlaceholderFactory : PlaceholderFactory<TP0, TP1, TP2, TP3, TP4, TInstance>
        {
            if (builder is null)
                throw new ArgumentNullException(nameof(builder));

            return new SubScopePlaceholderFactoryBuilder<TP0, TP1, TP2, TP3, TP4, TInstance, TPlaceholderFactory>(builder.Builder);
        }

        public static ISubScopeFactoryBuilder<
            TP0,
			TP1,
			TP2,
			TP3,
			TP4,
			TP5,
			TInstance,
            TPlaceholderFactory,
            SimpleActivatorData> FromSubScope<TP0, TP1, TP2, TP3, TP4, TP5, TInstance, TPlaceholderFactory, TActivatorData>(
                this IExtendedFactoryBuilder<TP0, TP1, TP2, TP3, TP4, TP5, TInstance, TPlaceholderFactory, TActivatorData> builder)
            where TInstance : class, IDisposable
            where TPlaceholderFactory : PlaceholderFactory<TP0, TP1, TP2, TP3, TP4, TP5, TInstance>
        {
            if (builder is null)
                throw new ArgumentNullException(nameof(builder));

            return new SubScopePlaceholderFactoryBuilder<TP0, TP1, TP2, TP3, TP4, TP5, TInstance, TPlaceholderFactory>(builder.Builder);
        }

        public static ISubScopeFactoryBuilder<
            TP0,
			TP1,
			TP2,
			TP3,
			TP4,
			TP5,
			TP6,
			TInstance,
            TPlaceholderFactory,
            SimpleActivatorData> FromSubScope<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance, TPlaceholderFactory, TActivatorData>(
                this IExtendedFactoryBuilder<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance, TPlaceholderFactory, TActivatorData> builder)
            where TInstance : class, IDisposable
            where TPlaceholderFactory : PlaceholderFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance>
        {
            if (builder is null)
                throw new ArgumentNullException(nameof(builder));

            return new SubScopePlaceholderFactoryBuilder<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TInstance, TPlaceholderFactory>(builder.Builder);
        }

        public static ISubScopeFactoryBuilder<
            TP0,
			TP1,
			TP2,
			TP3,
			TP4,
			TP5,
			TP6,
			TP7,
			TInstance,
            TPlaceholderFactory,
            SimpleActivatorData> FromSubScope<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance, TPlaceholderFactory, TActivatorData>(
                this IExtendedFactoryBuilder<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance, TPlaceholderFactory, TActivatorData> builder)
            where TInstance : class, IDisposable
            where TPlaceholderFactory : PlaceholderFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance>
        {
            if (builder is null)
                throw new ArgumentNullException(nameof(builder));

            return new SubScopePlaceholderFactoryBuilder<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TInstance, TPlaceholderFactory>(builder.Builder);
        }

        public static ISubScopeFactoryBuilder<
            TP0,
			TP1,
			TP2,
			TP3,
			TP4,
			TP5,
			TP6,
			TP7,
			TP8,
			TInstance,
            TPlaceholderFactory,
            SimpleActivatorData> FromSubScope<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance, TPlaceholderFactory, TActivatorData>(
                this IExtendedFactoryBuilder<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance, TPlaceholderFactory, TActivatorData> builder)
            where TInstance : class, IDisposable
            where TPlaceholderFactory : PlaceholderFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance>
        {
            if (builder is null)
                throw new ArgumentNullException(nameof(builder));

            return new SubScopePlaceholderFactoryBuilder<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TInstance, TPlaceholderFactory>(builder.Builder);
        }

        public static ISubScopeFactoryBuilder<
            TP0,
			TP1,
			TP2,
			TP3,
			TP4,
			TP5,
			TP6,
			TP7,
			TP8,
			TP9,
			TInstance,
            TPlaceholderFactory,
            SimpleActivatorData> FromSubScope<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance, TPlaceholderFactory, TActivatorData>(
                this IExtendedFactoryBuilder<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance, TPlaceholderFactory, TActivatorData> builder)
            where TInstance : class, IDisposable
            where TPlaceholderFactory : PlaceholderFactory<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance>
        {
            if (builder is null)
                throw new ArgumentNullException(nameof(builder));

            return new SubScopePlaceholderFactoryBuilder<TP0, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TInstance, TPlaceholderFactory>(builder.Builder);
        }

#endregion
    }
}