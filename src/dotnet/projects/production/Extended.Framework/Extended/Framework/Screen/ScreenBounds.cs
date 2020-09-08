// Copyright (c) Lucas Girouard-Stranks. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the Git repository root directory for full license information.

namespace Extended
{
    /// <summary>
    ///     A logical area of the screen.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         The <see cref="ScreenBounds" /> is in a Cartesian coordinate system. The origin, <c>(0,0)</c>, is the
    ///         top-left of the screen. <see cref="ScreenBounds.X" /> and <see cref="ScreenBounds.Y" /> are the starting
    ///         coordinates for the given context. <see cref="ScreenBounds.Width" /> and <see cref="ScreenBounds.Height" /> are
    ///         the positive extents of the given context. Together these fields define the rectangular area for the given
    ///         context.
    ///     </para>
    /// </remarks>
    public readonly struct ScreenBounds
    {
        public readonly uint X;
        public readonly uint Y;
        public readonly uint Width;
        public readonly uint Height;

        internal ScreenBounds(uint x, uint y, uint width, uint height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }
    }
}
