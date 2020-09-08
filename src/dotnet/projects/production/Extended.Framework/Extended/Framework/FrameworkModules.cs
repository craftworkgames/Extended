// Copyright (c) Lucas Girouard-Stranks. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the Git repository root directory for full license information.

using System;

namespace Extended
{
    /// <summary>
    ///     Defines the APIs of the <see cref="Framework" /> which can be dynamically loaded or swapped at
    ///     runtime.
    /// </summary>
    [Flags]
    public enum FrameworkModules
    {
        /// <summary>
        ///     Unknown kernel module.
        /// </summary>
        Unknown,

        /// <summary>
        ///     The loop events framework module. Responsible for keeping track of time and performing async operations.
        ///     Does not require any other module.
        /// </summary>
        Loop = 1 << 0,

        /// <summary>
        ///     The screen framework module. Responsible for windowing. Requires the <see cref="Loop" /> module.
        /// </summary>
        Screen = 1 << 1,

        /// <summary>
        ///     The graphics framework module. Responsible for rendering. Does not require any other module.
        /// </summary>
        Graphics = 1 << 2,

        /// <summary>
        ///     The input framework module. Responsible for input events of mouse, keyboard, and touch. Requires the
        ///     <see cref="Screen" /> module.
        /// </summary>
        Input = 1 << 3,

        /// <summary>
        ///     The gamepad framework module. Responsible for input of controllers. Requires the <see cref="Screen" />
        ///     module.
        /// </summary>
        Gamepad = 1 << 4,

        /// <summary>
        ///     The sound framework module. Responsible for playing and capturing audio. Does not require any othermodule.
        /// </summary>
        Sound = 1 << 5,

        /// <summary>
        ///     The network framework module. Responsible for communication with other running applications. Requires the
        ///     <see cref="Loop" /> module.
        /// </summary>
        Network = 1 << 6,

        /// <summary>
        ///     The localization framework module. Responsible for adapting the application to a target market. Does not
        ///     require any other module.
        /// </summary>
        Localization = 1 << 7,

        /// <summary>
        ///     All the framework modules.
        /// </summary>
        All = 0xFFFFFFF
    }
}
