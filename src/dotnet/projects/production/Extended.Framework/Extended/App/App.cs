// Copyright (c) Lucas Girouard-Stranks. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the Git repository root directory for full license information.

using System;

namespace Extended
{
    /// <summary>
    ///     Provides application state and functionality.
    /// </summary>
    public static class App
    {
        public static NativePlatform Platform => Framework.Platform;

        public static bool IsFixedTimeStep { get; private set; }

        public static TimeSpan FixedElapsedTime { get; private set; }

        public static TimeSpan MaximumElapsedTime { get; private set; }

        public static TimeSpan MaximumAccumulatedTime { get; private set; }

        internal static LogCallback LogCallback = null!;
        internal static AppQuitCallback QuitCallback = null!;
        internal static AppUpdateCallback UpdateCallback = null!;
        internal static AppFixedUpdateCallback FixedUpdateCallback = null!;
        internal static AppDrawCallback DrawCallback = null!;

        public static bool IsRunning { get; internal set; }

        public static void Setup(AppDescriptor descriptor)
        {
            IsFixedTimeStep = descriptor.IsFixedTimeStep;
            FixedElapsedTime = descriptor.FixedElapsedTime ?? TimeSpan.FromSeconds(1 / 60D);
            MaximumElapsedTime = descriptor.MaximumElapsedTime ?? TimeSpan.FromSeconds(5);
            MaximumAccumulatedTime = descriptor.MaximumAccumulatedTime ?? TimeSpan.FromSeconds(5);
            SetCallbacks(ref descriptor.Callbacks);

            Framework.Setup(descriptor.ModuleTypes);
        }

        public static void Run()
        {
            Framework.Run();
        }

        public static void Shutdown()
        {
            Framework.Shutdown();
        }

        private static void SetCallbacks(ref AppDescriptorCallbacks callbacks)
        {
            LogCallback = callbacks.Log ?? NoLogCallback;
            QuitCallback = callbacks.Quit ?? NoQuitCallback;
            UpdateCallback = callbacks.Update ?? NoUpdateCallback;
            FixedUpdateCallback = callbacks.UpdateFixed ?? NoFixedUpdateCallback;
            DrawCallback = callbacks.Draw ?? NoDrawCallback;
        }

        private static void NoLogCallback(LogLevel level, string message, long category)
        {
        }

        private static void NoQuitCallback()
        {
        }

        private static void NoUpdateCallback(TimeSpan totalTime, TimeSpan elapsedTime)
        {
        }

        private static void NoFixedUpdateCallback(TimeSpan totalTime, TimeSpan elapsedTime, uint fixedStepCount)
        {
        }

        private static void NoDrawCallback(TimeSpan totalTime, TimeSpan elapsedTime, float transitionAlpha)
        {
        }
    }
}
