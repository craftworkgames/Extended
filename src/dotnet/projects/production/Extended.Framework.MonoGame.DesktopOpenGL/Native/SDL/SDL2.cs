// Copyright (c) Lucas Girouard-Stranks. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the Git repository root directory for full license information.

using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using Extended;

namespace SDL
{
    [SuppressMessage("ReSharper", "SA1310", Justification = "SDL2 API.")]
    [SuppressMessage("ReSharper", "SA1300", Justification = "SDL2 API.")]
    internal static class SDL2
    {
        public static D_SDL_GetVersion SDL_GetVersion = null!;

        public static D_SDL_SetHint SDL_SetHint = null!;

        public static D_SDL_GetTicks SDL_GetTicks = null!;

        public static D_SDL_GetPerformanceCounter SDL_GetPerformanceCounter = null!;

        public static D_SDL_GetPerformanceFrequency SDL_GetPerformanceFrequency = null!;

        public static D_SDL_PumpEvents SDL_PumpEvents = null!;

        public static D_SDL_PeepEvents SDL_PeepEvents = null!;

        public static D_SDL_PollEvent SDL_PollEvent = null!;

        public static D_SDL_ShowWindow SDL_ShowWindow = null!;

        public static D_SDL_Init SDL_Init = null!;

        public static D_SDL_DisableScreenSaver SDL_DisableScreenSaver = null!;

        private static IntPtr _libraryHandle;

        public static unsafe void Load()
        {
            var libraryPath = GetLibraryPath();
            _libraryHandle = NativeLibrary.Load(libraryPath);

            SDL_GetVersion = NativeLibrary.GetFunction<D_SDL_GetVersion>(_libraryHandle);
            SDL_SetHint = NativeLibrary.GetFunction<D_SDL_SetHint>(_libraryHandle);
            SDL_GetTicks = NativeLibrary.GetFunction<D_SDL_GetTicks>(_libraryHandle);
            SDL_GetPerformanceCounter = NativeLibrary.GetFunction<D_SDL_GetPerformanceCounter>(_libraryHandle);
            SDL_GetPerformanceFrequency = NativeLibrary.GetFunction<D_SDL_GetPerformanceFrequency>(_libraryHandle);
            SDL_PumpEvents = NativeLibrary.GetFunction<D_SDL_PumpEvents>(_libraryHandle);
            SDL_PeepEvents = NativeLibrary.GetFunction<D_SDL_PeepEvents>(_libraryHandle);
            SDL_PollEvent = NativeLibrary.GetFunction<D_SDL_PollEvent>(_libraryHandle);
            SDL_ShowWindow = NativeLibrary.GetFunction<D_SDL_ShowWindow>(_libraryHandle);
            SDL_Init = NativeLibrary.GetFunction<D_SDL_Init>(_libraryHandle);
            SDL_DisableScreenSaver = NativeLibrary.GetFunction<D_SDL_DisableScreenSaver>(_libraryHandle);
        }

        public static void Unload()
        {
            SDL_GetVersion = null!;
            SDL_SetHint = null!;
            SDL_GetTicks = null!;
            SDL_GetPerformanceCounter = null!;
            SDL_GetPerformanceFrequency = null!;
            SDL_PumpEvents = null!;
            SDL_PeepEvents = null!;
            SDL_ShowWindow = null!;
            SDL_Init = null!;
            SDL_DisableScreenSaver = null!;

            NativeLibrary.Free(_libraryHandle);
        }

        private static string GetLibraryPath()
        {
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var platform = Framework.Platform;

            return platform switch
            {
                NativePlatform.Windows => Environment.Is64BitProcess
                    ? $"{baseDirectory}runtimes/win-x64/native/SDL2.dll"
                    : $"{baseDirectory}runtimes/win-x86/native/SDL2.dll",
                NativePlatform.macOS =>
                    $"{baseDirectory}runtimes/osx/native/libSDL2-2.0.0.dylib",
                NativePlatform.Linux =>
                    $"{baseDirectory}runtimes/linux-x64/native/libSDL2-2.0.so.0",
                _ => string.Empty
            };
        }
    }
}
