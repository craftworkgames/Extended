// Copyright (c) Lucas Girouard-Stranks. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the Git repository root directory for full license information.

using System;
using Microsoft.Xna.Framework.Input;

namespace Extended
{
    public static class Mouse
    {
        public static void Update(TimeSpan deltaTime)
        {
            var mouseState = Microsoft.Xna.Framework.Input.Mouse.GetState();

            var isDown = mouseState.LeftButton == ButtonState.Pressed;
            Input.UpdateMouseButton(MouseButton.Left, isDown, deltaTime);

            isDown = mouseState.RightButton == ButtonState.Pressed;
            Input.UpdateMouseButton(MouseButton.Right, isDown, deltaTime);

            isDown = mouseState.MiddleButton == ButtonState.Pressed;
            Input.UpdateMouseButton(MouseButton.Middle, isDown, deltaTime);

            isDown = mouseState.MiddleButton == ButtonState.Pressed;
            Input.UpdateMouseButton(MouseButton.Middle, isDown, deltaTime);

            isDown = mouseState.XButton1 == ButtonState.Pressed;
            Input.UpdateMouseButton(MouseButton.X1, isDown, deltaTime);

            isDown = mouseState.XButton2 == ButtonState.Pressed;
            Input.UpdateMouseButton(MouseButton.X2, isDown, deltaTime);
        }
    }
}
