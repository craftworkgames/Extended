// Copyright (c) Lucas Girouard-Stranks. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the Git repository root directory for full license information.

namespace Extended
{
    /// <summary>
    ///     Describes priorities for a log message in incrementing steps of severity.
    /// </summary>
    public enum LogLevel
    {
        /// <summary>
        ///     The log message is tedious. Used by developers to trace the application.
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         An example of a <see cref="Debug" /> log message would be a system call that returned a successful
        ///         error code to demonstrate that the program is operating normally.
        ///     </para>
        /// </remarks>
        Debug = 0,

        /// <summary>
        ///     The log message is interesting or unusual. Used by developers, administrators, or advanced users to
        ///     observe the side effects of the application.
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         An example of a <see cref="Info" /> log message would be a change in the program's state such as
        ///         a garbage collection, loaded library, locale change, etc.
        ///     </para>
        /// </remarks>
        Info = 1,

        /// <summary>
        ///     The log message represents a possible expected problem. Used by developers, administrators, or
        ///     advanced users to observe abnormal side effects of the application.
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         An example of a <see cref="Warning" /> log message would be when wrong input is given to the
        ///         program.
        ///     </para>
        /// </remarks>
        Warning = 2,

        /// <summary>
        ///     The log message represents an unexpected, but recoverable, problem. Used by developers, administrators,
        ///     or advanced users to observe abnormal side effects of the application.
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         An example of a <see cref="Error" /> log message would be when something went wrong unexpectedly in
        ///         the program such as an exception but the program is robust enough to continue execution.
        ///     </para>
        /// </remarks>
        Error = 3,

        /// <summary>
        ///     The log message represents an unexpected and unrecoverable problem. Used by developers, administrators,
        ///     or advanced users to understand why an application crashes.
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         An example of a <see cref="Error" /> log message would be when the application crashes unexpectedly
        ///         by violating assumptions made by the developers.
        ///     </para>
        /// </remarks>
        Critical = 5
    }
}
