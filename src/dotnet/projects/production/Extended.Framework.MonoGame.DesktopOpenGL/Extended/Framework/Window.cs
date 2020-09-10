// Copyright (c) Lucas Girouard-Stranks. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the Git repository root directory for full license information.

using System;

namespace Extended
{
    public static class Window
    {
        internal static void HandleEvents()
        {
            App.IsRunning = FrameworkDriver.Game.Window.Handle != IntPtr.Zero;
        }
    }
}