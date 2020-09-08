// Copyright (c) Lucas Girouard-Stranks. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the Git repository root directory for full license information.

using System;
using System.Diagnostics;
using System.Reflection;
using JetBrains.Annotations;
using Microsoft.Xna.Framework;
using SDL;

namespace Extended
{
    [UsedImplicitly]
    internal static class FrameworkDriver
    {
        private static Game? _game;
        private static GraphicsDeviceManager _graphics;

        [UsedImplicitly]
        public static NativePlatform Platform => Extended.Platform.GetNativePlatform();

        [UsedImplicitly]
        public static FrameworkModules Setup(FrameworkModules moduleTypes)
        {
            // Ignore any requested framework modules... MonoGame is all or nothing

            LoadSDL2();
            InitializeMonoGame();

            return FrameworkModules.All;
        }

        [UsedImplicitly]
        public static void Shutdown()
        {
            DeInitializeMonoGame();
            UnloadSDL2();
        }

        [UsedImplicitly]
        public static void Run()
        {
            Start();
            Loop();
            Exit();
        }

        private static unsafe void LoadSDL2()
        {
            SDL2.Load();

            SDL_Version libraryVersion;
            SDL2.SDL_GetVersion(&libraryVersion);

            var version = (100 * libraryVersion.major) + (10 * libraryVersion.minor) + (1 * libraryVersion.minor);
            if (version <= 204)
            {
                Log.Critical("Please use SDL 2.0.5 or higher.");
            }

            if (version >= 205 && App.Platform == NativePlatform.Windows && Debugger.IsAttached)
            {
                SDL2.SDL_SetHint("SDL_WINDOWS_DISABLE_THREAD_NAMING", "1");
            }

            SDL2.SDL_Init(
                SDL_InitFlags.SDL_INIT_VIDEO |
                SDL_InitFlags.SDL_INIT_JOYSTICK |
                SDL_InitFlags.SDL_INIT_GAMECONTROLLER |
                SDL_InitFlags.SDL_INIT_HAPTIC);

            SDL2.SDL_DisableScreenSaver();
        }

        private static void UnloadSDL2()
        {
            SDL2.Unload();
        }

        private static void InitializeMonoGame()
        {
            _game = new GameRoot();
            _graphics = new GraphicsDeviceManager(_game);
        }

        private static void DeInitializeMonoGame()
        {
            _game!.Dispose();
            _game = null;
        }

        private static void Start()
        {
            // WARNING!: This function is dependent on the internals of MonoGame; always check the source of truth:
            // https://github.com/MonoGame/MonoGame/blob/develop/MonoGame.Framework/Game.cs

            App.IsRunning = true;

            var type = _graphics.GetType();
            var createDeviceMethod = type.GetMethod("CreateDevice", BindingFlags.Instance | BindingFlags.NonPublic, Type.DefaultBinder, new Type[] {}, null) !;
            createDeviceMethod.Invoke(_graphics, null);

            SDL2.SDL_ShowWindow(_game.Window.Handle);
        }

        private static void Loop()
        {
            var previousTicks = SDL2.SDL_GetPerformanceCounter();
            var accumulatedTime = TimeSpan.Zero;
            var totalTime = TimeSpan.Zero;

            // Move variables into the stack frame
            var fixedElapsedTime = App.FixedElapsedTime;
            var maximumElapsedTime = App.MaximumElapsedTime;
            var maximumAccumulatedTime = App.MaximumAccumulatedTime;
            var performanceFrequency = SDL2.SDL_GetPerformanceFrequency();
            var isFixedTimeStep = App.IsFixedTimeStep;

            while (App.IsRunning)
            {
                var currentTicks = SDL2.SDL_GetPerformanceCounter();
                var elapsedMilliseconds = (currentTicks - previousTicks) / (double)performanceFrequency * 1000;
                var elapsedTime = TimeSpan.FromMilliseconds(elapsedMilliseconds);
                previousTicks = currentTicks;

                if (elapsedTime > maximumElapsedTime)
                {
                    elapsedTime = maximumElapsedTime;
                }

                PumpEvents();
                PumpMonoGame();

                accumulatedTime += elapsedTime;
                if (accumulatedTime > maximumAccumulatedTime)
                {
                    accumulatedTime = maximumAccumulatedTime;
                }

                float remainderFraction;
                if (isFixedTimeStep)
                {
                    var fixedStepCount = 0U;
                    while (accumulatedTime >= fixedElapsedTime)
                    {
                        accumulatedTime -= fixedElapsedTime;
                        totalTime += fixedElapsedTime;
                        fixedStepCount++;
                        App.FixedUpdateCallback(totalTime, elapsedTime, fixedStepCount);
                    }

                    elapsedTime = accumulatedTime + (fixedElapsedTime * fixedStepCount);
                    remainderFraction = accumulatedTime.Ticks / (float)fixedElapsedTime.Ticks;
                }
                else
                {
                    elapsedTime = accumulatedTime;
                    accumulatedTime = TimeSpan.Zero;
                    remainderFraction = 0.0f;
                }

                App.UpdateCallback(totalTime, elapsedTime);

                _graphics.BeginDraw();
                App.DrawCallback(totalTime, elapsedTime, remainderFraction);
                _graphics.EndDraw();
            }
        }

        private static void Exit()
        {
            App.QuitCallback();
        }

        private static unsafe void PumpEvents()
        {
            while (true)
            {
                SDL_Event e;
                var poll = SDL2.SDL_PollEvent(&e);
                if (poll == 0)
                {
                    break;
                }
            }

            Window.HandleEvents();
            Keyboard.HandleEvents();
        }

        private static void PumpMonoGame()
        {
            FrameworkDispatcher.Update();
        }
    }
}
