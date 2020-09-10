// Copyright (c) Lucas Girouard-Stranks. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the Git repository root directory for full license information.

using System;
using Microsoft.Xna.Framework.Input;

namespace Extended
{
    public static class Keyboard
    {
        private static KeyboardState _currentKeyboardState;
        private static KeyboardState _previousKeyboardState;

        internal static void HandleEvents(TimeSpan elapsedTime)
        {
            _previousKeyboardState = _currentKeyboardState;
            _currentKeyboardState = Microsoft.Xna.Framework.Input.Keyboard.GetState();

            for (var i = 0; i < Input.KeyboardButtonCount; i++)
            {
                var key = (Keys)i;
                var keyboardKey = Map(key);
                var isDown = _currentKeyboardState.IsKeyDown(key);
                Input.UpdateKeyboardButton(keyboardKey, isDown, elapsedTime);
            }
        }

        private static KeyboardKey Map(Keys key)
        {
            return key switch
            {
                Keys.A => KeyboardKey.A,
                Keys.B => KeyboardKey.B,
                Keys.C => KeyboardKey.C,
                Keys.D => KeyboardKey.D,
                Keys.E => KeyboardKey.E,
                Keys.F => KeyboardKey.F,
                Keys.G => KeyboardKey.G,
                Keys.H => KeyboardKey.H,
                Keys.I => KeyboardKey.I,
                Keys.J => KeyboardKey.J,
                Keys.K => KeyboardKey.K,
                Keys.L => KeyboardKey.L,
                Keys.M => KeyboardKey.M,
                Keys.N => KeyboardKey.N,
                Keys.O => KeyboardKey.O,
                Keys.P => KeyboardKey.P,
                Keys.Q => KeyboardKey.Q,
                Keys.R => KeyboardKey.R,
                Keys.S => KeyboardKey.S,
                Keys.T => KeyboardKey.T,
                Keys.U => KeyboardKey.U,
                Keys.V => KeyboardKey.V,
                Keys.W => KeyboardKey.W,
                Keys.X => KeyboardKey.X,
                Keys.Y => KeyboardKey.Y,
                Keys.Z => KeyboardKey.Z,
                Keys.D1 => KeyboardKey.Number1,
                Keys.D2 => KeyboardKey.Number2,
                Keys.D3 => KeyboardKey.Number3,
                Keys.D4 => KeyboardKey.Number4,
                Keys.D5 => KeyboardKey.Number5,
                Keys.D6 => KeyboardKey.Number6,
                Keys.D7 => KeyboardKey.Number7,
                Keys.D8 => KeyboardKey.Number8,
                Keys.D9 => KeyboardKey.Number9,
                Keys.D0 => KeyboardKey.Number0,
                Keys.Enter => KeyboardKey.Enter,
                Keys.Escape => KeyboardKey.Escape,
                Keys.Back => KeyboardKey.BackSpace,
                Keys.Tab => KeyboardKey.Tab,
                Keys.Space => KeyboardKey.Space,
                Keys.OemMinus => KeyboardKey.Minus,
                Keys.OemPlus => KeyboardKey.Plus,
                Keys.OemOpenBrackets => KeyboardKey.BracketLeft,
                Keys.OemCloseBrackets => KeyboardKey.BracketRight,
                Keys.OemBackslash => KeyboardKey.BackSlash,
                Keys.OemSemicolon => KeyboardKey.Semicolon,
                Keys.OemQuotes => KeyboardKey.Quote,
                Keys.OemTilde => KeyboardKey.Grave,
                Keys.OemComma => KeyboardKey.Comma,
                Keys.OemPeriod => KeyboardKey.Period,
                Keys.OemQuestion => KeyboardKey.Slash,
                Keys.CapsLock => KeyboardKey.CapsLock,
                Keys.F1 => KeyboardKey.F1,
                Keys.F2 => KeyboardKey.F2,
                Keys.F3 => KeyboardKey.F3,
                Keys.F4 => KeyboardKey.F4,
                Keys.F5 => KeyboardKey.F5,
                Keys.F6 => KeyboardKey.F6,
                Keys.F7 => KeyboardKey.F7,
                Keys.F8 => KeyboardKey.F8,
                Keys.F9 => KeyboardKey.F9,
                Keys.F10 => KeyboardKey.F10,
                Keys.F11 => KeyboardKey.F11,
                Keys.F12 => KeyboardKey.F12,
                Keys.F13 => KeyboardKey.F13,
                Keys.F14 => KeyboardKey.F14,
                Keys.F15 => KeyboardKey.F15,
                Keys.F16 => KeyboardKey.F16,
                Keys.F17 => KeyboardKey.F17,
                Keys.F18 => KeyboardKey.F18,
                Keys.F19 => KeyboardKey.F19,
                Keys.F20 => KeyboardKey.F20,
                Keys.F21 => KeyboardKey.F21,
                Keys.F22 => KeyboardKey.F22,
                Keys.F23 => KeyboardKey.F23,
                Keys.F24 => KeyboardKey.F24,
                Keys.PrintScreen => KeyboardKey.PrintScreen,
                Keys.Scroll => KeyboardKey.ScrollLock,
                Keys.Pause => KeyboardKey.Pause,
                Keys.Insert => KeyboardKey.Insert,
                Keys.Home => KeyboardKey.Home,
                Keys.PageUp => KeyboardKey.PageUp,
                Keys.Delete => KeyboardKey.Delete,
                Keys.End => KeyboardKey.End,
                Keys.PageDown => KeyboardKey.PageDown,
                Keys.Right => KeyboardKey.Right,
                Keys.Left => KeyboardKey.Left,
                Keys.Down => KeyboardKey.Down,
                Keys.Up => KeyboardKey.Up,
                Keys.NumLock => KeyboardKey.NumLock,
                Keys.Divide => KeyboardKey.KeypadDivide,
                Keys.Multiply => KeyboardKey.KeypadMultiply,
                Keys.NumPad1 => KeyboardKey.Keypad1,
                Keys.NumPad2 => KeyboardKey.Keypad2,
                Keys.NumPad3 => KeyboardKey.Keypad3,
                Keys.NumPad4 => KeyboardKey.Keypad4,
                Keys.NumPad5 => KeyboardKey.Keypad5,
                Keys.NumPad6 => KeyboardKey.Keypad6,
                Keys.NumPad7 => KeyboardKey.Keypad7,
                Keys.NumPad8 => KeyboardKey.Keypad8,
                Keys.NumPad9 => KeyboardKey.Keypad9,
                Keys.NumPad0 => KeyboardKey.Keypad0,
                Keys.LeftControl => KeyboardKey.ControlLeft,
                Keys.LeftShift => KeyboardKey.ShiftLeft,
                Keys.LeftAlt => KeyboardKey.AltLeft,
                Keys.RightControl => KeyboardKey.ControlRight,
                Keys.RightShift => KeyboardKey.ShiftRight,
                Keys.RightAlt => KeyboardKey.AltRight,
                _ => KeyboardKey.Unknown
            };
        }
    }
}
