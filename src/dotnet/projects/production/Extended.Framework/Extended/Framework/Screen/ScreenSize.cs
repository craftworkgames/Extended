// Copyright (c) Lucas Girouard-Stranks. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the Git repository root directory for full license information.

namespace Extended
{
    public readonly struct ScreenSize
    {
        public readonly uint Width;
        public readonly uint Height;

        internal ScreenSize(uint width, uint height)
        {
            Width = width;
            Height = height;
        }
    }
}
