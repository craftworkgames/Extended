// Copyright (c) Lucas Girouard-Stranks. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the Git repository root directory for full license information.

using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Security;

namespace Extended
{
    /// <summary>
    ///     Provides access to specific <see cref="NativePlatform" /> functionality and information.
    /// </summary>
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global", Justification = "Public API.")]
    [SuppressMessage("ReSharper", "MemberCanBeInternal", Justification = "Public API.")]
    public static class Native
    {
        public static bool Is64Bit => Environment.Is64BitProcess;

        [SuppressMessage("ReSharper", "CommentTypo", Justification = "Flags.")]
        public static IntPtr LoadLibrary(string libraryPath)
        {
            Trace.Begin("Loading library", ("path", libraryPath));

            var platform = Kernel.Platform;

            var libraryPointer = platform switch
            {
                NativePlatform.Linux => libdl.dlopen(libraryPath, 0x101), // RTLD_GLOBAL | RTLD_LAZY
                NativePlatform.macOS => libSystem.dlopen(libraryPath, 0x101), // RTLD_GLOBAL | RTLD_LAZY
                NativePlatform.Windows => Kernel32.LoadLibrary(libraryPath),
                _ => IntPtr.Zero
            };

            if (libraryPointer != IntPtr.Zero)
            {
                Trace.EndWithSuccess(("libraryPointer", $"{libraryPointer.ToInt64():X}"));
            }
            else
            {
                Trace.EndWithFailure();
            }

            return libraryPointer;
        }

        [SuppressMessage("ReSharper", "CommentTypo", Justification = "Flags.")]
        public static void FreeLibrary(IntPtr libraryPointer)
        {
            Trace.Begin("Freeing library", ("libraryPointer", $"{libraryPointer.ToInt64():X}"));

            var platform = Kernel.Platform;

            // ReSharper disable once UnusedVariable
            var errorCode = platform switch
            {
                NativePlatform.Linux => libdl.dlclose(libraryPointer),
                NativePlatform.macOS => libSystem.dlclose(libraryPointer),
                NativePlatform.Windows => Kernel32.FreeLibrary(libraryPointer),
                _ => 0
            };

            if (errorCode != 0)
            {
                Trace.EndWithSuccess();
            }
            else
            {
                Trace.EndWithFailure(("errorCode", errorCode));
            }
        }

        public static IntPtr GetLibraryFunctionPointer(IntPtr libraryPointer, string functionName)
        {
            Trace.Begin(
                "Loading library function pointer",
                ("libraryPointer", $"{libraryPointer.ToInt64():X}"),
                ("functionName", functionName));

            var platform = Kernel.Platform;

            var functionPointer = platform switch
            {
                NativePlatform.Linux => libdl.dlsym(libraryPointer, functionName),
                NativePlatform.macOS => libSystem.dlsym(libraryPointer, functionName),
                NativePlatform.Windows => Kernel32.GetProcAddress(libraryPointer, functionName),
                _ => IntPtr.Zero
            };

            if (functionPointer != IntPtr.Zero)
            {
                Trace.EndWithSuccess(("functionPointer", $"{functionPointer.ToInt64():X}"));
            }
            else
            {
                Trace.EndWithFailure();
            }

            return functionPointer;
        }

        public static TDelegate GetLibraryFunction<TDelegate>(IntPtr libraryHandle)
            where TDelegate : Delegate
        {
            return GetLibraryFunction<TDelegate>(libraryHandle, string.Empty);
        }

        public static TDelegate GetLibraryFunction<TDelegate>(IntPtr libraryHandle, string functionName)
            where TDelegate : Delegate
        {
            if (string.IsNullOrEmpty(functionName))
            {
                functionName = typeof(TDelegate).Name;
                if (functionName.StartsWith("d_", StringComparison.Ordinal))
                {
                    functionName = functionName.Substring(2);
                }
            }

            var functionHandle = GetLibraryFunctionPointer(libraryHandle, functionName);
            return (functionHandle == IntPtr.Zero
                ? null!
                : Marshal.GetDelegateForFunctionPointer<TDelegate>(functionHandle)) !;
        }

        [SuppressUnmanagedCodeSecurity]
        [SuppressMessage("ReSharper", "SA1300", Justification = "Native API.")]
        private static class libdl
        {
            private const string LibraryName = "libdl";

            [DllImport(LibraryName, CharSet = CharSet.Ansi)]
            public static extern IntPtr dlopen(string fileName, int flags);

            [DllImport(LibraryName, CharSet = CharSet.Ansi)]
            public static extern IntPtr dlsym(IntPtr handle, string name);

            [DllImport(LibraryName)]
            public static extern int dlclose(IntPtr handle);
        }

        [SuppressUnmanagedCodeSecurity]
        private static class Kernel32
        {
            // ReSharper disable once MemberHidesStaticFromOuterClass
            [DllImport("kernel32", CharSet = CharSet.Ansi)]
            public static extern IntPtr LoadLibrary(string fileName);

            [DllImport("kernel32", CharSet = CharSet.Ansi)]
            public static extern IntPtr GetProcAddress(IntPtr module, string procName);

            // ReSharper disable once MemberHidesStaticFromOuterClass
            [DllImport("kernel32")]
            public static extern int FreeLibrary(IntPtr module);
        }

        [SuppressUnmanagedCodeSecurity]
        [SuppressMessage("ReSharper", "SA1300", Justification = "Native API.")]
        private static class libSystem
        {
            private const string LibraryName = "libSystem";

            [DllImport(LibraryName, CharSet = CharSet.Ansi)]
            public static extern IntPtr dlopen(string fileName, int flags);

            [DllImport(LibraryName, CharSet = CharSet.Ansi)]
            public static extern IntPtr dlsym(IntPtr handle, string name);

            [DllImport(LibraryName, CallingConvention = CallingConvention.StdCall)]
            public static extern int dlclose(IntPtr handle);
        }
    }
}
