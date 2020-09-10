// Copyright (c) Lucas Girouard-Stranks. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the Git repository root directory for full license information.

using System;
using JetBrains.Annotations;
using Microsoft.Xna.Framework;

namespace Extended
{
    [UsedImplicitly]
    internal static class FrameworkDriver
    {
        public static Game Game = null!;
        public static GraphicsDeviceManager Graphics = null!;
        private static float _remainderFraction;

        [UsedImplicitly]
        public static NativePlatform Platform => Extended.Platform.GetNativePlatform();

        [UsedImplicitly]
        public static FrameworkModules Setup(FrameworkModules moduleTypes)
        {
            // Ignore any requested framework modules... MonoGame is all or nothing

            InitializeMonoGame();

            return FrameworkModules.All;
        }

        [UsedImplicitly]
        public static void Shutdown()
        {
            DeInitializeMonoGame();
        }

        [UsedImplicitly]
        public static void Run()
        {
            Start();
            Exit();
        }

        internal static void UpdateLoop(TimeSpan totalTime, TimeSpan deltaTime)
        {
            // Move variables into the stack frame
            var fixedElapsedTime = App.FixedDeltaTime;
            var maximumElapsedTime = App.MaximumDeltaTime;
            var maximumAccumulatedTime = App.MaximumAccumulatedTime;

            if (deltaTime > maximumElapsedTime)
            {
                deltaTime = maximumElapsedTime;
            }

            PumpEvents(deltaTime);

            var accumulatedTime = deltaTime;
            if (accumulatedTime > maximumAccumulatedTime)
            {
                accumulatedTime = maximumAccumulatedTime;
            }

            var fixedStepCount = 0U;
            while (accumulatedTime >= fixedElapsedTime)
            {
                accumulatedTime -= fixedElapsedTime;
                totalTime += fixedElapsedTime;
                fixedStepCount++;
                App.FixedUpdateCallback(totalTime, deltaTime, fixedStepCount);
            }

            deltaTime = accumulatedTime + (fixedElapsedTime * fixedStepCount);
            _remainderFraction = accumulatedTime.Ticks / (float)fixedElapsedTime.Ticks;

            App.UpdateCallback(totalTime, deltaTime);
        }

        internal static void DrawLoop(TimeSpan totalTime, TimeSpan deltaTime)
        {
            App.DrawCallback(totalTime, deltaTime, _remainderFraction);
        }

        private static void InitializeMonoGame()
        {
            Game = new GameRoot();
            Graphics = new GraphicsDeviceManager(Game);
        }

        private static void DeInitializeMonoGame()
        {
            Graphics.Dispose();
            Graphics = null!;
            Game!.Dispose();
            Game = null!;
        }

        private static void Start()
        {
            App.IsRunning = true;
            Game.Run();
        }

        private static void Exit()
        {
            App.QuitCallback();
        }

        private static void PumpEvents(TimeSpan elapsedTime)
        {
            Window.HandleEvents();
            Keyboard.HandleEvents(elapsedTime);
        }
    }
}
