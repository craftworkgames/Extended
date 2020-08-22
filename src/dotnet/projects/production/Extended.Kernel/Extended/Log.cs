// Copyright (c) Lucas Girouard-Stranks. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the Git repository root directory for full license information.

using System;
using System.Threading;

namespace Extended
{
    /// <summary>
    ///     Provides logging functionality.
    /// </summary>
    public static partial class Log
    {
        internal static LogCallback? Callback;

        private const long AnyCategory = long.MaxValue;

        private static int _logLevel;
        private static long _logCategory = long.MaxValue;

        /// <summary>
        ///     Gets or sets the current <see cref="Extended.LogLevel" /> used for logging.
        /// </summary>
        /// <value>
        ///     The current <see cref="Extended.LogLevel" /> used for logging.
        /// </value>
        public static LogLevel LogLevel
        {
            get => (LogLevel)_logLevel;
            set => Interlocked.Exchange(ref _logLevel, (int)value);
        }

        /// <summary>
        ///     Gets or sets the current category bit flags enum used for logging.
        /// </summary>
        /// <value>
        ///     The current category bit flags enum used for logging.
        /// </value>
        public static long LogCategory
        {
            get => _logCategory;
            set => Interlocked.Exchange(ref _logCategory, value);
        }

        /// <summary>
        ///     Logs a specified <see cref="Extended.LogLevel.Debug" /> message for a specified category.
        /// </summary>
        /// <param name="message">The <see cref="string" /> message.</param>
        /// <param name="category">The <see cref="long" /> category bit flags enum.</param>
        /// <typeparam name="TCategory">The type of the <see cref="long" /> category bit flags enum value.</typeparam>
        public static void LogDebug<TCategory>(string message, TCategory category)
            where TCategory : unmanaged, Enum
        {
            Write(GetLongCategory(category), LogLevel.Debug, message);
        }

        /// <summary>
        ///     Logs a specified <see cref="Extended.LogLevel.Debug" /> message for a specified category.
        /// </summary>
        /// <param name="message">The <see cref="string" /> message.</param>
        public static void LogDebug(string message)
        {
            Write(AnyCategory, LogLevel.Debug, message);
        }

        /// <summary>
        ///     Logs a specified <see cref="Extended.LogLevel.Info" /> message for a specified category.
        /// </summary>
        /// <param name="message">The <see cref="string" /> message.</param>
        /// <param name="category">The <see cref="long" /> category bit flags enum.</param>
        /// <typeparam name="TCategory">The type of the <see cref="long" /> category bit flags enum value.</typeparam>
        public static void Info<TCategory>(string message, TCategory category)
            where TCategory : unmanaged, Enum
        {
            Write(GetLongCategory(category), LogLevel.Info, message);
        }

        /// <summary>
        ///     Logs a specified <see cref="Extended.LogLevel.Info" /> message for any category.
        /// </summary>
        /// <param name="message">The <see cref="string" /> message.</param>
        public static void Info(string message)
        {
            Write(AnyCategory, LogLevel.Info, message);
        }

        /// <summary>
        ///     Logs a specified <see cref="Extended.LogLevel.Warning" /> message for a specified category.
        /// </summary>
        /// <param name="message">The <see cref="string" /> message.</param>
        /// <param name="category">The <see cref="long" /> category bit flags enum.</param>
        /// <typeparam name="TCategory">The type of the <see cref="long" /> category bit flags enum value.</typeparam>
        public static void Warning<TCategory>(string message, TCategory category)
            where TCategory : unmanaged, Enum
        {
            Write(GetLongCategory(category), LogLevel.Warning, message);
        }

        /// <summary>
        ///     Logs a specified <see cref="Extended.LogLevel.Warning" /> message for any category.
        /// </summary>
        /// <param name="message">The <see cref="string" /> message.</param>
        public static void Warning(string message)
        {
            Write(AnyCategory, LogLevel.Warning, message);
        }

        /// <summary>
        ///     Logs a specified <see cref="Extended.LogLevel.Error" /> message for a specified category.
        /// </summary>
        /// <param name="message">The <see cref="string" /> message.</param>
        /// <param name="category">The <see cref="long" /> category bit flags enum.</param>
        /// <typeparam name="TCategory">The type of the <see cref="long" /> category bit flags enum value.</typeparam>
        public static void Error<TCategory>(string message, TCategory category)
            where TCategory : unmanaged, Enum
        {
            Write(GetLongCategory(category), LogLevel.Error, message);
        }

        /// <summary>
        ///     Logs a specified <see cref="Extended.LogLevel.Error" /> message for any category.
        /// </summary>
        /// <param name="message">The <see cref="string" /> message.</param>
        public static void Error(string message)
        {
            Write(AnyCategory, LogLevel.Error, message);
        }

        /// <summary>
        ///     Logs a specified <see cref="Extended.LogLevel.Critical" /> message for a specified category.
        /// </summary>
        /// <param name="message">The <see cref="string" /> message.</param>
        /// <param name="category">The <see cref="long" /> category bit flags enum.</param>
        /// <typeparam name="TCategory">The type of the <see cref="long" /> category bit flags enum value.</typeparam>
        public static void Critical<TCategory>(string message, TCategory category)
            where TCategory : unmanaged, Enum
        {
            Write(GetLongCategory(category), LogLevel.Critical, message);
        }

        /// <summary>
        ///     Logs a specified <see cref="Extended.LogLevel.Critical" /> message for any category.
        /// </summary>
        /// <param name="message">The <see cref="string" /> message.</param>
        public static void Critical(string message)
        {
            Write(AnyCategory, LogLevel.Critical, message);
        }

        private static unsafe long GetLongCategory<TCategory>(TCategory externalCategory)
            where TCategory : unmanaged, Enum
        {
            var intCategory = *(uint*)&externalCategory;
            var longCategory = 0xFFFFFFFF + intCategory;
            return longCategory;
        }

        private static void Write(long category, LogLevel level, string message)
        {
            if ((_logCategory & category) == 0)
            {
                return;
            }

            if (level < LogLevel)
            {
                return;
            }

            Callback?.Invoke(level, message, category);
        }
    }
}
