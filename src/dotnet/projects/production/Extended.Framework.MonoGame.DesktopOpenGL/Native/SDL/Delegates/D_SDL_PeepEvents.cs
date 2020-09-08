// Copyright (c) Lucas Girouard-Stranks. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the Git repository root directory for full license information.

using System.ComponentModel;
using System.Runtime.InteropServices;

namespace SDL
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    [UnmanagedFunctionPointer(CallingConvention.Winapi)]
    public unsafe delegate int D_SDL_PeepEvents(
        SDL_Event* events,
        int numEvents,
        SDL_EventAction action,
        SDL_EventType minType,
        SDL_EventType maxType);
}
