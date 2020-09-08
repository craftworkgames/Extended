// Copyright (c) Lucas Girouard-Stranks. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the Git repository root directory for full license information.

using System;

namespace Extended
{
    public struct AppDescriptor
    {
        public FrameworkModules ModuleTypes;
        public AppDescriptorCallbacks Callbacks;
        public bool IsFixedTimeStep;
        public TimeSpan? FixedElapsedTime;
        public TimeSpan? MaximumElapsedTime;
        public TimeSpan? MaximumAccumulatedTime;
    }
}
