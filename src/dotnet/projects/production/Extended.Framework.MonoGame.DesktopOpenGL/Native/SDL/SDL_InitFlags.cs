// Copyright (c) Lucas Girouard-Stranks. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the Git repository root directory for full license information.

// Original code derived from: https://github.com/spurious/SDL-mirror/blob/master/include/SDL.h

/*
  Simple DirectMedia Layer
  Copyright (C) 1997-2020 Sam Lantinga <slouken@libsdl.org>
  This software is provided 'as-is', without any express or implied
  warranty.  In no event will the authors be held liable for any damages
  arising from the use of this software.
  Permission is granted to anyone to use this software for any purpose,
  including commercial applications, and to alter it and redistribute it
  freely, subject to the following restrictions:
  1. The origin of this software must not be misrepresented; you must not
     claim that you wrote the original software. If you use this software
     in a product, an acknowledgment in the product documentation would be
     appreciated but is not required.
  2. Altered source versions must be plainly marked as such, and must not be
     misrepresented as being the original software.
  3. This notice may not be removed or altered from any source distribution.
*/

// ReSharper disable All

using System;

namespace SDL
{
    [Flags]
    public enum SDL_InitFlags : uint
    {
        SDL_INIT_TIMER = 0x00000001u,
        SDL_INIT_AUDIO = 0x00000010u,
        SDL_INIT_VIDEO = 0x00000020u, /* SDL_INIT_VIDEO implies SDL_INIT_EVENTS */
        SDL_INIT_JOYSTICK = 0x00000200u, /* SDL_INIT_JOYSTICK implies SDL_INIT_EVENTS */
        SDL_INIT_HAPTIC = 0x00001000u,
        SDL_INIT_GAMECONTROLLER = 0x00002000u, /* SDL_INIT_GAMECONTROLLER implies SDL_INIT_JOYSTICK */
        SDL_INIT_EVENTS = 0x00004000u,
        SDL_INIT_SENSOR = 0x00008000u,
        SDL_INIT_NOPARACHUTE = 0x00100000u, /* compatibility; this flag is ignored. */
    }
}
