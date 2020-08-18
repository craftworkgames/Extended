// Copyright (c) Lucas Girouard-Stranks. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the Git repository root directory for full license information.

using System;

namespace Extended
{
    /// <summary>
    ///     Provides access to specific <see cref="NativePlatform" /> functionality and information.
    /// </summary>
    public static partial class Native
    {
        public static bool Is64Bit => Environment.Is64BitProcess;
    }
}
