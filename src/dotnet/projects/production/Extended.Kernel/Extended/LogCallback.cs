// Copyright (c) Lucas Girouard-Stranks. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the Git repository root directory for full license information.

namespace Extended
{
    /// <summary>
    ///     The log callback delegate.
    /// </summary>
    /// <param name="level">The <see cref="LogLevel" />.</param>
    /// <param name="message">The <see cref="string" /> message.</param>
    /// <param name="category">The <see cref="long" /> category bit flags enum.</param>
    public delegate void LogCallback(LogLevel level, string message, long category);
}
