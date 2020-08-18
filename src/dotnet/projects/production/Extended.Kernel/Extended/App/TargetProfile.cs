// Copyright (c) Lucas Girouard-Stranks. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the Git repository root directory for full license information.

namespace Extended
{
    /// <summary>
    ///     Defines groups of computing devices by broad limitations and human-computer interactions such as
    ///     physical size, power consumption, and input/output interfaces.
    /// </summary>
    public enum TargetProfile
    {
        /// <summary>
        ///     This value is reserved for the default initialization of structures. The default
        ///     <see cref="TargetProfile" /> is <see cref="Desktop" />.
        /// </summary>
        Default = 0,

        /// <summary>
        ///     A work-station, gaming-rig, or otherwise general personal computer which is typically used in a single
        ///     location and is pragmatically used to interact with a human from a distance of 2 meters or less.
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         A <see cref="Desktop" /> device is expected to have a mouse and keyboard input interfaces either
        ///         built-in or provided by attached peripheral devices.
        ///     </para>
        ///     <para>
        ///         An extra peripheral device may be available to attach to the <see cref="Desktop" /> device
        ///         to support a game-pad input interface or other interfaces. This is often used for development
        ///         purposes or to support running legacy or ported applications, but may be used for any modern
        ///         application as well.
        ///     </para>
        ///     <para>
        ///         A <see cref="Desktop" /> device is expected to be continuously drawing power. Do consider using
        ///         as much computational resources as needed for running an application on a <see cref="Desktop" />
        ///         device.
        ///     </para>
        /// </remarks>
        Desktop = 1,

        /// <summary>
        ///     A small computer which can pragmatically either fit inside the pockets of every-day clothing (e.g. a
        ///     smart-phone), inside a small portable storage container (e.g. a tablet), or otherwise on the body (e.g.
        ///     a watch).
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         A <see cref="Mobile" /> device is expected to have a built-in touch user-interface instead of a
        ///         mouse interface.
        ///     </para>
        ///     <para>
        ///         A keyboard interface is usually provided by the <see cref="Mobile" /> device using
        ///         an on-screen menu of some kind.
        ///     </para>
        ///     <para>
        ///         One or more peripheral devices may be available to attach to the <see cref="Mobile" /> device to
        ///         support mouse, keyboard, and/or game-pad input interfaces.
        ///     </para>
        ///     <para>
        ///         A <see cref="Mobile" /> device is expected to have an electric rechargeable battery and is not
        ///         expected to always be plugged in for charging when in use. Do consider using less computational
        ///         resources when running an application (i.e. let the app sleep more) on a <see cref="Mobile" />
        ///         device compared to a <see cref="Desktop" /> device to save battery life, especially when not plugged
        ///         in.
        ///     </para>
        /// </remarks>
        Mobile = 2,

        /// <summary>
        ///     A stationary, low cost, limited computer which is often used to interact with a human from a distance
        ///     of more than 2 meters, especially when the human has line of sight to a large monitor or television.
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         Unlike a <see cref="Desktop" /> device, a <see cref="Console" /> device usually has very specific
        ///         hardware limitations, input interfaces, and output interfaces. This can translate into developers
        ///         able to direct the limited development time of an application around locked in assumptions to
        ///         theoretically produce unique and higher quality products to a mass number of users.
        ///     </para>
        ///     <para>
        ///         A <see cref="Console" /> device is expected to have a game-pad or some other non-mouse/non keyboard
        ///         input interface.
        ///     </para>
        ///     <para>
        ///         A <see cref="Desktop" /> device is expected to be continuously drawing power but may have
        ///         low-power limitations. Do consider using as much computational resources as possible for running an
        ///         application on a <see cref="Console" /> device.
        ///     </para>
        /// </remarks>
        Console = 3
    }
}
