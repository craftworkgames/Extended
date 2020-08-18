// Copyright (c) Lucas Girouard-Stranks. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the Git repository root directory for full license information.

using System;

namespace Extended
{
    public readonly struct ScreenDensity
    {
        public readonly float Horizontal;
        public readonly float Vertical;
        public readonly float Diagonal;

        public ScreenDensity(in ScreenSize pixel, in ScreenSize physical, float scale)
        {
            Horizontal = CalculateHorizontalPixelsPerMillimeter(pixel, physical, scale);
            Vertical = CalculateVerticalPixelsPerMillimeter(pixel, physical, scale);
            Diagonal = CalculateDiagonalPixelsPerMillimeter(pixel, physical, scale);
        }

        private static float CalculateHorizontalPixelsPerMillimeter(
            in ScreenSize pixel,
            in ScreenSize physical,
            float scale)
        {
            return (float)(pixel.Width / (double)physical.Width) * scale;
        }

        private static float CalculateVerticalPixelsPerMillimeter(
            in ScreenSize pixel,
            in ScreenSize physical,
            float scale)
        {
            return (float)(pixel.Width / (double)physical.Width) * scale;
        }

        private static float CalculateDiagonalPixelsPerMillimeter(
            in ScreenSize pixel,
            in ScreenSize physical,
            float scale)
        {
            var pixelsDiagonal = Math.Sqrt((pixel.Width * pixel.Width) + (pixel.Height * pixel.Height));
            var millimetersDiagonal = Math.Sqrt((physical.Width * physical.Width) + (physical.Height * physical.Height));
            return (float)(pixelsDiagonal / millimetersDiagonal) * scale;
        }
    }
}
