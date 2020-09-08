// Copyright (c) Lucas Girouard-Stranks. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the Git repository root directory for full license information.

using System;
using System.Reflection;

namespace Extended
{
    /// <summary>
    ///     The application framework. Provides application APIs which the implementations can be dynamically
    ///     loaded or swapped at runtime.
    /// </summary>
    internal static class Framework
    {
        internal static NativePlatform Platform;

        private static Func<FrameworkModules, FrameworkModules> _setupAction = null!;
        private static Action _runAction = null!;
        private static Action _shutdownAction = null!;

        public static FrameworkModules LoadedModules { get; private set; }

        public static void Setup(FrameworkModules moduleTypes)
        {
            LoadDriver();
            LoadedModules = _setupAction(moduleTypes);
        }

        public static void Run()
        {
            _runAction();
        }

        public static void Shutdown()
        {
            _shutdownAction();
            LoadedModules = FrameworkModules.Unknown;
        }

        private static void LoadDriver()
        {
            var assembly = Assembly.Load("Extended.Framework.Driver");
            var driverType = assembly.GetType("Extended.FrameworkDriver");

            var setupMethod = driverType.GetMethod(
                "Setup");
            _setupAction =
                (Func<FrameworkModules, FrameworkModules>)setupMethod!.CreateDelegate(
                    typeof(Func<FrameworkModules, FrameworkModules>));

            var runMethod = driverType.GetMethod("Run");
            _runAction = (Action)runMethod!.CreateDelegate(typeof(Action));

            var shutdownMethod = driverType.GetMethod("Shutdown");
            _shutdownAction = (Action)shutdownMethod!.CreateDelegate(typeof(Action));

            var property = driverType.GetProperty("Platform");
            var getMethod = property!.GetGetMethod();
            Platform = (NativePlatform)getMethod.Invoke(null, null);
        }
    }
}
