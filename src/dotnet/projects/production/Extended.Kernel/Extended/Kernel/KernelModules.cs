// Copyright (c) Lucas Girouard-Stranks. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the Git repository root directory for full license information.

using System;

namespace Extended
{
    /// <summary>
    ///     Defines the plugins of the <see cref="Kernel" /> which can be dynamically loaded or swapped at
    ///     runtime.
    /// </summary>
    [Flags]
    public enum KernelModules
    {
        /// <summary>
        ///     Unknown kernel module.
        /// </summary>
        Unknown,

        /// <summary>
        ///     The loop events module. Responsible for keeping track of time and performing async operations. Does not
        ///     require any other module.
        /// </summary>
        Loop = 1 << 0,

        /// <summary>
        ///     The screen kernel module. Responsible for windowing. Includes input events of mouse, keyboard, and
        ///     touch. Requires the <see cref="Loop" /> module.
        /// </summary>
        Screen = 1 << 1,

        /// <summary>
        ///     The graphics kernel module. Responsible for rendering. Does not require any other module.
        /// </summary>
        Graphics = 1 << 2,

        /// <summary>
        ///     The gamepad kernel module. Responsible for input of controllers. Requires the <see cref="Loop" />
        ///     module.
        /// </summary>
        Gamepad = 1 << 3,

        /// <summary>
        ///     The sound kernel module. Responsible for playing and capturing audio. Does not require any other module.
        /// </summary>
        Sound = 1 << 4,

        /// <summary>
        ///     The network kernel module. Responsible for communication with other running applications. Requires the
        ///     <see cref="Loop" /> module.
        /// </summary>
        Network = 1 << 5,

        /// <summary>
        ///     The localization kernel module. Responsible for adapting the application to a target market. Does not
        ///     require any other module.
        /// </summary>
        Localization = 1 << 6,

        /// <summary>
        ///     All the kernel modules.
        /// </summary>
        All = 0xFFFFFFF
    }
}
