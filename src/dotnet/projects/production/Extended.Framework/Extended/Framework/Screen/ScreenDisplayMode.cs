// Copyright (c) Lucas Girouard-Stranks. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the Git repository root directory for full license information.

namespace Extended
{
    // TODO: Document remarks.

    /// <summary>
    ///     Defines the available ways of displaying the video (of the app) on the screen.
    /// </summary>
    public enum ScreenDisplayMode
    {
        /// <summary>
        ///     This value is reserved for the default initialization of structures.
        /// </summary>
        Default,

        /// <summary>
        ///     Display the app in a separate window.
        /// </summary>
        Window,

        /// <summary>
        ///     Display the app in a separate window that occupies the entire screen.
        /// </summary>
        FullscreenWindow,

        /// <summary>
        ///     Display the app on the entire screen.
        /// </summary>
        Fullscreen
    }
}
