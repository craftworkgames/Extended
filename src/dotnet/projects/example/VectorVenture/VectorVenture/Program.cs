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

            Input.KeyPressed += InputOnKeyPressed;
            Input.KeyReleased += InputOnKeyReleased;
            Input.KeyRepeated += InputOnKeyRepeated;

            App.Setup(appDescriptor);
            App.Run();
        }

        private static void InputOnKeyPressed(InputButton button, KeyboardKey key)
        {
            Log.Debug($"{key} pressed");
        }

        private static void InputOnKeyReleased(InputButton button, KeyboardKey key)
        {
            Log.Debug($"{key} released");
        }

        private static void InputOnKeyRepeated(InputButton button, KeyboardKey key)
        {
            Log.Debug($"{key} repeated");
        }

        private static void Update(TimeSpan totalTime, TimeSpan elapsedTime)
        {
            var key = Input.KeyboardButton(KeyboardKey.Space);
        }

        private static void Draw(TimeSpan totalTime, TimeSpan elapsedTime, float remainderFraction)
        {
        }

        private static void ConsoleLog(LogLevel level, string message, long category)
        {
            var dateTime = DateTime.Now;
            Console.WriteLine($"{dateTime:s}{level,9} - {message}");
        }
    }
}
