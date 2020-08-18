// Copyright (c) Lucas Girouard-Stranks. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the Git repository root directory for full license information.

using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Security;

namespace Extended
{
    [SuppressMessage("ReSharper", "SA1300", Justification = "Original names.")]
    [SuppressMessage("ReSharper", "IdentifierTypo", Justification = "Orignal names.")]
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global", Justification = "API.")]
    [SuppressMessage("ReSharper", "UnusedMember.Global", Justification = "API.")]
    [SuppressMessage("ReSharper", "MemberCanBeInternal", Justification = "API.")]
    public static partial class Native
    {
        [SuppressMessage("ReSharper", "CommentTypo", Justification = "Flags.")]
        public static IntPtr LoadLibrary(string libraryPath)
        {
            App.BeginTrace("Loading library", ("path", libraryPath));

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
                App.EndTraceSuccess(("libraryPointer", $"{libraryPointer.ToInt64():X}"));
            }
            else
            {
                App.EndTraceFailure();
            }

            return libraryPointer;
        }

        [SuppressMessage("ReSharper", "CommentTypo", Justification = "Flags.")]
        public static void FreeLibrary(IntPtr libraryPointer)
        {
            App.BeginTrace("Freeing library", ("libraryPointer", $"{libraryPointer.ToInt64():X}"));

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
                App.EndTraceSuccess();
            }
            else
            {
                App.EndTraceFailure(("errorCode", errorCode));
            }
        }

        public static IntPtr GetLibraryFunctionPointer(IntPtr libaryPointer, string functionName)
        {
            App.BeginTrace(
                "Loading library function pointer",
                ("libraryPointer", $"{libaryPointer.ToInt64():X}"),
                ("functionName", functionName));

            var platform = Kernel.Platform;

            var functionPointer = platform switch
            {
                NativePlatform.Linux => libdl.dlsym(libaryPointer, functionName),
                NativePlatform.macOS => libSystem.dlsym(libaryPointer, functionName),
                NativePlatform.Windows => Kernel32.GetProcAddress(libaryPointer, functionName),
                _ => IntPtr.Zero
            };

            if (functionPointer != IntPtr.Zero)
            {
                App.EndTraceSuccess(("functionPointer", $"{functionPointer.ToInt64():X}"));
            }
            else
            {
                App.EndTraceFailure();
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
