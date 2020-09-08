// Copyright (c) Lucas Girouard-Stranks. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the Git repository root directory for full license information.

using System.Runtime.CompilerServices;

namespace Extended
{
    public static class Graphics
    {
        private static GraphicsFunctions _delegates;

        public static void Load(ref GraphicsFunctions delegates)
        {
            _delegates = delegates;
        }

        public static void Unload()
        {
            _delegates = default;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Clear(Rgba32F color)
        {
            _delegates.Clear(color);
        }
    }
}
