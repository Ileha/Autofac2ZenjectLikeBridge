# ZenAutofac

[![NuGet Version](https://img.shields.io/nuget/v/com.alexey-developer89.ZenAutofac.svg)](https://www.nuget.org/packages/com.alexey-developer89.ZenAutofac)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://github.com/Ileha/ZenAutofac?tab=MIT-1-ov-file#MIT-1-ov-file)

Brings the power of Zenject's subcontainers syntax to Autofac, enabling Zenject-style dependency injection patterns in
your Autofac applications. This library provides a familiar API for developers who love Zenject's approach to scoping
and subcontainers but want to leverage Autofac's robust dependency injection capabilities.

## 🚀 Key Features

- **Zenject-inspired subcontainer syntax** for Autofac
- Subcontainer lifetime management
- Seamless integration of Zenject's scoping patterns
- Simplified decorator registration with isolated scopes
- Full compatibility with existing Autofac applications
- `IFactory<...>` and `PlaceholderFactory<...>` for factory registration with subcontainer support

## 💡 Why Use ZenAutofac?

This library is ideal for:

- Teams transitioning from Zenject to Autofac
- Projects that want to combine the best of both DI containers
- Developers who prefer Zenject's subcontainer API but need Autofac's features
- Applications requiring advanced dependency injection scenarios with clean scoping

## 📦 Installation

Install the package from NuGet:

```bash
Install-Package com.alexey-developer89.ZenAutofac
```

Or via the .NET CLI:

```bash
dotnet add package com.alexey-developer89.ZenAutofac
```

## 🛠️ Quick Start

```csharp
// Create your container builder
var builder = new ContainerBuilder();

// Register your service from subcontainer
builder
    .RegisterExtended<ISampleService>()
    .FromSubScope()
    .ByFunction(
        subcontainerBuilder =>
        {
            // Register service in the subcontainer
            // registered type should match type in RegisterFromSubScope
            subcontainerBuilder
                .RegisterType<SampleService>()
                .As<ISampleService>()
                .SingleInstance();

            // Register dependencies in the subcontainer
            // needed to run SampleService
            subcontainerBuilder
                .RegisterType<SampleDependency>()
                .SingleInstance();
        });

// ...

using var container = builder.Build();

container.Resolve<ISampleService>();
```

## 📚 Documentation

> ℹ️ **Info**: All instances resolved from subcontainers have to implement `IDisposable` interface. This needed to limit subcontainers lifetime. When instance is disposed, it's subcontainer will be disposed too. Instance's `Dispose` method will be called patched via [Harmony](https://github.com/pardeike/Harmony) library, more information [here](#harmonypatch-related).

### Creating Subcontainers

Create isolated subcontainers for instance. Based on Autofac's lifetime scope. Scope will inherit all dependencies from
parent scope(s). In the same time scope could have own dependencies, that will be available only in this scope.
See [Quick Start](#-quick-start) for code sample.
When `FromSubScope()` called it supposed to create new nested `ILifetimeScope` register required type and all it dependencies and resolve that type form created subcontainer. In other words target type have to be registered in subcontainer installer and implements `IDisposable`

### Overall structure

 - Type registration:

    - from subScope:
        - [by function](#-quick-start)
        - [by module](#simple-registrations)

 - [Decorators:](#decorators)

    - [from function](#from-function)
    - [from subScope](#with-subcontainer):
        - [by function](#byfunction)
        - [by module](#by-module)

 - [Factories:](#factories)

    - [IFactory<P0, P1, ... , PN, TInstance>](#ifactory)
        - from new instance
        - [from function](#from-functions)
        - [from subScope](#from-subcontainers):
            - [by function](#by-function)
            - [by module](#by-module-1)

    - [PlaceholderFactory<P0, P1, ... , PN, TInstance>](#placeholders-factories)
        - from new instance
        - [from function](#from-functions-1)
        - [from subScope](#from-subcontainers-1):
            - [by function](#by-function-1)
            - [by module](#by-module-2)

### Modules

[Autofac's modules](https://autofac.readthedocs.io/en/latest/configuration/modules.html) could be used to register types in subcontainers.
Module sample:

```csharp
class SampleServiceModule : Module
{
    private readonly object _data;

    //pass all parameters to module's constructor as well as extra parameters or dependencies
    //from parent DI container(s)
    public SampleServiceModule(object data)
    {
        _data = data;
    }

    protected override void Load(ContainerBuilder builder)
    {
        //do ISampleService registration here
    }
}
```

#### Simple registrations:
```csharp
builder
    .RegisterExtended<ISampleService>()
    .FromSubScope()
    .ByModule<SampleServiceModule>();
```
or even create module with using [service provider](#icomponentcontextcreateinstance). In that case module will be created in subcontainer and all dependencies from current scope will be available in the module.
```csharp
builder
    .RegisterExtended<ISampleService>()
    .FromSubScope()
    .ByModule<SampleServiceModule>((scope) => scope.CreateInstance<SampleServiceModule>(parameter));
```

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
    .RegisterDecoratorExtended<ServiceDecorator, IService>()
    .FromFunction(
        (context, baseService) =>
        {
            var parameters = new Parameters();

            return context.CreateInstance<ServiceDecorator>(baseService, parameters);
        });
```

#### With Subcontainer

##### ByFunction

Use subcontainer to create decorator:

```csharp
builder
    .RegisterDecoratorExtended<ServiceDecorator, IService>()
    .FromSubScope()
    .ByFunction(
        (subcontainerBuilder, baseService) =>
        {
            // Register service in the subcontainer
            // registered type should match type in RegisterFromSubScope
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

##### By Module
As well instances could be created from module, decorator could also be created from module:
In that case decoratable service will be passed to module constructor.
Module sample:

```csharp
class ServiceDecoratorModule : Module
{
    private readonly object _data;
    private readonly IService _service;

    //pass all parameters and decoratable service to module's constructor as well as extra parameters or dependencies
    //from parent DI container(s)
    public ServiceDecoratorModule(IService service, object data)
    {
        _data = data;
        _service = service;
    }

    protected override void Load(ContainerBuilder builder)
    {
        //do ServiceDecorator registration here
    }
}
```
registration sample:
```csharp
builder
    .RegisterDecoratorExtended<ServiceDecorator, IService>()
    .FromSubScope()
    .ByModule<ServiceDecoratorModule>();
```
registration via [service provider](#icomponentcontextcreateinstance):
```csharp
builder
    .RegisterDecoratorExtended<ServiceDecorator, IService>()
    .FromSubScope()
    .ByModule((scope, service) => scope.CreateInstance<ServiceDecoratorModule>(service, parameter));
```

### Factories

#### IFactory

Provides interface `IFactory<parameter1, parameter2, ... , parameterN, Iinstance>` where
`parameter1, parameter2, ... , parameterN` are parameters for factory creation and `Iinstance` is instance type.

##### From Functions

Use function to register `IFactory<Iinstance>` in DI:

```csharp
builder
    .RegisterIFactoryExtended<Iinstance>()
    .FromFunction(
        scope => new Instance
        {
            Data = Guid.NewGuid()
        });
```

Use function to register `IFactory<Guid, Iinstance>` in DI:

```csharp
builder
    .RegisterIFactoryExtended<Guid, Iinstance>()
    .FromFunction(
        (scope, parameter) => new Instance
        {
            Data = parameter
        });
```

##### From Subcontainers

Use subcontainer to create factory `IFactory<Iinstance>`, new subcontainer will be created when factory's `Create`
method is called:

###### By Function

```csharp
builder
    .RegisterIFactoryExtended<Iinstance>()
    .FromSubScope()
    .ByFunction(subcontainerBuilder =>
    {
        // Register service in the subcontainer
        // registered type should match type in RegisterFactoryFromSubScope
        subcontainerBuilder
            .RegisterType<Iinstance>()
            .SingleInstance();

        // Register dependencies in the subcontainer
        // needed to run Iinstance
        subcontainerBuilder
            .RegisterType<SampleDependency>()
            .SingleInstance();
    });
```

Parameters edition:

```csharp
builder
    .RegisterIFactoryExtended<Guid, Iinstance>()
    .FromSubScope()
    .ByFunction((subcontainerBuilder, parameter) =>
    {
        // Register service in the subcontainer
        // registered type should match type in RegisterFactoryFromSubScope
        subcontainerBuilder
            .RegisterType<Iinstance>()
            .WithParameters(TypedParameter.From(parameter))
            .SingleInstance();

        // Register dependencies in the subcontainer
        // needed to run Iinstance
        subcontainerBuilder
            .RegisterType<SampleDependency>()
            .SingleInstance();
    });
```

###### By Module
Registration factories to resolve from module. All parameters will be passed to module's constructor.
Module sample:

```csharp
class ServiceModule : Module
{
    private readonly string _data;

    //pass all parameters to module's constructor as well as extra parameters or dependencies
    //from parent DI container(s)
    public ServiceModule(string data)
    {
        _data = data;
    }

    protected override void Load(ContainerBuilder builder)
    {
        //do IService registration here
    }
}
```
Registration sample:
```csharp
builder
    .RegisterIFactoryExtended<string, IService>()
    .FromSubScope()
    .ByModule<ServiceModule>();
```

Registration sample with extra parameters via [service provider](#icomponentcontextcreateinstance):
```csharp
builder
    .RegisterIFactoryExtended<string, IService>()
    .FromSubScope()
    .ByModule<ServiceModule>(
        (scope, arg3)
            => scope.CreateInstance<ServiceModule>(arg3, extraParameter));
```

#### Placeholders Factories

Used for registration of type distinct from interface IFactory<T>, and/or modify factory `Create` behavior, like some instance
initialization:
Create new class and inherit from PlaceholderFactory<T>:

```csharp
class MyCustomFactory : PlaceholderFactory<Iinstance>
{
    public MyCustomFactory(SomeDependency dependency)
    {
        //...
    }

    //you can override Create method
    public override Iinstance Create()
    {
        return base.Create();
    }
}
```

##### From Functions

Placeholders Factories registration is available from function:

```csharp
builder
    .RegisterPlaceholderFactoryExtended<Iinstance, MyCustomFactory>()
    .FromFunction(
        scope => new Instance
        {
            Data = Guid.NewGuid()
        });
```

##### From Subcontainers

and for subcontainers, new subcontainer will be created and installer called to register all content in subcontainer

###### By Function

via function

```csharp
builder
    .RegisterPlaceholderFactoryExtended<
        Guid,
        Iinstance,
        MyCustomFactory>()
    .FromSubScope()
    .ByFunction((subcontainerBuilder, parameter) =>
    {
        // Register service in the subcontainer
        // registered type should match type in RegisterPlaceholderFactoryExtended
        subcontainerBuilder
            .RegisterType<Iinstance>()
            .WithParameters(TypedParameter.From(parameter))
            .SingleInstance();

        // Register dependencies in the subcontainer
        // needed to run Iinstance
        subcontainerBuilder
            .RegisterType<SampleDependency>()
            .SingleInstance();
    });
```

###### By Module
For module sample see [by module section in `IFactory` registration](#by-module-1).
The registration is similar to `IFactory` registration. And could reuse same modules.

Registration sample:
```csharp
builder
    .RegisterPlaceholderFactoryExtended<string, IService, MyCustomServiceFactory>()
    .FromSubScope()
    .ByModule<ServiceModule>();
```

Registration sample with extra parameters via [service provider](#icomponentcontextcreateinstance):
```csharp
builder
    .RegisterPlaceholderFactoryExtended<string, IService, MyCustomServiceFactory>()
    .FromSubScope()
    .ByModule<ServiceModule>(
        (scope, arg3)
            => scope.CreateInstance<ServiceModule>(arg3, extraParameter));
```
where placeholder factory type is
```csharp
class MyCustomServiceFactory : PlaceholderFactory<string, IService>
{
    public MyCustomServiceFactory(SomeDependency dependency)
    {
        //...
    }

    //you can override Create method
    public override IService Create(string arg)
    {
        return base.Create(arg);
    }
}
```

### Other Helpers

#### CompositeDisposable

Use `CompositeDisposable` for services and decorators to manage multiple disposables and comply with `IDisposable` and `ICollection<IDisposable>`. `CompositeDisposable` will dispose all disposables, added to it, when disposed.

Example:

```csharp
var composite = new CompositeDisposable();

_disposable1.AddTo(composite);
_disposable2.AddTo(composite);

//_disposable1 & _disposable2 will be disposed here
composite.Dispose();
```

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

#### HarmonyPatch Related
As mentioned before each instance resolved from subcontainer have to implement `IDisposable` interface. And subcontainer will be disposed when instance is disposed. To achieve this behavior `HarmonyPatch` is used.  
It can add a finalizer to the instance A and set a reference to the instance B. When instance B will be disposed A will be disposed too.  
That behavior is accessible via `A.AddToHarmony(B)` method. In that case `B` will be patched if not patched yet.  
To force patch, in order to improve performance, use `HarmonyPatch.EnsurePatched(typeof(B))` when program starts. Or use `HarmonyPatch.PatchNonLazy()` method to patch all types (in that case generic will not be patched).

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
