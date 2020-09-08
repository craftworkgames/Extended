// Copyright (c) Lucas Girouard-Stranks. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the Git repository root directory for full license information.

// Original code derived from: https://github.com/spurious/SDL-mirror/blob/master/include/SDL_events.h

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
using System.Runtime.InteropServices;

namespace SDL
{
    [StructLayout(LayoutKind.Explicit, Size = 56, Pack = 8)]
    [SuppressMessage("ReSharper", "SA1307", Justification = "3rd party.")]
    public struct SDL_Event
    {
        [FieldOffset(0)]
        public readonly SDL_EventType type; /* Event type, shared with all events */
        [FieldOffset(0)]
        public readonly SDL_CommonEvent common; /* Common event data */
        // [FieldOffset(0)]
        // public readonly SDL_DisplayEvent display; /* Display event data */
        // [FieldOffset(0)]
        // public readonly SDL_WindowEvent window; /* Window event data */
        [FieldOffset(0)]
        public readonly SDL_KeyboardEvent key; /* Keyboard event data */
        // [FieldOffset(0)]
        // public readonly SDL_TextEditingEvent edit; /* Text editing event data */
        // [FieldOffset(0)]
        // public readonly SDL_TextInputEvent text; /* Text input event data */
        // [FieldOffset(0)]
        // public readonly SDL_MouseMotionEvent motion; /* Mouse motion event data */
        // [FieldOffset(0)]
        // public readonly SDL_MouseButtonEvent button; /* Mouse button event data */
        // [FieldOffset(0)]
        // public readonly SDL_MouseWheelEvent wheel; /* Mouse wheel event data */
        // [FieldOffset(0)]
        // public readonly SDL_JoyAxisEvent jaxis; /* Joystick axis event data */
        // [FieldOffset(0)]
        // public readonly SDL_JoyBallEvent jball; /* Joystick ball event data */
        // [FieldOffset(0)]
        // public readonly SDL_JoyHatEvent jhat; /* Joystick hat event data */
        // [FieldOffset(0)]
        // public readonly SDL_JoyButtonEvent jbutton; /* Joystick button event data */
        // [FieldOffset(0)]
        // public readonly SDL_JoyDeviceEvent jdevice; /* Joystick device change event data */
        // [FieldOffset(0)]
        // public readonly SDL_ControllerAxisEvent caxis; /* Game Controller axis event data */
        // [FieldOffset(0)]
        // public readonly SDL_ControllerButtonEvent cbutton; /* Game Controller button event data */
        // [FieldOffset(0)]
        // public readonly SDL_ControllerDeviceEvent cdevice; /* Game Controller device event data */
        // [FieldOffset(0)]
        // public readonly SDL_AudioDeviceEvent adevice; /* Audio device event data */
        // [FieldOffset(0)]
        // public readonly SDL_SensorEvent sensor; /* Sensor event data */
        // [FieldOffset(0)]
        // public readonly SDL_QuitEvent quit; /* Quit request event data */
        // [FieldOffset(0)]
        // public readonly SDL_UserEvent user; /* Custom event data */
        // [FieldOffset(0)]
        // public readonly SDL_SysWMEvent syswm; /* System dependent window event data */
        // [FieldOffset(0)]
        // public readonly SDL_TouchFingerEvent tfinger; /* Touch finger event data */
        // [FieldOffset(0)]
        // public readonly SDL_MultiGestureEvent mgesture; /* Gesture event data */
        // [FieldOffset(0)]
        // public readonly SDL_DollarGestureEvent dgesture; /* Gesture event data */
        // [FieldOffset(0)]
        // public readonly SDL_DropEvent drop; /* Drag and drop event data */
    }
}
