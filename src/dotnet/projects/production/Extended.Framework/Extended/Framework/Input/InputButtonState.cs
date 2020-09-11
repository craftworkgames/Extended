// Copyright (c) Lucas Girouard-Stranks. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the Git repository root directory for full license information.

using System;
using System.Runtime.CompilerServices;

namespace Extended
{
    public readonly struct InputButtonState
    {
        public readonly TimeSpan DownDuration;
        public readonly byte State;

        internal InputButtonState(TimeSpan downDuration, byte pressedState)
        {
            DownDuration = downDuration;
            State = pressedState;
        }

        public bool IsDown
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => (State & 0x1) == 1;
        }

        public bool IsUp
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => (State & 0x1) == 0;
        }

        public bool WasDown
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => (State & 0x2) == 1;
        }

        public bool WasUp
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => (State & 0x2) == 0;
        }

        public bool IsPressed
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => State == 1;
        }

        public bool IsReleased
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => State == 2;
        }

        public bool IsRepeated
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => State == 3;
        }

        internal static void Update(ref InputButtonState button, bool isDown, TimeSpan elapsedTime)
        {
            var byteIsDown = Convert.ToByte(isDown);
            var newPressedState = (byte)((button.State & 0x1) << 1 | byteIsDown);

            TimeSpan downDuration;
            if (isDown)
            {
                downDuration = button.DownDuration + elapsedTime;
            }
            else
            {
                downDuration = TimeSpan.Zero;
            }

            button = new InputButtonState(downDuration, newPressedState);
        }
    }
}
