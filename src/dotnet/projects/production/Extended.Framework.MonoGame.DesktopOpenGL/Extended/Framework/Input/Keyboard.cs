// Copyright (c) Lucas Girouard-Stranks. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the Git repository root directory for full license information.

using System;
using Microsoft.Xna.Framework.Input;

namespace Extended
{
    public static class Keyboard
    {
        public static void Update(TimeSpan deltaTime)
        {
            var keyboardState = Microsoft.Xna.Framework.Input.Keyboard.GetState();

            for (var i = 0; i < Input.KeyboardButtonCount; i++)
            {
                var key = (Keys)i;
                var isDown = keyboardState.IsKeyDown(key);
                var keyboardKey = Map(key);
                Input.UpdateKeyboardButton(keyboardKey, isDown, deltaTime);
            }
        }

        private static KeyboardButton Map(Keys key)
        {
            return key switch
            {
                Keys.A => KeyboardButton.A,
                Keys.B => KeyboardButton.B,
                Keys.C => KeyboardButton.C,
                Keys.D => KeyboardButton.D,
                Keys.E => KeyboardButton.E,
                Keys.F => KeyboardButton.F,
                Keys.G => KeyboardButton.G,
                Keys.H => KeyboardButton.H,
                Keys.I => KeyboardButton.I,
                Keys.J => KeyboardButton.J,
                Keys.K => KeyboardButton.K,
                Keys.L => KeyboardButton.L,
                Keys.M => KeyboardButton.M,
                Keys.N => KeyboardButton.N,
                Keys.O => KeyboardButton.O,
                Keys.P => KeyboardButton.P,
                Keys.Q => KeyboardButton.Q,
                Keys.R => KeyboardButton.R,
                Keys.S => KeyboardButton.S,
                Keys.T => KeyboardButton.T,
                Keys.U => KeyboardButton.U,
                Keys.V => KeyboardButton.V,
                Keys.W => KeyboardButton.W,
                Keys.X => KeyboardButton.X,
                Keys.Y => KeyboardButton.Y,
                Keys.Z => KeyboardButton.Z,
                Keys.D1 => KeyboardButton.Number1,
                Keys.D2 => KeyboardButton.Number2,
                Keys.D3 => KeyboardButton.Number3,
                Keys.D4 => KeyboardButton.Number4,
                Keys.D5 => KeyboardButton.Number5,
                Keys.D6 => KeyboardButton.Number6,
                Keys.D7 => KeyboardButton.Number7,
                Keys.D8 => KeyboardButton.Number8,
                Keys.D9 => KeyboardButton.Number9,
                Keys.D0 => KeyboardButton.Number0,
                Keys.Enter => KeyboardButton.Enter,
                Keys.Escape => KeyboardButton.Escape,
                Keys.Back => KeyboardButton.BackSpace,
                Keys.Tab => KeyboardButton.Tab,
                Keys.Space => KeyboardButton.Space,
                Keys.OemMinus => KeyboardButton.Minus,
                Keys.OemPlus => KeyboardButton.Plus,
                Keys.OemOpenBrackets => KeyboardButton.BracketLeft,
                Keys.OemCloseBrackets => KeyboardButton.BracketRight,
                Keys.OemBackslash => KeyboardButton.BackSlash,
                Keys.OemSemicolon => KeyboardButton.Semicolon,
                Keys.OemQuotes => KeyboardButton.Quote,
                Keys.OemTilde => KeyboardButton.Grave,
                Keys.OemComma => KeyboardButton.Comma,
                Keys.OemPeriod => KeyboardButton.Period,
                Keys.OemQuestion => KeyboardButton.Slash,
                Keys.CapsLock => KeyboardButton.CapsLock,
                Keys.F1 => KeyboardButton.F1,
                Keys.F2 => KeyboardButton.F2,
                Keys.F3 => KeyboardButton.F3,
                Keys.F4 => KeyboardButton.F4,
                Keys.F5 => KeyboardButton.F5,
                Keys.F6 => KeyboardButton.F6,
                Keys.F7 => KeyboardButton.F7,
                Keys.F8 => KeyboardButton.F8,
                Keys.F9 => KeyboardButton.F9,
                Keys.F10 => KeyboardButton.F10,
                Keys.F11 => KeyboardButton.F11,
                Keys.F12 => KeyboardButton.F12,
                Keys.F13 => KeyboardButton.F13,
                Keys.F14 => KeyboardButton.F14,
                Keys.F15 => KeyboardButton.F15,
                Keys.F16 => KeyboardButton.F16,
                Keys.F17 => KeyboardButton.F17,
                Keys.F18 => KeyboardButton.F18,
                Keys.F19 => KeyboardButton.F19,
                Keys.F20 => KeyboardButton.F20,
                Keys.F21 => KeyboardButton.F21,
                Keys.F22 => KeyboardButton.F22,
                Keys.F23 => KeyboardButton.F23,
                Keys.F24 => KeyboardButton.F24,
                Keys.PrintScreen => KeyboardButton.PrintScreen,
                Keys.Scroll => KeyboardButton.ScrollLock,
                Keys.Pause => KeyboardButton.Pause,
                Keys.Insert => KeyboardButton.Insert,
                Keys.Home => KeyboardButton.Home,
                Keys.PageUp => KeyboardButton.PageUp,
                Keys.Delete => KeyboardButton.Delete,
                Keys.End => KeyboardButton.End,
                Keys.PageDown => KeyboardButton.PageDown,
                Keys.Right => KeyboardButton.Right,
                Keys.Left => KeyboardButton.Left,
                Keys.Down => KeyboardButton.Down,
                Keys.Up => KeyboardButton.Up,
                Keys.NumLock => KeyboardButton.NumLock,
                Keys.Divide => KeyboardButton.KeypadDivide,
                Keys.Multiply => KeyboardButton.KeypadMultiply,
                Keys.NumPad1 => KeyboardButton.Keypad1,
                Keys.NumPad2 => KeyboardButton.Keypad2,
                Keys.NumPad3 => KeyboardButton.Keypad3,
                Keys.NumPad4 => KeyboardButton.Keypad4,
                Keys.NumPad5 => KeyboardButton.Keypad5,
                Keys.NumPad6 => KeyboardButton.Keypad6,
                Keys.NumPad7 => KeyboardButton.Keypad7,
                Keys.NumPad8 => KeyboardButton.Keypad8,
                Keys.NumPad9 => KeyboardButton.Keypad9,
                Keys.NumPad0 => KeyboardButton.Keypad0,
                Keys.LeftControl => KeyboardButton.ControlLeft,
                Keys.LeftShift => KeyboardButton.ShiftLeft,
                Keys.LeftAlt => KeyboardButton.AltLeft,
                Keys.RightControl => KeyboardButton.ControlRight,
                Keys.RightShift => KeyboardButton.ShiftRight,
                Keys.RightAlt => KeyboardButton.AltRight,
                _ => KeyboardButton.Unknown
            };
        }
    }
}
