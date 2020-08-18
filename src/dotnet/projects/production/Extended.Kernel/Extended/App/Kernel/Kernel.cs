// Copyright (c) Lucas Girouard-Stranks. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the Git repository root directory for full license information.

using System;
using System.Reflection;

namespace Extended
{
    internal static class Kernel
    {
        private static Func<KernelModuleTypes, object?, KernelModuleTypes> _setupAction = null!;
        private static Action _runAction = null!;
        private static Action _pumpEventsAction = null!;
        private static Action _shutdownAction = null!;
        private static Func<bool> _isExiting = null!;

        public static NativePlatform Platform { get; private set; }

        public static bool IsExiting => _isExiting();

        public static void Setup(KernelModuleTypes moduleTypes, object? param = null)
        {
            TryLoadDriver();
            _setupAction(moduleTypes, param);
        }

        public static void Run()
        {
            _runAction();
        }

        public static void PumpEvents()
        {
            _pumpEventsAction();
        }

        public static void Shutdown()
        {
            _shutdownAction();
        }

        private static void TryLoadDriver()
        {
            App.BeginTrace("Loading kernel driver");

            try
            {
                LoadDriver();
            }
            catch (Exception e)
            {
                App.EndTraceFailure(e);
                Environment.Exit(-1);
            }

            App.EndTraceSuccess();
        }

        private static void LoadDriver()
        {
            var assembly = Assembly.Load("Extended.Kernel.Driver");
            var driverType = assembly.GetType("Extended.KernelDriver");

            var setupMethod = driverType.GetMethod(
                "Setup");
            _setupAction =
                (Func<KernelModuleTypes, object?, KernelModuleTypes>)setupMethod!.CreateDelegate(
                    typeof(Func<KernelModuleTypes, object?, KernelModuleTypes>));

            var runMethod = driverType.GetMethod("Run");
            _runAction = (Action)runMethod!.CreateDelegate(typeof(Action));

            var pumpEventsMethod = driverType.GetMethod("PumpEvents");
            _pumpEventsAction = (Action)pumpEventsMethod!.CreateDelegate(typeof(Action));

            var shutdownMethod = driverType.GetMethod("Shutdown");
            _shutdownAction = (Action)shutdownMethod!.CreateDelegate(typeof(Action));

            var isExitingProperty = driverType.GetProperty("IsExiting");
            var isExitingMethod = isExitingProperty!.GetMethod;
            _isExiting = (Func<bool>)isExitingMethod.CreateDelegate(typeof(Func<bool>));

            var property = driverType.GetProperty("Platform");
            var getMethod = property!.GetGetMethod();
            Platform = (NativePlatform)getMethod.Invoke(null, null);
        }
    }
}
