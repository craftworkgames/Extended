// Copyright (c) Lucas Girouard-Stranks. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the Git repository root directory for full license information.

using System;
using System.Reflection;

namespace Extended
{
    /// <summary>
    ///     The bedrock of an application system. Provides application APIs which the implementations can be dynamically
    ///     loaded or swapped at runtime.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         The decomposition of the <see cref="Kernel" /> responsibilities are expressed as
    ///         <see cref="KernelModules" />. This decomposition follows modular programming which is historically
    ///         successful for I/O sub-systems found in systems programming of an operating system. The kernel found in
    ///         a operating system is where the name comes from for <see cref="Kernel" />. One of the goals of an
    ///         operating system kernel is to provide hardware compatibility. This can be compared to one of the goals
    ///         the application system <see cref="Kernel" /> which is software compatibility.
    ///     </para>
    /// </remarks>
    internal static class Kernel
    {
        internal static NativePlatform Platform;
        internal static LoopCallback LoopCallback = null!;
        internal static QuitCallback? QuitCallback;

        private static Func<KernelModules, object?, KernelModules> _setupAction = null!;
        private static Action _runAction = null!;
        private static Action _pumpEventsAction = null!;
        private static Action _shutdownAction = null!;

        public static void Setup(KernelModules moduleTypes, object? param = null)
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
            Trace.Begin("Loading kernel driver");

            try
            {
                LoadDriver();
            }
            catch (Exception e)
            {
                Trace.EndWithFailure(e);
                Environment.Exit(-1);
            }

            Trace.EndWithSuccess();
        }

        private static void LoadDriver()
        {
            var assembly = Assembly.Load("Extended.Kernel.Driver");
            var driverType = assembly.GetType("Extended.KernelDriver");

            var setupMethod = driverType.GetMethod(
                "Setup");
            _setupAction =
                (Func<KernelModules, object?, KernelModules>)setupMethod!.CreateDelegate(
                    typeof(Func<KernelModules, object?, KernelModules>));

            var runMethod = driverType.GetMethod("Run");
            _runAction = (Action)runMethod!.CreateDelegate(typeof(Action));

            var pumpEventsMethod = driverType.GetMethod("PumpEvents");
            _pumpEventsAction = (Action)pumpEventsMethod!.CreateDelegate(typeof(Action));

            var shutdownMethod = driverType.GetMethod("Shutdown");
            _shutdownAction = (Action)shutdownMethod!.CreateDelegate(typeof(Action));

            var property = driverType.GetProperty("Platform");
            var getMethod = property!.GetGetMethod();
            Platform = (NativePlatform)getMethod.Invoke(null, null);
        }
    }
}
