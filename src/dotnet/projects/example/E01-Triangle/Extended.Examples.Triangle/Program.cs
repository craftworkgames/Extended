// Copyright (c) Lucas Girouard-Stranks. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the Git repository root directory for full license information.

using System;

namespace Extended.Examples.Triangle
{
    internal static class Program
    {
        private static void Main()
        {
            var appDescriptor = default(AppDescriptor);
            appDescriptor.Callbacks.Log = Log;
            appDescriptor.Callbacks.Loop = GameLoop;

            App.Setup(appDescriptor);
            App.Run();
        }

        private static void GameLoop(IsExitingFunc isExiting)
        {
            while (true)
            {
                App.PumpEvents();

                if (isExiting())
                {
                    break;
                }
            }
        }

        private static void Log(LogLevel level, string message, long category)
        {
            var dateTime = DateTime.Now;
            Console.WriteLine($"{dateTime:s}{level,9}: {message}");
        }
    }
}
