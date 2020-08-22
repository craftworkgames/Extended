// Copyright (c) Lucas Girouard-Stranks. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the Git repository root directory for full license information.

namespace Extended
{
    public readonly struct ScreenResolution
    {
        public readonly ScreenSize PixelSize;
        public readonly ScreenSize PhysicalSize;
        public readonly ScreenDensity PixelDensity;
        public readonly float RefreshRate;

        internal ScreenResolution(in ScreenSize pixel, in ScreenSize physical, float refreshRate, float scale = 1.0f)
        {
            PixelSize = pixel;
            PhysicalSize = physical;
            PixelDensity = new ScreenDensity(pixel, physical, scale);
            RefreshRate = refreshRate;
        }
    }
}
