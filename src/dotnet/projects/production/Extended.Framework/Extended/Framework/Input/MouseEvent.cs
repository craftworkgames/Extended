// Copyright (c) Lucas Girouard-Stranks. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the Git repository root directory for full license information.

namespace Extended
{
    public readonly struct MouseEvent
    {
        public readonly MouseButton MouseButton;
        public readonly bool Down;

        public MouseEvent(MouseButton button, bool down)
        {
            MouseButton = button;
            Down = down;
        }
    }
}
