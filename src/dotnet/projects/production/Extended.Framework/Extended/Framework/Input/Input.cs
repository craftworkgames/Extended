// Copyright (c) Lucas Girouard-Stranks. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the Git repository root directory for full license information.

using System;

namespace Extended
{
    public static class Input
    {
        private const int KeyButtonCount = 256;
        private const int MouseButtonCount = 13;

        private static readonly ButtonState[] _buttonStates = new ButtonState[KeyButtonCount + MouseButtonCount];

        public static ButtonState KeyButton(KeyboardKey key)
        {
            return _buttonStates[(int)key];
        }

        public static ButtonState MouseButton(MouseButton mouseButton)
        {
            return _buttonStates[256 + (int)mouseButton];
        }

        internal static void UpdateKeyButton(KeyboardKey key, bool isDown, in TimeSpan elapsedTime)
        {
            ButtonState.Update(ref _buttonStates[(int)key], isDown, elapsedTime);
        }
    }
}
