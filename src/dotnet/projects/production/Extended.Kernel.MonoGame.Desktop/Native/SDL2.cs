// Copyright (c) Lucas Girouard-Stranks. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the Git repository root directory for full license information.

using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using Extended;

[SuppressMessage("ReSharper", "SA1310", Justification = "SDL2 API.")]
[SuppressMessage("ReSharper", "SA1300", Justification = "SDL2 API.")]
public static class SDL2
{
    private static IntPtr _libraryHandle;

    [EditorBrowsable(EditorBrowsableState.Never)]
    [UnmanagedFunctionPointer(CallingConvention.Winapi)]
    public delegate void d_SDL_ShowWindow(IntPtr window);

    public static d_SDL_ShowWindow SDL_ShowWindow = null!;

    public static void LoadApi()
    {
        var libraryPath = GetLibraryPath();
        _libraryHandle = Native.LoadLibrary(libraryPath);

        SDL_ShowWindow = Native.GetLibraryFunction<d_SDL_ShowWindow>(_libraryHandle);
    }

    public static void UnloadApi()
    {
        SDL_ShowWindow = null!;

        Native.FreeLibrary(_libraryHandle);
    }

    private static string GetLibraryPath()
    {
        var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        var platform = App.Platform;

        return platform switch
        {
            NativePlatform.Windows => Native.Is64Bit
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
