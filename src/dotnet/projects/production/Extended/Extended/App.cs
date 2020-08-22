// Copyright (c) Lucas Girouard-Stranks. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the Git repository root directory for full license information.

namespace Extended
{
    /// <summary>
    ///     Provides application state and functionality.
    /// </summary>
    public static class App
    {
        // TODO: Create Loop static class, set up callback for "i do loop", "you do loop"

        public static NativePlatform Platform => Kernel.Platform;

        public static void Setup(AppDescriptor descriptor)
        {
            SetCallbacks(ref descriptor.Callbacks);
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

        private static void SetCallbacks(ref AppDescriptorCallbacks callbacks)
        {
            Kernel.LoopCallback = callbacks.Loop;
            Kernel.QuitCallback = callbacks.Quit;
            Log.Callback = callbacks.Log;
        }
    }
}
