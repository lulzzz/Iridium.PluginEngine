
# Iridium.PluginEngine

Unified .NET Core Service Locator plugin system. A port of my Platinum.PluginEngine

## About

`Iridium.PluginEngine` is a complete port of my [Platinum.PluginEngine](https://github.com/0xFireball/Platinum.PluginEngine) library,
that allows you to use a service locator pattern with a framework that makes setup very easy.

A [full example](https://github.com/0xFireball/Iridium.PluginEngine/tree/master/Iridium.PluginEngine/src/example) is provided:
here is an excerpt of the main code complete with comments explaining everything:

```csharp
using DemoPlugins;
using DemoPlugins.Sdk;
using Iridium.PluginCore;
using Iridium.PluginEngine;
using Iridium.PluginEngine.Types;
using System.Reflection;

namespace DemoApp
{
    public class Program
    {
        private static void Main()
        {
            // First, use the Iridium.PluginCore API to load component plugins
            // See the Iridium.PluginCore documentation for more information
            // Create a new PluginLoader that loads plugins that implement IPluginComponent
            // IPluginComponent is a special type of plugin that contains a component
            var plgLoader = new PluginLoader<IPlatinumComponent>();
            // In this example, we will load the plugin directly from the assembly
            // The PluginFactory<T> has other methods to load plugins from other locations, such as
            // files and directories
            var plugins = plgLoader.Factory.LoadPlugin(typeof(Dummy).GetTypeInfo().Assembly);

            // Register default implementation of components
            // This is an optional step, but these registered components will be used
            // in case no custom component implementations are loaded from the plugin
            // IConsole in this case is the interface of the component
            // Typically, the declaration of such interfaces should be in a Common or SDK
            // library that will be referenced both by the original application
            // and any plugins built for that application.
            // In this example, IConsole is declared in the DemoPlugin.SDK assembly
            ComponentRegistry.Register(new DefaultConsole(), typeof(IConsole));

            // Register components from plugins
            // PluginLoader<T>.RegisterAll() is an extension method that
            // will automatically find all components in all loaded plugins, and register
            // them in the global ComponentRegistry
            // In this example, all found implementations of IConsole will be registered as
            // IConsole components. The order of component registration is the same as the order the
            // plugin assemblies were loaded
            plgLoader.RegisterAll();

            // Load components from registry
            // Since the default implementation was registered first,
            // any other implementations that were registered subsequently will have
            // a higher priority when retrieving them from the registry.
            // ComponentRegistry.Get<T> will fetch the most recently registered
            // implementation of a component type.
            // GetAll<T> will fetch all implementations in an IEnumerable<T>
            var consoles = ComponentRegistry.GetAll<IConsole>();
            var myConsole = ComponentRegistry.Get<IConsole>();

            // After retreiving a component implementation from the ComponentRegistry,
            // this line demonstrates calling a method declared in the IConsole interface.
            // The implementation is up to the component in the plugin.
            // The plugin component implementation will be fully debuggable as long as
            // the source and debugging symbols are present in the IDE.
            // For example, if the source files for the plugin project are part of the solution
            // in Visual Studio, a developer will be able to step into this call and debug
            // the code in the component implementation
            myConsole.WriteLine("Hello, World");
        }
    }
}
```

## License

Copyright &copy; 2016-2017 0xFireball, IridiumIon Software. All Rights Reserved.

Licensed under the Apache License 2.0