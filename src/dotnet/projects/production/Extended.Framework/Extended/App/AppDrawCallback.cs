// Copyright (c) Lucas Girouard-Stranks. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the Git repository root directory for full license information.

using System;

namespace Extended
{
    public delegate void AppDrawCallback(TimeSpan totalTime, TimeSpan deltaTime, float remainderFraction);
}
