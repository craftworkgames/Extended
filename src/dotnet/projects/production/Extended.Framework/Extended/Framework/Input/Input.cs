// Copyright (c) Lucas Girouard-Stranks. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the Git repository root directory for full license information.

using System;

namespace Extended
{
    public static class Input
    {
        public const int TotalButtonCount = KeyboardButtonCount + MouseButtonCount;
        public const int KeyboardButtonCount = 256;
        public const int MouseButtonCount = 5;

        private static readonly InputButtonState[] _buttonStates = new InputButtonState[TotalButtonCount];

        public static event KeyboardButtonCallback? KeyPressed;

        public static event KeyboardButtonCallback? KeyReleased;

        public static event KeyboardButtonCallback? KeyRepeated;

        public static event MouseButtonCallback? MousePressed;

        public static event MouseButtonCallback? MouseReleased;

        public static event MouseButtonCallback? MouseRepeated;

        public static InputButtonState KeyboardButton(KeyboardButton button)
        {
            return _buttonStates[(int)button];
        }

        public static InputButtonState MouseButton(MouseButton button)
        {
            return _buttonStates[KeyboardButtonCount + (int)button];
        }

        public static void UpdateKeyboardButton(KeyboardButton keyboardButton, bool isDown, TimeSpan elapsedTime)
        {
            ref var state = ref _buttonStates[(int)keyboardButton];
            InputButtonState.Update(ref state, isDown, elapsedTime);

            if (state.IsPressed)
            {
                KeyPressed?.Invoke(state, keyboardButton);
            }

            if (state.IsReleased)
            {
                KeyReleased?.Invoke(state, keyboardButton);
            }

            if (state.IsRepeated)
            {
                KeyRepeated?.Invoke(state, keyboardButton);
            }
        }

        public static void UpdateMouseButton(MouseButton mouseButton, bool isDown, TimeSpan elapsedTime)
        {
            ref var state = ref _buttonStates[KeyboardButtonCount + (int)mouseButton];
            InputButtonState.Update(ref state, isDown, elapsedTime);

            if (state.IsPressed)
            {
                MousePressed?.Invoke(state, mouseButton);
            }

            if (state.IsReleased)
            {
                MouseReleased?.Invoke(state, mouseButton);
            }

            if (state.IsRepeated)
            {
                MouseRepeated?.Invoke(state, mouseButton);
            }
        }
    }
}
