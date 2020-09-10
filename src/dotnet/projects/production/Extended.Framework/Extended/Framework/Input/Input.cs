// Copyright (c) Lucas Girouard-Stranks. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the Git repository root directory for full license information.

using System;

namespace Extended
{
    public static class Input
    {
        public const int KeyboardButtonCount = 256;
        public const int MouseButtonCount = 13;

        private static readonly InputButton[] _buttonStates = new InputButton[KeyboardButtonCount + MouseButtonCount];

        public static event KeyboardKeyCallback? KeyPressed;

        public static event KeyboardKeyCallback? KeyReleased;

        public static event KeyboardKeyCallback? KeyRepeated;

        public static InputButton KeyboardButton(KeyboardKey key)
        {
            return _buttonStates[(int)key];
        }

        public static InputButton MouseButton(MouseButton mouseButton)
        {
            return _buttonStates[256 + (int)mouseButton];
        }

        public static void UpdateKeyboardButton(KeyboardKey key, bool isDown, in TimeSpan elapsedTime)
        {
            ref var button = ref _buttonStates[(int)key];
            InputButton.Update(ref button, isDown, elapsedTime);

            if (button.IsPressed)
            {
                KeyPressed?.Invoke(button, key);
            }

            if (button.IsReleased)
            {
                KeyReleased?.Invoke(button, key);
            }

            if (button.IsRepeated)
            {
                KeyRepeated?.Invoke(button, key);
            }
        }
    }
}
