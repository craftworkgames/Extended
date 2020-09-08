// Copyright (c) Lucas Girouard-Stranks. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the Git repository root directory for full license information.

using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace SDL
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    [UnmanagedFunctionPointer(CallingConvention.Winapi)]
    public delegate BlittableBoolean D_SDL_SetHint(string name, string value);
}
