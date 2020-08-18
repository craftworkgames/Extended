// Copyright (c) Lucas Girouard-Stranks. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the Git repository root directory for full license information.

using Microsoft.Xna.Framework;

namespace Extended
{
    internal class KernelGame : Game
    {
        private GraphicsDeviceManager _graphics;

        public KernelGame()
        {
            _graphics = new GraphicsDeviceManager(this);
        }
    }
}
