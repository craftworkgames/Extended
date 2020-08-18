// Copyright (c) Lucas Girouard-Stranks. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the Git repository root directory for full license information.

namespace Extended
{
    /// <summary>
    ///     Provides access to the `Extended` app.
    /// </summary>
    public static partial class App
    {
        internal static event LogCallback LogCallback;

        private static event LoopCallback LoopCallback;

        private static event QuitCallback QuitCallback;

        public static NativePlatform Platform => Kernel.Platform;

        public static bool IsExiting => Kernel.IsExiting;

        public static void Setup(AppDescriptor descriptor)
        {
            SetCallbacks(descriptor.LogCallback, descriptor.LoopCallback, descriptor.QuitCallback);
            Kernel.Setup(descriptor.ModuleTypes);
        }

        public static void Run()
        {
            Kernel.Run();
        }

        public static void PumpEvents()
        {
            Kernel.PumpEvents();
        }

        public static void Shutdown()
        {
            Kernel.Shutdown();
        }

        internal static void OnLoop()
        {
            LoopCallback.Invoke();
        }

        internal static void OnLog(LogLevel level, string message, long category)
        {
            LogCallback.Invoke(level, message, category);
        }

        private static void SetCallbacks(LogCallback log, LoopCallback loop, QuitCallback quit)
        {
            LogCallback = log;
            LoopCallback = loop;
            QuitCallback = quit;
        }
    }
}
