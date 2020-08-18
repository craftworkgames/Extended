// Copyright (c) Lucas Girouard-Stranks. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the Git repository root directory for full license information.

using System;

namespace Extended
{
    /// <summary>
    ///     Defines a set of native APIs which are made available in a cross-platform manner.
    /// </summary>
    [Flags]
    public enum KernelModuleTypes
    {
        /// <summary>
        ///     Unknown kernel module.
        /// </summary>
        Unknown,

        /// <summary>
        ///     The screen kernel module. Responsible for windowing. Includes input events: mouse, keyboard, touch.
        /// </summary>
        Screen = 1 << 0,

        /// <summary>
        ///     The graphics kernel module. Responsible for rendering.
        /// </summary>
        Graphics = 1 << 1,

        /// <summary>
        ///     The gamepad kernel module. Responsible for input events of one or more controllers.
        /// </summary>
        Gamepad = 1 << 2,

        /// <summary>
        ///     All the modules.
        /// </summary>
        All = 0xFFFFFFF
    }
}
