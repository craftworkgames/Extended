// Copyright (c) Lucas Girouard-Stranks. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the Git repository root directory for full license information.

using System;
using System.Diagnostics.CodeAnalysis;

namespace Extended
{
    /// <summary>
    ///     Defines personal computing device ecosystems where applications are executed.
    /// </summary>
    [Flags]
    [SuppressMessage("ReSharper", "MemberCanBeInternal", Justification = "Public API.")]
    public enum NativePlatform : uint
    {
        /// <summary>
        ///     Unknown platform.
        /// </summary>
        Unknown = 0,

        /// <summary>
        ///     Versions of the Windows on 64-bit computing architecture. Includes Windows 7, Windows 8.1, Windows 10,
        ///     and up.
        /// </summary>
        Windows = 1 << 0,

        /// <summary>
        ///     Versions of macOS on 64-bit computing architecture. Includes macOS 10.3 and up.
        /// </summary>
        [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "Product name.")]
        [SuppressMessage("ReSharper", "SA1300", Justification = "Product name.")]
        macOS = 1 << 1,

        /// <summary>
        ///     Distributions of Linux on 64-bit computing architecture. Includes, but is not limited to, CentOS,
        ///     Debian, Fedora, and Ubuntu.
        /// </summary>
        Linux = 1 << 2,

        /// <summary>
        ///     Versions of Android on 64-bit computing architecture. Includes Android 5.x and up.
        /// </summary>
        Android = 1 << 3,

        /// <summary>
        ///     Versions of iOS on 64-bit computing architecture. Includes iOS 11.x and up.
        /// </summary>
        [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "Product name.")]
        [SuppressMessage("ReSharper", "SA1300", Justification = "Product name.")]
        iOS = 1 << 4,

        /// <summary>
        ///     Versions of tvOS 64-bit computing architecture. Includes tvOS 13.x and up.
        /// </summary>
        [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "Product name.")]
        [SuppressMessage("ReSharper", "SA1300", Justification = "Product name.")]
        tvOS = 1 << 5,

        /// <summary>
        ///     Any modern web-browser using WebAssembly with 64-bit computing architecture.
        /// </summary>
        Web = 1 << 6,
    }
}
