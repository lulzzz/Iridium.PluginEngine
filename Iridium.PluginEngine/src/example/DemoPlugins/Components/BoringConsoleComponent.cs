﻿using DemoPlugins.Components.Consoles;
using DemoPlugins.Sdk;
using Iridium.PluginCore.Classes;
using Iridium.PluginEngine.Types;
using System;

namespace DemoPlugins.Components
{
    public class BoringConsoleComponent : ComponentPlugin<IConsole>
    {
        public override string Author => "0xFireball";

        public override IConsole ComponentImplementation { get; protected set; } = new BoringConsole();

        public override string Description => "A component that adds a boring console";

        public override string Name => nameof(BoringConsoleComponent);

        public override string PluginGuid => "0937tyvhwocmwcn99amrnovnr09-doesitlooklikeitried";

        public override string PreferencesKey => "boringconsole";

        public override Version Version => new Version(0, 0);

        public override void ConfigurePlugin(PluginPreferences pluginSettings)
        {
        }

        public override void Dispose()
        {
        }

        public override void LoadComponents()
        {
        }

        public override void Shutdown()
        {
        }

        public override void UnloadComponents()
        {
        }
    }
}