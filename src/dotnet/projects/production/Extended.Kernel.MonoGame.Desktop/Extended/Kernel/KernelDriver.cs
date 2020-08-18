// Copyright (c) Lucas Girouard-Stranks. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the Git repository root directory for full license information.

using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using JetBrains.Annotations;
using Microsoft.Xna.Framework;

namespace Extended
{
    [UsedImplicitly]
    internal class KernelDriver
    {
        private static Game? _game;
        private static object? _gamePlatform;
        private static Type _baseGameType;
        private static Action _pumpEventsSDL2;
        private static Action _gameTick;
        private static FieldInfo _isExitingField;

        [UsedImplicitly]
        public static NativePlatform Platform => GetNativePlatform();

        [UsedImplicitly]
        public static bool IsExiting => GetIsExiting();

        [UsedImplicitly]
        public static KernelModuleTypes Setup(KernelModuleTypes moduleTypes, object? param = null)
        {
            // Ignore any requested modules... MonoGame is all or nothing

            SetGame(param);
            InitializeReflectedMembers();
            SDL2.LoadApi();

            return KernelModuleTypes.All;
        }

        [UsedImplicitly]
        public static void Shutdown()
        {
            _game!.Dispose();
            _game = null;
        }

        [UsedImplicitly]
        public static void PumpEvents()
        {
            _pumpEventsSDL2();
            _game!.Tick();
        }

        [UsedImplicitly]
        public static void Run()
        {
            RunGameNoLoop();
            App.OnLoop();
            ExitGame();
        }

        private static void SetGame(object? param)
        {
            var game = param as Game;
            _game = game ?? new KernelGame();
        }

        private static void InitializeReflectedMembers()
        {
            var gameType = _game!.GetType();
            while (true)
            {
                gameType = gameType.BaseType;
                if (gameType!.Name == "Game")
                {
                    break;
                }
            }

            _baseGameType = gameType;

            var gamePlatformField = _baseGameType.GetField(
                "Platform", BindingFlags.NonPublic | BindingFlags.Instance);
            _gamePlatform = gamePlatformField!.GetValue(_game);
            var gamePlatformType = _gamePlatform.GetType();

            var pumpEventsSDL2Method = gamePlatformType.GetMethod(
                "SdlRunLoop", BindingFlags.NonPublic | BindingFlags.Instance);
            _pumpEventsSDL2 = (Action)pumpEventsSDL2Method!.CreateDelegate(typeof(Action), _gamePlatform);

            _isExitingField = gamePlatformType.GetField(
                "_isExiting",
                BindingFlags.NonPublic | BindingFlags.Instance) !;
        }

        private static void RunGameNoLoop()
        {
            // WARNING!: This function is dependent on the internals of MonoGame; always check the source of truth:
            // https://github.com/MonoGame/MonoGame/blob/develop/MonoGame.Framework/Game.cs

            var type = _game!.GetType();

            var doInitializeMethod = _baseGameType.GetMethod(
                "DoInitialize", BindingFlags.NonPublic | BindingFlags.Instance);
            doInitializeMethod!.Invoke(_game, null);

            var initializedField = _baseGameType.GetField(
                "_initialized",
                BindingFlags.NonPublic | BindingFlags.Instance);
            initializedField!.SetValue(_game, true);

            var beginRunMethod = type.GetMethod(
                "BeginRun", BindingFlags.NonPublic | BindingFlags.Instance);
            beginRunMethod!.Invoke(_game, null);

            var gameTimerField = _baseGameType.GetField(
                "_gameTimer", BindingFlags.NonPublic | BindingFlags.Instance);
            gameTimerField!.SetValue(_game, Stopwatch.StartNew());

            var doUpdateMethod = _baseGameType.GetMethod(
                "DoUpdate", BindingFlags.NonPublic | BindingFlags.Instance);
            doUpdateMethod!.Invoke(_game, new[] { new GameTime() });

            SDL2.SDL_ShowWindow(_game.Window.Handle);
        }

        private static void ExitGame()
        {
            // WARNING!: This function is dependent on the internals of MonoGame; always check the source of truth:
            // https://github.com/MonoGame/MonoGame/blob/develop/MonoGame.Framework/Game.cs

            var type = _game!.GetType();
            var baseType = type.BaseType!;

            var endRunMethod = type.GetMethod(
                "EndRun", BindingFlags.NonPublic | BindingFlags.Instance);
            endRunMethod!.Invoke(_game, null);

            var doExitingMethod = baseType.GetMethod(
                "DoExiting", BindingFlags.NonPublic | BindingFlags.Instance);
            doExitingMethod!.Invoke(_game, null);
        }

        private static void PumpEventsSDL2()
        {
        }

        private static NativePlatform GetNativePlatform()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return NativePlatform.Windows;
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                return NativePlatform.Linux;
            }

            // ReSharper disable once ConvertIfStatementToReturnStatement
            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                return NativePlatform.macOS;
            }

            return NativePlatform.Unknown;
        }

        private static bool GetIsExiting()
        {
            var isExiting = (int)_isExitingField.GetValue(_gamePlatform);
            return Convert.ToBoolean(isExiting);
        }
    }
}
