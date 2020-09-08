// Copyright (c) Lucas Girouard-Stranks. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the Git repository root directory for full license information.

// Original code derived from: https://github.com/spurious/SDL-mirror/blob/master/include/SDL_keyboard.h

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

// ReSharper disable all

using System.Diagnostics.CodeAnalysis;

namespace SDL
{
    /// <summary>
    ///     The SDL keysym structure, used in key events.
    /// </summary>
    [SuppressMessage("ReSharper", "SX1309", Justification = "C code.")]
    [SuppressMessage("ReSharper", "SA1307", Justification = "C code.")]
    public readonly struct SDL_Keysym
    {
        public readonly SDL_Scancode scancode;      /* SDL physical key code - see ::SDL_Scancode for details */
        public readonly SDL_Keycode sym;            /* SDL virtual key code - see ::SDL_Keycode for details */
        public readonly SDL_Keymod mod;                 /* current key modifiers */
        public readonly uint unused;
    }
}
