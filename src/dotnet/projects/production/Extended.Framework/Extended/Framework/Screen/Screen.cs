// Copyright (c) Lucas Girouard-Stranks. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the Git repository root directory for full license information.

using System.Collections.Immutable;

// ReSharper disable ConvertToAutoPropertyWhenPossible
// ReSharper disable ConvertToAutoProperty

namespace Extended
{
    /// <summary>
    ///     The device of the internal display or external monitor in the the logical context of the app.
    /// </summary>
    public static class Screen
    {
        private static ScreenDisplayMode _mode;
        private static ScreenResolution _resolution;
        private static ScreenBounds _bounds;
        private static ImmutableArray<ScreenResolution> _availableResolutions;

        /// <summary>
        ///     Gets or sets the <see cref="ScreenDisplayMode" /> of the app.
        /// </summary>
        /// <value>
        ///     The <see cref="ScreenDisplayMode" /> of the app.
        /// </value>
        public static ScreenDisplayMode DisplayMode
        {
            get => _mode;
            set => _mode = value;
        }

        /// <summary>
        ///     Gets the full rectangular area of the <see cref="Screen" /> in pixels.
        /// </summary>
        /// <value>
        ///     The full rectangular area of the <see cref="Screen" /> in pixels.
        /// </value>
        public static ScreenBounds Bounds => _bounds;

        /// <summary>
        ///     Gets the usable rectangular area of the <see cref="Screen" /> in pixels.
        /// </summary>
        /// <value>
        ///     The usable rectangular area of the <see cref="Screen" /> in pixels.
        /// </value>
        public static ScreenBounds UsableBounds => _bounds;

        /// <summary>
        ///     Gets the current <see cref="ScreenResolution" /> of the app.
        /// </summary>
        /// <value>
        ///     The current <see cref="ScreenResolution" /> of the app.
        /// </value>
        public static ScreenResolution Resolution => _resolution;

        /// <summary>
        ///     Gets the set of <see cref="ScreenResolution" />s that the <see cref="Screen" /> supports for the app.
        /// </summary>
        /// <value>
        ///     The set of <see cref="ScreenResolution" />s that the <see cref="Screen" /> supports for the app.
        /// </value>
        public static ImmutableArray<ScreenResolution> AvailableResolutions => _availableResolutions;
    }
}
