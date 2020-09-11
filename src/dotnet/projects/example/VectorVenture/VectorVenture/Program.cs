// Copyright (c) Lucas Girouard-Stranks. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the Git repository root directory for full license information.

using System;
using Extended;

namespace VectorVenture
{
    internal static class Program
    {
        private static void Main()
        {
            var appDescriptor = default(AppDescriptor);
            appDescriptor.Callbacks.Log = ConsoleLog;
            appDescriptor.Callbacks.Draw = Draw;
            appDescriptor.Callbacks.Update = Update;

            App.Setup(appDescriptor);
            App.Run();
        }

        private static void Update(TimeSpan totalTime, TimeSpan elapsedTime)
        {
        }

        private static void Draw(TimeSpan totalTime, TimeSpan elapsedTime, float remainderFraction)
        {
        }

        private static void ConsoleLog(LogLevel level, string message, long category)
        {
            var dateTime = DateTime.Now;
            Console.WriteLine($"{dateTime:s} - {message}");
        }
    }
}
