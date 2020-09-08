// Copyright (c) Lucas Girouard-Stranks. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the Git repository root directory for full license information.

using System;
using System.Runtime.CompilerServices;

namespace Extended
{
    public struct ButtonState
    {
        private TimeSpan _downDuration;
        private byte _pressedState;

        private const int StateIsDownMask = 0x1;
        private const int StateIsDownMaskValue = 0x1;

        private const int StateIsUpMask = 0x1;
        private const int StateIsUpMaskValue = 0x0;

        private const int StateIsPressedMask = 0x3;
        private const int StateIsPressedMaskValue = 0x1;

        private const int StateWasDownMask = 0x2;
        private const int StateWasDownMaskValue = 0x1;

        private const int StateWasUpMask = 0x2;
        private const int StateWasUpMaskValue = 0x0;

        // ReSharper disable once ConvertToAutoPropertyWithPrivateSetter
        public TimeSpan DownDuration
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _downDuration;
            set => _downDuration = value;
        }

        public bool IsDown
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => (_pressedState & StateIsDownMask) == StateIsDownMaskValue;
        }

        public bool IsUp
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => (_pressedState & StateIsUpMask) == StateIsUpMaskValue;
        }

        public bool IsPressed
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => (_pressedState & StateIsPressedMask) == StateIsPressedMaskValue;
        }

        public bool WasDown
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => (_pressedState & StateWasDownMask) == StateWasDownMaskValue;
        }

        public bool WasUp
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => (_pressedState & StateWasUpMask) == StateWasUpMaskValue;
        }

        internal static void Update(ref ButtonState buttonState, bool isDown, TimeSpan elapsedTime)
        {
            var intIsDown = Convert.ToInt32(isDown);
            var newPressedState = buttonState._pressedState << 1 | intIsDown;
            buttonState._pressedState = (byte)newPressedState;
            if (isDown)
            {
                buttonState.DownDuration += elapsedTime;
            }
            else
            {
                buttonState.DownDuration = TimeSpan.Zero;
            }
        }
    }
}
