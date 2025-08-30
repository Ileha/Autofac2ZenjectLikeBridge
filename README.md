# Autofac2ZenjectLikeBridge

[![NuGet Version](https://img.shields.io/nuget/v/Autofac2ZenjectLikeBridge.svg?style=flat-square)](https://www.nuget.org/packages/com.alexey-developer89.Autofac2ZenjectLikeBridge)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

Brings the power of Zenject's subcontainers syntax to Autofac, enabling Zenject-style dependency injection patterns in
your Autofac applications. This library provides a familiar API for developers who love Zenject's approach to scoping
and subcontainers but want to leverage Autofac's robust dependency injection capabilities.

## 🚀 Key Features

- **Zenject-inspired subcontainer syntax** for Autofac
- Seamless integration of Zenject's scoping patterns
- Simplified decorator registration with isolated scopes
- Cross-container dependency management
- Full compatibility with existing Autofac applications

## 💡 Why Use Autofac2ZenjectLikeBridge?

This library is ideal for:

- Teams transitioning from Zenject to Autofac
- Projects that want to combine the best of both DI containers
- Developers who prefer Zenject's subcontainer API but need Autofac's features
- Applications requiring advanced dependency injection scenarios with clean scoping

## 📦 Installation

Install the package from NuGet:

```bash
Install-Package com.alexey-developer89.Autofac2ZenjectLikeBridge
```

Or via the .NET CLI:

```bash
dotnet add package com.alexey-developer89.Autofac2ZenjectLikeBridge
```

## 🛠️ Quick Start

```csharp
// Create your container builder
var builder = new ContainerBuilder();

// Register your service from subcontainer
builder
    .RegisterFromSubScope<ISampleService>(
        subcontainerBuilder =>
        {
            // Register service in the subcontainer
            // registred type should match type in RegisterFromSubScope
            subcontainerBuilder
                .RegisterType<SampleService>()
                .As<ISampleService>()
                .SingleInstance();

            // Register dependencies in the subcontainer
            // needed to run SampleService
            subcontainerBuilder
                .RegisterType<SampleDependency>()
                .SingleInstance();
        })
    .SingleInstance();

    //...

    using var container = builder.Build()

    container.Resolve<ISampleService>();
```

## 📚 Documentation

> ℹ️ **Info**: All instances resolved from subcontainers have to be implement `IDisposable` and
`ICollection<IDisposable>` interfaces. This needed limit subcontainers lifetime. When instance is disposed, it's
> subcontainer will be disposed too. See [BaseCompositeDisposable](#basecompositedisposable) approach for more details.

### Creating Subcontainers

Create isolated subcontainers for instance. Based on Autofac's lifetime scope. Scope will inherit all dependencies from
parent scope(s). In the same time scope could have own dependencies, that will be available only in this scope.
See [Quick Start](#️-quick-start) for code sample.

### Decorators

#### Simple

Autofac default:

```csharp
builder
    .RegisterDecorator<ServiceDecorator, IService>();
```

#### From Function

Use function to create decorator instance:

```csharp
builder
    .RegisterDecoratorFromFunction<ServiceDecorator, IService>(
        (context, baseService) =>
        {
            var parameters = new Parameters();

            return context.CreateInstance<ServiceDecorator>(baseService, parameters);
        });
```

#### With Subcontainer

Use subcontainer to create decorator:

```csharp
builder
    .RegisterDecoratorFromSubScope<ServiceDecorator, IService>(
        (subcontainerBuilder, baseService) =>
        {
            // Register service in the subcontainer
            // registred type should match type in RegisterFromSubScope
            subcontainerBuilder
                .RegisterType<ServiceDecorator>()
                .WithParameters(TypedParameter.From(baseService))
                .SingleInstance();

            // Register dependencies in the subcontainer
            // needed to run ServiceDecorator
            subcontainerBuilder
                .RegisterType<SampleDependency>()
                .SingleInstance();
        });
```

### Factories

Provides interface `IFactory<parameter1, parameter2, ... , parameterN, Iinstance>` where
`parameter1, parameter2, ... , parameterN` are parameters for factory creation and `Iinstance` is instance type.

#### From Functions

Use function to register IFactory<Iinstance> in DI:

```csharp
builder
    .RegisterFactoryFromFunction<Iinstance>(
        scope => new Instance
        {
            Data = Guid.NewGuid()
        })
```

Use function to register IFactory<Guid, Iinstance> in DI:

```csharp
builder
    .RegisterFactoryFromFunction<Guid, Iinstance>(
        (scope, parameter) => new Instance
        {
            Data = parameter
        })
```

#### From Subcontainers

Use subcontainer to create factory `IFactory<Iinstance>`, new subcontainer will be created when factory's `Create`
method is called:

```csharp
builder
    .RegisterFactoryFromSubScope<Iinstance>(
        (subcontainerBuilder) =>
        {
            // Register service in the subcontainer
            // registred type should match type in RegisterFactoryFromSubScope
            subcontainerBuilder
                .RegisterType<Iinstance>()
                .SingleInstance();

            // Register dependencies in the subcontainer
            // needed to run Iinstance
            subcontainerBuilder
                .RegisterType<SampleDependency>()
                .SingleInstance();
        })
```

Parameters edition:

```csharp
builder
    .RegisterFactoryFromSubScope<Guid, Iinstance>(
        (subcontainerBuilder, parameter) =>
        {
            // Register service in the subcontainer
            // registred type should match type in RegisterFactoryFromSubScope
            subcontainerBuilder
                .RegisterType<Iinstance>()
                .WithParameters(TypedParameter.From(parameter))
                .SingleInstance();

            // Register dependencies in the subcontainer
            // needed to run Iinstance
            subcontainerBuilder
                .RegisterType<SampleDependency>()
                .SingleInstance();
        })
```

#### Placeholders Factories

Used to register type distincted from interface IFactory<T>, and/or modify factory `Create` behavior, like some instance
initialization:
Create new class and inherit from PlaceholderFactory<T>:

```csharp
class MyCustomFactory : PlaceholderFactory<Iinstance>
{
    //you can override Create method
    public override Iinstance Create()
    {
        return base.Create();
    }
}
```

Placeholders Factories registration is available only for SubScope factories:

```csharp
builder
    .RegisterFactoryFromSubScope<Iinstance, MyCustomFactory>(
        (subcontainerBuilder) =>
        {
            // Register service in the subcontainer
            // registred type should match type in RegisterFactoryFromSubScope
            subcontainerBuilder
                .RegisterType<Iinstance>()
                .SingleInstance();

            // Register dependencies in the subcontainer
            // needed to run Iinstance
            subcontainerBuilder
                .RegisterType<SampleDependency>()
                .SingleInstance();
        })
```

and for Function factories:

```csharp
builder
    .RegisterFactoryFromFunction<Iinstance, MyCustomFactory>(
        scope => new Instance
        {
            Data = Guid.NewGuid()
        })
```

### Other Helpers

#### BaseCompositeDisposable

Inherit from `BaseCompositeDisposable` for services or from `BaseCompositeDisposable<T>` for decorators to comply with
`IDisposable` and `ICollection<IDisposable>` interfaces.

#### IComponentContext.CreateInstance

Use `IComponentContext.CreateInstance` to create instance of type with using DI container:

```csharp
builder
    .Register<SampleService>(context =>
    {
        var result = context.CreateInstance<SampleService>(Guid.NewGuid());

        result.Setup();

        return result;
    })
    .As<ISampleService>()
    .SingleInstance();
```

## 🤝 Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

1. Fork the repository
2. Create your feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 🙏 Acknowledgments

- Inspired by Zenject's clean subcontainer API
- Built on top of Autofac's powerful DI container
- Thanks to all contributors who helped improve this project
