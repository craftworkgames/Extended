// Copyright (c) Lucas Girouard-Stranks. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the Git repository root directory for full license information.

using Microsoft.Xna.Framework;

namespace Extended
{
    internal class GameRoot : Game
    {
        public GameRoot()
        {
            IsFixedTimeStep = false;
        }

        protected override void Update(GameTime gameTime)
        {
            FrameworkDriver.UpdateLoop(gameTime.TotalGameTime, gameTime.ElapsedGameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            FrameworkDriver.DrawLoop(gameTime.TotalGameTime, gameTime.ElapsedGameTime);
        }
    }
}
