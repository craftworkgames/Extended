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
            appDescriptor.FixedElapsedTime = TimeSpan.Zero;
            appDescriptor.Callbacks.Log = Log;
            appDescriptor.Callbacks.Draw = Draw;
            appDescriptor.Callbacks.Update = Update;

            App.Setup(appDescriptor);
            App.Run();
        }

        private static void Update(TimeSpan totalTime, TimeSpan elapsedTime)
        {
            Extended.Log.Debug("Test update!\t" + elapsedTime.TotalMilliseconds);
        }

        private static void Draw(TimeSpan totalTime, TimeSpan elapsedTime, float remainderFraction)
        {
            Extended.Log.Debug("Test draw!\t" + elapsedTime.TotalMilliseconds);
        }

        private static void Log(LogLevel level, string message, long category)
        {
            var dateTime = DateTime.Now;
            Console.WriteLine($"{dateTime:s}{level,9}: {message}");
        }
    }
}
