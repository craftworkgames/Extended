// Copyright (c) Lucas Girouard-Stranks. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the Git repository root directory for full license information.

using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Extended
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    [UnmanagedFunctionPointer(CallingConvention.Winapi)]
    public delegate void GraphicsFunctionClear(Rgba32F color);
}
