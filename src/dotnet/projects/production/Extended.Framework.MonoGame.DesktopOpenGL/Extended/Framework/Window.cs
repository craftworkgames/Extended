// Copyright (c) Lucas Girouard-Stranks. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the Git repository root directory for full license information.

using SDL;

namespace Extended
{
    public static class Window
    {
        internal static unsafe void HandleEvents()
        {
            while (true)
            {
                SDL_Event @event;
                var eventCount = SDL2.SDL_PeepEvents(
                    &@event,
                    1,
                    SDL_EventAction.SDL_GETEVENT,
                    SDL_EventType.SDL_QUIT,
                    SDL_EventType.SDL_QUIT);

                if (eventCount == 0)
                {
                    break;
                }

                App.IsRunning = false;
            }
        }
    }
}
